using System;
using System.Data;
using System.Data.Common;
using Sybase.Data.AseClient;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using Npgsql;
using System.Data.SQLite;
using System.Data.SqlClient;
using Advantage.Data.Provider;
using iAnywhere.Data.SQLAnywhere;
using FirebirdSql.Data.FirebirdClient;
using Mimer.Data.Client;
using NexusDB.ADOProvider;
using Pervasive.Data.SqlClient;
using System.Data.SqlServerCe;
using Teradata.Client.Provider;
using VistaDB.Provider;

namespace DBUtility
{
    #region SqlServer操作类

    public class SqlServer : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as SqlCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as SqlCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as SqlCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as SqlCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }
    #endregion

    #region SQLite操作类

    public class SQLite : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SQLiteCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as SQLiteCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as SQLiteCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as SQLiteCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as SQLiteCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new SQLiteParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region PostgreSql操作类

    public class PostgreSql : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new NpgsqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as NpgsqlCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as NpgsqlCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as NpgsqlCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as NpgsqlCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new NpgsqlParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region Oracle操作类

    public class Oracle : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            OracleDataAdapter adapter = new OracleDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as OracleCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as OracleCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as OracleCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as OracleCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new OracleParameter();
            parameter.ParameterName = parameterName.Replace("@", ":").Replace("?", ":");
            return parameter;
        }
    }

    #endregion

    #region Ase操作类

    public class Ase : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new AseConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new AseCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            AseDataAdapter adapter = new AseDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as AseCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as AseCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as AseCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as AseCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new AseParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region DB2操作类

    public class DB2 : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new DB2Connection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new DB2Command();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            DB2DataAdapter adapter = new DB2DataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as DB2Command;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as DB2Command;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as DB2Command;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as DB2Command;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new DB2Parameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }

    }

    #endregion

    #region MySql操作类

    public class MySql : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as MySqlCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as MySqlCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as MySqlCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as MySqlCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new MySqlParameter();
            parameter.ParameterName = parameterName.Replace("@", "?").Replace(":", "?");
            return parameter;
        }
    }

    #endregion

    #region OleDb操作类

    public class OleDb : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new OleDbConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new OleDbCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as OleDbCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as OleDbCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as OleDbCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as OleDbCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new OleDbParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region Advantage操作类

    public class Advantage : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new AdsConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new AdsCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            AdsDataAdapter adapter = new AdsDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as AdsCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as AdsCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as AdsCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as AdsCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new AdsParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region Asa操作类

    public class Asa : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new SAConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SACommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            SADataAdapter adapter = new SADataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as SACommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as SACommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as SACommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as SACommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new SAParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region Firebird操作类

    public class Firebird : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new FbConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new FbCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            FbDataAdapter adapter = new FbDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as FbCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as FbCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as FbCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as FbCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new FbParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region Mimer操作类

    public class Mimer : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new MimerConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new MimerCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            MimerDataAdapter adapter = new MimerDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as MimerCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as MimerCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as MimerCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as MimerCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new MimerParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region NexusDB操作类

    public class NexusDB : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new NxConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new NxCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            NxDataAdapter adapter = new NxDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as NxCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as NxCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as NxCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as NxCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new NxParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region PervasiveSql操作类
    public class PervasiveSql : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new PsqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new PsqlCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            PsqlDataAdapter adapter = new PsqlDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as PsqlCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as PsqlCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as PsqlCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as PsqlCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new PsqlParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }
    #endregion

    #region SqlServerCe操作类

    public class SqlServerCe : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlCeConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCeCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as SqlCeCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as SqlCeCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as SqlCeCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as SqlCeCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new SqlCeParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region Teradata操作类

    public class Teradata : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new TdConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new TdCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            TdDataAdapter adapter = new TdDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as TdCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as TdCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as TdCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as TdCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new TdParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion

    #region VistaDB操作类

    public class VistaDB : DbHelper
    {
        public override IDbConnection CreateConnection()
        {
            return new VistaDBConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new VistaDBCommand();
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            VistaDBDataAdapter adapter = new VistaDBDataAdapter();
            if (selectCommand != null)
                adapter.SelectCommand = selectCommand as VistaDBCommand;
            if (insertCommand != null)
                adapter.InsertCommand = insertCommand as VistaDBCommand;
            if (deleteCommand != null)
                adapter.DeleteCommand = deleteCommand as VistaDBCommand;
            if (updateCommand != null)
                adapter.UpdateCommand = updateCommand as VistaDBCommand;
            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new VistaDBParameter();
            parameter.ParameterName = parameterName.Replace("?", "@").Replace(":", "@");
            return parameter;
        }
    }

    #endregion
}

