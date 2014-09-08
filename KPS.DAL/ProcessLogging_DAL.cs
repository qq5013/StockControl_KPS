using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;//Please add references
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_ProcessLogging
	/// </summary>
	public partial class ProcessLogging_DAL
	{
        public ProcessLogging_DAL()
		{}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProcessID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_ProcessLogging");
			strSql.Append(" where ProcessID=@ProcessID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProcessID", OleDbType.Integer,4)
			};
			parameters[0].Value = ProcessID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.ProcessLoggingInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_ProcessLogging(");
            strSql.Append("ProcessDate,ProcessCustomerUnit,Processlinkman,Processtel,ProcessProductName,ProcessStandard,ProcessPurchasingDate,ProcessContentInquired,ProcessHandlingSuggestion,ProcessServiceUser,DataType)");
			strSql.Append(" values (");
            strSql.Append("@ProcessDate,@ProcessCustomerUnit,@Processlinkman,@Processtel,@ProcessProductName,@ProcessStandard,@ProcessPurchasingDate,@ProcessContentInquired,@ProcessHandlingSuggestion,@ProcessServiceUser,@DataType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProcessDate", OleDbType.Date),
					new OleDbParameter("@ProcessCustomerUnit", OleDbType.VarChar,255),
					new OleDbParameter("@Processlinkman", OleDbType.VarChar,255),
					new OleDbParameter("@Processtel", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessProductName", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessStandard", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessPurchasingDate", OleDbType.Date),
					new OleDbParameter("@ProcessContentInquired", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessHandlingSuggestion", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessServiceUser", OleDbType.VarChar,255),
                    new OleDbParameter("@DataType", OleDbType.Integer,4)};
			parameters[0].Value = model.ProcessDate;
			parameters[1].Value = model.ProcessCustomerUnit;
			parameters[2].Value = model.Processlinkman;
			parameters[3].Value = model.Processtel;
			parameters[4].Value = model.ProcessProductName;
			parameters[5].Value = model.ProcessStandard;
			parameters[6].Value = model.ProcessPurchasingDate;
			parameters[7].Value = model.ProcessContentInquired;
			parameters[8].Value = model.ProcessHandlingSuggestion;
            parameters[9].Value = model.ProcessServiceUser;
            parameters[10].Value = model.DataType;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
 
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.ProcessLoggingInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_ProcessLogging set ");
			strSql.Append("ProcessDate=@ProcessDate,");
			strSql.Append("ProcessCustomerUnit=@ProcessCustomerUnit,");
			strSql.Append("Processlinkman=@Processlinkman,");
			strSql.Append("Processtel=@Processtel,");
			strSql.Append("ProcessProductName=@ProcessProductName,");
			strSql.Append("ProcessStandard=@ProcessStandard,");
			strSql.Append("ProcessPurchasingDate=@ProcessPurchasingDate,");
			strSql.Append("ProcessContentInquired=@ProcessContentInquired,");
			strSql.Append("ProcessHandlingSuggestion=@ProcessHandlingSuggestion,");
            strSql.Append("ProcessServiceUser=@ProcessServiceUser,");
            strSql.Append("DataType=@DataType");
			strSql.Append(" where ProcessID=@ProcessID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProcessDate", OleDbType.Date),
					new OleDbParameter("@ProcessCustomerUnit", OleDbType.VarChar,255),
					new OleDbParameter("@Processlinkman", OleDbType.VarChar,255),
					new OleDbParameter("@Processtel", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessProductName", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessStandard", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessPurchasingDate", OleDbType.Date),
					new OleDbParameter("@ProcessContentInquired", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessHandlingSuggestion", OleDbType.VarChar,255),
					new OleDbParameter("@ProcessServiceUser", OleDbType.VarChar,255),
					new OleDbParameter("@DataType", OleDbType.Integer,4),
					new OleDbParameter("@ProcessID", OleDbType.Integer,4)};
			parameters[0].Value = model.ProcessDate;
			parameters[1].Value = model.ProcessCustomerUnit;
			parameters[2].Value = model.Processlinkman;
			parameters[3].Value = model.Processtel;
			parameters[4].Value = model.ProcessProductName;
			parameters[5].Value = model.ProcessStandard;
			parameters[6].Value = model.ProcessPurchasingDate;
			parameters[7].Value = model.ProcessContentInquired;
			parameters[8].Value = model.ProcessHandlingSuggestion;
            parameters[9].Value = model.ProcessServiceUser;
            parameters[10].Value = model.DataType;
			parameters[11].Value = model.ProcessID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProcessID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_ProcessLogging ");
			strSql.Append(" where ProcessID=@ProcessID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProcessID", OleDbType.Integer,4)
			};
			parameters[0].Value = ProcessID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ProcessIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_ProcessLogging ");
			strSql.Append(" where ProcessID in ("+ProcessIDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KPS.Model.ProcessLoggingInfo GetModel(int ProcessID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ProcessID,ProcessDate,ProcessCustomerUnit,Processlinkman,Processtel,ProcessProductName,ProcessStandard,ProcessPurchasingDate,ProcessContentInquired,ProcessHandlingSuggestion,ProcessServiceUser from PSI_ProcessLogging,DataType ");
			strSql.Append(" where ProcessID=@ProcessID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProcessID", OleDbType.Integer,4)
			};
			parameters[0].Value = ProcessID;

			KPS.Model.ProcessLoggingInfo model=new KPS.Model.ProcessLoggingInfo();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public KPS.Model.ProcessLoggingInfo DataRowToModel(DataRow row)
		{
			KPS.Model.ProcessLoggingInfo model=new KPS.Model.ProcessLoggingInfo();
			if (row != null)
			{
				if(row["ProcessID"]!=null && row["ProcessID"].ToString()!="")
				{
					model.ProcessID=int.Parse(row["ProcessID"].ToString());
				}
				if(row["ProcessDate"]!=null && row["ProcessDate"].ToString()!="")
				{
					model.ProcessDate=DateTime.Parse(row["ProcessDate"].ToString());
				}
				if(row["ProcessCustomerUnit"]!=null)
				{
					model.ProcessCustomerUnit=row["ProcessCustomerUnit"].ToString();
				}
				if(row["Processlinkman"]!=null)
				{
					model.Processlinkman=row["Processlinkman"].ToString();
				}
				if(row["Processtel"]!=null)
				{
					model.Processtel=row["Processtel"].ToString();
				}
				if(row["ProcessProductName"]!=null)
				{
					model.ProcessProductName=row["ProcessProductName"].ToString();
				}
				if(row["ProcessStandard"]!=null)
				{
					model.ProcessStandard=row["ProcessStandard"].ToString();
				}
				if(row["ProcessPurchasingDate"]!=null && row["ProcessPurchasingDate"].ToString()!="")
				{
					model.ProcessPurchasingDate=DateTime.Parse(row["ProcessPurchasingDate"].ToString());
				}
				if(row["ProcessContentInquired"]!=null)
				{
					model.ProcessContentInquired=row["ProcessContentInquired"].ToString();
				}
				if(row["ProcessHandlingSuggestion"]!=null)
				{
					model.ProcessHandlingSuggestion=row["ProcessHandlingSuggestion"].ToString();
				}
				if(row["ProcessServiceUser"]!=null)
				{
					model.ProcessServiceUser=row["ProcessServiceUser"].ToString();
				}
                if (row["DataType"] != null)
				{
                    model.DataType =Convert.ToInt32(row["DataType"]);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ProcessID,ProcessDate,ProcessCustomerUnit,Processlinkman,Processtel,ProcessProductName,ProcessStandard,ProcessPurchasingDate,ProcessContentInquired,ProcessHandlingSuggestion,ProcessServiceUser,DataType ");
			strSql.Append(" FROM PSI_ProcessLogging ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PSI_ProcessLogging ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ProcessID desc");
			}
			strSql.Append(")AS Row, T.*  from PSI_ProcessLogging T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="where">条件  需要带where 关键字</param>
        /// <param name="order">排序条件 需要带 order by关键字</param>
        public DataSet getDataByPage(int pageIndex, int pageSize, string where, string order, string _tableName, string key, bool isPage)
        {
            string strSQL = KPS.DBUtility.PageSql.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);

            DataSet ds = DbHelperOleDb.Query(strSQL);

            return ds;
        }
	}
}

