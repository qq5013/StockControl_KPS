using System;
using System.Data;
using System.Collections.Generic;
using KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// PSI_Supplier
	/// </summary>
	public partial class SupplierManager
	{
        private readonly KPS.DAL.Supplier_DAL dal = new KPS.DAL.Supplier_DAL();
        public SupplierManager()
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
		public bool Exists(int supplierID)
		{
			return dal.Exists(supplierID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.Supplier model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(KPS.Model.Supplier model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int supplierID)
		{
			
			return dal.Delete(supplierID);
		}
		/// <summary>
        /// 批量删除数据  如"1,2,3,4,5,6,7,8"
		/// </summary>
		public bool DeleteList(string supplierIDlist )
		{
			return dal.DeleteList(supplierIDlist );
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Supplier> GetModelList(string strWhere)
        {
            List<KPS.Model.Supplier> listsupers = null;
            DataSet _ds = GetList(strWhere);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                listsupers = new List<KPS.Model.Supplier>();
                foreach (DataRow _row in _ds.Tables[0].Rows)
                {
                    listsupers.Add(dal.DataRowToModel(_row));
                }
            }
            return listsupers;
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
            string _tableName = "PSI_Supplier";
            string key = "supplierID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}

