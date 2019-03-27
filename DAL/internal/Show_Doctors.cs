using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类 Show_Doctors ，此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    public partial class Show_Doctors
    {
        internal const string COMMAND_ADD = "INSERT INTO Show_Doctors(Name, Education, Position, Specialty, Photo, Copay, ClinicTime) VALUES (@in_Name, @in_Education, @in_Position, @in_Specialty, @in_Photo, @in_Copay, @in_ClinicTime)";
        internal const string COMMAND_UPDATE = "UPDATE Show_Doctors SET Name=@in_Name, Education=@in_Education, Position=@in_Position, Specialty=@in_Specialty, Photo=@in_Photo, Copay=@in_Copay, ClinicTime=@in_ClinicTime WHERE Id=@in_Id";
        internal const string COMMAND_DELETE = "DELETE FROM Show_Doctors WHERE Id=@in_Id";
        internal const string COMMAND_TRUNCATE = "TRUNCATE TABLE Show_Doctors";
        internal const string COMMAND_EXISTS = "SELECT COUNT(1) FROM Show_Doctors WHERE Id=@in_Id";
        internal const string COMMAND_GETMODEL = "SELECT * FROM Show_Doctors WHERE Id=@in_Id";
        internal const string COMMAND_GETLIST = "SELECT * FROM Show_Doctors";
        internal const string COMMAND_GETMAXID = "SELECT MAX(Id) FROM Show_Doctors";

        internal const string PARM_ID = "@in_Id";
        internal const string PARM_NAME = "@in_Name";
        internal const string PARM_EDUCATION = "@in_Education";
        internal const string PARM_POSITION = "@in_Position";
        internal const string PARM_SPECIALTY = "@in_Specialty";
        internal const string PARM_PHOTO = "@in_Photo";
        internal const string PARM_COPAY = "@in_Copay";
        internal const string PARM_CLINICTIME = "@in_ClinicTime";

        /// <summary>
        /// 为新增一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareAddParameters(Model.Show_Doctors model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_ADD);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_NAME, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_EDUCATION, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_POSITION, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_SPECIALTY, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PHOTO, DbType.Binary, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_COPAY, DbType.Double, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_CLINICTIME, DbType.AnsiString, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_ADD, parms);
            }

            parms[0].Value = model.Name;
            parms[1].Value = model.Education;
            parms[2].Value = model.Position;
            parms[3].Value = model.Specialty;
            parms[4].Value = model.Photo;
            parms[5].Value = model.Copay;
            parms[6].Value = model.ClinicTime;

            return parms;
        }

        /// <summary>
        /// 为更新一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareUpdateParameters(Model.Show_Doctors model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_NAME, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_EDUCATION, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_POSITION, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_SPECIALTY, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PHOTO, DbType.Binary, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_COPAY, DbType.Double, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_CLINICTIME, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE, parms);
            }

            parms[0].Value = model.Name;
            parms[1].Value = model.Education;
            parms[2].Value = model.Position;
            parms[3].Value = model.Specialty;
            parms[4].Value = model.Photo;
            parms[5].Value = model.Copay;
            parms[6].Value = model.ClinicTime;
            parms[7].Value = model.Id;

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
        internal static void PrepareModel(Model.Show_Doctors model, IDataReader dr)
        {
            model.Id = DbValue.GetInt(dr["Id"]);
            model.Name = DbValue.GetString(dr["Name"]);
            model.Education = DbValue.GetString(dr["Education"]);
            model.Position = DbValue.GetString(dr["Position"]);
            model.Specialty = DbValue.GetString(dr["Specialty"]);
            model.Photo = DbValue.GetBinary(dr["Photo"]);
            model.Copay = DbValue.GetDouble(dr["Copay"]);
            model.ClinicTime = DbValue.GetString(dr["ClinicTime"]);
        }
    }
}
