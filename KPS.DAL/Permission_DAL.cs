using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;//Please add references
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_Permission
	/// </summary>
	public partial class Permission_DAL
	{
        public Permission_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("permissionID", "PSI_Permission"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int permissionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_Permission");
			strSql.Append(" where permissionID=@permissionID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@permissionID", OleDbType.Integer,4)
			};
			parameters[0].Value = permissionID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(KPS.Model.PermissionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_Permission(");
			strSql.Append("userName,moduleInfoID)");
			strSql.Append(" values (");
			strSql.Append("@userName,@moduleInfoID)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,255),
					new OleDbParameter("@moduleInfoID", OleDbType.Integer,4)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.moduleInfoID;

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
        public bool Update(KPS.Model.PermissionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_Permission set ");
			strSql.Append("userName=@userName,");
			strSql.Append("moduleInfoID=@moduleInfoID");
			strSql.Append(" where permissionID=@permissionID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,255),
					new OleDbParameter("@moduleInfoID", OleDbType.Integer,4),
					new OleDbParameter("@permissionID", OleDbType.Integer,4)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.moduleInfoID;
			parameters[2].Value = model.permissionID;

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
		public bool Delete(int permissionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Permission ");
			strSql.Append(" where permissionID=@permissionID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@permissionID", OleDbType.Integer,4)
			};
			parameters[0].Value = permissionID;

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
        /// 删除用户的权限记录
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public bool DeleteItemByUserName(string _userName)
        {
            bool bolSucced = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PSI_Permission ");
            strSql.Append(" where userName=@UserName");
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,255)
			};
            parameters[0].Value = _userName;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                bolSucced= true;
            }
            else
            {
                bolSucced= false;
            }
            return bolSucced;
        }

		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string permissionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_Permission ");
			strSql.Append(" where permissionID in ("+permissionIDlist + ")  ");
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
        public KPS.Model.PermissionInfo GetModel(int permissionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select permissionID,userName,moduleInfoID from PSI_Permission ");
			strSql.Append(" where permissionID=@permissionID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@permissionID", OleDbType.Integer,4)
			};
			parameters[0].Value = permissionID;

            KPS.Model.PermissionInfo model = new KPS.Model.PermissionInfo();
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
        public KPS.Model.PermissionInfo DataRowToModel(DataRow row)
		{
            KPS.Model.PermissionInfo model = new KPS.Model.PermissionInfo();
			if (row != null)
			{
				if(row["permissionID"]!=null && row["permissionID"].ToString()!="")
				{
					model.permissionID=int.Parse(row["permissionID"].ToString());
				}
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["moduleInfoID"]!=null && row["moduleInfoID"].ToString()!="")
				{
					model.moduleInfoID=int.Parse(row["moduleInfoID"].ToString());
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
			strSql.Append("select permissionID,userName,moduleInfoID ");
			strSql.Append(" FROM PSI_Permission ");
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
			strSql.Append("select count(1) FROM PSI_Permission ");
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

