using System;
namespace KPS.Model
{
	/// <summary>
    /// 不合格品记录:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BuHeGePinJiLuInfo
	{
        public BuHeGePinJiLuInfo()
		{}
		#region Model
		private int _id;
		private DateTime? _y_date;
		private string _y_pm;
		private string _y_ggxh;
		private string _y_dw;
		private int? _y_sl;
		private string _y_sccj;
		private string _y_cpdm;
		private string _y_ghdw;
		private string _y_cpzczh;
		private string _y_scph;
		private string _y_mjph;
		private string _y_yxq;
		private bool _y_ishgz= false;
		private string _y_zlqk;
		private string _y_zgy;
		private string _y_fhrqz;
        private int _DataType=0;

		/// <summary>
		///                           2验收信息表
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime? y_date
		{
			set{ _y_date=value;}
			get{return _y_date;}
		}
		/// <summary>
		/// 品名
		/// </summary>
		public string y_pm
		{
			set{ _y_pm=value;}
			get{return _y_pm;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string y_ggxh
		{
			set{ _y_ggxh=value;}
			get{return _y_ggxh;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string y_dw
		{
			set{ _y_dw=value;}
			get{return _y_dw;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? y_sl
		{
			set{ _y_sl=value;}
			get{return _y_sl;}
		}
		/// <summary>
		/// 生产厂家
		/// </summary>
		public string y_sccj
		{
			set{ _y_sccj=value;}
			get{return _y_sccj;}
		}
		/// <summary>
		/// 是否有许可证
		/// </summary>
		public string y_cpdm
		{
			set{ _y_cpdm=value;}
			get{return _y_cpdm;}
		}
		/// <summary>
		/// 供货单位
		/// </summary>
		public string y_ghdw
		{
			set{ _y_ghdw=value;}
			get{return _y_ghdw;}
		}
		/// <summary>
		/// 产品注册证号
		/// </summary>
		public string y_cpzczh
		{
			set{ _y_cpzczh=value;}
			get{return _y_cpzczh;}
		}
		/// <summary>
		/// 生产批号
		/// </summary>
		public string y_scph
		{
			set{ _y_scph=value;}
			get{return _y_scph;}
		}
		/// <summary>
		/// 灭菌批号
		/// </summary>
		public string y_mjph
		{
			set{ _y_mjph=value;}
			get{return _y_mjph;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public string y_yxq
		{
			set{ _y_yxq=value;}
			get{return _y_yxq;}
		}
		/// <summary>
		/// 是否有合格证
		/// </summary>
		public bool y_isHGZ
		{
			set{ _y_ishgz=value;}
			get{return _y_ishgz;}
		}
		/// <summary>
		/// 处理情况
		/// </summary>
		public string y_zlqk
		{
			set{ _y_zlqk=value;}
			get{return _y_zlqk;}
		}
		/// <summary>
		/// 质管员签名
		/// </summary>
		public string y_zgy
		{
			set{ _y_zgy=value;}
			get{return _y_zgy;}
		}
		/// <summary>
		/// 复核人签名
		/// </summary>
		public string y_fhrqz
		{
			set{ _y_fhrqz=value;}
			get{return _y_fhrqz;}
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

