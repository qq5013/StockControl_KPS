using System;
using System.Data;
using System.Collections.Generic;
using  KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// 用户信息处理
	/// </summary>
	public partial class UserInfoManager
	{
		private readonly KPS.DAL.PSI_UserInfoDAL dal=new KPS.DAL.PSI_UserInfoDAL();
        public UserInfoManager()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.UserInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.UserInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
        /// 批量删除数据  如"1,2,3,4,5,6,7,8"
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<UserInfo> GetModelLIst(string strWhere)
        {
            List<UserInfo> users = null;
            try
            {
                DataTable _dt = dal.GetList(strWhere).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0)
                { 
                    users=new List<UserInfo> ();
                    foreach(DataRow _row in _dt.Rows)
                    {
                        users.Add(dal.DataRowToModel(_row));
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
            return users;
        }
		
		/// <summary>
        /// 获取数据条数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet getDataByPage(int pageIndex, int pageSize, string where, string order, bool isPage)
        {
            string _tableName = "PSI_UserInfo";
            string key = "ID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}

