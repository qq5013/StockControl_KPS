using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_BuLiangShiJian
	/// </summary>
	public partial class BuLiangShiJian_DAL
	{
		public BuLiangShiJian_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "PSI_BuLiangShiJian"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_BuLiangShiJian");
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
		public bool Add(KPS.Model.BuLiangShiJianInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_BuLiangShiJian(");
            strSql.Append("b_ylqxmc,b_ggxh,b_sccj,b_cpdm,b_sl,b_sydw,b_scrq,b_zlsgqk,b_bgr,b_bgsj,b_sydwyj,b_fzr,b_resj,b_qyzgfzryj,b_fzrqz,b_fzrqzsj,b_zgclqk,b_zgjbr,b_zgjbsj,DataType)");
			strSql.Append(" values (");
            strSql.Append("@b_ylqxmc,@b_ggxh,@b_sccj,@b_cpdm,@b_sl,@b_sydw,@b_scrq,@b_zlsgqk,@b_bgr,@b_bgsj,@b_sydwyj,@b_fzr,@b_resj,@b_qyzgfzryj,@b_fzrqz,@b_fzrqzsj,@b_zgclqk,@b_zgjbr,@b_zgjbsj,@DataType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@b_ylqxmc", OleDbType.VarChar,255),
					new OleDbParameter("@b_ggxh", OleDbType.VarChar,255),
					new OleDbParameter("@b_sccj", OleDbType.VarChar,255),
					new OleDbParameter("@b_cpdm", OleDbType.VarChar,255),
					new OleDbParameter("@b_sl", OleDbType.Integer,4),
					new OleDbParameter("@b_sydw", OleDbType.VarChar,255),
					new OleDbParameter("@b_scrq", OleDbType.VarChar,255),
					new OleDbParameter("@b_zlsgqk", OleDbType.VarChar,255),
					new OleDbParameter("@b_bgr", OleDbType.VarChar,255),
					new OleDbParameter("@b_bgsj", OleDbType.Date),
					new OleDbParameter("@b_sydwyj", OleDbType.VarChar,255),
					new OleDbParameter("@b_fzr", OleDbType.VarChar,255),
					new OleDbParameter("@b_resj", OleDbType.Date),
					new OleDbParameter("@b_qyzgfzryj", OleDbType.VarChar,255),
					new OleDbParameter("@b_fzrqz", OleDbType.VarChar,255),
					new OleDbParameter("@b_fzrqzsj", OleDbType.Date),
					new OleDbParameter("@b_zgclqk", OleDbType.VarChar,255),
					new OleDbParameter("@b_zgjbr", OleDbType.VarChar,255),
					new OleDbParameter("@b_zgjbsj", OleDbType.Date),
                    new OleDbParameter("@DataType", OleDbType.Integer,4),};
			parameters[0].Value = model.b_ylqxmc;
			parameters[1].Value = model.b_ggxh;
			parameters[2].Value = model.b_sccj;
			parameters[3].Value = model.b_cpdm;
			parameters[4].Value = model.b_sl;
			parameters[5].Value = model.b_sydw;
			parameters[6].Value = model.b_scrq;
			parameters[7].Value = model.b_zlsgqk;
			parameters[8].Value = model.b_bgr;
			parameters[9].Value = model.b_bgsj;
			parameters[10].Value = model.b_sydwyj;
			parameters[11].Value = model.b_fzr;
			parameters[12].Value = model.b_resj;
			parameters[13].Value = model.b_qyzgfzryj;
			parameters[14].Value = model.b_fzrqz;
			parameters[15].Value = model.b_fzrqzsj;
			parameters[16].Value = model.b_zgclqk;
			parameters[17].Value = model.b_zgjbr;
            parameters[18].Value = model.b_zgjbsj;
            parameters[19].Value = model.DataType;

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
		public bool Update(KPS.Model.BuLiangShiJianInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_BuLiangShiJian set ");
			strSql.Append("b_ylqxmc=@b_ylqxmc,");
			strSql.Append("b_ggxh=@b_ggxh,");
			strSql.Append("b_sccj=@b_sccj,");
			strSql.Append("b_cpdm=@b_cpdm,");
			strSql.Append("b_sl=@b_sl,");
			strSql.Append("b_sydw=@b_sydw,");
			strSql.Append("b_scrq=@b_scrq,");
			strSql.Append("b_zlsgqk=@b_zlsgqk,");
			strSql.Append("b_bgr=@b_bgr,");
			strSql.Append("b_bgsj=@b_bgsj,");
			strSql.Append("b_sydwyj=@b_sydwyj,");
			strSql.Append("b_fzr=@b_fzr,");
			strSql.Append("b_resj=@b_resj,");
			strSql.Append("b_qyzgfzryj=@b_qyzgfzryj,");
			strSql.Append("b_fzrqz=@b_fzrqz,");
			strSql.Append("b_fzrqzsj=@b_fzrqzsj,");
			strSql.Append("b_zgclqk=@b_zgclqk,");
			strSql.Append("b_zgjbr=@b_zgjbr,");
            strSql.Append("b_zgjbsj=@b_zgjbsj,");
            strSql.Append("DataType=@DataType");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@b_ylqxmc", OleDbType.VarChar,255),
					new OleDbParameter("@b_ggxh", OleDbType.VarChar,255),
					new OleDbParameter("@b_sccj", OleDbType.VarChar,255),
					new OleDbParameter("@b_cpdm", OleDbType.VarChar,255),
					new OleDbParameter("@b_sl", OleDbType.Integer,4),
					new OleDbParameter("@b_sydw", OleDbType.VarChar,255),
					new OleDbParameter("@b_scrq", OleDbType.VarChar,255),
					new OleDbParameter("@b_zlsgqk", OleDbType.VarChar,255),
					new OleDbParameter("@b_bgr", OleDbType.VarChar,255),
					new OleDbParameter("@b_bgsj", OleDbType.Date),
					new OleDbParameter("@b_sydwyj", OleDbType.VarChar,255),
					new OleDbParameter("@b_fzr", OleDbType.VarChar,255),
					new OleDbParameter("@b_resj", OleDbType.Date),
					new OleDbParameter("@b_qyzgfzryj", OleDbType.VarChar,255),
					new OleDbParameter("@b_fzrqz", OleDbType.VarChar,255),
					new OleDbParameter("@b_fzrqzsj", OleDbType.Date),
					new OleDbParameter("@b_zgclqk", OleDbType.VarChar,255),
					new OleDbParameter("@b_zgjbr", OleDbType.VarChar,255),
					new OleDbParameter("@b_zgjbsj", OleDbType.Date),
					new OleDbParameter("@DataType", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.b_ylqxmc;
			parameters[1].Value = model.b_ggxh;
			parameters[2].Value = model.b_sccj;
			parameters[3].Value = model.b_cpdm;
			parameters[4].Value = model.b_sl;
			parameters[5].Value = model.b_sydw;
			parameters[6].Value = model.b_scrq;
			parameters[7].Value = model.b_zlsgqk;
			parameters[8].Value = model.b_bgr;
			parameters[9].Value = model.b_bgsj;
			parameters[10].Value = model.b_sydwyj;
			parameters[11].Value = model.b_fzr;
			parameters[12].Value = model.b_resj;
			parameters[13].Value = model.b_qyzgfzryj;
			parameters[14].Value = model.b_fzrqz;
			parameters[15].Value = model.b_fzrqzsj;
			parameters[16].Value = model.b_zgclqk;
			parameters[17].Value = model.b_zgjbr;
            parameters[18].Value = model.b_zgjbsj;
            parameters[19].Value = model.DataType;
			parameters[20].Value = model.ID;

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
			strSql.Append("delete from PSI_BuLiangShiJian ");
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
			strSql.Append("delete from PSI_BuLiangShiJian ");
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
		public KPS.Model.BuLiangShiJianInfo DataRowToModel(DataRow row)
		{
            KPS.Model.BuLiangShiJianInfo model = new KPS.Model.BuLiangShiJianInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["b_ylqxmc"]!=null)
				{
					model.b_ylqxmc=row["b_ylqxmc"].ToString();
				}
				if(row["b_ggxh"]!=null)
				{
					model.b_ggxh=row["b_ggxh"].ToString();
				}
				if(row["b_sccj"]!=null)
				{
					model.b_sccj=row["b_sccj"].ToString();
				}
				if(row["b_cpdm"]!=null)
				{
					model.b_cpdm=row["b_cpdm"].ToString();
				}
				if(row["b_sl"]!=null && row["b_sl"].ToString()!="")
				{
					model.b_sl=int.Parse(row["b_sl"].ToString());
				}
				if(row["b_sydw"]!=null)
				{
					model.b_sydw=row["b_sydw"].ToString();
				}
				if(row["b_scrq"]!=null)
				{
					model.b_scrq=row["b_scrq"].ToString();
				}
				if(row["b_zlsgqk"]!=null)
				{
					model.b_zlsgqk=row["b_zlsgqk"].ToString();
				}
				if(row["b_bgr"]!=null)
				{
					model.b_bgr=row["b_bgr"].ToString();
				}
				if(row["b_bgsj"]!=null && row["b_bgsj"].ToString()!="")
				{
					model.b_bgsj=DateTime.Parse(row["b_bgsj"].ToString());
				}
				if(row["b_sydwyj"]!=null)
				{
					model.b_sydwyj=row["b_sydwyj"].ToString();
				}
				if(row["b_fzr"]!=null)
				{
					model.b_fzr=row["b_fzr"].ToString();
				}
				if(row["b_resj"]!=null && row["b_resj"].ToString()!="")
				{
					model.b_resj=DateTime.Parse(row["b_resj"].ToString());
				}
				if(row["b_qyzgfzryj"]!=null)
				{
					model.b_qyzgfzryj=row["b_qyzgfzryj"].ToString();
				}
				if(row["b_fzrqz"]!=null)
				{
					model.b_fzrqz=row["b_fzrqz"].ToString();
				}
				if(row["b_fzrqzsj"]!=null && row["b_fzrqzsj"].ToString()!="")
				{
					model.b_fzrqzsj=DateTime.Parse(row["b_fzrqzsj"].ToString());
				}
				if(row["b_zgclqk"]!=null)
				{
					model.b_zgclqk=row["b_zgclqk"].ToString();
				}
				if(row["b_zgjbr"]!=null)
				{
					model.b_zgjbr=row["b_zgjbr"].ToString();
				}
				if(row["b_zgjbsj"]!=null && row["b_zgjbsj"].ToString()!="")
				{
					model.b_zgjbsj=DateTime.Parse(row["b_zgjbsj"].ToString());
				}
                if (row["DataType"] != null && row["DataType"].ToString() != "")
				{
                    model.DataType = Convert.ToInt32(row["DataType"]);
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
            strSql.Append("select ID,b_ylqxmc,b_ggxh,b_sccj,b_cpdm,b_sl,b_sydw,b_scrq,b_zlsgqk,b_bgr,b_bgsj,b_sydwyj,b_fzr,b_resj,b_qyzgfzryj,b_fzrqz,b_fzrqzsj,b_zgclqk,b_zgjbr,b_zgjbsj,DataType ");
			strSql.Append(" FROM PSI_BuLiangShiJian ");
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
			strSql.Append("select count(1) FROM PSI_BuLiangShiJian ");
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

