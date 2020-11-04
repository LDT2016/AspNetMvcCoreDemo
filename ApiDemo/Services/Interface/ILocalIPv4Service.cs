namespace ApiDemo.Services.Interface
{
    /// <summary>
    /// ILocalIPv4
    /// </summary>
    public interface ILocalIPv4Service
    {
        #region methods

        /// <summary>
        /// 获取当前使用的IP
        /// </summary>
        /// <returns>当前使用的IP</returns>
        string GetLocalIp();


        /// <summary>
        /// 获取本机主DNS
        /// </summary>
        /// <returns>本机主DNS</returns>
        string GetPrimaryDns();

        #endregion
    }
}
