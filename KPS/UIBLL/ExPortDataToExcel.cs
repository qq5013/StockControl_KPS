using System;
using System.Collections.Generic;

using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.IO;
using KPS.UIModels;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 导出数据至Excel
    /// </summary>
    public class ExPortDataToExcel
    {
        private System.Collections.ICollection dataList;
        private UIModels.EntryType dataType=UIModels.EntryType.ZDSJGJ;
        private UIModels.SellTotalType SellTotalType = UIModels.SellTotalType.Customer;
        private string SaveExcelPath = "";
        private bool IsExportSellTotalData = false;

        public delegate void DelExportDataArg(bool _statevalue, string _MsgInfo);
        /// <summary>
        /// 导出列表数据结束 事件
        /// </summary>
        public event DelExportDataArg ExportListDataEndEvent;

        /// <summary>
        /// 导出数据至Excel 构造函数
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="_type"></param>
        /// <param name="_SavePath">导出文件存储路径</param>
        public ExPortDataToExcel(System.Collections.ICollection _list, UIModels.EntryType _type,string _SavePath)
        {
            dataList = _list;
            dataType = _type;
            SaveExcelPath = _SavePath;
        }

        /// <summary>
        /// 导出销售汇总记录至Excel 构造函数
        /// </summary>
        /// <param name="_list">列表</param>
        /// <param name="_type">类型</param>
        /// <param name="_SavePath">保存路径</param>
        public ExPortDataToExcel(System.Collections.ICollection _list, UIModels.SellTotalType _type, string _SavePath)
        { 
             dataList = _list;
             SellTotalType = _type;
            SaveExcelPath = _SavePath;
            IsExportSellTotalData = true;
        }

        System.Threading.Thread ExportDataThread;
        /// <summary>
        /// 开始导出
        /// </summary>
        public void Start()
        {
            if (!IsExportSellTotalData)
            {
                switch (dataType)
                {
                    case UIModels.EntryType.ZDSJGJ:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(ZDSJGJExportThread));
                        break;
                    case UIModels.EntryType.YS:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(YSExportThread));
                        break;
                    case UIModels.EntryType.CC:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(CCExportThread));
                        break;
                    case UIModels.EntryType.XS:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(XSExportThread));
                        break;
                    case UIModels.EntryType.CK:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(CKExportThread));
                        break;
                    case UIModels.EntryType.SH:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(SHExportThread));
                        break;
                    case UIModels.EntryType.BHGPJL:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(BHGPJLExportThread));
                        break;
                    case UIModels.EntryType.BLSJ:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(BLSJExportThread));
                        break;
                    case UIModels.EntryType.ZLGZ:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(ZLGZExportThread));
                        break;
                    case UIModels.EntryType.Inventory:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(InventoryThread));
                        break;
                    default:
                        ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(ZDSJGJExportThread));
                        break;
                }
            }
            else
            {
                ExportDataThread = new System.Threading.Thread(new System.Threading.ThreadStart(SellTotalRecordExportThread));
            }
            if (ExportDataThread != null)
            {
                ExportDataThread.IsBackground = true;
                ExportDataThread.Start();
            }

        }


        /// <summary>
        /// 1.诊断试剂购进
        /// </summary>
        private void ZDSJGJExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetZDSJGJColumns();
            List<GouJinInfo> plist = null;
            if (dataList is List<GouJinInfo>)
            {
                plist = (List<GouJinInfo>)dataList;
            }
            else 
            {
                plist = new List<GouJinInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((GouJinInfo)_obj);
                }
            }
            

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容


                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (GouJinInfo  p in plist)
                {
                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容
                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "p_clmc"://品名
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_clmc);
                                break;
                            case "p_cpmc"://产品名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_cpmc);
                                break;
                            case "p_date"://购进时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "p_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_dw);
                                break;
                            case "p_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_ggxh);
                                break;
                            case "p_gys"://供应商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_gys);
                                break;
                            case "p_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_mjph);
                                break;
                            case "p_ph"://批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_ph);
                                break;
                            case "p_sl1"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_sl1.Value);
                                break;
                            case "p_zczh"://注册证号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_zczh);
                                break;
                            case "p_zzs"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_zzs);
                                break;
                            case "p_jsr"://经手人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_jsr);
                                break;
                            case "p_sl2":
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(FormatDoubleBalue(p.p_sl2));
                                break;
                            case "ToltalMoney":
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(TotalMoney(p));
                                break;
                               default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }

        /// <summary>
        /// 2.验收
        /// </summary>
        private void YSExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList =GetYSColumns();
            List<YanShouInfo> plist = null;
            if (dataList is List<YanShouInfo>)
            {
                plist = (List<YanShouInfo>)dataList;
            }
            else
            {
                plist = new List<YanShouInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((YanShouInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容


                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (YanShouInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        //ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
                        //ColumnArray.Add(new ListColumnInfo("质量管理员", "y_zgy", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
                        //ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "y_pm"://品名
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_pm);
                                break;
                            case "y_cpdm"://产品代码
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpdm);
                                break;
                            case "y_cpzczh"://产品注册号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpzczh);
                                break;
                            case "y_date"://日期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "y_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_dw);
                                break;
                            case "y_fhrqz"://复核人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_fhrqz);
                                break;
                            case "y_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ggxh);
                                break;
                            case "y_ghdw"://供应商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ghdw);
                                break;
                            case "y_isHGZ"://合格证
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(GetBolStateValue(p.y_isHGZ,"有","无"));
                                break;
                            case "y_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_mjph);
                                break;
                            case "y_sccj"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sccj);
                                break;
                            case "y_scph"://生产批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_scph);
                                break;
                            case "y_sl"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sl.Value);
                                break;
                            case "y_yxq"://有效期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_yxq);
                                break;
                            case "y_zgy"://质量管理员
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zgy);
                                break;
                            case "y_zlqk"://质量情况
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zlqk);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }

        }


        /// <summary>
        /// 3.存储
        /// </summary>
        private void CCExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetCCColumns();
            List<CunChuInfo> plist = null;
            if (dataList is List<CunChuInfo>)
            {
                plist = (List<CunChuInfo>)dataList;
            }
            else
            {
                plist = new List<CunChuInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((CunChuInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (CunChuInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "s_csmc"://场所名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_csmc);
                                break;
                            case "s_sworxw"://时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(GetTimeStrByState(p.s_sworxw.Value));
                                break;
                            case "s_date"://日期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "s_wd"://温度
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_wd);
                                break;
                            case "s_sd"://湿度
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_sd);
                                break;
                            case "s_sywdfw"://适宜温度范围
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_sywdfw);
                                break;
                            case "s_syxdsdfw"://适宜相对湿度范围
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_syxdsdfw);
                                break;
                            case "s_cqcs"://采取措施
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_cqcs);
                                break;
                            case "s_wded"://采取措施后温度
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_wded);
                                break;
                            case "s_sded"://采取措施后湿度
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_sded);
                                break;
                            case "s_jlr"://记录人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.s_jlr);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 4.销售
        /// </summary>
        private void XSExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetXSColumns();

            List<XiaoShouInfo> plist = null;
            if (dataList is List<XiaoShouInfo>)
            {
                plist = (List<XiaoShouInfo>)dataList;
            }
            else
            {
                plist = new List<XiaoShouInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((XiaoShouInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (XiaoShouInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "p_cpmc"://产品名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_cpmc);
                                break;
                            case "p_date"://时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "p_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_dw);
                                break;
                            case "p_clmc"://材料名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_clmc);
                                break;
                            case "p_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_ggxh);
                                break;
                            case "p_gys"://采购单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_gys);
                                break;
                            case "p_jsr"://经手人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_jsr);
                                break;
                            case "p_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_mjph);
                                break;
                            case "p_ph"://批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_ph);
                                break;
                            case "p_sl1"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_sl1.Value);
                                break;
                            case "p_zczh"://注册证号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_zczh);
                                break;
                            case "p_zzs"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_zzs);
                                break;
                            case "p_sl2":
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(FormatDoubleBalue(p.p_sl2));
                                break;
                            case "ToltalMoney":
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(TotalMoney(p));
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 5.出库
        /// </summary>
        private void CKExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetCKColumns();
            List<ChuKuInfo> plist = null;
            if (dataList is List<ChuKuInfo>)
            {
                plist = (List<ChuKuInfo>)dataList;
            }
            else
            {
                plist = new List<ChuKuInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((ChuKuInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (ChuKuInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "y_pm"://品名
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_pm);
                                break;
                            case "y_cpdm"://产品代码
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpdm);
                                break;
                            case "y_cpzczh"://产品注册证号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpzczh);
                                break;
                            case "y_date"://日期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "y_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_dw);
                                break;
                            case "y_fhrqz"://复核人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_fhrqz);
                                break;
                            case "y_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ggxh);
                                break;
                            case "y_ghdw"://供应商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ghdw);
                                break;
                            case "y_isHGZ"://是否有合格证
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(GetBolStateValue(p.y_isHGZ,"有","无"));
                                break;
                            case "y_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_mjph);
                                break;
                            case "y_sccj"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sccj);
                                break;
                            case "y_scph"://生产批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_scph);
                                break;
                            case "y_sl"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sl.Value);
                                break;
                            case "y_yxq"://有效期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_yxq);
                                break;
                            case "y_zgy"://质管员
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zgy);
                                break;
                            case "y_zlqk"://质量情况
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zlqk);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 6.退换货
        /// </summary>
        private void SHExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetSHColumns();
            List<ShouHouInfo> plist = null;
            if (dataList is List<ShouHouInfo>)
            {
                plist = (List<ShouHouInfo>)dataList;
            }
            else
            {
                plist = new List<ShouHouInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((ShouHouInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (ShouHouInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "y_pm"://产品名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_pm);
                                break;
                            case "y_managertype"://类型
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_managertype);
                                break;
                            case "y_date"://日期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "y_cpdm"://产品代码
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpdm);
                                break;
                            case "y_cpzczh"://产品注册证号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpzczh);
                                break;
                            case "y_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_dw);
                                break;
                            case "y_fhrqz"://复核人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_fhrqz);
                                break;
                            case "y_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ggxh);
                                break;
                            case "y_ghdw"://供应商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ghdw);
                                break;
                            case "y_isHGZ"://是否有合格证
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(GetBolStateValue(p.y_isHGZ,"有","无"));
                                break;
                             case "y_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_mjph);
                                break;
                            case "y_sccj"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sccj);
                                break;
                            case "y_scph"://生产批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_scph);
                                break;
                            case "y_sl"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sl.Value);
                                break;
                            case "y_yxq"://有效期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_yxq);
                                break;
                            case "y_zgy"://质管员
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zgy);
                                break;
                            case "y_zlqk"://质量情况
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zlqk);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 7.不合格产品记录
        /// </summary>
        private void BHGPJLExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetBHGPJLColumns();

            List<BuHeGePinJiLuInfo> plist = null;
            if (dataList is List<BuHeGePinJiLuInfo>)
            {
                plist = (List<BuHeGePinJiLuInfo>)dataList;
            }
            else
            {
                plist = new List<BuHeGePinJiLuInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((BuHeGePinJiLuInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (BuHeGePinJiLuInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "y_pm"://产品名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_pm);
                                break;
                            case "y_date"://时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "y_cpdm"://是否有许可证
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpdm);
                                break;
                            case "y_cpzczh"://产品注册证号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_cpzczh);
                                break;
                            case "y_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_dw);
                                break;
                            case "y_fhrqz"://复核人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_fhrqz);
                                break;
                            case "y_ggxh"://规格
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ggxh);
                                break;
                            case "y_ghdw"://供应商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_ghdw);
                                break;
                            case "y_isHGZ"://是否有合格证
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(GetBolStateValue(p.y_isHGZ, "有", "无"));
                                break;
                            case "y_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_mjph);
                                break;
                            case "y_sccj"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sccj);
                                break;
                            case "y_scph"://生产批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_scph);
                                break;
                            case "y_sl"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_sl.Value);
                                break;
                            case "y_yxq"://有效期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_yxq);
                                break;
                            case "y_zgy"://质管员
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zgy);
                                break;
                            case "y_zlqk"://质量情况
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.y_zlqk);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 8.不良事件
        /// </summary>
        private void BLSJExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetBLSJColumns();

            List<BuLiangShiJianInfo> plist = null;
            if (dataList is List<BuLiangShiJianInfo>)
            {
                plist = (List<BuLiangShiJianInfo>)dataList;
            }
            else
            {
                plist = new List<BuLiangShiJianInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((BuLiangShiJianInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (BuLiangShiJianInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "b_ylqxmc"://医疗器械名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_ylqxmc);
                                break;
                            case "b_cpdm"://产品代码
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_cpdm);
                                break;
                            case "b_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_ggxh);
                                break;
                            case "b_sccj"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_sccj);
                                break;
                            case "b_sydw"://使用单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_sydw);
                                break;
                            case "b_scrq"://生产日期
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_scrq);
                                break;
                            case "b_sl"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_sl.Value);
                                break;
                            case "b_zlsgqk"://质量事故情况说明
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_zlsgqk);
                                break;
                           case "b_bgr"://报告人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_bgr);
                                break;
                            case "b_bgsj"://报告时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_bgsj.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "b_fzr"://使用单位负责人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_fzr);
                                break;
                            case "b_sydwyj"://使用单位意见
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_sydwyj);
                                break;
                            case "b_resj"://使用单位意见反馈时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_resj.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "b_fzrqz"://企业质量负责人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_fzrqz);
                                break;
                            case "b_qyzgfzryj"://企业质量负责人意见
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_qyzgfzryj);
                                break;
                            case "b_fzrqzsj"://企业质量负责人签字时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_fzrqzsj.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                             case "b_zgclqk"://处理情况
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_zgclqk);
                                break;
                            case "b_zgjbr"://经办人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_zgjbr);
                                break;
                            case "b_zgjbsj"://最终处理时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.b_zgjbsj.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 9.质量跟踪
        /// </summary>
        private void ZLGZExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetZLGZColumns();
 
            List<ProcessLoggingInfo> plist = null;
            if (dataList is List<ProcessLoggingInfo>)
            {
                plist = (List<ProcessLoggingInfo>)dataList;
            }
            else
            {
                plist = new List<ProcessLoggingInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((ProcessLoggingInfo)_obj);
                }
            }

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容
                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (ProcessLoggingInfo p in plist)
                {

                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容

                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessID);
                                break;
                            case "ProcessProductName"://产品名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessProductName);
                                break;
                            case "ProcessDate"://时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "ProcessCustomerUnit"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessCustomerUnit);
                                break;
                            case "ProcessContentInquired"://查询内容
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessContentInquired);
                                break;
                            case "ProcessHandlingSuggestion"://处理意见
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessHandlingSuggestion);
                                break;
                            case "Processlinkman"://联系人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.Processlinkman);
                                break;
                            case "ProcessPurchasingDate"://经手人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessPurchasingDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "ProcessServiceUser"://服务人员
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessServiceUser);
                                break;
                            case "ProcessStandard"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ProcessStandard);
                                break;
                            case "Processtel"://电话
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.Processtel);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }

        /// <summary>
        /// 10.库存记录
        /// </summary>
        private void InventoryThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetInventoryColumns();
            List<GouJinInfo> plist = null;
            if (dataList is List<GouJinInfo>)
            {
                plist = (List<GouJinInfo>)dataList;
            }
            else
            {
                plist = new List<GouJinInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((GouJinInfo)_obj);
                }
            }


            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容


                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (GouJinInfo p in plist)
                {
                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容
                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "OrderNumber"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.ID);
                                break;
                            case "p_clmc"://品名
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_clmc);
                                break;
                            case "p_cpmc"://产品名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_cpmc);
                                break;
                            case "p_date"://购进时间
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "p_dw"://单位
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_dw);
                                break;
                            case "p_ggxh"://规格型号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_ggxh);
                                break;
                            case "p_gys"://供应商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_gys);
                                break;
                            case "p_mjph"://灭菌批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_mjph);
                                break;
                            case "p_ph"://批号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_ph);
                                break;
                            case "p_sl1"://数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_sl1.Value);
                                break;
                            case "p_zczh"://注册证号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_zczh);
                                break;
                            case "p_zzs"://生产商
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_zzs);
                                break;
                            case "p_jsr"://经手人
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.p_jsr);
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        
        /// <summary>
        /// 11.销售统计汇总
        /// </summary>
        private void SellTotalRecordExportThread()
        {
            bool bolState = true;
            string strMsgInfo = "导出成功";

            List<ListColumnInfo> ColumnList = GetSellTotalRecordsColumns();
            List<SellRecordInfo> plist = null;
            if (dataList is List<GouJinInfo>)
            {
                plist = (List<SellRecordInfo>)dataList;
            }
            else
            {
                plist = new List<SellRecordInfo>();
                foreach (object _obj in dataList)
                {
                    plist.Add((SellRecordInfo)_obj);
                }
            }


            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet("Sheet1");
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();
            HSSFClientAnchor anchor = null;

            CellStyle celstyle = GetStyleVlig(hssfworkbook);//单元格，格式
            HSSFFont font = GetFontStyle(hssfworkbook);//说明书查看链接文字样式

            CellStyle headstyle = GetHeadStyle(hssfworkbook);//头样式

            string strFlName;

            if (SaveExcelPath.Trim() != "")
            {
                strFlName = SaveExcelPath;
            }
            else
            {
                return;
            }
            if (System.IO.File.Exists(strFlName))
            {
                System.IO.File.Delete(strFlName);
            }

            #region 写入sheet1
            try
            {

                //添加列头（第一行）
                #region 添加列头

                sheet1.CreateRow(0);
                int i = 0;

                #region 设定的显示栏位添加
                foreach (ListColumnInfo column in ColumnList)
                {
                    //添加一列的列头
                    sheet1.GetRow(0).CreateCell(i).SetCellValue(column.ColumnTitle);
                    sheet1.GetRow(0).GetCell(i).CellStyle = headstyle;
                    i++;
                }
                #endregion

                #endregion

                #region 写入专利内容


                int intRowIndex = 1;
                #region 内容填充，创建行，并向单元格中写入内容
                foreach (SellRecordInfo p in plist)
                {
                    sheet1.CreateRow(intRowIndex);

                    #region 填充一件专利各个栏位的内容
                    int intJ = 0;
                    foreach (ListColumnInfo obj in ColumnList)
                    {
                        //SortNo SGroupName  STotalNumber  STotalMoney  SProfit
                        #region 添加栏位
                        switch (obj.ColumnName)
                        {
                            case "SortNo"://编号
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.SortNo);
                                break;
                            case "SGroupName"://分组名称
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.SGroupName);
                                break;
                            case "STotalNumber"://统计数量
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.STotalNumber);
                                break;
                            case "STotalMoney"://统计金额
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.STotalMoney.ToString());
                                break;
                            case "SProfit"://统计毛利
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue(p.SProfit.ToString());
                                break;
                            default:
                                sheet1.GetRow(intRowIndex).CreateCell(intJ).SetCellValue("");
                                break;
                        }

                        #endregion
                        sheet1.GetRow(intRowIndex).GetCell(intJ).CellStyle = celstyle;//单元格格式
                        intJ++;
                    }
                    #endregion
                    intRowIndex++;
                }
                #endregion
                #endregion

            }
            catch (Exception e)
            {
                bolState = false;
                strMsgInfo = e.Message;
            }
            finally
            {
            }
            #endregion
            try
            {
                WriteToFile(strFlName);
            }
            catch (Exception ex)
            {
                bolState = false;
                strMsgInfo = ex.Message;
            }

            if (ExportListDataEndEvent != null)
            {
                ExportListDataEndEvent(bolState, strMsgInfo);
            }
        }
        /// <summary>
        /// 获取状态描述文字
        /// </summary>
        /// <param name="_State"></param>
        /// <param name="_TrueValue"></param>
        /// <param name="_FalseValue"></param>
        /// <returns></returns>
        private string GetBolStateValue(bool _State, string _TrueValue, string _FalseValue)
        {
            if (_State)
            {
                return _TrueValue;
            }
            return _FalseValue;
        }

        private string GetTimeStrByState(int _intValue)
        {
            if (_intValue == 0)
            {
                return "上午";
            }
            return "下午";
        }

        /// <summary>
        /// 总金额计算
        /// </summary>
        /// <param name="_goujinInfo"></param>
        /// <returns></returns>
        private string TotalMoney(GouJinInfo _goujinInfo)
        {
            string strReturnValue = "0.00";
            try
            {
                int _Number = _goujinInfo.p_sl1.Value;
                double _price = Convert.ToDouble(_goujinInfo.p_sl2);
                double TotalValue = _price * _Number;
                strReturnValue = TotalValue.ToString("n");
            }
            catch (Exception ex)
            {
            }
            return strReturnValue;
        }
        /// <summary>
        /// 销售总金额计算
        /// </summary>
        /// <param name="_goujinInfo"></param>
        /// <returns></returns>
        private string TotalMoney(XiaoShouInfo _goujinInfo)
        {
            string strReturnValue = "0.00";
            try
            {
                int _Number = _goujinInfo.p_sl1.Value;
                double _price = Convert.ToDouble(_goujinInfo.p_sl2);
                double TotalValue = _price * _Number;
                strReturnValue = string.Format("{0}", TotalValue.ToString("n"));
            }
            catch (Exception ex)
            {
            }
            return strReturnValue;
        }
        /// <summary>
        /// 单价格式化
        /// </summary>
        /// <param name="_Price"></param>
        /// <returns></returns>
        private string FormatDoubleBalue(string _Price)
        {
            string strReturnValue = "0.00";
            try
            {
                double _price = Convert.ToDouble(_Price);
                strReturnValue = _price.ToString("n");
            }
            catch (Exception ex)
            {
            }
            return strReturnValue;
        }
        #region 导出数据至 Excel 初始化动作 
        
        static HSSFWorkbook hssfworkbook;
        private void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();


            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;


            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;
        }

        /// <summary>
        /// 单元格样式 (垂直居中，自动换行)
        /// </summary>
        /// <param name="_workbook"></param>
        /// <returns></returns>
        private CellStyle GetStyleVlig(HSSFWorkbook _workbook)
        {
            CellStyle style = _workbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.CENTER;
            style.WrapText = true;
            return style;
        }

        /// <summary>
        /// 说明书查看链接文字的样式
        /// </summary>
        /// <param name="_workbook"></param>
        /// <returns></returns>
        private HSSFFont GetFontStyle(HSSFWorkbook _workbook)
        {
            HSSFFont font = (HSSFFont)_workbook.CreateFont();
            font.Color = HSSFColor.BLUE.index;
            font.Underline = HSSFFontFormatting.U_SINGLE;

            return font;
        }

        /// <summary>
        /// 表格头样式
        /// </summary>
        /// <param name="_workbook"></param>
        /// <returns></returns>
        private CellStyle GetHeadStyle(HSSFWorkbook _workbook)
        {
            CellStyle style = _workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.CENTER;
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.YELLOW.index;
            style.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.YELLOW.index;
            style.FillPattern = FillPatternType.SQUARES;

            HSSFFont font = (HSSFFont)_workbook.CreateFont();
            font.FontName = "微软雅黑";
            font.Boldweight = 1;
            font.FontHeightInPoints = 12;

            style.SetFont(font);
            return style;
        }

        /// <summary>
        /// 写入 保存文件
        /// </summary>
        /// <param name="strPath"></param>
        private void WriteToFile(string strPath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(strPath, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                file.Dispose();
            }
            catch (Exception ex)
            {
                file.Close();
                file.Dispose();
                throw ex;
            }
            finally
            {
                file.Close();
                file.Dispose();
            }
        }
        #endregion

        #region 栏位信息
        /// <summary>
        /// 1.1.诊断试剂购进 字段列表
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetZDSJGJColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("材料名称", "p_clmc", 120,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "p_cpmc", 120,System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("购进时间", "p_date", 120,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("单位", "p_dw", 60,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "p_ggxh", 80,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("供应商", "p_gys", 120,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "p_mjph", 100,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("批号(系列号)", "p_ph", 100,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("数量", "p_sl1", 60,System.Windows.Forms.HorizontalAlignment.Left,true));

            ColumnArray.Add(new ListColumnInfo("进价", "p_sl2", 60,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("总金额", "ToltalMoney", 80,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("备注", "RemarkInfo", 120,System.Windows.Forms.HorizontalAlignment.Left,true));

            ColumnArray.Add(new ListColumnInfo("注册证号", "p_zczh", 120,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("生产商", "p_zzs", 120,System.Windows.Forms.HorizontalAlignment.Left,true));
            ColumnArray.Add(new ListColumnInfo("经手人", "p_jsr", 100,System.Windows.Forms.HorizontalAlignment.Left,true));
            return ColumnArray;

        }

        /// <summary>
        /// 1.2.验收
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetYSColumns()
        {
            KPS.Model.YanShouInfo yanshou = new Model.YanShouInfo();
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "y_cpdm", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册号", "y_cpzczh", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量管理员", "y_zgy", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.3.存储
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetCCColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("场所名称", "s_csmc", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("时间", "s_sworxw", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "s_date", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("温度", "s_wd", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("湿度", "s_sd", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("适宜温度范围", "s_sywdfw", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("适宜相对湿度范围", "s_syxdsdfw", 140, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采取措施", "s_cqcs", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采取措施后温度", "s_wded", 140, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采取措施后湿度", "s_sded", 140, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("记录人", "s_jlr", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.4.销售
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetXSColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "p_cpmc", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("时间", "p_date", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "p_dw", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("材料名称", "p_clmc", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "p_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采购单位", "p_gys", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("经手人", "p_jsr", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "p_mjph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("批号", "p_ph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "p_sl1", 40, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("单价", "p_sl2", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("总金额", "ToltalMoney", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("备注", "RemarkInfo", 120, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("注册证号", "p_zczh", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "p_zzs", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.5.出库
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetCKColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "y_cpdm", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册证号", "y_cpzczh", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质管员", "y_zgy", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.6.售后
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetSHColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 100,System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("类型", "y_managertype", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "y_cpdm", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册证号", "y_cpzczh", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质管员", "y_zgy", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.7.不合格品记录
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetBHGPJLColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("许可证", "y_cpdm", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册证号", "y_cpzczh", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质管员", "y_zgy", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.8.不良事件
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetBLSJColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));


            ColumnArray.Add(new ListColumnInfo("医疗器械名称", "b_ylqxmc", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "b_cpdm", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "b_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("生产商", "b_sccj", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("使用单位", "b_sydw", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产日期", "b_scrq", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "b_sl", 40, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("质量事故情况说明", "b_zlsgqk", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("报告人", "b_bgr", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("报告时间", "b_bgsj", 80, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("使用单位负责人", "b_fzr", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("使用单位意见", "b_sydwyj", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("使用单位意见反馈时间", "b_resj", 150, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("企业质量负责人", "b_fzrqz", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("企业质量负责人意见", "b_qyzgfzryj", 150, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("企业质量负责人签字时间", "b_fzrqzsj", 150, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("处理情况", "b_zgclqk", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("经办人", "b_zgjbr", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("最终处理时间", "b_zgjbsj", 100, System.Windows.Forms.HorizontalAlignment.Left, true));


            return ColumnArray;
        }

        /// <summary>
        /// 1.9.质量跟踪
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetZLGZColumns()
        {

            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "ProcessProductName", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("时间", "ProcessDate", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("客户单位", "ProcessCustomerUnit", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("查询内容", "ProcessContentInquired", 150, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("处理意见", "ProcessHandlingSuggestion", 150, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("联系人", "Processlinkman", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("购买日期", "ProcessPurchasingDate", 100, System.Windows.Forms.HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("服务人员", "ProcessServiceUser", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "ProcessStandard", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("电话", "Processtel", 100, System.Windows.Forms.HorizontalAlignment.Left, true));

            return ColumnArray;
        }
        /// <summary>
        /// 1.10.库存记录
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetInventoryColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "p_cpmc", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产厂家", "p_zzs", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "p_ggxh", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("材料名称", "p_clmc", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("注册证号", "p_zczh", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "p_sl1", 100, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("更新时间", "p_date", 120, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.11.销售统计汇总记录
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetSellTotalRecordsColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            string strGroupName = "";
            switch (SellTotalType)
            { 
                case UIModels.SellTotalType.Customer:
                    strGroupName = "客户名称";
                    break;
                case UIModels.SellTotalType.Product:
                    strGroupName = "产品名称";
                    break;
                case UIModels.SellTotalType.ProductAndType:
                    strGroupName = "产品名称+规格型号";
                    break;
                default :
                    strGroupName = "客户名称";
                    break;
            }
            ColumnArray.Add(new ListColumnInfo("NO", "SortNo",60, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo(strGroupName, "SGroupName", 350, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "STotalNumber", 80, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("金额（￥）", "STotalMoney", 150, System.Windows.Forms.HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("毛利（￥）", "SProfit", 150, System.Windows.Forms.HorizontalAlignment.Left, true));
            return ColumnArray;
        }
        #endregion

    }
}
