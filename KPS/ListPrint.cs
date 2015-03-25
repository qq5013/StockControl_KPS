using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSharpWin;
using KPS.UIModels;
using System.IO;
using KPS.Model;

namespace KPS
{
    public partial class ListPrint:SkinForm
    {
        private List<SellRecordInfo> listitems;
        private KPS.Model.GouJinInfo goujininfo;
        private List<GouJinInfo> inventorylist;
        public ListPrint(System.Collections.ICollection _recors)
        {
            if (_recors is List<SellRecordInfo>)
            {
                listitems = (List<SellRecordInfo>)_recors;
            }
            InitializeComponent();
            PrintSellRecordList();//打印销售列表
        }
        /// <summary>
        /// 库存记录
        /// </summary>
        /// <param name="_InventoryList"></param>
        public ListPrint(List<GouJinInfo> _InventoryList)
        {
            inventorylist = _InventoryList;
            InitializeComponent();
            PrintInventoryList();
        }
        /// <summary>
        /// 购进信息打印
        /// </summary>
        /// <param name="_GoujinInfo"></param>
        public ListPrint(KPS.Model.GouJinInfo _GoujinInfo)
        {
            goujininfo = _GoujinInfo;
            InitializeComponent();
            PrintGouJinInfo();//打印购进记录信息
        }

        /// <summary>
        /// 页面窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListPrint_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 打印销售记录列表
        /// </summary>
        private void PrintGouJinInfo()
        {
            string strHTML = GetListToHtmlModelHTML("GJPrintModel.html");//获取html内容
            strHTML=strHTML.Replace("$htmlformat[0]", goujininfo.p_cpmc);
            strHTML=strHTML.Replace("$htmlformat[1]", goujininfo.p_date.Value.ToString("yyyy年MM月dd日"));
            strHTML=strHTML.Replace("$htmlformat[2]", goujininfo.p_ggxh);
            strHTML=strHTML.Replace("$htmlformat[3]", goujininfo.p_clmc);
            strHTML=strHTML.Replace("$htmlformat[4]", goujininfo.p_ph);
            strHTML=strHTML.Replace("$htmlformat[5]", goujininfo.p_dw);
            strHTML=strHTML.Replace("$htmlformat[6]", goujininfo.p_gys);
            strHTML=strHTML.Replace("$htmlformat[7]", goujininfo.p_mjph);
            strHTML=strHTML.Replace("$htmlformat[8]", goujininfo.p_zzs);
            strHTML=strHTML.Replace("$htmlformat[9]", goujininfo.p_zczh);
            strHTML=strHTML.Replace("$htmlformat[10]", goujininfo.p_sl1.Value.ToString());
            strHTML=strHTML.Replace("$htmlformat[11]", goujininfo.p_sl2);
            strHTML=strHTML.Replace("$htmlformat[12]", goujininfo.p_jsr);
            strHTML=strHTML.Replace("$htmlformat[13]", TotalMoney(goujininfo.p_sl1.Value,Convert.ToDouble(goujininfo.p_sl2)));
            strHTML=strHTML.Replace("$htmlformat[14]", goujininfo.RemarkInfo);
            strHTML = strHTML.Replace("$htmlformat[15]", goujininfo.p_date.Value.ToString("yyyy年MM月dd日"));//有效期
            strHTML = strHTML.Replace("$htmlformat[16]", goujininfo.Reconfirm);//复核人

            string strAbstrctPageURL = "file://" + UIBLL.CommonFileManager.Instance.CreateTempFile(strHTML, "SellRecord20130921.html");
            this.webBrowser1.Navigate(strAbstrctPageURL);
        }
        /// <summary>
        /// 计算合计金额显示
        /// </summary>
        /// <param name="_Number"></param>
        /// <param name="_price"></param>
        /// <returns></returns>
        private string TotalMoney(int _Number, double _price)
        {
            string strReturnValue = "0.00";
            double TotalValue = _price * _Number;
            strReturnValue = string.Format("{0}", TotalValue.ToString("n"));
            return strReturnValue;
        }

