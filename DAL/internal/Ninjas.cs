using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类 Ninjas ，此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    public partial class Ninjas
    {
        internal const string COMMAND_ADD = "INSERT INTO Ninjas(Name) VALUES (@in_Name)";
        internal const string COMMAND_UPDATE = "UPDATE Ninjas SET Name=@in_Name WHERE Id=@in_Id";
        internal const string COMMAND_DELETE = "DELETE FROM Ninjas WHERE Id=@in_Id";
        internal const string COMMAND_TRUNCATE = "TRUNCATE TABLE Ninjas";
        internal const string COMMAND_EXISTS = "SELECT COUNT(1) FROM Ninjas WHERE Id=@in_Id";
        internal const string COMMAND_GETMODEL = "SELECT * FROM Ninjas WHERE Id=@in_Id";
        internal const string COMMAND_GETLIST = "SELECT * FROM Ninjas";
        internal const string COMMAND_GETMAXID = "SELECT MAX(Id) FROM Ninjas";

        internal const string PARM_ID = "@in_Id";
        internal const string PARM_NAME = "@in_Name";

        /// <summary>
        /// 为新增一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareAddParameters(Model.Ninjas model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_ADD);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_NAME, DbType.AnsiString, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_ADD, parms);
            }

            parms[0].Value = model.Name;

            return parms;
        }

        /// <summary>
        /// 为更新一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareUpdateParameters(Model.Ninjas model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_NAME, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE, parms);
            }

            parms[0].Value = model.Name;
            parms[1].Value = model.Id;

            return parms;
        }

        /// <summary>
        /// 为删除一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareDeleteParameters(int? Id)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_DELETE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_DELETE, parms);
            }

            parms[0].Value = Id;

            return parms;
        }

        /// <summary>
        /// 为查询是否存在一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareExistParameters(int? Id)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_EXISTS);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_EXISTS, parms);
            }

            parms[0].Value = Id;

            return parms;
        }

        /// <summary>
        /// 为获取一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareGetModelParameters(int? Id)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_GETMODEL);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_GETMODEL, parms);
            }

            parms[0].Value = Id;

            return parms;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        internal static void PrepareModel(Model.Ninjas model, IDataReader dr)
        {
            model.Id = DbValue.GetInt(dr["Id"]);
            model.Name = DbValue.GetString(dr["Name"]);
        }
    }
}
