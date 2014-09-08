using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_YanShou
	/// </summary>
	public partial class YanShou_DAL
	{
		public YanShou_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "PSI_YanShou"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_YanShou");
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
		public bool Add(KPS.Model.YanShouInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_YanShou(");
            strSql.Append("y_date,y_pm,y_ggxh,y_dw,y_sl,y_sccj,y_cpdm,y_ghdw,y_cpzczh,y_scph,y_mjph,y_yxq,y_isHGZ,y_zlqk,y_zgy,y_fhrqz,DataType)");
			strSql.Append(" values (");
            strSql.Append("@y_date,@y_pm,@y_ggxh,@y_dw,@y_sl,@y_sccj,@y_cpdm,@y_ghdw,@y_cpzczh,@y_scph,@y_mjph,@y_yxq,@y_isHGZ,@y_zlqk,@y_zgy,@y_fhrqz,@DataType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@y_date", OleDbType.Date),
					new OleDbParameter("@y_pm", OleDbType.VarChar,255),
					new OleDbParameter("@y_ggxh", OleDbType.VarChar,255),
					new OleDbParameter("@y_dw", OleDbType.VarChar,255),
					new OleDbParameter("@y_sl", OleDbType.Integer,4),
					new OleDbParameter("@y_sccj", OleDbType.VarChar,255),
					new OleDbParameter("@y_cpdm", OleDbType.VarChar,255),
					new OleDbParameter("@y_ghdw", OleDbType.VarChar,255),
					new OleDbParameter("@y_cpzczh", OleDbType.VarChar,255),
					new OleDbParameter("@y_scph", OleDbType.VarChar,255),
					new OleDbParameter("@y_mjph", OleDbType.VarChar,255),
					new OleDbParameter("@y_yxq", OleDbType.VarChar,255),
					new OleDbParameter("@y_isHGZ", OleDbType.Boolean,1),
					new OleDbParameter("@y_zlqk", OleDbType.VarChar,255),
					new OleDbParameter("@y_zgy", OleDbType.VarChar,255),
					new OleDbParameter("@y_fhrqz", OleDbType.VarChar,255),
                    new OleDbParameter("@DataType", OleDbType.Integer,4)};
			parameters[0].Value = model.y_date;
			parameters[1].Value = model.y_pm;
			parameters[2].Value = model.y_ggxh;
			parameters[3].Value = model.y_dw;
			parameters[4].Value = model.y_sl;
			parameters[5].Value = model.y_sccj;
			parameters[6].Value = model.y_cpdm;
			parameters[7].Value = model.y_ghdw;
			parameters[8].Value = model.y_cpzczh;
			parameters[9].Value = model.y_scph;
			parameters[10].Value = model.y_mjph;
			parameters[11].Value = model.y_yxq;
			parameters[12].Value = model.y_isHGZ;
			parameters[13].Value = model.y_zlqk;
			parameters[14].Value = model.y_zgy;
			parameters[15].Value = model.y_fhrqz;
            parameters[16].Value = model.DataType;

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
		public bool Update(KPS.Model.YanShouInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_YanShou set ");
			strSql.Append("y_date=@y_date,");
			strSql.Append("y_pm=@y_pm,");
			strSql.Append("y_ggxh=@y_ggxh,");
			strSql.Append("y_dw=@y_dw,");
			strSql.Append("y_sl=@y_sl,");
			strSql.Append("y_sccj=@y_sccj,");
			strSql.Append("y_cpdm=@y_cpdm,");
			strSql.Append("y_ghdw=@y_ghdw,");
			strSql.Append("y_cpzczh=@y_cpzczh,");
			strSql.Append("y_scph=@y_scph,");
			strSql.Append("y_mjph=@y_mjph,");
			strSql.Append("y_yxq=@y_yxq,");
			strSql.Append("y_isHGZ=@y_isHGZ,");
			strSql.Append("y_zlqk=@y_zlqk,");
			strSql.Append("y_zgy=@y_zgy,");
			strSql.Append("y_fhrqz=@y_fhrqz,");
            strSql.Append("DataType=@DataType");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@y_date", OleDbType.Date),
					new OleDbParameter("@y_pm", OleDbType.VarChar,255),
					new OleDbParameter("@y_ggxh", OleDbType.VarChar,255),
					new OleDbParameter("@y_dw", OleDbType.VarChar,255),
					new OleDbParameter("@y_sl", OleDbType.Integer,4),
					new OleDbParameter("@y_sccj", OleDbType.VarChar,255),
					new OleDbParameter("@y_cpdm", OleDbType.VarChar,255),
					new OleDbParameter("@y_ghdw", OleDbType.VarChar,255),
					new OleDbParameter("@y_cpzczh", OleDbType.VarChar,255),
					new OleDbParameter("@y_scph", OleDbType.VarChar,255),
					new OleDbParameter("@y_mjph", OleDbType.VarChar,255),
					new OleDbParameter("@y_yxq", OleDbType.VarChar,255),
					new OleDbParameter("@y_isHGZ", OleDbType.Boolean,1),
					new OleDbParameter("@y_zlqk", OleDbType.VarChar,255),
					new OleDbParameter("@y_zgy", OleDbType.VarChar,255),
					new OleDbParameter("@y_fhrqz", OleDbType.VarChar,255),
                    new OleDbParameter("@DataType", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.y_date;
			parameters[1].Value = model.y_pm;
			parameters[2].Value = model.y_ggxh;
			parameters[3].Value = model.y_dw;
			parameters[4].Value = model.y_sl;
			parameters[5].Value = model.y_sccj;
			parameters[6].Value = model.y_cpdm;
			parameters[7].Value = model.y_ghdw;
			parameters[8].Value = model.y_cpzczh;
			parameters[9].Value = model.y_scph;
			parameters[10].Value = model.y_mjph;
			parameters[11].Value = model.y_yxq;
			parameters[12].Value = model.y_isHGZ;
			parameters[13].Value = model.y_zlqk;
			parameters[14].Value = model.y_zgy;
			parameters[15].Value = model.y_fhrqz;
            parameters[16].Value = model.DataType;
			parameters[17].Value = model.ID;

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
			strSql.Append("delete from PSI_YanShou ");
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
			strSql.Append("delete from PSI_YanShou ");
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
		public KPS.Model.YanShouInfo DataRowToModel(DataRow row)
		{
            KPS.Model.YanShouInfo model = new KPS.Model.YanShouInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["y_date"]!=null && row["y_date"].ToString()!="")
				{
					model.y_date=DateTime.Parse(row["y_date"].ToString());
				}
				if(row["y_pm"]!=null)
				{
					model.y_pm=row["y_pm"].ToString();
				}
				if(row["y_ggxh"]!=null)
				{
					model.y_ggxh=row["y_ggxh"].ToString();
				}
				if(row["y_dw"]!=null)
				{
					model.y_dw=row["y_dw"].ToString();
				}
				if(row["y_sl"]!=null && row["y_sl"].ToString()!="")
				{
					model.y_sl=int.Parse(row["y_sl"].ToString());
				}
				if(row["y_sccj"]!=null)
				{
					model.y_sccj=row["y_sccj"].ToString();
				}
				if(row["y_cpdm"]!=null)
				{
					model.y_cpdm=row["y_cpdm"].ToString();
				}
				if(row["y_ghdw"]!=null)
				{
					model.y_ghdw=row["y_ghdw"].ToString();
				}
				if(row["y_cpzczh"]!=null)
				{
					model.y_cpzczh=row["y_cpzczh"].ToString();
				}
				if(row["y_scph"]!=null)
				{
					model.y_scph=row["y_scph"].ToString();
				}
				if(row["y_mjph"]!=null)
				{
					model.y_mjph=row["y_mjph"].ToString();
				}
				if(row["y_yxq"]!=null)
				{
					model.y_yxq=row["y_yxq"].ToString();
				}
				if(row["y_isHGZ"]!=null && row["y_isHGZ"].ToString()!="")
				{
					if((row["y_isHGZ"].ToString()=="1")||(row["y_isHGZ"].ToString().ToLower()=="true"))
					{
						model.y_isHGZ=true;
					}
					else
					{
						model.y_isHGZ=false;
					}
				}
				if(row["y_zlqk"]!=null)
				{
					model.y_zlqk=row["y_zlqk"].ToString();
				}
				if(row["y_zgy"]!=null)
				{
					model.y_zgy=row["y_zgy"].ToString();
				}
				if(row["y_fhrqz"]!=null)
				{
					model.y_fhrqz=row["y_fhrqz"].ToString();
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
            strSql.Append("select ID,y_date,y_pm,y_ggxh,y_dw,y_sl,y_sccj,y_cpdm,y_ghdw,y_cpzczh,y_scph,y_mjph,y_yxq,y_isHGZ,y_zlqk,y_zgy,y_fhrqz,DataType ");
			strSql.Append(" FROM PSI_YanShou ");
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
			strSql.Append("select count(1) FROM PSI_YanShou ");
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

