#region using

using Microsoft.AspNetCore.Mvc;

#endregion

namespace ShowInfos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}