using System;
using System.Data;
using System.Collections.Generic;
using KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// PSI_Unit
	/// </summary>
	public partial class UnitManager
	{
        private readonly KPS.DAL.Unit_DAL dal = new KPS.DAL.Unit_DAL();
        public UnitManager()
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
		public bool Exists(int unitid)
		{
			return dal.Exists(unitid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.Unit model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.Unit model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int unitid)
		{
			
			return dal.Delete(unitid);
		}
		/// <summary>
        /// 批量删除数据  如"1,2,3,4,5,6,7,8"
		/// </summary>
		public bool DeleteList(string unitidlist )
		{
			return dal.DeleteList(unitidlist );
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据Model列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<KPS.Model.Unit> GetModelList(string strWhere)
        {
            List<KPS.Model.Unit> listunits = null;
            DataSet _ds = GetList(strWhere);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                listunits=new List<KPS.Model.Unit>();
                foreach (DataRow _row in _ds.Tables[0].Rows)
                {
                    listunits.Add(dal.DataRowToModel(_row)); 
                }
            }
            return listunits;
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
            string _tableName = "PSI_Unit";
            string key = "unitid";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}

