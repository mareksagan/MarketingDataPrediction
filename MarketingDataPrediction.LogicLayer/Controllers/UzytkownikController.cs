using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MarketingDataPrediction.DataLayer.Enums;
using MarketingDataPrediction.DataLayer.Models;
using MarketingDataPrediction.LogicLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Route("[controller]")]
    public class UzytkownikController : Controller
    {
        MarketingDataPredictionDbContext _db;

        public UzytkownikController()
        {
            _db = new MarketingDataPredictionDbContext();
        }

        [HttpGet("[action]")]
        public JsonResult Get()
        {
            var response = from k in _db.Klient
                           where k.Wiek == 56
                           select new KlientWynikUczeniaDTO()
                           {
                               Id = k.IdKlient.ToString(),
                               Wiek = k.Wiek.GetValueOrDefault(),
                               Wyksztalcenie = ((WyksztalcenieEnum) k.Wyksztalcenie.GetValueOrDefault()).ToString(),
                               Kredyt = ((StatusFinansowyEnum) k.Kzadluzenie.GetValueOrDefault()).ToString(),
                               Hipoteka = ((StatusFinansowyEnum)k.Khipoteczny.GetValueOrDefault()).ToString(),
                               Wynik = ((RezultatEnum)k.Wynik.FirstOrDefault().Rezultat).ToString()
                           };

            var dataTable = new DataTable();
            // DataTables from db and decision trees example

            return Json(response.ToList());
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
    }
}
