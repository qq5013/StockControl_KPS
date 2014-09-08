using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;//Please add references
namespace KPS.DAL
{
	/// <summary>
    /// 数据访问类:Supplier_DAL 
	/// </summary>
	public partial class Supplier_DAL
	{
        public Supplier_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("supplierID", "PSI_Supplier"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int supplierID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_Supplier");
			strSql.Append(" where supplierID=@supplierID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@supplierID", OleDbType.Integer,4)
			};
			parameters[0].Value = supplierID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_Supplier(");
			strSql.Append("supplierName)");
			strSql.Append(" values (");
			strSql.Append("@supplierName)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@supplierName", OleDbType.VarChar,255)};
			parameters[0].Value = model.supplierName;

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
		public bool Update(KPS.Model.Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_Supplier set ");
			strSql.Append("supplierName=@supplierName");
			strSql.Append(" where supplierID=@supplierID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@supplierName", OleDbType.VarChar,255),
					new OleDbParameter("@supplierID", OleDbType.Integer,4)};
			parameters[0].Value = model.supplierName;
			parameters[1].Value = model.supplierID;

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
		public bool Delete(int supplierID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Supplier ");
			strSql.Append(" where supplierID=@supplierID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@supplierID", OleDbType.Integer,4)
			};
			parameters[0].Value = supplierID;

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
		public bool DeleteList(string supplierIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Supplier ");
			strSql.Append(" where supplierID in ("+supplierIDlist + ")  ");
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
		public KPS.Model.Supplier GetModel(int supplierID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select supplierID,supplierName from PSI_Supplier ");
			strSql.Append(" where supplierID=@supplierID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@supplierID", OleDbType.Integer,4)
			};
			parameters[0].Value = supplierID;

			KPS.Model.Supplier model=new KPS.Model.Supplier();
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
		public KPS.Model.Supplier DataRowToModel(DataRow row)
		{
			KPS.Model.Supplier model=new KPS.Model.Supplier();
			if (row != null)
			{
				if(row["supplierID"]!=null && row["supplierID"].ToString()!="")
				{
					model.supplierID=int.Parse(row["supplierID"].ToString());
				}
				if(row["supplierName"]!=null)
				{
					model.supplierName=row["supplierName"].ToString();
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
			strSql.Append("select supplierID,supplierName ");
			strSql.Append(" FROM PSI_Supplier ");
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
			strSql.Append("select count(1) FROM PSI_Supplier ");
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

