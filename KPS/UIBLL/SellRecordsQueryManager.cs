using System;
using System.Collections.Generic;
using System.Text;
using KPS.UIModels;
using System.Data;

namespace KPS.UIBLL
{
    /// <summary>
    /// 销售统计查询处理
    /// </summary>
    public class SellRecordsQueryManager
    {
        private SellTotalCondition thiscondition = null;
        /// <summary>
        /// 销售汇总记录 委托
        /// </summary>
        /// <param name="_recors">记录集合</param>
        /// <param name="_Succed">查询是否成功</param>
        /// <param name="_MsgInfo">错误信息</param>
        public delegate void DelSellRecordQueryEndArg(List<SellRecordInfo> _recors, TotalSumInfo _totalinfo,bool _Succed, string _MsgInfo);
        public event DelSellRecordQueryEndArg QueryEndEvent;
        System.Threading.Thread SellTotalThread;
        /// <summary>
        /// 销售汇总统计
        /// </summary>
        /// <param name="_Condition"></param>
        public void TotalSellRecords(SellTotalCondition _Condition)
        {
            thiscondition = _Condition;
            SellTotalThread = new System.Threading.Thread(new System.Threading.ThreadStart(start));
            SellTotalThread.IsBackground = true;
            SellTotalThread.Start();
        }
        /// <summary>
        /// 开始处理
        /// </summary>
        private void start()
        {
            string strSQL = "";
            string strBeginTime = thiscondition.StartTime.ToString("yyyy-MM-dd 00:00:00");
            string strEndTime = thiscondition.EndTime.ToString("yyyy-MM-dd 23:59:59");
            
            List<SellRecordInfo> list = null;
            TotalSumInfo _suminfo = new TotalSumInfo();

            #region 组织查询条件
            string strKeyName = "";
            switch (thiscondition.TotalType)
            { 
                case SellTotalType.Customer:
                    strKeyName = "p_gys";
                    strSQL = @"select p_gys,sum(p_sl1) as totalsl,sum(CCur(PSI_XiaoShou.p_sl2)*p_sl1) as totalje,sum(Profit*p_sl1)  as totallr 
                     FROM (select PSI_XiaoShou.*,(CCur(PSI_XiaoShou.p_sl2)-CCur(PSI_GouJin.p_sl2)) as Profit from PSI_XiaoShou left join PSI_GouJin on PSI_XiaoShou.GJID=PSI_GouJin.ID)TabAA
                    where (p_date>=#" + strBeginTime + "# and p_date<=#" + strEndTime + "#) and DataType=" +thiscondition.DeviceType+ " group by p_gys";
                    break;
                case SellTotalType.Product:
                    strKeyName = "p_cpmc";
                    strSQL = @"select p_cpmc,sum(p_sl1) as totalsl,sum(CCur(PSI_XiaoShou.p_sl2)*p_sl1) as totalje,sum(Profit*p_sl1)  as totallr 
                     FROM (select PSI_XiaoShou.*,(CCur(PSI_XiaoShou.p_sl2)-CCur(PSI_GouJin.p_sl2)) as Profit from PSI_XiaoShou left join PSI_GouJin on PSI_XiaoShou.GJID=PSI_GouJin.ID)TabAA
                    where (p_date>=#" + strBeginTime + "# and p_date<=#" + strEndTime + "#) and DataType=" + thiscondition.DeviceType + " group by p_cpmc";
                    break;
                case SellTotalType.ProductAndType:
                    strKeyName = "pgxh";
                    strSQL = @"select pgxh, sum(p_sl1) as totalsl,sum(CCur(PSI_XiaoShou.p_sl2)*p_sl1) as totalje,sum(Profit*p_sl1)  as totallr
                     FROM (select PSI_XiaoShou.*,(CCur(PSI_XiaoShou.p_sl2)-CCur(PSI_GouJin.p_sl2)) as Profit,(PSI_XiaoShou.p_cpmc&'+'&PSI_XiaoShou.p_ggxh) as pgxh from PSI_XiaoShou left join PSI_GouJin on PSI_XiaoShou.GJID=PSI_GouJin.ID)TabAA
                    where (p_date>=#" + strBeginTime + "# and p_date<=#" + strEndTime + "#) and DataType=" + thiscondition.DeviceType + " group by pgxh";
                    break;
                default:
                    break;
            }
            #endregion
            
            #region 数据查询 格式化 事件通知 返回记录
            KPS.BLL.XiaoShouManager bll=new BLL.XiaoShouManager();
            DataSet _ds = bll.GetDataBySQL(strSQL);
            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    SellRecordInfo _newrecord = null;
                    list = new List<SellRecordInfo>();
                    int _Index = 1;
                    foreach (DataRow _row in _ds.Tables[0].Rows)
                    {
                        _newrecord = FormatRecordByDataRow(_row, strKeyName);
                        if (_newrecord != null)
                        {
                            _newrecord.SType = thiscondition.TotalType;
                            _newrecord.SortNo = _Index;
                            list.Add(_newrecord);

                            _suminfo.TotalSumNumber += _newrecord.STotalNumber;
                            _suminfo.TotalSumMoney += _newrecord.STotalMoney;
                            _suminfo.TOtalSumProfit += _newrecord.SProfit;

                            _Index++;
                        }
                    }
                    if (QueryEndEvent != null)
                    {
                        QueryEndEvent(list,_suminfo, true,string.Format("共找到{0}条符合条件的记录!",list.Count));
                    }
                }
                else
                {
                    if (QueryEndEvent != null)
                    {
                        QueryEndEvent(list, _suminfo, true, "未能找到符合条件的记录！");
                    }
                }
            }
            else 
            {
                if (QueryEndEvent != null)
                {
                    QueryEndEvent(list, _suminfo, false, "查询失败,查询结果格式错误！");
                }
            }
            #endregion
        }

        /// <summary>
        /// 格式化结果行，返回记录对象
        /// </summary>
        /// <param name="_row"></param>
        /// <param name="_KeyType"></param>
        /// <returns></returns>
        private SellRecordInfo FormatRecordByDataRow(DataRow _row, string _KeyType)
        {
            SellRecordInfo item = null;
            try
            {
                item = new SellRecordInfo();
                item.SGroupName = _row[_KeyType].ToString();
                item.SProfit = Convert.ToDecimal(_row["totallr"]);
                item.STotalMoney = Convert.ToDecimal(_row["totalje"]);
                item.STotalNumber = Convert.ToInt32(_row["totalsl"]);
            }
            catch (Exception ex)
            { 
            }
            return item;
        }
    }
    /// <summary>
    /// 统计汇总信息
    /// </summary>
    public class TotalSumInfo
    {

        private int _TotalSumNumber;
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalSumNumber
        {
            get { return _TotalSumNumber; }
            set { _TotalSumNumber = value; }
        }
        private decimal _TotalSumMoney;
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalSumMoney
        {
            get { return _TotalSumMoney; }
            set { _TotalSumMoney = value; }
        }
        private decimal _TOtalSumProfit;
        /// <summary>
        /// 总毛利
        /// </summary>
        public decimal TOtalSumProfit
        {
            get { return _TOtalSumProfit; }
            set { _TOtalSumProfit = value; }
        }
    }
}
