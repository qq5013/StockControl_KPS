using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KPS.BLL
{
    /// <summary>
    /// 医疗仪器类型处理类
    /// </summary>
    public class DeviceInfoManager
    {
        private readonly KPS.DAL.Device_DAL dal = new KPS.DAL.Device_DAL();
        public DeviceInfoManager()
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
		public bool Add(KPS.Model.DeviceInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.DeviceInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int deviceid)
		{

            return dal.Delete(deviceid);
		}
		/// <summary>
        /// 批量删除数据  如"1,2,3,4,5,6,7,8"
		/// </summary>
		public bool DeleteList(string devicelist)
		{
            return dal.DeleteList(devicelist);
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
        public List<KPS.Model.DeviceInfo> GetModelList(string strWhere)
        {
            List<KPS.Model.DeviceInfo> listdevices = null;
            DataSet _ds = GetList(strWhere);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                listdevices = new List<KPS.Model.DeviceInfo>();
                foreach (DataRow _row in _ds.Tables[0].Rows)
                {
                    listdevices.Add(dal.DataRowToModel(_row)); 
                }
            }
            return listdevices;
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
            string _tableName = "PSI_DeViceInfo";
            string key = "DeviceID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
    }
}
