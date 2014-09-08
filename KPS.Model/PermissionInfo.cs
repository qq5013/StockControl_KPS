using System;
namespace KPS.Model
{
	/// <summary>
	/// PSI_Permission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PermissionInfo
	{
        public PermissionInfo()
		{}
		#region Model
		private int _permissionid;
		private string _username;
		private int? _moduleinfoid;
		/// <summary>
		/// 
		/// </summary>
		public int permissionID
		{
			set{ _permissionid=value;}
			get{return _permissionid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 模块ID
		/// </summary>
		public int? moduleInfoID
		{
			set{ _moduleinfoid=value;}
			get{return _moduleinfoid;}
		}
		#endregion Model

	}
}

