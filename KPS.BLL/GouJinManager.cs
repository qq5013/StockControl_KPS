﻿using System;
using System.Data;
using System.Collections.Generic;
using KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// 诊断试剂购进
	/// </summary>
	public partial class GouJinManager
	{
		private readonly KPS.DAL.GouJin_DAL dal=new KPS.DAL.GouJin_DAL();
        public GouJinManager()
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
		public bool Add(KPS.Model.GouJinInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.GouJinInfo model)
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
		/// 批量删除
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
            string _tableName = "PSI_GouJin";
            string key = "ID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}
