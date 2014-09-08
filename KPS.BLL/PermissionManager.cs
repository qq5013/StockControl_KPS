using System;
using System.Data;
using System.Collections.Generic;
using KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// PSI_Permission
	/// </summary>
	public partial class PermissionManager
	{
        private readonly KPS.DAL.Permission_DAL dal = new KPS.DAL.Permission_DAL();
        public PermissionManager()
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
		public bool Exists(int permissionID)
		{
			return dal.Exists(permissionID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.PermissionInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(KPS.Model.PermissionInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int permissionID)
		{
			
			return dal.Delete(permissionID);
		}
          /// <summary>
        /// 删除用户的权限记录
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public bool DeleteItemByUserName(string _userName)
        {
            return dal.DeleteItemByUserName(_userName);
        }

		/// <summary>
        /// 批量删除数据  如"1,2,3,4,5,6,7,8"
		/// </summary>
		public bool DeleteList(string permissionIDlist )
		{
			return dal.DeleteList(permissionIDlist );
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得Model 列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<PermissionInfo> GetModelList(string strWhere)
        {
            List<PermissionInfo> Perslist = null;
            try
            {
                DataTable _dt = dal.GetList(strWhere).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    Perslist = new List<PermissionInfo>();
                    foreach (DataRow _row in _dt.Rows)
                    {
                        Perslist.Add(dal.DataRowToModel(_row));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Perslist;
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
            string _tableName = "PSI_Permission";
            string key = "permissionID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}

