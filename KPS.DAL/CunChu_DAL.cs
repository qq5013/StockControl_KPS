using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;

namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_CunChu
	/// </summary>
	public partial class CunChu_DAL
	{
		public CunChu_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "PSI_CunChu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_CunChu");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KPS.Model.CunChuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_CunChu(");
            strSql.Append("s_csmc,s_date,s_sywdfw,s_syxdsdfw,s_sworxw,s_wd,s_sd,s_cqcs,s_wded,s_sded,s_jlr,DataType)");
			strSql.Append(" values (");
            strSql.Append("@s_csmc,@s_date,@s_sywdfw,@s_syxdsdfw,@s_sworxw,@s_wd,@s_sd,@s_cqcs,@s_wded,@s_sded,@s_jlr,@DataType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@s_csmc", OleDbType.VarChar,255),
					new OleDbParameter("@s_date", OleDbType.Date),
					new OleDbParameter("@s_sywdfw", OleDbType.VarChar,255),
					new OleDbParameter("@s_syxdsdfw", OleDbType.VarChar,255),
					new OleDbParameter("@s_sworxw", OleDbType.Integer,4),
					new OleDbParameter("@s_wd", OleDbType.VarChar,255),
					new OleDbParameter("@s_sd", OleDbType.VarChar,255),
					new OleDbParameter("@s_cqcs", OleDbType.VarChar,255),
					new OleDbParameter("@s_wded", OleDbType.VarChar,255),
					new OleDbParameter("@s_sded", OleDbType.VarChar,255),
					new OleDbParameter("@s_jlr", OleDbType.VarChar,255),
                    new OleDbParameter("@DataType", OleDbType.Integer,4)};
			parameters[0].Value = model.s_csmc;
			parameters[1].Value = model.s_date;
			parameters[2].Value = model.s_sywdfw;
			parameters[3].Value = model.s_syxdsdfw;
			parameters[4].Value = model.s_sworxw;
			parameters[5].Value = model.s_wd;
			parameters[6].Value = model.s_sd;
			parameters[7].Value = model.s_cqcs;
			parameters[8].Value = model.s_wded;
			parameters[9].Value = model.s_sded;
            parameters[10].Value = model.s_jlr;
            parameters[11].Value = model.DataType;

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
		public bool Update(KPS.Model.CunChuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_CunChu set ");
			strSql.Append("s_csmc=@s_csmc,");
			strSql.Append("s_date=@s_date,");
			strSql.Append("s_sywdfw=@s_sywdfw,");
			strSql.Append("s_syxdsdfw=@s_syxdsdfw,");
			strSql.Append("s_sworxw=@s_sworxw,");
			strSql.Append("s_wd=@s_wd,");
			strSql.Append("s_sd=@s_sd,");
			strSql.Append("s_cqcs=@s_cqcs,");
			strSql.Append("s_wded=@s_wded,");
			strSql.Append("s_sded=@s_sded,");
			strSql.Append("s_jlr=@s_jlr,");
            strSql.Append("DataType=@DataType");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@s_csmc", OleDbType.VarChar,255),
					new OleDbParameter("@s_date", OleDbType.Date),
					new OleDbParameter("@s_sywdfw", OleDbType.VarChar,255),
					new OleDbParameter("@s_syxdsdfw", OleDbType.VarChar,255),
					new OleDbParameter("@s_sworxw", OleDbType.Integer,4),
					new OleDbParameter("@s_wd", OleDbType.VarChar,255),
					new OleDbParameter("@s_sd", OleDbType.VarChar,255),
					new OleDbParameter("@s_cqcs", OleDbType.VarChar,255),
					new OleDbParameter("@s_wded", OleDbType.VarChar,255),
					new OleDbParameter("@s_sded", OleDbType.VarChar,255),
					new OleDbParameter("@s_jlr", OleDbType.VarChar,255),
					new OleDbParameter("@DataType", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.s_csmc;
			parameters[1].Value = model.s_date;
			parameters[2].Value = model.s_sywdfw;
			parameters[3].Value = model.s_syxdsdfw;
			parameters[4].Value = model.s_sworxw;
			parameters[5].Value = model.s_wd;
			parameters[6].Value = model.s_sd;
			parameters[7].Value = model.s_cqcs;
			parameters[8].Value = model.s_wded;
			parameters[9].Value = model.s_sded;
			parameters[10].Value = model.s_jlr;
            parameters[11].Value = model.DataType;
			parameters[12].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_CunChu ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_CunChu ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public KPS.Model.CunChuInfo DataRowToModel(DataRow row)
		{
            KPS.Model.CunChuInfo model = new KPS.Model.CunChuInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["s_csmc"]!=null)
				{
					model.s_csmc=row["s_csmc"].ToString();
				}
				if(row["s_date"]!=null && row["s_date"].ToString()!="")
				{
					model.s_date=DateTime.Parse(row["s_date"].ToString());
				}
				if(row["s_sywdfw"]!=null)
				{
					model.s_sywdfw=row["s_sywdfw"].ToString();
				}
				if(row["s_syxdsdfw"]!=null)
				{
					model.s_syxdsdfw=row["s_syxdsdfw"].ToString();
				}
				if(row["s_sworxw"]!=null && row["s_sworxw"].ToString()!="")
				{
					model.s_sworxw=int.Parse(row["s_sworxw"].ToString());
				}
				if(row["s_wd"]!=null)
				{
					model.s_wd=row["s_wd"].ToString();
				}
				if(row["s_sd"]!=null)
				{
					model.s_sd=row["s_sd"].ToString();
				}
				if(row["s_cqcs"]!=null)
				{
					model.s_cqcs=row["s_cqcs"].ToString();
				}
				if(row["s_wded"]!=null)
				{
					model.s_wded=row["s_wded"].ToString();
				}
				if(row["s_sded"]!=null)
				{
					model.s_sded=row["s_sded"].ToString();
				}
				if(row["s_jlr"]!=null)
				{
					model.s_jlr=row["s_jlr"].ToString();
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
            strSql.Append("select ID,s_csmc,s_date,s_sywdfw,s_syxdsdfw,s_sworxw,s_wd,s_sd,s_cqcs,s_wded,s_sded,s_jlr,DataType ");
			strSql.Append(" FROM PSI_CunChu ");
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
			strSql.Append("select count(1) FROM PSI_CunChu ");
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
        /// <param name="where">条件</param>
        /// <param name="order">排序条件</param>
        public DataSet getDataByPage(int pageIndex, int pageSize, string where, string order, string _tableName, string key, bool isPage)
        {
            string strSQL = KPS.DBUtility.PageSql.getDataByPage(pageIndex, pageSize, where, order, _tableName, key, isPage);

            DataSet ds = DbHelperOleDb.Query(strSQL);

            return ds;
        }
	}
}

