using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KPS.BLL
{
    /// <summary>
    /// 库存记录处理
    /// </summary>
    public class InventoryManager
    {
        private readonly KPS.DAL.Inventory_DAL dal = new KPS.DAL.Inventory_DAL();
        public InventoryManager()
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
        /// 增加一条数据(内部根据 产品名称+厂家+注册证号+批号 判断是否已存在，若存在则只更新数量)
		/// </summary>
		public bool Add(KPS.Model.GouJinInfo model)
		{
			return dal.Add(model);
		}
        
        /// <summary>
        /// 销售 减少库存(当添加产品的销售记录时，则通过此方法更新已有产品的销售记录)
        /// </summary>
        /// <param name="xsmodel"></param>
        /// <returns></returns>
        public KPS.Model.InventoryUpState Sell(KPS.Model.XiaoShouInfo xsmodel)
        {
            return dal.Sell(xsmodel);
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
		public List<KPS.Model.GouJinInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KPS.Model.GouJinInfo> DataTableToList(DataTable dt)
		{
            List<KPS.Model.GouJinInfo> modelList = new List<KPS.Model.GouJinInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                KPS.Model.GouJinInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 条数
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
            string _tableName = "PSI_Inventory";
            string key = "ID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
    }
}
