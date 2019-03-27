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


            #region Construction
            #endregion Construction

            #region UI Binding Variant
            #endregion UI Binding Variant

            #region Initial Method
            #endregion Initial Method

            #region Override Method
            #endregion Override Method

            #region BettingLottery
            #endregion BettingLottery

            #region UpdateBetting
            #endregion UpdateBetting

            #region Private Method
            #endregion Private Method

        }
    }
}