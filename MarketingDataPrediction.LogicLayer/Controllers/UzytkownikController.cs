using Accord.Math;
using MarketingDataPrediction.LogicLayer.Enums;
using MarketingDataPrediction.DataLayer.Models;
using MarketingDataPrediction.LogicLayer.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.ComponentModel;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Route("uzytkownik")]
    public class UzytkownikController : Controller
    {
        private MarketingDataPredictionDbContext _db = null;

        public UzytkownikController(DbContext context = null)
        {
            if (context == null)
            {
                _db = new MarketingDataPredictionDbContext();
            }
            else if (context != null)
            {
                _db = (MarketingDataPredictionDbContext)context;
            }
        }

        [Authorize(Roles = "Uzytkownik")]
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
                               ((DzienTygodniaEnum)k.Kampania.DzienKontaktu).ToString(),
                               ((MiesiacEnum)k.Kampania.MiesiacKontaktu).ToString(),
                               ((RodzajKontaktuEnum)k.Kampania.RodzajKontaktu).ToString(),
                               k.Inne.IloscDni.ToString(),
                               k.Inne.IloscProb.ToString(),
                               k.Inne.IloscProbAkt.ToString(),
                               ((RezultatEnum)k.Inne.PopRezultat).ToString(),
                               ((RezultatEnum)k.Wynik.Rezultat).ToString()
                           };

            string[] nazwyKolumn =
            {
                "Wiek", "Wyksztalcenie", "MaKredyt", "Hipoteka", "Stanowisko",
                "StatusMatrymonialny", "KredytKonsumencki", "Cci", "Cev", "Cpi",
                "Euribor3m", "IloscPracownikow", "DlugoscKontaktu", "DzienKontaktu", "MiesiacKontaktu",
                "RodzajKontaktu", "IloscDni", "IloscProb", "IloscProbAkt", "PoprzedniRezultat", "Wynik"
            };

            var dane = response.ToArray();

            var rfh = new RandomForestHelper(0.75);
            rfh.Uczenie(nazwyKolumn, dane);

            var wyniki = rfh.ZwrocWyniki().Select(w => ((RezultatEnum)w).ToString()).ToArray();
            var blad = rfh.PoliczBlad();

            var actionResult = new KlientUczenieBO
            {
                Dane = dane,
                Wyniki = wyniki,
                Blad = blad
            };

            return Json(actionResult);
        }

        [Authorize(Roles = "Uzytkownik")]
        [HttpGet("[action]")]
        public JsonResult Statystyki()
        {
            var sredniWiek = (int)_db.Klient.Average(k => k.Wiek);
            var dlugoscKontaktu = (int)_db.Klient.Average(k => k.Kampania.DlugoscKontaktu);
            var miesiaceKontaktu = _db.Kampania.GroupBy(k => k.MiesiacKontaktu)
                .OrderBy(g => g.FirstOrDefault().MiesiacKontaktu).Select(c => new MiesiacKontaktBO
                {
                    Miesiac = ((MiesiacEnum)c.FirstOrDefault().MiesiacKontaktu).GetAttributeOfType<DescriptionAttribute>().Description,
                    IloscKontaktow = c.Count()
                }).ToArray();

            var result = new StatystykiBO()
            {
                SredniWiekKlienta = sredniWiek,
                SredniaDlugoscKontaktu = dlugoscKontaktu,
                MiesiaceKontaktu = miesiaceKontaktu
            };

            return Json(result);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public JsonResult Zarejestruj([FromForm]UzytkownikBO nowyUzytkownik)
        {
            try
            {
                _db.Uzytkownik.Add(new Uzytkownik
                {
                    IdUzytkownik = Guid.NewGuid(),
                    Email = nowyUzytkownik.Email,
                    Haslo = nowyUzytkownik.Haslo,
                    Imie = nowyUzytkownik.Imie,
                    Nazwisko = nowyUzytkownik.Nazwisko,
                    Admin = false
                });

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("Dodano użytkownika");
        }

        [Authorize(Roles = "Uzytkownik,Admin")]
        [HttpPost("[action]")]
        public JsonResult ZmienProfil([FromForm]UzytkownikBO uzytkownik)
        {
            Guid userId;
            Guid.TryParse(this.User.Identity.Name, out userId);

            var isAdmin = this.User.IsInRole("Admin");

            try
            {
                _db.Uzytkownik.Update(new Uzytkownik
                {
                    IdUzytkownik = userId,
                    Email = uzytkownik.Email,
                    Haslo = uzytkownik.Haslo,
                    Imie = uzytkownik.Imie,
                    Nazwisko = uzytkownik.Nazwisko,
                    Admin = isAdmin
                });

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("Zmodyfikowano użytkownika");
        }

        [Authorize(Roles = "Uzytkownik,Admin")]
        [HttpGet("[action]")]
        public JsonResult ZmienProfil()
        {
            Guid userId;
            Guid.TryParse(this.User.Identity.Name, out userId);

            UzytkownikBO response = null;

            try
            {
                var user = _db.Uzytkownik.Where(u => u.IdUzytkownik.Equals(userId)).FirstOrDefault();

                response = new UzytkownikBO()
                {
                    Email = user.Email,
                    Haslo = user.Haslo,
                    Imie = user.Imie,
                    Nazwisko = user.Nazwisko
                };
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json(response);
        }
    }
}
