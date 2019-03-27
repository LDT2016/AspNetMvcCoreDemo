//如果要从UI中设置数据库，请取消注释下一行，如果从配置中读取，请注释下一行
//#define UISET

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using DBUtility;
using Microsoft.Extensions.Configuration;

//using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DALHelper
    {
#if UISET
        public static DbHelper dbHelper;

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="dbType">不区分大小写，可选值：Advantage、Asa、Ase、DB2、Firebird、Mimer、MySql、NexusDB、OleDb、Oracle、
        /// PervasiveSql、PostgreSql、SQLite、SqlServer、SqlServerCe、Teradata、VistaDB</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void SetHelper(string dbType, string connectionString)
        {
            dbHelper = DbHelper.Create(dbType);
            dbHelper.ConnectionString = connectionString;
        }
#else
        public static DbHelper dbHelper = GetHelper("showinfos");
        public static string MySqlConnection => ConfigurationManager.Configuration.GetConnectionString("MySqlConnection");

        /// <summary>
        /// 从Web.config从读取数据库的连接以及数据库类型
        /// </summary>
        private static DbHelper GetHelper(string connectionStringName)
        {
            //var connectionSetting = System.Configuration.ConfigurationManager.AppSettings[connectionStringName];
            //string className = connectionSetting.ProviderName;
            //DbHelper db = DbHelper.Create(className);
            //db.ConnectionString = connectionSetting.ConnectionString;
            DbHelper db = DbHelper.Create("SqlServer");
            db.ConnectionString = MySqlConnection;
            return db;
        }
#endif
        /// <summary>
        /// 对IDataReader读取依次执行事件
        /// </summary>
        public static void ExecuteReaderAction(IDataReader dr, Action<IDataReader> readAction)
        {
            while (dr.Read())
            {
                if (readAction != null) readAction(dr);
            }
        }

        /// <summary>
        /// 对IDataReader读取依次执行事件
        /// </summary>
        public static void ExecuteReaderAction(IDataReader dr, int first, int count, Action<IDataReader> readAction)
        {
            for (int i = 0; i < first; i++)
            {
                if (!dr.Read()) return;
            }

            int resultsFetched = 0;
            while (resultsFetched < count && dr.Read())
            {
                if (readAction != null) readAction(dr);
                resultsFetched++;
            }
        }
    }
}
