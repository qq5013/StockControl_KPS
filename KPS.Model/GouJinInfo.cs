using System;
namespace KPS.Model
{
	/// <summary>
	/// 诊断试剂购进:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GouJinInfo
	{
        public GouJinInfo()
		{}
		#region Model
		private int _id;
		private DateTime? _p_date;
		private string _p_cpmc;
		private string _p_ggxh;
		private string _p_clmc;
		private string _p_ph;
		private string _p_dw;
		private int? _p_sl1;
		private string _p_mjph;
		private string _p_zzs;
		private string _p_zczh;
		private string _p_gys;
		private string _p_sl2;
		private string _p_jsr;
        private int _DataType=0;
        private string _remarkInfo;
        private string _reconfirm;
        private DateTime? _p_valid;

		/// <summary>
		/// 主键编号                   购进表
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? p_date
		{
			set{ _p_date=value;}
			get{return _p_date;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string p_cpmc
		{
			set{ _p_cpmc=value;}
			get{return _p_cpmc;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string p_ggxh
		{
			set{ _p_ggxh=value;}
			get{return _p_ggxh;}
		}
		/// <summary>
		/// 材料名称
		/// </summary>
		public string p_clmc
		{
			set{ _p_clmc=value;}
			get{return _p_clmc;}
		}
		/// <summary>
		/// 批号
		/// </summary>
		public string p_ph
		{
			set{ _p_ph=value;}
			get{return _p_ph;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string p_dw
		{
			set{ _p_dw=value;}
			get{return _p_dw;}
		}
		/// <summary>
		/// 数量1
		/// </summary>
		public int? p_sl1
		{
			set{ _p_sl1=value;}
			get{return _p_sl1;}
		}
		/// <summary>
		/// 灭菌批号
		/// </summary>
		public string p_mjph
		{
			set{ _p_mjph=value;}
			get{return _p_mjph;}
		}
		/// <summary>
		/// 制造商
		/// </summary>
		public string p_zzs
		{
			set{ _p_zzs=value;}
			get{return _p_zzs;}
		}
		/// <summary>
		/// 注册证号
		/// </summary>
		public string p_zczh
		{
			set{ _p_zczh=value;}
			get{return _p_zczh;}
		}
		/// <summary>
		/// 供应商
		/// </summary>
		public string p_gys
		{
			set{ _p_gys=value;}
			get{return _p_gys;}
		}
		/// <summary>
		/// 单价(小数点后两位)
		/// </summary>
		public string p_sl2
		{
			set{ _p_sl2=value;}
			get{return _p_sl2;}
		}
		/// <summary>
		/// 经手人
		/// </summary>
		public string p_jsr
		{
			set{ _p_jsr=value;}
			get{return _p_jsr;}
		}

        /// <summary>
        /// 数据类型
        /// </summary>
        public int DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string RemarkInfo
        {
            get { return _remarkInfo; }
            set { _remarkInfo = value; }
        }
        /// <summary>
        /// 复核人
        /// </summary>
        public string Reconfirm
        {
            get { return _reconfirm; }
            set { _reconfirm = value; }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? p_valid
        {
            get { return _p_valid; }
            set { _p_valid = value; }
        }
		#endregion Model

	}
}

