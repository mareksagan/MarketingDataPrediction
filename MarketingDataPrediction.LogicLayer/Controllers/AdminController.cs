using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingDataPrediction.DataLayer.Models;
using MarketingDataPrediction.LogicLayer.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private MarketingDataPredictionDbContext _db = null;

        public AdminController(DbContext context = null)
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

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult DodajUzytkownika([FromForm]AdminBO newUser)
        {
            try
            {
                _db.Uzytkownik.Add(new Uzytkownik
                {
                    IdUzytkownik = Guid.NewGuid(),
                    Email = newUser.Email,
                    Haslo = newUser.Haslo,
                    Imie = newUser.Imie,
                    Nazwisko = newUser.Nazwisko,
                    Admin = newUser.Admin
                });

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("Dodano użytkownika");
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult EdytujUzytkownika([FromForm]Uzytkownik updateUser)
        {
            try
            {
                _db.Uzytkownik.Update(new Uzytkownik
                {
                    IdUzytkownik = updateUser.IdUzytkownik,
                    Email = updateUser.Email,
                    Haslo = updateUser.Haslo,
                    Imie = updateUser.Imie,
                    Nazwisko = updateUser.Nazwisko,
                    Admin = updateUser.Admin
                });

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("Zmodyfikowano użytkownika");
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult PobierzUzytkownika([FromForm]Guid idUzytkownika)
        {
            Uzytkownik response = null;

            try
            {
                response = _db.Uzytkownik.Where(u => u.IdUzytkownik == idUzytkownika).FirstOrDefault();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult ListaUzytkownikow()
        {
            UzytkownikListaBO[] response = null;

            try
            {
                var query = from u in _db.Uzytkownik
                            select new UzytkownikListaBO()
                            {
                                IdUzytkownik = u.IdUzytkownik,
                                Email = u.Email,
                                Imie = u.Imie,
                                Nazwisko = u.Nazwisko,
                                Admin = u.Admin ? "Tak" : "Nie"
                            };

                response = query.ToArray();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json(response);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult UsunUzytkownika([FromForm] Guid idUzytkownika)
        {
            try
            {
                var userToRemove = _db.Uzytkownik.Where(u => u.IdUzytkownik.Equals(idUzytkownika)).FirstOrDefault();
                _db.Uzytkownik.Remove(userToRemove);

                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }

            return Json("Usunięto użytkownika");
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult StatystykiSystemu()
        {
            IloscUzytkownikowBO[] result = null;

            try
            {
                var iloscKlientow = _db.Klient.Count();
                var iloscAdminow = _db.Uzytkownik.Where(u => u.Admin == true).Count();
                var iloscUzytkownikow = _db.Uzytkownik.Where(u => u.Admin == false).Count();

                result = new IloscUzytkownikowBO[]
                {
                    new IloscUzytkownikowBO()
                    {
                        RodzajUzytkownika = "Klienci",
                        IloscUzytkownikow = iloscKlientow
                    },
                    new IloscUzytkownikowBO()
                    {
                        RodzajUzytkownika = "Admini",
                        IloscUzytkownikow = iloscAdminow
                    },
                    new IloscUzytkownikowBO()
                    {
                        RodzajUzytkownika = "Uzytkownicy",
                        IloscUzytkownikow = iloscUzytkownikow
                    }
                };
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }

            return Json(result);
        }
    }
}