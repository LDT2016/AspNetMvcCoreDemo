#region using

using FiftyOne.Foundation.Mobile.Detection;
using FiftyOne.Foundation.Mobile.Detection.Entities;
using FiftyOne.Foundation.Mobile.Detection.Factories;
using Microsoft.AspNetCore.Mvc;
using WebSupergoo.ABCpdf10;

#endregion

namespace ShowInfos.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AbcPdfCreate()
        {
            var theDoc = new Doc();
            theDoc.Width = 24;
            theDoc.Color.String = "120 0 0";
            theDoc.AddArc(0, 270, 300, 400, 200, 300);
            theDoc.Save(@"C:\Users\yjli\Desktop\docaddarc.pdf");
            theDoc.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult AbcPdfCreate1()
        {
            var theImg = new XImage();
            var theDoc = new Doc();
            // read the data from a file
            var thePath = @"D:\LIDATONG\soccer\18583.png";
            var theStream = System.IO.File.OpenRead(thePath);
            var theData = new byte[theStream.Length];
            theStream.Read(theData, 0, (int) theStream.Length);
            theStream.Close();
            // place the data into the image
            theImg.SetData(theData);
            theDoc.Rect.Inset(20, 20);
            theDoc.AddImageObject(theImg, false);
            theImg.Clear();
            theDoc.Save(@"C:\Users\yjli\Desktop\imagesetdata.pdf");
            theDoc.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult AbcPdfCreate2()
        {
            var fileName = @"D:\MobileDeviceDetection\51Degrees.mobi-Premium.dat";
            DataSet dataSet = StreamFactory.Create(fileName, false);
            // Provides access to device detection functions.
            var provider = new Provider(dataSet);

            //// Used to store and access detection results.
            //Match match;

            //// Contains detection result for the IsMobile property.
            //string IsMobile;

            //// User-Agent string of an iPhone mobile device.
            //string mobileUserAgent = ("Mozilla/5.0 (iPhone; CPU iPhone " +
            //    "OS 7_1 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like " +
            //    "Gecko) 'Version/7.0 Mobile/11D167 Safari/9537.53");

            //// User-Agent string of Firefox Web browser version 41 on desktop.
            //string desktopUserAgent = ("Mozilla/5.0 (Windows NT 6.3; " +
            //    "WOW64; rv:41.0) Gecko/20100101 Firefox/41.0");

            //// User-Agent string of a MediaHub device.
            //string mediaHubUserAgent = ("Mozilla/5.0 (Linux; Android " +
            //    "4.4.2; X7 Quad Core Build/KOT49H) AppleWebKit/537.36 " +
            //    "(KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 " +
            //    "Safari/537.36");

            //Console.WriteLine("Staring Getting Started Example.");

            //// Carries out a match for a mobile User-Agent.
            //Console.WriteLine("\nMobile User-Agent: " + mobileUserAgent);
            //match = provider.Match(mobileUserAgent);
            //IsMobile = match["IsMobile"].ToString();
            //Console.WriteLine("   IsMobile: " + IsMobile);

            //// Carries out a match for a desktop User-Agent.
            //Console.WriteLine("\nDesktop User-Agent: " + desktopUserAgent);
            //match = provider.Match(desktopUserAgent);
            //IsMobile = match["IsMobile"].ToString();
            //Console.WriteLine("   IsMobile: " + IsMobile);

            //// Carries out a match for a MediaHub User-Agent.
            //Console.WriteLine("\nMediaHub User-Agent: " + mediaHubUserAgent);
            //match = provider.Match(mediaHubUserAgent);
            //IsMobile = match["IsMobile"].ToString();
            //Console.WriteLine("   IsMobile: " + IsMobile);

            //// Returns the number of profiles that are Mobile.
            //Console.WriteLine("\nNumber of mobile profiles: {0}", dataSet.FindProfiles("IsMobile", "True").Length);


            var clientAgent = Request.Headers["User-Agent"];
            var clientMatch = provider.Match(clientAgent);
            var isMobile = clientMatch["IsMobile"].ToString();
            var isTablet = clientMatch["IsTablet"].ToString();
            ViewBag.IsMobile = isMobile;
            ViewBag.IsTablet = isTablet;
            ViewBag.ClientAgent = clientAgent;

            return View();
        }
    }
}