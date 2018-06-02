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
        public JsonResult DodajUzytkownika([FromBody]AdminBO newUser)
        {
            try
            {
                var lastUserId = _db.Uzytkownik.OrderByDescending(u => u.IdUzytkownik).FirstOrDefault().IdUzytkownik;

                _db.Uzytkownik.Add(new Uzytkownik
                {
                    IdUzytkownik = lastUserId + 1,
                    Email = newUser.Email,
                    Haslo = newUser.Haslo,
                    Imie = newUser.Imie,
                    Nazwisko = newUser.Nazwisko,
                    Admin = newUser.Admin
                });
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("User added");
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult EdytujUzytkownika([FromBody]int userId, AdminBO updateUser)
        {
            try
            {
                _db.Uzytkownik.Update(new Uzytkownik
                {
                    IdUzytkownik = userId,
                    Email = updateUser.Email,
                    Haslo = updateUser.Haslo,
                    Imie = updateUser.Imie,
                    Nazwisko = updateUser.Nazwisko,
                    Admin = updateUser.Admin
                });
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("User updated");
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult EdytujUzytkownika()
        {
            List<Uzytkownik> response = null;

            try
            {
                response = _db.Uzytkownik.ToList();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json(response);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult UsunUzytkownika([FromBody] int idUzytkownika)
        {
            try
            {
                var userToRemove = _db.Uzytkownik.Where(u => u.IdUzytkownik == idUzytkownika).FirstOrDefault();
                _db.Uzytkownik.Remove(userToRemove);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
            return Json("User deleted");
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public JsonResult StatystykiSystemu()
        {
            StatystykiSystemuBO result = null;

            try
            {
                result = new StatystykiSystemuBO
                {
                    IloscKlientow = _db.Klient.Count(),
                    IloscAdminow = _db.Uzytkownik.Where(u => u.Admin == true).Count(),
                    IloscUzytkownikow = _db.Uzytkownik.Where(u => u.Admin == false).Count()
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