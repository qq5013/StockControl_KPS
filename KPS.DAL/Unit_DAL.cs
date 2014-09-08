using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;//Please add references
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:Unit
	/// </summary>
	public partial class Unit_DAL
	{
        public Unit_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("unitid", "PSI_Unit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int unitid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_Unit");
			strSql.Append(" where unitid=@unitid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@unitid", OleDbType.Integer,4)
			};
			parameters[0].Value = unitid;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.Unit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_Unit(");
			strSql.Append("unitname)");
			strSql.Append(" values (");
			strSql.Append("@unitname)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@unitname", OleDbType.VarChar,255)};
			parameters[0].Value = model.unitname;

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
        public bool Update(KPS.Model.Unit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_Unit set ");
			strSql.Append("unitname=@unitname");
			strSql.Append(" where unitid=@unitid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@unitname", OleDbType.VarChar,255),
					new OleDbParameter("@unitid", OleDbType.Integer,4)};
			parameters[0].Value = model.unitname;
			parameters[1].Value = model.unitid;

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
		public bool Delete(int unitid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Unit ");
			strSql.Append(" where unitid=@unitid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@unitid", OleDbType.Integer,4)
			};
			parameters[0].Value = unitid;

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
		public bool DeleteList(string unitidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Unit ");
			strSql.Append(" where unitid in ("+unitidlist + ")  ");
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
        public KPS.Model.Unit GetModel(int unitid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select unitid,unitname from PSI_Unit ");
			strSql.Append(" where unitid=@unitid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@unitid", OleDbType.Integer,4)
			};
			parameters[0].Value = unitid;

            KPS.Model.Unit model = new KPS.Model.Unit();
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
        public KPS.Model.Unit DataRowToModel(DataRow row)
		{
            KPS.Model.Unit model = new KPS.Model.Unit();
			if (row != null)
			{
				if(row["unitid"]!=null && row["unitid"].ToString()!="")
				{
					model.unitid=int.Parse(row["unitid"].ToString());
				}
				if(row["unitname"]!=null)
				{
					model.unitname=row["unitname"].ToString();
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
			strSql.Append("select unitid,unitname ");
			strSql.Append(" FROM PSI_Unit ");
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
			strSql.Append("select count(1) FROM PSI_Unit ");
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

