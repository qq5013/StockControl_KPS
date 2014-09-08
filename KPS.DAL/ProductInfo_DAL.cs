using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;//Please add references
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_ProductInfo
	/// </summary>
	public partial class ProductInfo_DAL
	{
        public ProductInfo_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("productid", "PSI_ProductInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string productname)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_ProductInfo");
            strSql.Append(" where productname=@productname");
			OleDbParameter[] parameters = {
					new OleDbParameter("@productname", OleDbType.VarChar,255)
			};
            parameters[0].Value = productname;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(KPS.Model.ProductInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PSI_ProductInfo(");
            strSql.Append("productname,promoney)");
			strSql.Append(" values (");
            strSql.Append("@productname,@promoney)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@productname", OleDbType.VarChar,255),
                    new OleDbParameter("@promoney", OleDbType.Double,2)};
            parameters[0].Value = model.productname;
            parameters[1].Value = model.promoney;

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
        public bool Update(KPS.Model.ProductInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_ProductInfo set ");
            strSql.Append("productname=@productname ,");
            strSql.Append("promoney=@promoney ");
			strSql.Append(" where productid=@productid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@productname", OleDbType.VarChar,255),
                    new OleDbParameter("@promoney", OleDbType.Double,2)};
			parameters[0].Value = model.productname;
            parameters[1].Value = model.promoney;

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
		public bool Delete(int productid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_ProductInfo ");
			strSql.Append(" where productid=@productid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@productid", OleDbType.Integer,4)
			};
			parameters[0].Value = productid;

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
		public bool DeleteList(string productidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PSI_ProductInfo ");
			strSql.Append(" where productid in ("+productidlist + ")  ");
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
        public KPS.Model.ProductInfo GetModel(int productid)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select productid,productname,promoney ");
			strSql.Append(" where productid=@productid");
			OleDbParameter[] parameters = {
					new OleDbParameter("@productid", OleDbType.Integer,4)
			};
			parameters[0].Value = productid;

            KPS.Model.ProductInfo model = new KPS.Model.ProductInfo();
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
        public KPS.Model.ProductInfo DataRowToModel(DataRow row)
		{
            KPS.Model.ProductInfo model = new KPS.Model.ProductInfo();
			if (row != null)
			{
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["productname"]!=null)
				{
					model.productname=row["productname"].ToString();
				}
                if (row["promoney"] != null)
                {
                    model.promoney =Convert.ToDouble(row["promoney"]);
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
            strSql.Append("select productid,productname,promoney ");
			strSql.Append(" FROM PSI_ProductInfo ");
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
			strSql.Append("select count(1) FROM PSI_ProductInfo ");
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

