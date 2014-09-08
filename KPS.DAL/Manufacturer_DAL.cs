using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;//Please add references
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_Manufacturer
	/// </summary>
	public partial class Manufacturer_DAL
	{
        public Manufacturer_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("manufacturerID", "PSI_Manufacturer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int manufacturerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_Manufacturer");
			strSql.Append(" where manufacturerID=@manufacturerID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@manufacturerID", OleDbType.Integer,4)
			};
			parameters[0].Value = manufacturerID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.Manufacturer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_Manufacturer(");
			strSql.Append("manufacturerName,manufacturerTel,manufacturerAdd)");
			strSql.Append(" values (");
			strSql.Append("@manufacturerName,@manufacturerTel,@manufacturerAdd)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@manufacturerName", OleDbType.VarChar,255),
					new OleDbParameter("@manufacturerTel", OleDbType.VarChar,255),
					new OleDbParameter("@manufacturerAdd", OleDbType.VarChar,255)};
			parameters[0].Value = model.manufacturerName;
			parameters[1].Value = model.manufacturerTel;
			parameters[2].Value = model.manufacturerAdd;

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
		public bool Update(KPS.Model.Manufacturer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_Manufacturer set ");
			strSql.Append("manufacturerName=@manufacturerName,");
			strSql.Append("manufacturerTel=@manufacturerTel,");
			strSql.Append("manufacturerAdd=@manufacturerAdd");
			strSql.Append(" where manufacturerID=@manufacturerID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@manufacturerName", OleDbType.VarChar,255),
					new OleDbParameter("@manufacturerTel", OleDbType.VarChar,255),
					new OleDbParameter("@manufacturerAdd", OleDbType.VarChar,255),
					new OleDbParameter("@manufacturerID", OleDbType.Integer,4)};
			parameters[0].Value = model.manufacturerName;
			parameters[1].Value = model.manufacturerTel;
			parameters[2].Value = model.manufacturerAdd;
			parameters[3].Value = model.manufacturerID;

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
		public bool Delete(int manufacturerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Manufacturer ");
			strSql.Append(" where manufacturerID=@manufacturerID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@manufacturerID", OleDbType.Integer,4)
			};
			parameters[0].Value = manufacturerID;

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
		public bool DeleteList(string manufacturerIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Manufacturer ");
			strSql.Append(" where manufacturerID in ("+manufacturerIDlist + ")  ");
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
		public KPS.Model.Manufacturer GetModel(int manufacturerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select manufacturerID,manufacturerName,manufacturerTel,manufacturerAdd from PSI_Manufacturer ");
			strSql.Append(" where manufacturerID=@manufacturerID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@manufacturerID", OleDbType.Integer,4)
			};
			parameters[0].Value = manufacturerID;

			KPS.Model.Manufacturer model=new KPS.Model.Manufacturer();
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
		public KPS.Model.Manufacturer DataRowToModel(DataRow row)
		{
			KPS.Model.Manufacturer model=new KPS.Model.Manufacturer();
			if (row != null)
			{
				if(row["manufacturerID"]!=null && row["manufacturerID"].ToString()!="")
				{
					model.manufacturerID=int.Parse(row["manufacturerID"].ToString());
				}
				if(row["manufacturerName"]!=null)
				{
					model.manufacturerName=row["manufacturerName"].ToString();
				}
				if(row["manufacturerTel"]!=null)
				{
					model.manufacturerTel=row["manufacturerTel"].ToString();
				}
				if(row["manufacturerAdd"]!=null)
				{
					model.manufacturerAdd=row["manufacturerAdd"].ToString();
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
			strSql.Append("select manufacturerID,manufacturerName,manufacturerTel,manufacturerAdd ");
			strSql.Append(" FROM PSI_Manufacturer ");
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
			strSql.Append("select count(1) FROM PSI_Manufacturer ");
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

