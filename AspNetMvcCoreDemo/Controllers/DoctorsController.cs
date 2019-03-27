#region using

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShowInfos.Core.Interfaces;
using ShowInfos.Core.Models;

#endregion

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowInfos.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IRepository<Doctors> _ninjaRepository;

        public DoctorsController(IRepository<Doctors> ninjaRepository)
        {
            _ninjaRepository = ninjaRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        #region MyRegion

        

        #endregion

        #region asdfas

        public IActionResult Index()

            #endregion
        {
            if (RouteData.Values["id"] != null)
            {
                var ids = RouteData.Values["id"].ToString();
                var idArray = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var Ids = idArray.ToList().Select(x =>
                {
                    int.TryParse(x, out var y);
                    return y;
                });

                var entities = _ninjaRepository.List(Ids.ToList());
                //for (var i = 0; i < entities.Count; i++)
                //{
                //    entities[i].Specialty.Replace("\r\n", "<br/>");
                //}
                return View(entities);
            }

            return View();
        }

        public ActionResult GetSpecialty()
        {
            var id0 = Request.Query["id"].First();
            if (id0 != null)
            {
                var ids = Request.Query["id"].ToString();
                var idArray = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var Ids = idArray.ToList().Select(x =>
                {
                    int.TryParse(x, out var y);
                    return y;
                });

                var entities = _ninjaRepository.List(Ids.ToList());
                for (var i = 0; i < entities.Count; i++)
                {
                    entities[i].Specialty = entities[i].Specialty.Replace("\r\n", "<br/>");
                }

                return Json(entities);
            }

            return Json("");
        }


        //private ImageFormat GetImageFormat(Image img, out string format)
        //{
        //    if (img.RawFormat.Equals(ImageFormat.Jpeg))
        //    {
        //        format = ".jpg";
        //        return ImageFormat.Jpeg;
        //    }
        //    if (img.RawFormat.Equals(ImageFormat.Gif))
        //    {
        //        format = ".gif";
        //        return ImageFormat.Gif;
        //    }
        //    if (img.RawFormat.Equals(ImageFormat.Png))
        //    {
        //        format = ".png";
        //        return ImageFormat.Png;
        //    }
        //    if (img.RawFormat.Equals(ImageFormat.Bmp))
        //    {
        //        format = ".bmp";
        //        return ImageFormat.Bmp;
        //    }
        //    format = string.Empty;
        //    return null;
        //}

        public FileResult ShowImage(int id)
        {
            FileResult file = null;
            var model = _ninjaRepository.GetById(id);
            if (model.Photo != null)
            {
                file = File(model.Photo, "image/jpg");
            }

            return file;
        }
    }
}