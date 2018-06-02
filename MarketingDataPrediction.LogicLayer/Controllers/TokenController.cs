using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using MarketingDataPrediction.LogicLayer.BusinessObjects;
using MarketingDataPrediction.DataLayer.Models;
using System.Linq;
using MarketingDataPrediction.Security;
using Microsoft.EntityFrameworkCore;

namespace MarketingDataPrediction.LogicLayer.Controllers
{
    public class TokenController : Controller
    {
        private MarketingDataPredictionDbContext _db = null;

        public TokenController(DbContext context = null)
        {
            if (context == null)
            {
                _db = new MarketingDataPredictionDbContext();
            }
            else if (context != null)
            {
                _db = (MarketingDataPredictionDbContext) context;
            }
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public JsonResult PobierzToken(
             [FromServices]SigningConfigurations signingConfigurations,
             [FromServices]TokenConfigurations tokenConfigurations,
             [FromForm]LoginBO uzytkownik)
        {
            string email = uzytkownik.Email;
            string haslo = uzytkownik.Haslo;

            DateTime dtCreation = DateTime.Now;
            DateTime dtExpiration = dtCreation + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            string token = null;

            TokenBO odpowiedz = null;

            IQueryable<Uzytkownik> query = _db.Uzytkownik.Where(u => u.Email == email && u.Haslo == haslo);

            bool authentication = (query.Count() > 0);

            if (authentication)
            {
                var instance = query.FirstOrDefault();

                var userId = instance.IdUzytkownik;
                var isAdmin = instance.Admin;

                try
                {
                    token = GenerujToken(signingConfigurations, tokenConfigurations, dtCreation, dtExpiration, userId.ToString(), isAdmin);
                }
                catch (Exception e)
                {
                    return Json
                    (
                        new TokenBO
                        {
                            Authenticated = false,
                            Created = "",
                            Expiration = "",
                            AccessToken = "",
                            Message = e.Message.ToString()
                        }
                    );
                }

                odpowiedz = new TokenBO
                {
                    Authenticated = true,
                    Created = dtCreation.ToString("yyyy-MM-dd HH:mm:ss"),
                    Expiration = dtExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
                    AccessToken = token,
                    Message = "OK"
                };
            }
            else if (!authentication)
            {
                odpowiedz = new TokenBO
                {
                    Authenticated = false,
                    Created = "",
                    Expiration = "",
                    AccessToken = "",
                    Message = "Failed to authenticate"
                };
            }

            return Json(odpowiedz);
        }

        public string GenerujToken(SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, DateTime creation, DateTime expiration, string userId, bool isAdmin)
        {
            string role = "Uzytkownik";

            if (isAdmin)
            {
                role = "Admin";
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(userId, "Login"),
                new Claim[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(ClaimTypes.Role, role)
                }
            );
            
            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = creation,
                Expires = expiration
            });
            return handler.WriteToken(securityToken);
        }

        public void Dispose()
        {
        }
    }
}
