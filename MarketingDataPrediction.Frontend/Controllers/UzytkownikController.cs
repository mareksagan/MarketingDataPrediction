using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarketingDataPrediction.Controllers
{
    public class UzytkownikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}