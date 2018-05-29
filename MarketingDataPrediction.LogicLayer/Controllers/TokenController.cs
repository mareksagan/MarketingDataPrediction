using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        public ActionResult GenerujToken()
        {
            return Json("");
        }

        public bool PobierzToken()
        {
            return true;
        }

        public bool Zaloguj()
        {
            return true;
        }

        public bool Wyloguj()
        {
            return true;
        }

        public bool Zarejestruj()
        {
            return true;
        }

        public bool Profil()
        {
            return true;
        }

        public void Dispose()
        {
        }
    }
}
