using System;
namespace KPS.Model
{
	/// <summary>
	/// ProductInfo:产品信息(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductInfo
	{
        public ProductInfo()
		{}
		#region Model
		private int _productid;
		private string _productname;
        private double _promoney;
		 
		/// <summary>
		/// 产品id
		/// </summary>
		public int productid
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string productname
		{
			set{ _productname=value;}
			get{return _productname;}
		}

        /// <summary>
        /// 价格
        /// </summary>
        public double promoney
        {
            set { _promoney = value; }
            get { return _promoney; }
        }
		 
		#endregion Model

	}
}

