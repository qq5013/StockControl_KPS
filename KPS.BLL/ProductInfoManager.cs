using System;
using System.Data;
using System.Collections.Generic;
using KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// PSI_ProductInfo
	/// </summary>
	public partial class ProductInfoManager
	{
        private readonly KPS.DAL.ProductInfo_DAL dal = new KPS.DAL.ProductInfo_DAL();
        public ProductInfoManager()
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
		public bool Exists(string productname)
		{
            return dal.Exists(productname);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.ProductInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.ProductInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int productid)
		{
			
			return dal.Delete(productid);
		}
		/// <summary>
        /// 批量删除数据  如"1,2,3,4,5,6,7,8"
		/// </summary>
		public bool DeleteList(string productidlist )
		{
			return dal.DeleteList(productidlist );
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public List<ProductInfo> GetModelList(string strWhere)
        {
            List<KPS.Model.ProductInfo> listitems = null;
            DataSet _ds = GetList(strWhere);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                listitems = new List<KPS.Model.ProductInfo>();
                foreach (DataRow _row in _ds.Tables[0].Rows)
                {
                    listitems.Add(dal.DataRowToModel(_row));
                }
            }
            return listitems;
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
            string _tableName = "PSI_ProductInfo";
            string key = "productid";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}

