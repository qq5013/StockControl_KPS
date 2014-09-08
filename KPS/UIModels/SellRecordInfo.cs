using System;
using System.Collections.Generic;
using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 销售记录信息
    /// </summary>
    public class SellRecordInfo
    {
        private int _SortNo;
        /// <summary>
        /// 序号
        /// </summary>
        public int SortNo
        {
            get { return _SortNo; }
            set { _SortNo = value; }
        }
        private SellTotalType _SType;
        /// <summary>
        /// 统计类型
        /// </summary>
        public SellTotalType SType
        {
            get { return _SType; }
            set { _SType = value; }
        }
        private string _SGroupName;
        /// <summary>
        /// 统计分组名称
        /// </summary>
        public string SGroupName
        {
            get { return _SGroupName; }
            set { _SGroupName = value; }
        }
        private int _STotalNumber;
        /// <summary>
        /// 数量
        /// </summary>
        public int STotalNumber
        {
            get { return _STotalNumber; }
            set { _STotalNumber = value; }
        }
        private decimal _STotalMoney;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal STotalMoney
        {
            get { return _STotalMoney; }
            set { _STotalMoney = value; }
        }
        private decimal _SProfit;
        /// <summary>
        /// 毛利
        /// </summary>
        public decimal SProfit
        {
            get { return _SProfit; }
            set { _SProfit = value; }
        }
    }
    
    /// <summary>
    /// 销售汇总类型
    /// </summary>
    public enum SellTotalType
    {
        /// <summary>
        /// 客户
        /// </summary>
        Customer,
        /// <summary>
        /// 产品名称
        /// </summary>
        Product,
        /// <summary>
        /// 产品名称+规格型号
        /// </summary>
        ProductAndType
    }

    /// <summary>
    /// 统计条件
    /// </summary>
    public class SellTotalCondition
    {
        public SellTotalCondition()
        { 
        }
        public SellTotalCondition(DateTime _starttime, DateTime _endtime, SellTotalType _type,int _devideTypevalue)
        {
            _StartTime = _starttime;
            _EndTime = _endtime;
            _TotalType = _type;
            _DeviceType = _devideTypevalue;
        }

        private DateTime _StartTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        private DateTime _EndTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        private SellTotalType _TotalType;
        /// <summary>
        /// 统计类型
        /// </summary>
        public SellTotalType TotalType
        {
            get { return _TotalType; }
            set { _TotalType = value; }
        }
        private int _DeviceType;
        /// <summary>
        /// 类型 
        /// </summary>
        public int DeviceType
        {
            get { return _DeviceType; }
            set { _DeviceType = value; }
        }

    }
}
