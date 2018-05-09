using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MarketingDataPrediction.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Route("api/[controller]")]
    public class UzytkownikController : Controller
    {
        MarketingDataPredictionDbContext _db;

        public UzytkownikController()
        {
            _db = new MarketingDataPredictionDbContext();
        }

        // GET api/Uzytkownik
        [HttpGet]
        public JsonResult Get()
        {
            var response = _db.Klient.Where(k => k.Wiek == 56).ToList();

            var dataTable = new DataTable();
            // DataTables from db and decision trees example

            return Json(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
