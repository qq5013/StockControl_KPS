using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using KPS.DBUtility;
using KPS.Model;
namespace KPS.DAL
{
	/// <summary>
	/// 数据访问类:PSI_Inventory
	/// </summary>
	public partial class Inventory_DAL
	{
        public Inventory_DAL()
		{}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperOleDb.GetMaxID("ID", "PSI_Inventory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PSI_Inventory");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
        /// 增加一条数据(内部根据 产品名称+厂家+注册证号+批号 判断是否已存在，若存在则只更新数量)
		/// </summary>
		public bool Add(KPS.Model.GouJinInfo model)
		{
            bool _bolSucced = false;
            bool _RecordIsExt = false;
            int _ToltalRecordCount = 0;
            int _RecordID = -1;
            #region 判断产品记录是否已存在
            StringBuilder strQuerySQL = new StringBuilder();
            strQuerySQL.Append("select ID,p_date,p_cpmc,p_ggxh,p_clmc,p_ph,p_dw,p_sl1,p_mjph,p_zzs,p_zczh,p_gys,p_sl2,p_jsr,DataType,RemarkInfo ");
            strQuerySQL.Append(" FROM PSI_Inventory where p_cpmc=@p_cpmc and p_zczh=@p_zczh and p_zzs=@p_zzs and p_ph=@p_ph");
            OleDbParameter[] parameters = {
					new OleDbParameter("@p_cpmc", OleDbType.VarChar,255),
					new OleDbParameter("@p_zczh", OleDbType.VarChar,255),
					new OleDbParameter("@p_zzs", OleDbType.VarChar,255),
					new OleDbParameter("@p_ph", OleDbType.VarChar,255)};
            parameters[0].Value = model.p_cpmc;
            parameters[1].Value = model.p_zczh;
            parameters[2].Value = model.p_zzs;
            parameters[3].Value = model.p_ph;

           DataSet _ds= DbHelperOleDb.Query(strQuerySQL.ToString(),parameters);
           if (_ds != null && _ds.Tables[0].Rows.Count > 0)
           {
               try
               {
                   _ToltalRecordCount = Convert.ToInt32(_ds.Tables[0].Rows[0]["p_sl1"]);
                   _RecordID = Convert.ToInt32(_ds.Tables[0].Rows[0]["ID"]);
                   _RecordIsExt = true;
               }
               catch (Exception ex)
               { 
               }
           }
            #endregion

           if (!_RecordIsExt)
           {
               #region 新增记录
               StringBuilder strSql = new StringBuilder();
               strSql.Append("insert into PSI_Inventory(");
               strSql.Append("p_date,p_cpmc,p_ggxh,p_clmc,p_ph,p_dw,p_sl1,p_mjph,p_zzs,p_zczh,p_gys,p_sl2,p_jsr,DataType,RemarkInfo)");
               strSql.Append(" values (");
               strSql.Append("@p_date,@p_cpmc,@p_ggxh,@p_clmc,@p_ph,@p_dw,@p_sl1,@p_mjph,@p_zzs,@p_zczh,@p_gys,@p_sl2,@p_jsr,@DataType,@RemarkInfo)");
               OleDbParameter[] parameterstwo = {
					new OleDbParameter("@p_date", OleDbType.Date),
					new OleDbParameter("@p_cpmc", OleDbType.VarChar,255),
					new OleDbParameter("@p_ggxh", OleDbType.VarChar,255),
					new OleDbParameter("@p_clmc", OleDbType.VarChar,255),
					new OleDbParameter("@p_ph", OleDbType.VarChar,255),
					new OleDbParameter("@p_dw", OleDbType.VarChar,255),
					new OleDbParameter("@p_sl1", OleDbType.Integer,4),
					new OleDbParameter("@p_mjph", OleDbType.VarChar,255),
					new OleDbParameter("@p_zzs", OleDbType.VarChar,255),
					new OleDbParameter("@p_zczh", OleDbType.VarChar,255),
					new OleDbParameter("@p_gys", OleDbType.VarChar,255),
					new OleDbParameter("@p_sl2", OleDbType.VarChar,255),
					new OleDbParameter("@p_jsr", OleDbType.VarChar,255),
                    new OleDbParameter("@DataType", OleDbType.Integer,4),
                    new OleDbParameter("@RemarkInfo", OleDbType.VarChar,255)};
               parameterstwo[0].Value = model.p_date;
               parameterstwo[1].Value = model.p_cpmc;
               parameterstwo[2].Value = model.p_ggxh;
               parameterstwo[3].Value = model.p_clmc;
               parameterstwo[4].Value = model.p_ph;
               parameterstwo[5].Value = model.p_dw;
               parameterstwo[6].Value = model.p_sl1;
               parameterstwo[7].Value = model.p_mjph;
               parameterstwo[8].Value = model.p_zzs;
               parameterstwo[9].Value = model.p_zczh;
               parameterstwo[10].Value = model.p_gys;
               parameterstwo[11].Value = model.p_sl2;
               parameterstwo[12].Value = model.p_jsr;
               parameterstwo[13].Value = model.DataType;
               parameterstwo[14].Value = model.RemarkInfo;

               int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameterstwo);
               if (rows > 0)
               {
                   _bolSucced = true;
               }
               else
               {
                   _bolSucced = false;
               }
               #endregion
           }
           else
           {
               int SurplusNumber = _ToltalRecordCount + model.p_sl1.Value;//统计总数量
               #region 更新产品库存数量
               StringBuilder strSql = new StringBuilder();
               strSql.Append("update PSI_Inventory set ");
               strSql.Append("p_sl1=@p_sl1,");
               strSql.Append("p_date=@p_date");
               strSql.Append(" where ID=@ID");
               OleDbParameter[] upparameters = {
					new OleDbParameter("@p_sl1", OleDbType.Integer,4),
					new OleDbParameter("@p_date", OleDbType.Date),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
               upparameters[0].Value = SurplusNumber;
               upparameters[1].Value =DateTime.Now;
               upparameters[2].Value = _RecordID;

               int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), upparameters);
               if (rows > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
               #endregion
           }
            return _bolSucced;
        }

