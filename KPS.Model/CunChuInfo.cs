using System;
namespace KPS.Model
{
	/// <summary>
	/// 存储:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CunChuInfo
	{
        public CunChuInfo()
		{}
		#region Model
		private int _id;
		private string _s_csmc;
		private DateTime? _s_date;
		private string _s_sywdfw;
		private string _s_syxdsdfw;
		private int? _s_sworxw;
		private string _s_wd;
		private string _s_sd;
		private string _s_cqcs;
		private string _s_wded;
		private string _s_sded;
		private string _s_jlr;
        private int _DataType=0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 场所名称
		/// </summary>
		public string s_csmc
		{
			set{ _s_csmc=value;}
			get{return _s_csmc;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime? s_date
		{
			set{ _s_date=value;}
			get{return _s_date;}
		}
		/// <summary>
		/// 适宜温度范围
		/// </summary>
		public string s_sywdfw
		{
			set{ _s_sywdfw=value;}
			get{return _s_sywdfw;}
		}
		/// <summary>
		/// 适宜相对湿度范围
		/// </summary>
		public string s_syxdsdfw
		{
			set{ _s_syxdsdfw=value;}
			get{return _s_syxdsdfw;}
		}
		/// <summary>
		/// 0:上午/1:下午
		/// </summary>
		public int? s_sworxw
		{
			set{ _s_sworxw=value;}
			get{return _s_sworxw;}
		}
		/// <summary>
		/// 温度
		/// </summary>
		public string s_wd
		{
			set{ _s_wd=value;}
			get{return _s_wd;}
		}
		/// <summary>
		/// 湿度
		/// </summary>
		public string s_sd
		{
			set{ _s_sd=value;}
			get{return _s_sd;}
		}
		/// <summary>
		/// 采取措施
		/// </summary>
		public string s_cqcs
		{
			set{ _s_cqcs=value;}
			get{return _s_cqcs;}
		}
		/// <summary>
		/// 采取措施后温度
		/// </summary>
		public string s_wded
		{
			set{ _s_wded=value;}
			get{return _s_wded;}
		}
		/// <summary>
		/// 采取措施后湿度
		/// </summary>
		public string s_sded
		{
			set{ _s_sded=value;}
			get{return _s_sded;}
		}
		/// <summary>
		/// 记录人
		/// </summary>
		public string s_jlr
		{
			set{ _s_jlr=value;}
			get{return _s_jlr;}
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

