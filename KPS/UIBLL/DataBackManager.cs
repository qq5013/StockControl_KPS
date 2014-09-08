using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace KPS.UIBLL
{
    /// <summary>
    /// 数据库备份/还原本地记录信息 管理
    /// </summary>
    public class DataBackManager
    {
        private static DataBackManager manager = new DataBackManager();
        private List<UIModels.DataBaseBackInfo> recordlist = null;
        /// <summary>
        /// 数据库备份/还原管理实例  单例
        /// </summary>
        public static DataBackManager Instance
        {
            get
            {
                return manager;
            }
        }
        /// <summary>
        /// 获取数据库备份记录
        /// </summary>
        /// <returns></returns>
        public List<UIModels.DataBaseBackInfo> GetDataBackRecords()
        {
            if (recordlist== null)
            {
                if (System.IO.File.Exists("DataBaseBackLog.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("DataBaseBackLog.xml");

                    //<Record No="1" FileName="aa" UpTime=""></Record>
                    XmlNodeList retrunDataList = doc.GetElementsByTagName("Record"); //取得节点名为Record的XmlNode集合
                    if (retrunDataList != null && retrunDataList.Count > 0)
                    {
                        recordlist = new List<UIModels.DataBaseBackInfo>();
                        UIModels.DataBaseBackInfo _backrecord = null;
                        foreach (XmlNode _node in retrunDataList)
                        {
                            _backrecord = new UIModels.DataBaseBackInfo();
                            _backrecord.BackDataFileName = _node.Attributes["FileName"].Value;
                            _backrecord.DataBackTime = _node.Attributes["UpTime"].Value;
                            _backrecord.SortNo = Convert.ToInt32(_node.Attributes["No"].Value);
                            _backrecord.DataFilePath = _node.InnerText;

                            recordlist.Add(_backrecord);
                        }
                    }
                }
            }
            return recordlist;
        }

        /// <summary>
        /// 删除备份记录
        /// </summary>
        /// <param name="_backrecord"></param>
        public bool DelBackRecord(UIModels.DataBaseBackInfo _backrecord)
        {
            bool bolSucced = false;
            if (recordlist == null)
            {
                GetDataBackRecords();
            }
            if (recordlist != null && recordlist.Count > 0)
            {
                foreach (UIModels.DataBaseBackInfo item in recordlist)
                {
                    if (item.SortNo == _backrecord.SortNo)
                    {
                        recordlist.Remove(item);
                        if (File.Exists(item.DataFilePath))
                        {
                            File.Delete(item.DataFilePath);
                        }
                        break;
                    }
                }

                int SortNo = 1;
                foreach (UIModels.DataBaseBackInfo item in recordlist)
                {
                    item.SortNo = SortNo;
                    SortNo++;
                }

               bolSucced= SaveRecords();//保存记录
               
            }

            return bolSucced;
        }

        /// <summary>
        /// 添加新备份
        /// </summary>
        /// <param name="_backrecord"></param>
        /// <returns></returns>
        public bool AddBackRecord(UIModels.DataBaseBackInfo _backrecord)
        {
            bool bolsucced = false;
            if (recordlist == null)
            {
                GetDataBackRecords();
            }
            if (recordlist== null)
            {
                recordlist=new List<UIModels.DataBaseBackInfo> ();
            }
            recordlist.Add(_backrecord);

            //重新排序号
            int SortNo = 1;
            foreach (UIModels.DataBaseBackInfo item in recordlist)
            {
                item.SortNo = SortNo;
                SortNo++;
            }

            if (SaveRecords())
            {
                bolsucced = true;
            }

            return bolsucced;
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <returns></returns>
        private bool SaveRecords()
        {
            bool bolsucced = false;
            if (recordlist == null)
            {
                recordlist = new List<UIModels.DataBaseBackInfo>();
            }
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlElement Root = doc.CreateElement("LogInfo");//主内容
                doc.AppendChild(Root);

                XmlElement Recordnode = null;
                 XmlAttribute attr = null;
                //<Record No="1" FileName="aa" UpTime=""></Record>
                foreach (UIModels.DataBaseBackInfo _record in recordlist)
                {
                    Recordnode = doc.CreateElement("Record");//记录信息
                    Recordnode.InnerText = _record.DataFilePath;

                    attr = doc.CreateAttribute("No");
                    attr.Value = _record.SortNo.ToString();
                    Recordnode.Attributes.Append(attr);

                    attr= doc.CreateAttribute("FileName");
                    attr.Value = _record.BackDataFileName;
                    Recordnode.Attributes.Append(attr);

                    attr = doc.CreateAttribute("UpTime");
                    attr.Value = _record.DataBackTime;
                    Recordnode.Attributes.Append(attr);

                    Root.AppendChild(Recordnode);
                }
                doc.Save("DataBaseBackLog.xml");//保存/覆盖配置文件

                bolsucced = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bolsucced;
        }
    }

    /// <summary>
    /// 数据库备份还原文件处理(后台线程处理)
    /// </summary>
    public class DataBaseBackRestoreManager
    {
        /// <summary>
        /// 备份还原委托方法
        /// </summary>
        /// <param name="_state">备份还原状态</param>
        /// <param name="_MsgInfo">错误描述信息</param>
        public delegate void DelBackRestorStateArg(bool _state, string _MsgInfo);
        /// <summary>
        /// 备份结束.事件
        /// </summary>
        public event DelBackRestorStateArg BackEndEvent;
        /// <summary>
        /// 还原结束.事件
        /// </summary>
        public event DelBackRestorStateArg RestoreEndEvent;

        /// <summary>
        /// 本地创建一个备份版本
        /// </summary>
        public void CreateLocalBackVesion()
        {
            System.Threading.Thread createbackthread = new System.Threading.Thread(new System.Threading.ThreadStart(CreatebackvesionThread));
            createbackthread.IsBackground = true;
            createbackthread.Start();
        }
        /// <summary>
        /// 创建备份版本现场执行操作
        /// </summary>
        private void CreatebackvesionThread()
        {
            bool bolState = false;
            string strErrorMsgInfo = "备份发生错误!";
            string DbFilePath = KPS.DBUtility.DbHelperOleDb.getDBPath();
            if (File.Exists(DbFilePath))
            {
                try
                {
                    #region 执行备份操作
                    string strExePath = System.Windows.Forms.Application.StartupPath;//当前程序目录
                    string strBackupDirPath = Path.Combine(strExePath, "DataBack");
                    if (!Directory.Exists(strBackupDirPath))
                    {
                        //文件夹不存在则创建
                        Directory.CreateDirectory(strBackupDirPath);
                    }

                    string BackUpFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    FileInfo DataFile = new FileInfo(DbFilePath);

                    //复制备份文件
                    string strfilecopytoPath = Path.Combine(strBackupDirPath, string.Format("{0}{1}", BackUpFileName, DataFile.Extension));
                    DataFile.CopyTo(strfilecopytoPath, true);

                    //本地添加备份日志
                    UIModels.DataBaseBackInfo newback = new UIModels.DataBaseBackInfo(strfilecopytoPath, BackUpFileName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), -1);
                    bolState = DataBackManager.Instance.AddBackRecord(newback);
                    if (!bolState)
                    {
                        strErrorMsgInfo = "本地记录备份日志错误！";
                    }
                    else
                    {
                        strErrorMsgInfo = "数据备份成功！";
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    strErrorMsgInfo = ex.Message;
                }
            }
            else
            {
                strErrorMsgInfo = "无法找到备份所需的数据库文件，请确定系统配置路径正确！";
            }
            if (BackEndEvent != null)
            {
                BackEndEvent(bolState, strErrorMsgInfo);
            }
        }

        /// <summary>
        /// 还原数据库至本地的一个版本
        /// </summary>
        /// <param name="_backrecord">本地备份版本信息</param>
        public void RestoreByLocalVesion(UIModels.DataBaseBackInfo backrecordinfo)
        {
            _backrecord = backrecordinfo;
            System.Threading.Thread restoreToVesionthread = new System.Threading.Thread(new System.Threading.ThreadStart(RestoreThread));
            restoreToVesionthread.IsBackground = true;
            restoreToVesionthread.Start();
        }

        private UIModels.DataBaseBackInfo _backrecord = null;
        /// <summary>
        /// 
        /// </summary>
        private void RestoreThread()
        {
            bool bolState = false;
            string strErrorMsgInfo = "还原发生错误!";
            string DbFilePath = KPS.DBUtility.DbHelperOleDb.getDBPath();
            if (File.Exists(_backrecord.DataFilePath))
            {
                try
                {
                    #region 执行还原操作
                    FileInfo _backfile = new FileInfo(_backrecord.DataFilePath);
                    _backfile.CopyTo(DbFilePath, true);

                    bolState = true;
                    strErrorMsgInfo = "还原成功！";
                    #endregion
                }
                catch (Exception ex)
                {
                    strErrorMsgInfo = ex.Message;
                }
            }
            else
            {
                strErrorMsgInfo = "无法找到备份文件，无法完成还原操作！";
            }
            if (RestoreEndEvent != null)
            {
                RestoreEndEvent(bolState, strErrorMsgInfo);
            }
        }
    }
}
