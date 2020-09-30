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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Taylor.Apl.Dapper.Sql;
using ApiDemo.Utils;

namespace ApiDemo.Services
{
    public class TestProductService : ITestProductService
    {
        private readonly string _connectionString;
        private readonly ISqlHelper _dbHelper;

        public TestProductService(IConfiguration configuration, ISqlHelper dbHelper)
        {
            _connectionString = configuration.GetConnectionString("AplWebsites");
            _dbHelper = dbHelper;
        }

        /// <inheritdoc />
        public async Task<IList<TestProduct>> GetTestProduct()
        {
            try
            {
                var entities = await _dbHelper.GetEntityAsync<TestProduct>(_connectionString, "util.test_GetProducts");

                return entities?.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                LogSave(e);
                throw e;
            }
        }

        public async Task<IList<int>> GetProductVendorId(string itemId)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 { "@ItemId", itemId }
                             };
            var entities = await _dbHelper.GetEntityAsync<int>(_connectionString, "dbo.prod_GetVendorIdsByItemId", parameters);

            return entities?.ToList();

        }

        public async Task<IList<ImprintColorModel>> GetImprintColors(string itemId, object imprintAreaCode)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 {"@ItemId",itemId },
                                 {"@ImprintAreaCode" ,imprintAreaCode}
                             };
            var imprintColors = await _dbHelper.GetEntityAsync<ImprintColorModel>(_connectionString, "prod_GetImprintColor", parameters);

            return imprintColors.ToList();
        }

        public async Task<List<ImprintFormatData>> GetImprintFormat(string itemId)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 { "@ItemId", itemId }
                             };
            var imprintFormats = await _dbHelper.GetEntityAsync<ImprintFormatData>(_connectionString, "prod_GetImprintFormat", parameters);

            return imprintFormats.ToList();
        }

        public async Task<ImprintAreaHeaderModel> GetImprintAreaHeader(string imprintAreaCode)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 { "@ImprintAreaCode", imprintAreaCode }
                             };
            var imprintAreaHeader = await _dbHelper.GetEntityAsync<ImprintAreaHeaderModel>(_connectionString, "prod_GetImprintAreaHeader", parameters);

            return imprintAreaHeader.FirstOrDefault();
        }

        public async Task<int> GetVerseSequenceByImageCode(string imprintAreaCode, string pptfeCode)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 { "@ImprintAreaCode", imprintAreaCode },
                                 { "@PptfeCode", pptfeCode }
                             };
            var lineSequence = await _dbHelper.GetResultAsync(_connectionString, "prod_GetVerseLineSequence", parameters);
            return lineSequence.ToString().GetIntOrZero();
        }
        public async Task<bool> AllowAutoDefaultVerse(string imprintAreaCode, string pptfeCode)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 { "@ImprintAreaCode", imprintAreaCode },
                                 { "@PptfeCode", pptfeCode }
                             };
            var count = await _dbHelper.GetResultAsync(_connectionString, "prod_CheckDefaultVerse", parameters);

            return count.ToString().GetIntOrZero() > 0;
        }
        public async Task<int> GetSentimentSequenceByImageCode(string imprintAreaCode, string pptfeCode)
        {
            var parameters = new Dictionary<string, object>
                             {
                                 { "@ImprintAreaCode", imprintAreaCode },
                                 { "@PptfeCode", pptfeCode }
                             };
            var lineSequence = await _dbHelper.GetResultAsync(_connectionString, "prod_GetVerseLineSequence", parameters);

            return lineSequence.ToString().GetIntOrZero();
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
