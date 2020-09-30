using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiDemo.Services.Interface;
using ApiDemo.Models;
using ApiDemo.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Taylor.Apl.Dapper.Sql;

namespace ApiDemo.Services
{
    public class ConfigIdService : IConfigIdService
    {
        private readonly string _connectionString;
        private readonly ISqlHelper _dbHelper;

        public ConfigIdService(IConfiguration configuration, ISqlHelper dbHelper)
        {
            _connectionString = configuration.GetConnectionString("AplWebsites");
            _dbHelper = dbHelper;
        }

        /// <inheritdoc />
        public async Task<string> GetNewConfigId()
        {
            try
            {
                var result = await _dbHelper.GetResultAsync(_connectionString, "dbo.vendor_GetConfigId");

                LogSave((result.FirstOrDefault()
                               ?.Id
                         ?? 0).ToString());
                return (result.FirstOrDefault()
                              ?.Id
                        ?? 0).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                LogSave(e);
                throw e;
            }
        }

        public static void LogSave(Exception ex)
        {
            LogSave("Exception:" +
                    "\r\n\r\nException Message: \r\n" + ex.Message + "\r\n" +
                    "\r\nBase Exception: \r\n" + ex.GetBaseException() + "\r\n" +
                    "\r\nStack Trace: \r\n" + ex.StackTrace + "\r\n" +
                    (ex.InnerException != null ? ("\r\nInner Exception: \r\n" + ex.InnerException.Message) : string.Empty));
        }

        public static void LogSave(string msg)
        {
            string logpath = GetRootPath() + "\\ExecuteLog.log";
            var sw = new StreamWriter(logpath, true);
            sw.WriteLine("********************************************************");
            sw.Write(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            sw.Write("    Server: ");
            sw.WriteLine((string.IsNullOrEmpty(Environment.MachineName) ? string.Empty : Environment.MachineName));
            sw.WriteLine(msg);
            sw.Flush();
            sw.Close();
        }
        /// <summary>
        /// 取得网站根目录的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            string AppPath = AppDomain.CurrentDomain.BaseDirectory;
            if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                AppPath = AppPath.Substring(0, AppPath.Length - 1);
            return AppPath;
        }

    }
}