        /// <summary>
        /// 销售(当添加产品的销售记录时，则通过此方法更新已有产品的销售记录)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InventoryUpState Sell(KPS.Model.XiaoShouInfo model)
        {
            InventoryUpState _state = InventoryUpState.SysTemError;
            bool _RecordIsExt = false;
            int _ToltalRecordCount = 0;
            int _RecordID = -1;

            int _GouJinRecordID = -1;
            #region 更新销售记录的GJID(购进记录编号)
            string StrSQLA = "select ID FROM PSI_GouJin where p_cpmc=@p_cpmc and p_zczh=@p_zczh and p_zzs=@p_zzs and p_ph=@p_ph";
            OleDbParameter[] parametersA = {
					new OleDbParameter("@p_cpmc", OleDbType.VarChar,255),
					new OleDbParameter("@p_zczh", OleDbType.VarChar,255),
					new OleDbParameter("@p_zzs", OleDbType.VarChar,255),
					new OleDbParameter("@p_ph", OleDbType.VarChar,255)};
            parametersA[0].Value = model.p_cpmc;
            parametersA[1].Value = model.p_zczh;
            parametersA[2].Value = model.p_zzs;
            parametersA[3].Value = model.p_ph;
            DataSet _ds = DbHelperOleDb.Query(StrSQLA.ToString(), parametersA);
              if (_ds != null && _ds.Tables[0].Rows.Count > 0)
              {
                  try
                  {
                      _GouJinRecordID = Convert.ToInt32(_ds.Tables[0].Rows[0]["ID"]);
                      model.GJID = _GouJinRecordID;
                  }
                  catch (Exception ex)
                  {}
              }

            #endregion
            if (_GouJinRecordID > -1)
            {
                #region 判断产品记录是否已存在
                StringBuilder strQuerySQL = new StringBuilder();
                strQuerySQL.Append("select ID,p_date,p_cpmc,p_ggxh,p_clmc,p_ph,p_dw,p_sl1,p_mjph,p_zzs,p_zczh,p_gys,p_sl2,p_jsr,DataType,RemarkInfo ");
                strQuerySQL.Append(" FROM PSI_Inventory where p_cpmc=@p_cpmc and p_zczh=@p_zczh and p_zzs=@p_zzs and p_ph=@p_ph");
                OleDbParameter[] parameters = {
				new OleDbParameter("@p_cpmc", OleDbType.VarChar,255),
				new OleDbParameter("@p_zczh", OleDbType.VarChar,255),
				new OleDbParameter("@p_zzs", OleDbType.VarChar,255),
				new OleDbParameter("@p_ph", OleDbType.VarChar,255)};
                parameters[0].Value = model.p_cpmc;
                parameters[1].Value = model.p_zczh;
                parameters[2].Value = model.p_zzs;
                parameters[3].Value = model.p_ph;

                _ds = DbHelperOleDb.Query(strQuerySQL.ToString(), parameters);
                if (_ds != null && _ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        _ToltalRecordCount = Convert.ToInt32(_ds.Tables[0].Rows[0]["p_sl1"]);
                        _RecordID = Convert.ToInt32(_ds.Tables[0].Rows[0]["ID"]);
                        _RecordIsExt = true;
                    }
                    catch (Exception ex)
                    {
                        _state = InventoryUpState.SysTemError;
                    }
                }
                else
                {
                    _RecordIsExt = false;
                }
                #endregion
            }
            if (_RecordIsExt)
            {
                #region 存在产品的购进记录时
                if (model.p_sl1.Value > _ToltalRecordCount)
                {
                    _state = InventoryUpState.ProductLacking;
                }
                else
                {
                    int SurplusNumber = _ToltalRecordCount-model.p_sl1.Value;//统计总数量
                    #region 更新产品库存数量
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update PSI_Inventory set ");
                    strSql.Append("p_sl1=@p_sl1,");
                    strSql.Append("p_date=@p_date");
                    strSql.Append(" where ID=@ID");
                    OleDbParameter[] upparameters = {
					new OleDbParameter("@p_sl1", OleDbType.Integer,4),
					new OleDbParameter("@p_date", OleDbType.Date),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
                    upparameters[0].Value = SurplusNumber;
                    upparameters[1].Value = DateTime.Now;
                    upparameters[2].Value = _RecordID;

                    int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), upparameters);
                    if (rows > 0)
                    {
                        _state = InventoryUpState.Succed;
                    }
                    else
                    {
                        _state = InventoryUpState.ProductNoExt;
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                _state = InventoryUpState.ProductNoExt;
            }

            return _state;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KPS.Model.GouJinInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PSI_Inventory set ");
			strSql.Append("p_date=@p_date,");
			strSql.Append("p_cpmc=@p_cpmc,");
			strSql.Append("p_ggxh=@p_ggxh,");
			strSql.Append("p_clmc=@p_clmc,");
			strSql.Append("p_ph=@p_ph,");
			strSql.Append("p_dw=@p_dw,");
			strSql.Append("p_sl1=@p_sl1,");
			strSql.Append("p_mjph=@p_mjph,");
			strSql.Append("p_zzs=@p_zzs,");
			strSql.Append("p_zczh=@p_zczh,");
			strSql.Append("p_gys=@p_gys,");
			strSql.Append("p_sl2=@p_sl2,");
			strSql.Append("p_jsr=@p_jsr,");
            strSql.Append("DataType=@DataType,");
            strSql.Append("RemarkInfo=@RemarkInfo");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@p_date", OleDbType.Date),
					new OleDbParameter("@p_cpmc", OleDbType.VarChar,255),
					new OleDbParameter("@p_ggxh", OleDbType.VarChar,255),
					new OleDbParameter("@p_clmc", OleDbType.VarChar,255),
					new OleDbParameter("@p_ph", OleDbType.VarChar,255),
					new OleDbParameter("@p_dw", OleDbType.VarChar,255),
					new OleDbParameter("@p_sl1", OleDbType.Integer,4),
					new OleDbParameter("@p_mjph", OleDbType.VarChar,255),
					new OleDbParameter("@p_zzs", OleDbType.VarChar,255),
					new OleDbParameter("@p_zczh", OleDbType.VarChar,255),
					new OleDbParameter("@p_gys", OleDbType.VarChar,255),
					new OleDbParameter("@p_sl2", OleDbType.VarChar,255),
					new OleDbParameter("@p_jsr", OleDbType.VarChar,255),
					new OleDbParameter("@DataType", OleDbType.Integer,4),
                    new OleDbParameter("@RemarkInfo", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.p_date;
			parameters[1].Value = model.p_cpmc;
			parameters[2].Value = model.p_ggxh;
			parameters[3].Value = model.p_clmc;
			parameters[4].Value = model.p_ph;
			parameters[5].Value = model.p_dw;
			parameters[6].Value = model.p_sl1;
			parameters[7].Value = model.p_mjph;
			parameters[8].Value = model.p_zzs;
			parameters[9].Value = model.p_zczh;
			parameters[10].Value = model.p_gys;
			parameters[11].Value = model.p_sl2;
			parameters[12].Value = model.p_jsr;
            parameters[13].Value = model.DataType;
			parameters[14].Value = model.RemarkInfo;
            parameters[15].Value = model.ID;

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
			strSql.Append("delete from PSI_Inventory ");
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
			strSql.Append("delete from PSI_Inventory ");
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
		public KPS.Model.GouJinInfo DataRowToModel(DataRow row)
		{
            KPS.Model.GouJinInfo model = new KPS.Model.GouJinInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["p_date"]!=null && row["p_date"].ToString()!="")
				{
					model.p_date=DateTime.Parse(row["p_date"].ToString());
				}
				if(row["p_cpmc"]!=null)
				{
					model.p_cpmc=row["p_cpmc"].ToString();
				}
				if(row["p_ggxh"]!=null)
				{
					model.p_ggxh=row["p_ggxh"].ToString();
				}
				if(row["p_clmc"]!=null)
				{
					model.p_clmc=row["p_clmc"].ToString();
				}
				if(row["p_ph"]!=null)
				{
					model.p_ph=row["p_ph"].ToString();
				}
				if(row["p_dw"]!=null)
				{
					model.p_dw=row["p_dw"].ToString();
				}
				if(row["p_sl1"]!=null && row["p_sl1"].ToString()!="")
				{
					model.p_sl1=int.Parse(row["p_sl1"].ToString());
				}
				if(row["p_mjph"]!=null)
				{
					model.p_mjph=row["p_mjph"].ToString();
				}
				if(row["p_zzs"]!=null)
				{
					model.p_zzs=row["p_zzs"].ToString();
				}
				if(row["p_zczh"]!=null)
				{
					model.p_zczh=row["p_zczh"].ToString();
				}
				if(row["p_gys"]!=null)
				{
					model.p_gys=row["p_gys"].ToString();
				}
				if(row["p_sl2"]!=null)
				{
					model.p_sl2=row["p_sl2"].ToString();
				}
				if(row["p_jsr"]!=null)
				{
					model.p_jsr=row["p_jsr"].ToString();
				}
                if(row["DataType"]!=null)
				{
					model.DataType=Convert.ToInt32(row["DataType"]);
				}
                if (row["RemarkInfo"] != null)
				{
					model.RemarkInfo=row["RemarkInfo"].ToString();
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
            strSql.Append("select ID,p_date,p_cpmc,p_ggxh,p_clmc,p_ph,p_dw,p_sl1,p_mjph,p_zzs,p_zczh,p_gys,p_sl2,p_jsr,DataType,RemarkInfo ");
			strSql.Append(" FROM PSI_Inventory ");
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
			strSql.Append("select count(1) FROM PSI_Inventory ");
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

