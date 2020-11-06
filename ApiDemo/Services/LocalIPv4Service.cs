using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ApiDemo.Services.Interface;
using Microsoft.Extensions.Configuration;

namespace ApiDemo.Services
{
    /// <inheritdoc />
    public class LocalIPv4Service : ILocalIPv4Service
    {
        private readonly string _defaultGateway;
        public LocalIPv4Service(IConfiguration configuration)
        {
            if (configuration != null)
            {
                _defaultGateway = configuration["DefaultGateway"];
            }
        }
        #region methods

        /// <inheritdoc cref="ILocalIPv4Service.GetLocalIp()"/>
        public string GetLocalIp()
        {
            //var localIps = NetworkInterface.GetAllNetworkInterfaces()
            //                                 .Select(p => p.GetIPProperties())
            //                                 .SelectMany(p => p.UnicastAddresses).ToList().FindAll(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address));

            //var localIps1 = NetworkInterface.GetAllNetworkInterfaces()
            //                                .Select(p => new { Interfaces = p, IPProperties = p.GetIPProperties() });

            var ethernetAdapterEthernetNetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
                                                                          .ToList()
                                                                          .Find(p => p.GetIPProperties().DnsAddresses.Any(x => x.ToString() == _defaultGateway));

            //var routerIpProps = NetworkInterface.GetAllNetworkInterfaces()
            //                                    .Select(p => p.GetIPProperties())
            //                                    .ToList()
            //                                    .Find(x => x.DnsAddresses.Any(y => y.ToString() == "192.168.1.1"));
            var localIp = "127.0.0.1";

            if (ethernetAdapterEthernetNetworkInterface != null)
            {
                var localProps = NetworkInterface.GetAllNetworkInterfaces()
                                               .ToList()
                                               .Find(x => x.Description == ethernetAdapterEthernetNetworkInterface.Description)
                                               ?.GetIPProperties()
                                               .UnicastAddresses.ToList()
                                               .FirstOrDefault(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address));
                if (localProps != null)
                {
                    localIp = localProps.Address.ToString();
                }
            }

            return localIp;
        }

        /// <inheritdoc cref="ILocalIPv4Service.GetPrimaryDns()"/>
        public string GetPrimaryDns()
        {
            var result = RunApp("nslookup", "", true);
            var m = Regex.Match(result, @"\d+\.\d+\.\d+\.\d+");

            if (m.Success)
            {
                return m.Value;
            }

            return null;
        }

        /// <summary>
        /// 运行一个控制台程序并返回其输出参数。
        /// </summary>
        /// <param name="filename">程序名</param>
        /// <param name="arguments">输入参数</param>
        /// <param name="recordLog">recordLog</param>
        /// <returns></returns>
        public string RunApp(string filename, string arguments, bool recordLog = false)
        {
            try
            {
                if (recordLog)
                {
                    Trace.WriteLine(filename + " " + arguments);
                }

                var proc = new Process();
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                using (var sr = new StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    //string txt = sr.ReadToEnd();
                    //sr.Close();
                    //if (recordLog)
                    //{
                    //    Trace.WriteLine(txt);
                    //}
                    //if (!proc.HasExited)
                    //{
                    //    proc.Kill();
                    //}
                    //上面标记的是原文，下面是我自己调试错误后自行修改的
                    Thread.Sleep(100); //貌似调用系统的nslookup还未返回数据或者数据未编码完成，程序就已经跳过直接执行

                    //txt = sr.ReadToEnd()了，导致返回的数据为空，故睡眠令硬件反应
                    if (!proc.HasExited) //在无参数调用nslookup后，可以继续输入命令继续操作，如果进程未停止就直接执行
                    {
                        //txt = sr.ReadToEnd()程序就在等待输入，而且又无法输入，直接掐住无法继续运行
                        proc.Kill();
                    }

                    var txt = sr.ReadToEnd();
                    sr.Close();

                    if (recordLog)
                    {
                        Trace.WriteLine(txt);
                    }

                    return txt;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);

                return ex.Message;
            }
        }

        private void GetIP()
        {
            var cmd = new Process();
            cmd.StartInfo.FileName = "ipconfig.exe"; //设置程序名
            cmd.StartInfo.Arguments = "/all"; //参数

            //重定向标准输出
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.CreateNoWindow = true; //不显示窗口（控制台程序是黑屏）

            //cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//暂时不明白什么意思
            /*
            收集一下 有备无患
            关于:ProcessWindowStyle.Hidden隐藏后如何再显示？
            hwndWin32Host = Win32Native.FindWindow(null, win32Exinfo.windowsName);
            Win32Native.ShowWindow(hwndWin32Host, 1);     //先FindWindow找到窗口后再ShowWindow
            */
            cmd.Start();
            var info = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            cmd.Close();
        }

        #endregion
    }
}
