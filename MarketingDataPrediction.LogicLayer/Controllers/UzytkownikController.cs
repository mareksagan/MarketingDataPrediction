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
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.MachineLearning.DecisionTrees;
using System;
using System.Runtime.Serialization;
using Accord.Math;
using Accord.Compat;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Accord.Statistics.Filters;

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


            string[] columnNames = { "Outlook", "Temperature", "Humidity", "Wind", "PlayTennis" };

            string[][] data =
            {
                new string[] { "Sunny", "Hot", "1", "Weak", "No" },
                new string[] { "Sunny", "Hot", "1", "Strong", "No" },
                new string[] { "Overcast", "Hot", "1", "Weak", "Yes" },
                new string[] { "Rain", "Mild", "1", "Weak", "Yes" },
                new string[] { "Rain", "Cool", "0", "Weak", "Yes" },
                new string[] { "Rain", "Cool", "0", "Strong", "No" },
                new string[] { "Overcast", "Cool", "0", "Strong", "Yes" },
                new string[] { "Sunny", "Mild", "1", "Weak", "No" },
                new string[] { "Sunny", "Cool", "0", "Weak", "Yes" },
                new string[] {  "Rain", "Mild", "0", "Weak", "Yes" },
                new string[] {  "Sunny", "Mild", "0", "Strong", "Yes" },
                new string[] {  "Overcast", "Mild", "1", "Strong", "Yes" },
                new string[] {  "Overcast", "Hot", "0", "Weak", "Yes" },
                new string[] {  "Rain", "Mild", "1", "Strong", "No" },
            };

            // Create a new codification codebook to
            // convert strings into discrete symbols
            Codification codebook = new Codification(columnNames, data);

            // Extract input and output pairs to train
            int[][] symbols = codebook.Transform(data);
            int[][] inputs = symbols.Get(null, 0, -1); // Gets all rows, from 0 to the last (but not the last)
            int[] outputs = symbols.GetColumn(-1);     // Gets only the last column


            RandomForestLearning teacher = new RandomForestLearning();

            RandomForest forest = teacher.Learn(inputs, outputs);

            int[] predictedValues = forest.Decide(inputs);

            var response = from k in _db.Klient
                           where k.Wiek == 56
                           select new KlientWynikUczeniaDTO()
                           {
                               Id = k.IdKlient.ToString(),
                               Wiek = k.Wiek.GetValueOrDefault(),
                               Wyksztalcenie = ((WyksztalcenieEnum)k.Wyksztalcenie.GetValueOrDefault()).ToString(),
                               Kredyt = ((StatusFinansowyEnum)k.Kzadluzenie.GetValueOrDefault()).ToString(),
                               Hipoteka = ((StatusFinansowyEnum)k.Khipoteczny.GetValueOrDefault()).ToString(),
                               Wynik = ((RezultatEnum)k.Wynik.FirstOrDefault().Rezultat).ToString()
                           };

            return Json(response.ToList());
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
        public JsonResult EdytujProfil()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult UczenieMaszynowe()
        {
            return Json("hel");
        }

        [HttpGet("[action]")]
        public JsonResult EksportujWyniki()
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
    }
}
