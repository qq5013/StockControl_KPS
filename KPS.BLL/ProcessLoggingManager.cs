using System;
using System.Data;
using System.Collections.Generic;
using KPS.Model;
namespace KPS.BLL
{
	/// <summary>
	/// PSI_ProcessLogging
	/// </summary>
	public partial class ProcessLoggingManager
	{
        private readonly KPS.DAL.ProcessLogging_DAL dal = new KPS.DAL.ProcessLogging_DAL();
        public ProcessLoggingManager()
		{}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProcessID)
		{
			return dal.Exists(ProcessID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Add(KPS.Model.ProcessLoggingInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(KPS.Model.ProcessLoggingInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ProcessID)
		{
			
			return dal.Delete(ProcessID);
		}
		/// <summary>
		/// ����ɾ��
		/// </summary>
		public bool DeleteList(string ProcessIDlist )
		{
			return dal.DeleteList(ProcessIDlist );
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<KPS.Model.ProcessLoggingInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        private List<KPS.Model.ProcessLoggingInfo> DataTableToList(DataTable dt)
        {
            List<KPS.Model.ProcessLoggingInfo> modelList = new List<KPS.Model.ProcessLoggingInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KPS.Model.ProcessLoggingInfo model;
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
		/// ��ȡ��������
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}

        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet getDataByPage(int pageIndex, int pageSize, string where, string order, bool isPage)
        {
            string _tableName = "PSI_ProcessLogging";
            string key = "ProcessID";
            return dal.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);
        }
	}
}

