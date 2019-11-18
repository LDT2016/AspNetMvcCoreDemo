#region using

using System.IO;
using Microsoft.Extensions.Configuration;

#endregion

namespace ShowInfos.Infrastructure.Data
{
    public class ConfigurationManager
    {
        public static readonly IConfiguration Configuration;

        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}