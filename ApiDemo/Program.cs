using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ApiDemo
{
    public class Program
    {
        #region methods

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).
                           UseStartup<Startup>();
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).
                Build().
                Run();
        }

        #endregion
    }
}
