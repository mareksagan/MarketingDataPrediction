﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingDataPrediction.DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        MarketingDataPredictionDbContext _db;

        public AdminController()
        {
            _db = new MarketingDataPredictionDbContext();
        }

        [HttpPost("[action]")]
        public JsonResult DodajUzytkownika()
        {
            return Json("hel");
        }

        [HttpPost("[action]")]
        public JsonResult EdytujUzytkownika()
        {
            return Json("hel");
        }

        [HttpPost("[action]")]
        public JsonResult UsunUzytkownika()
        {
            return Json("hel");
        }

        [HttpPost("[action]")]
        public JsonResult StatystykiSystemu()
        {
            return Json("hel");
        }
    }
}