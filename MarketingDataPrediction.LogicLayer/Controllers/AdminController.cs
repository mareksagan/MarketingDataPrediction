using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingDataPrediction.DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        MarketingDataPredictionDbContext _db;

        public AdminController()
        {
            _db = new MarketingDataPredictionDbContext();
        }

        [HttpGet("[action]")]
        public JsonResult Zaloguj()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult Zarejestruj()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult DodajAdmina()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult EdytujAdmina()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult WeryfikacjaLogowania()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult Wyloguj()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult ZmienParametry()
        {
            return Json("hel");
        }
    }
}