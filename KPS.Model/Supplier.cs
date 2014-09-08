using System;
namespace KPS.Model
{
	/// <summary>
	/// Supplier:供货商(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Supplier
	{
        public Supplier()
		{}
		#region Model
		private int _supplierid;
		private string _suppliername;
		/// <summary>
		///                                供应商信息表
		/// </summary>
		public int supplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string supplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		#endregion Model

	}
}