        /// <summary>
        /// 打印销售记录列表
        /// </summary>
        private void PrintSellRecordList()
        {
            string strHTML = GetListToHtmlModelHTML("ListPrintModel.html");//获取html内容
            StringBuilder HTMLContent = new StringBuilder();
            if (listitems != null && listitems.Count > 0)
            {
                #region  组织表格填充内容
                string strTotalTypeName = "客户名称";
                switch (listitems[0].SType)
                {
                    case SellTotalType.Customer:
                        strTotalTypeName = "客户名称";
                        break;
                    case SellTotalType.Product:
                        strTotalTypeName = "产品名称";
                        break;
                    case SellTotalType.ProductAndType:
                        strTotalTypeName = "产品名称+规格型号";
                        break;
                    default:
                        strTotalTypeName = "产品名称";
                        break;
                }

                HTMLContent.Append("<tr><td>NO</dt><td>" + strTotalTypeName + "</dt><td>数量</dt><td>金额（￥）</dt><td>毛利（￥）</dt></tr>");
                foreach (SellRecordInfo _item in listitems)
                {
                    HTMLContent.Append("<tr>");
                    HTMLContent.Append("<td>" + _item.SortNo + "</td>");
                    HTMLContent.Append("<td>" + _item.SGroupName + "</td>");
                    HTMLContent.Append("<td>" + _item.STotalNumber + "</td>");
                    HTMLContent.Append("<td>" + _item.STotalMoney + "</td>");
                    HTMLContent.Append("<td>" + _item.SProfit + "</td>");
                    HTMLContent.Append("</tr>");
                }
                #endregion
            }
            strHTML = strHTML=strHTML.Replace("$$Replace", HTMLContent.ToString());

            string strAbstrctPageURL = "file://" + UIBLL.CommonFileManager.Instance.CreateTempFile(strHTML, "SellRecord20130921.html");
            this.webBrowser1.Navigate(strAbstrctPageURL);
        }

        /// <summary>
        /// 打印库存列表
        /// </summary>
        private void PrintInventoryList()
        {
            string strHTML = GetListToHtmlModelHTML("InventoryPrintModel.html");//获取html内容
            StringBuilder HTMLContent = new StringBuilder();
            if (inventorylist != null && inventorylist.Count > 0)
            {
                #region  组织表格填充内容

                HTMLContent.Append("<tr><td>NO</dt><td>产品名称</dt><td>生产商</dt><td>规格型号</dt><td>材料名称</dt><td>注册证号</dt><td>数量</dt><td>更新时间</dt></tr>");
                foreach (GouJinInfo _item in inventorylist)
                {
                    HTMLContent.Append("<tr>");
                    HTMLContent.Append("<td>" + _item.ID + "</td>");
                    HTMLContent.Append("<td>" + _item.p_cpmc + "</td>");
                    HTMLContent.Append("<td>" + _item.p_zzs + "</td>");
                    HTMLContent.Append("<td>" + _item.p_ggxh + "</td>");
                    HTMLContent.Append("<td>" + _item.p_clmc + "</td>");
                    HTMLContent.Append("<td>" + _item.p_zczh + "</td>");
                    HTMLContent.Append("<td>" + _item.p_sl1 + "</td>");
                    HTMLContent.Append("<td>" + _item.p_date.Value.ToString("yyyy年MM月dd日") + "</td>");
                    HTMLContent.Append("</tr>");
                }
                #endregion
            }
            strHTML = strHTML=strHTML.Replace("$$Replace", HTMLContent.ToString());

            string strAbstrctPageURL = "file://" + UIBLL.CommonFileManager.Instance.CreateTempFile(strHTML, "SellRecord20130921.html");
            this.webBrowser1.Navigate(strAbstrctPageURL);
        }
        /// <summary>
        /// 列表转换到html文件
        /// </summary>
        private string  GetListToHtmlModelHTML(string _ModelFileName)
        {
            StringBuilder htmltext = new StringBuilder();  //完整的html页面代码
            try
            {
                #region 读取模板html内容
                string strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + _ModelFileName;
                using (StreamReader sr = new StreamReader(strPath, Encoding.UTF8, false))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        htmltext.Append(line);
                    }
                    sr.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return htmltext.ToString();
        }

        private void TolMenuPrint_Click(object sender, EventArgs e)
        {
            this.webBrowser1.ShowPrintDialog();
        }

    }
}
