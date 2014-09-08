using System;
namespace KPS.Model
{
	/// <summary>
	/// Unit:产品单位 (属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Unit
	{
        public Unit()
		{}
		#region Model
		private int _unitid;
		private string _unitname;
		/// <summary>
		/// 
		/// </summary>
		public int unitid
		{
			set{ _unitid=value;}
			get{return _unitid;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string unitname
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		#endregion Model

	}
}

