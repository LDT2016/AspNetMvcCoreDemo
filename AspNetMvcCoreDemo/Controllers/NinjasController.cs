using System.Collections.Generic;
using ShowInfos.Core.Interfaces;
using ShowInfos.Core.Model;
using ShowInfos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShowInfos.Controllers
{
    public class NinjasController : Controller
    {
        private readonly IRepository<Ninja> _ninjaRepository;

        public NinjasController(IRepository<Ninja> ninjaRepository)
        {
            _ninjaRepository = ninjaRepository;
        }

        public IActionResult Index()
        {
            var entities = _ninjaRepository.List();
            return View(entities);

            //var entities = new List<Ninja>();
            //entities.Add(new Ninja{Name = "1"});
            //entities.Add(new Ninja { Name = "2" });
            //return View(entities);
        }

        public IActionResult Index(string ids)
        {
            var entities = _ninjaRepository.List();
            return View(entities);

            //var entities = new List<Ninja>();
            //entities.Add(new Ninja{Name = "1"});
            //entities.Add(new Ninja { Name = "2" });
            //return View(entities);
        }

        public IActionResult Details(int id)
        {
            var entity = _ninjaRepository.GetById(id);
            return View(entity);

            ////var entity = _ninjaRepository.GetById(id);
            //return View(new Ninja { Name = "1" });
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        public ActionResult Create(Ninja entity)
        {
            _ninjaRepository.Add(entity);

            return Content("OK");
        }

        public IActionResult Add()
        {
            var entity = new Ninja()
            {
                Name = "Random Ninja"
            };
            _ninjaRepository.Add(entity);

            return RedirectToAction("Index");
        }

        public ActionResult GetAll()
        {
            var entities = _ninjaRepository.List();
            return Json(entities);
        }
    }
}