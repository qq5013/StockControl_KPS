using System;
namespace KPS.Model
{
	/// <summary>
	/// 质量跟踪:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProcessLoggingInfo
	{
        public ProcessLoggingInfo()
		{}
		#region Model
		private int _processid;
		private DateTime? _processdate;
		private string _processcustomerunit;
		private string _processlinkman;
		private string _processtel;
		private string _processproductname;
		private string _processstandard;
		private DateTime? _processpurchasingdate;
		private string _processcontentinquired;
		private string _processhandlingsuggestion;
		private string _processserviceuser;
        private int _DataType=0;
		/// <summary>
		/// 
		/// </summary>
		public int ProcessID
		{
			set{ _processid=value;}
			get{return _processid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? ProcessDate
		{
			set{ _processdate=value;}
			get{return _processdate;}
		}
		/// <summary>
		/// 客户单位
		/// </summary>
		public string ProcessCustomerUnit
		{
			set{ _processcustomerunit=value;}
			get{return _processcustomerunit;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Processlinkman
		{
			set{ _processlinkman=value;}
			get{return _processlinkman;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Processtel
		{
			set{ _processtel=value;}
			get{return _processtel;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string ProcessProductName
		{
			set{ _processproductname=value;}
			get{return _processproductname;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string ProcessStandard
		{
			set{ _processstandard=value;}
			get{return _processstandard;}
		}
		/// <summary>
		/// 购买日期
		/// </summary>
		public DateTime? ProcessPurchasingDate
		{
			set{ _processpurchasingdate=value;}
			get{return _processpurchasingdate;}
		}
		/// <summary>
		/// 查询内容
		/// </summary>
		public string ProcessContentInquired
		{
			set{ _processcontentinquired=value;}
			get{return _processcontentinquired;}
		}
		/// <summary>
		/// 处理意见
		/// </summary>
		public string ProcessHandlingSuggestion
		{
			set{ _processhandlingsuggestion=value;}
			get{return _processhandlingsuggestion;}
		}
		/// <summary>
		/// 服务人员
		/// </summary>
		public string ProcessServiceUser
		{
			set{ _processserviceuser=value;}
			get{return _processserviceuser;}
		}

        /// <summary>
        /// 数据类型
        /// </summary>
        public int DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }
		#endregion Model

	}
}

