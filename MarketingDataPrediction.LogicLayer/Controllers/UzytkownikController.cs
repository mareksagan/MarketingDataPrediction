using Accord.Math;
using MarketingDataPrediction.DataLayer.Enums;
using MarketingDataPrediction.DataLayer.Models;
using MarketingDataPrediction.LogicLayer.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public JsonResult UczenieMaszynowe()
        {
            var response = from k in _db.Klient
                           select new string[]
                           {
                               k.Wiek.ToString(),
                               ((WyksztalcenieEnum)k.Wyksztalcenie).ToString(),
                               ((StatusFinansowyEnum)k.Kzadluzenie).ToString(),
                               ((StatusFinansowyEnum)k.Khipoteczny).ToString(),
                               ((StanowiskoEnum)k.Stanowisko).ToString(),
                               ((StatusMatrymonialnyEnum)k.Smatrymonialny).ToString(),
                               ((StatusFinansowyEnum)k.Kkonsumencki).ToString(),
                               k.WskazSocEkon.Cci.ToString(),
                               k.WskazSocEkon.Cev.ToString(),
                               k.WskazSocEkon.Cpi.ToString(),
                               k.WskazSocEkon.Euribor3m.ToString(),
                               k.WskazSocEkon.IloscPrac.ToString(),
                               k.Kampania.DlugoscKontaktu.ToString(),
                               k.Kampania.DzienKontaktu.ToString(),
                               k.Kampania.MiesiacKontaktu.ToString(),
                               k.Kampania.RodzajKontaktu.ToString(),
                               k.Inne.IloscDni.ToString(),
                               k.Inne.IloscProb.ToString(),
                               k.Inne.IloscProbAkt.ToString(),
                               k.Inne.PopRezultat.ToString(),
                               ((RezultatEnum)k.Wynik.Rezultat).ToString()
                               //more TypeScript
                           };

            string[] nazwyKolumn =
            {
                "Wiek", "Wyksztalcenie", "Kredyt", "Hipoteka", "Stanowisko",
                "StatusMatrymonialny", "KredytKonsumencki", "Cci", "Cev", "Cpi",
                "Euribor3m", "IloscPracownikow", "DlugoscKontaktu", "DzienKontaktu", "MiesiacKontaktu",
                "RodzajKontaktu", "IloscDni", "IloscProb", "IloscProbAkt", "PoprzedniRezultat", "Wynik"
            };

            var dane = response.ToArray();

            var rfh = new RandomForestHelper(0.75);
            rfh.Uczenie(nazwyKolumn, dane);

            var actionResult = new KlientUczenieBO
            {
                Dane = dane,
                Wyniki = rfh.ZwrocWyniki(),
                Blad = rfh.PoliczBlad()
            };
            //Identity core
            return Json(actionResult);
        }

        [HttpGet("[action]")]
        public JsonResult Statystyki()
        {
            var result = new StatystykiBO()
            {
                AverageClientAge = _db.Klient.Average(k => k.Wiek),
                AverageLoanAmount = _db.Klient.Average(k => k.Kzadluzenie),
                MostFreqMonth = "January"
            };

            return Json(result);
        }
    }
}
