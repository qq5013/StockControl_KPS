using System;
namespace KPS.Model
{
	/// <summary>
	/// 不良事件:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BuLiangShiJianInfo
	{
		public BuLiangShiJianInfo()
		{}
		#region Model
		private int _id;
		private string _b_ylqxmc;
		private string _b_ggxh;
		private string _b_sccj;
		private string _b_cpdm;
		private int? _b_sl;
		private string _b_sydw;
		private string _b_scrq;
		private string _b_zlsgqk;
		private string _b_bgr;
		private DateTime? _b_bgsj;
		private string _b_sydwyj;
		private string _b_fzr;
		private DateTime? _b_resj;
		private string _b_qyzgfzryj;
		private string _b_fzrqz;
		private DateTime? _b_fzrqzsj;
		private string _b_zgclqk;
		private string _b_zgjbr;
		private DateTime? _b_zgjbsj;
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
		/// 医疗器械名称
		/// </summary>
		public string b_ylqxmc
		{
			set{ _b_ylqxmc=value;}
			get{return _b_ylqxmc;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string b_ggxh
		{
			set{ _b_ggxh=value;}
			get{return _b_ggxh;}
		}
		/// <summary>
		/// 生产厂家
		/// </summary>
		public string b_sccj
		{
			set{ _b_sccj=value;}
			get{return _b_sccj;}
		}
		/// <summary>
		/// 产品代码
		/// </summary>
		public string b_cpdm
		{
			set{ _b_cpdm=value;}
			get{return _b_cpdm;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? b_sl
		{
			set{ _b_sl=value;}
			get{return _b_sl;}
		}
		/// <summary>
		/// 使用单位
		/// </summary>
		public string b_sydw
		{
			set{ _b_sydw=value;}
			get{return _b_sydw;}
		}
		/// <summary>
		/// 生产日期
		/// </summary>
		public string b_scrq
		{
			set{ _b_scrq=value;}
			get{return _b_scrq;}
		}
		/// <summary>
        /// 质量事故情况内容
		/// </summary>
		public string b_zlsgqk
		{
			set{ _b_zlsgqk=value;}
			get{return _b_zlsgqk;}
		}
		/// <summary>
		/// 报告人
		/// </summary>
		public string b_bgr
		{
			set{ _b_bgr=value;}
			get{return _b_bgr;}
		}
		/// <summary>
		/// 报告时间
		/// </summary>
		public DateTime? b_bgsj
		{
			set{ _b_bgsj=value;}
			get{return _b_bgsj;}
		}
		/// <summary>
		/// 使用单位意见
		/// </summary>
		public string b_sydwyj
		{
			set{ _b_sydwyj=value;}
			get{return _b_sydwyj;}
		}
		/// <summary>
        /// 使用单位意见 负责人
		/// </summary>
		public string b_fzr
		{
			set{ _b_fzr=value;}
			get{return _b_fzr;}
		}
		/// <summary>
		/// 使用单位意见 反馈 日期时间
		/// </summary>
		public DateTime? b_resj
		{
			set{ _b_resj=value;}
			get{return _b_resj;}
		}
		/// <summary>
		/// 企业主管负责人意见
		/// </summary>
		public string b_qyzgfzryj
		{
			set{ _b_qyzgfzryj=value;}
			get{return _b_qyzgfzryj;}
		}
		/// <summary>
        /// 企业主管质量负责人 签字
		/// </summary>
		public string b_fzrqz
		{
			set{ _b_fzrqz=value;}
			get{return _b_fzrqz;}
		}
		/// <summary>
		/// 企业主管质量负责人意见  签字时间
		/// </summary>
		public DateTime? b_fzrqzsj
		{
			set{ _b_fzrqzsj=value;}
			get{return _b_fzrqzsj;}
		}
		/// <summary>
		/// 最终处理情况
		/// </summary>
		public string b_zgclqk
		{
			set{ _b_zgclqk=value;}
			get{return _b_zgclqk;}
		}
		/// <summary>
		/// 经办人
		/// </summary>
		public string b_zgjbr
		{
			set{ _b_zgjbr=value;}
			get{return _b_zgjbr;}
		}
		/// <summary>
		///最终处理情况 经办时间
		/// </summary>
		public DateTime? b_zgjbsj
		{
			set{ _b_zgjbsj=value;}
			get{return _b_zgjbsj;}
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

