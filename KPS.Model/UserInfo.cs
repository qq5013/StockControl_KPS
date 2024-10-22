﻿using System;
namespace KPS.Model
{
	/// <summary>
	/// 用户信息:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
        public UserInfo()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _userpwd;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userPwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		#endregion Model

	}
}

