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

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/Konta")]
    public class KontaController : Controller
    {

        public void Dispose()
        {
        }
    }
}
