using System;
using System.Collections.Generic;
using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 数据库备份信息
    /// </summary>
    public class DataBaseBackInfo
    {
        public DataBaseBackInfo()
        { }

        /// <summary>
        /// 数据库备份记录信息 构造函数
        /// </summary>
        /// <param name="strpath">备份文件路径</param>
        /// <param name="strfilename">备份数据文件名称</param>
        /// <param name="strbacktime">备份时间</param>
        /// <param name="Srno">序号</param>
        public DataBaseBackInfo(string strpath,string strfilename,string strbacktime, int Srno)
        {
            _DataFilePath = strpath;
            _DataBackTime = strbacktime;
            _SortNo = Srno;
            _BackDataFileName = strfilename;
        }

        private string _DataFilePath;
        /// <summary>
        /// 备份数据文件路径
        /// </summary>
        public string DataFilePath
        {
            get { return _DataFilePath; }
            set { _DataFilePath = value; }
        }

        private string _BackDataFileName;
        /// <summary>
        /// 备份数据文件名称
        /// </summary>
        public string BackDataFileName
        {
            get { return _BackDataFileName; }
            set { _BackDataFileName = value; }
        }
        private string _DataBackTime;
        /// <summary>
        /// 备份时间
        /// </summary>
        public string DataBackTime
        {
            get { return _DataBackTime; }
            set { _DataBackTime = value; }
        }
        private int _SortNo;
        /// <summary>
        /// 排序Number
        /// </summary>
        public int SortNo
        {
            get { return _SortNo; }
            set { _SortNo = value; }
        }
    }
}
