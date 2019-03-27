using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类 Ninjas
    /// <summary>
    public partial class Ninjas : DALHelper
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Ninjas model)
        {
            IDbDataParameter[] parms4Ninjas = PrepareAddParameters(model);
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_ADD, parms4Ninjas);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Ninjas model)
        {
            IDbDataParameter[] parms4Ninjas = PrepareUpdateParameters(model);
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_UPDATE, parms4Ninjas);
        }

        /// <summary>
        /// 清空所有数据
        /// </summary>
        public int Truncate()
        {
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_TRUNCATE);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? Id)
        {
            IDbDataParameter[] parms4Ninjas = PrepareDeleteParameters(Id);
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_DELETE, parms4Ninjas);
        }

        /// <summary>
        /// 获取DataTable数据列表
        /// </summary>
        public DataTable GetDataTable(string strWhere = "", string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Ninjas");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            DataTable dt = dbHelper.ExecuteDataTable(CommandType.Text, strSql.ToString(), null);
            return dt;
        }

        /// <summary>
        /// 获取DataSet数据列表
        /// </summary>
        public DataSet GetDataSet(string strWhere = "", string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Ninjas");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            DataSet ds = dbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), null);
            return ds;
        }

        /// <summary>
        /// 获取DataView数据列表
        /// </summary>
        public DataView GetDataView(string strWhere = "", string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Ninjas");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            DataView dv = dbHelper.ExecuteDataView(CommandType.Text, strSql.ToString(), null);
            return dv;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Ninjas GetModel(int? Id)
        {
            IDbDataParameter[] parms4Ninjas = PrepareGetModelParameters(Id);
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, COMMAND_GETMODEL, parms4Ninjas))
            {
                if (dr.Read()) return GetModel(dr);
                return null;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? Id)
        {
            IDbDataParameter[] parms4Ninjas = PrepareExistParameters(Id);
            object obj = dbHelper.ExecuteScalar(CommandType.Text, COMMAND_EXISTS, parms4Ninjas);
            return int.Parse(obj.ToString()) > 0;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        public int GetCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM Ninjas");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = dbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), null);
            return int.Parse(obj.ToString());
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        public int GetMaxId()
        {
            object obj = dbHelper.ExecuteScalar(CommandType.Text, COMMAND_GETMAXID, null);
            return int.Parse(obj.ToString());
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.Ninjas> GetList(string strWhere = "",string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Ninjas");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                List<Model.Ninjas> lst = new List<Model.Ninjas>();
                ExecuteReaderAction(dr, r => lst.Add(GetModel(r)));
                return lst;
            }
        }

        /// <summary>
        /// 根据每页记录数及所要获取的页数
        /// </summary>
        public Model.PageData GetPageList(int pageSize, int curPage, string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Ninjas");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            List<Model.Ninjas> list = new List<Model.Ninjas>();
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                Model.PageData pageData = new Model.PageData();
                pageData.PageSize = pageSize;
                pageData.CurPage = curPage;
                pageData.RecordCount = 0;
                pageData.PageCount = 1;
                int first = (curPage - 1) * pageSize + 1;
                int last = curPage * pageSize;

                while (dr.Read())
                {
                    pageData.RecordCount++;
                    if (pageData.RecordCount >= first && last >= pageData.RecordCount)
                    {
                        Model.Ninjas md = new Model.Ninjas();
                        PrepareModel(md, dr);
                        list.Add(md);
                    }
                }
                dr.Close();
                if (pageData.RecordCount > 0)
                    pageData.PageCount = Convert.ToInt32(Math.Ceiling((double)pageData.RecordCount / (double)pageSize));
                pageData.PageList = list;
                return pageData;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.Ninjas> GetListByPage(string strWhere, string strOrder, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(strOrder.Trim()))
            {
                strSql.Append("order by T." + strOrder);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Ninjas T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                List<Model.Ninjas> lst = new List<Model.Ninjas>();
                ExecuteReaderAction(dr, r => lst.Add(GetModel(r)));
                return lst;
            }
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.Ninjas GetModel(IDataReader dr)
        {
            Model.Ninjas model = new Model.Ninjas();
            PrepareModel(model, dr);
            return model;
        }
    }
}