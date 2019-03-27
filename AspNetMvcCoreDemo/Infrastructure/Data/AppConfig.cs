#region using

using Microsoft.Extensions.Configuration;

#endregion

namespace ShowInfos.Infrastructure.Data
{
    public class AppConfig
    {
        public static string MySqlConnection => ConfigurationManager.Configuration.GetConnectionString("MySqlConnection");
    }
}