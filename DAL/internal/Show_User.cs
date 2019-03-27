using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类 Show_User ，此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    public partial class Show_User
    {
        internal const string COMMAND_ADD = "INSERT INTO Show_User(UserId, Passcode, IsAdmin) VALUES (@in_UserId, @in_Passcode, @in_IsAdmin)";
        internal const string COMMAND_UPDATE = "UPDATE Show_User SET UserId=@in_UserId, Passcode=@in_Passcode, IsAdmin=@in_IsAdmin WHERE Id=@in_Id";
        internal const string COMMAND_DELETE = "DELETE FROM Show_User WHERE Id=@in_Id";
        internal const string COMMAND_TRUNCATE = "TRUNCATE TABLE Show_User";
        internal const string COMMAND_EXISTS = "SELECT COUNT(1) FROM Show_User WHERE Id=@in_Id";
        internal const string COMMAND_GETMODEL = "SELECT * FROM Show_User WHERE Id=@in_Id";
        internal const string COMMAND_GETLIST = "SELECT * FROM Show_User";
        internal const string COMMAND_GETMAXID = "SELECT MAX(Id) FROM Show_User";

        internal const string PARM_ID = "@in_Id";
        internal const string PARM_USERID = "@in_UserId";
        internal const string PARM_PASSCODE = "@in_Passcode";
        internal const string PARM_ISADMIN = "@in_IsAdmin";

        /// <summary>
        /// 为新增一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareAddParameters(Model.Show_User model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_ADD);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_USERID, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PASSCODE, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ISADMIN, DbType.Boolean, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_ADD, parms);
            }

            parms[0].Value = model.UserId;
            parms[1].Value = model.Passcode;
            parms[2].Value = model.IsAdmin;

            return parms;
        }

        /// <summary>
        /// 为更新一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareUpdateParameters(Model.Show_User model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_USERID, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PASSCODE, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ISADMIN, DbType.Boolean, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE, parms);
            }

            parms[0].Value = model.UserId;
            parms[1].Value = model.Passcode;
            parms[2].Value = model.IsAdmin;
            parms[3].Value = model.Id;

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
        internal static void PrepareModel(Model.Show_User model, IDataReader dr)
        {
            model.Id = DbValue.GetInt(dr["Id"]);
            model.UserId = DbValue.GetString(dr["UserId"]);
            model.Passcode = DbValue.GetString(dr["Passcode"]);
            model.IsAdmin = DbValue.GetBool(dr["IsAdmin"]);
        }
    }
}
