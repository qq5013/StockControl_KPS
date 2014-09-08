using System;
namespace KPS.Model
{
	/// <summary>
    /// Manufacturer:制造/生产商 (属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Manufacturer
	{
        public Manufacturer()
		{}
		#region Model
		private int _manufacturerid;
        private string _manufacturername = "";
		private string _manufacturertel="";
		private string _manufactureradd="";
		/// <summary>
		/// 主键                                        制造商信息表
		/// </summary>
		public int manufacturerID
		{
			set{ _manufacturerid=value;}
			get{return _manufacturerid;}
		}
		/// <summary>
		/// 制造商名称
		/// </summary>
		public string manufacturerName
		{
			set{ _manufacturername=value;}
			get{return _manufacturername;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string manufacturerTel
		{
			set{ _manufacturertel=value;}
			get{return _manufacturertel;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string manufacturerAdd
		{
			set{ _manufactureradd=value;}
			get{return _manufactureradd;}
		}
		#endregion Model

	}
}

