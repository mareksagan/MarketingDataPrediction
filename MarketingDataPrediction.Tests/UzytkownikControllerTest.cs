using MarketingDataPrediction.DataLayer.Models;
using MarketingDataPrediction.LogicLayer.Controllers;
using MarketingDataPrediction.LogicLayer.BusinessObjects;
using MarketingDataPrediction.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Xunit;

namespace MarketingDataPrediction.Tests
{
    public class UzytkownikControllerTest
    {
        public UzytkownikController controller { get; set; }
        public MarketingDataPredictionDbContext mockContext { get; set; }
        public TokenConfigurations tokenConfig { get; set; }
        public SigningConfigurations signingConfig { get; set; }

        public UzytkownikControllerTest()
        {
            IQueryable<Uzytkownik> daneUzytkownik = new List<Uzytkownik>
            {
                new Uzytkownik { IdUzytkownik = Guid.Parse("2f15b775-a345-4445-b91b-c4cb965c12b8"), Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "a@a.pl", Haslo = "haslo", Admin = true},
                new Uzytkownik { IdUzytkownik = Guid.Parse("3726ab5d-89bf-45ac-a3cc-191dbd200274"), Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "b@a.pl", Haslo = "haslo", Admin = false},
                new Uzytkownik { IdUzytkownik = Guid.Parse("f6c5b1a5-4516-4d77-ade0-c483bcbb9466"), Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "c@a.pl", Haslo = "haslo", Admin = false}
            }.AsQueryable();

            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();

            IQueryable<Kampania> daneKampania = new List<Kampania>
            {
                new Kampania { IdKlient = guid1, DlugoscKontaktu = 5645, DzienKontaktu = 3, RodzajKontaktu = 1, MiesiacKontaktu = 10 },
                new Kampania { IdKlient = guid2, DlugoscKontaktu = 5646, DzienKontaktu = 4, RodzajKontaktu = 1, MiesiacKontaktu = 9 },
                new Kampania { IdKlient = guid3, DlugoscKontaktu = 5647, DzienKontaktu = 5, RodzajKontaktu = 1, MiesiacKontaktu = 10 }
            }.AsQueryable();

            IQueryable<Klient> daneKlient = new List<Klient>
            {
                new Klient { IdKlient = guid1, Wiek = 65, Khipoteczny = 1, Kkonsumencki = 1, Kzadluzenie = 1, Smatrymonialny = 2, Stanowisko = 1, Wyksztalcenie = 4, Kampania = daneKampania.Where(id => id.IdKlient == guid1).FirstOrDefault() },
                new Klient { IdKlient = guid2, Wiek = 55, Khipoteczny = 1, Kkonsumencki = 0, Kzadluzenie = 1, Smatrymonialny = 2, Stanowisko = 5, Wyksztalcenie = 4, Kampania = daneKampania.Where(id => id.IdKlient == guid2).FirstOrDefault() },
                new Klient { IdKlient = guid3, Wiek = 45, Khipoteczny = 0, Kkonsumencki = 1, Kzadluzenie = 0, Smatrymonialny = 2, Stanowisko = 1, Wyksztalcenie = 4, Kampania = daneKampania.Where(id => id.IdKlient == guid3).FirstOrDefault() }
            }.AsQueryable();

            var mockSetUzytkownik = Substitute.For<DbSet<Uzytkownik>, IQueryable<Uzytkownik>>();
            var mockSetKampania = Substitute.For<DbSet<Kampania>, IQueryable<Kampania>>();
            var mockSetKlient = Substitute.For<DbSet<Klient>, IQueryable<Klient>>();

            ((IQueryable<Uzytkownik>)mockSetUzytkownik).Provider.Returns(daneUzytkownik.Provider);
            ((IQueryable<Uzytkownik>)mockSetUzytkownik).Expression.Returns(daneUzytkownik.Expression);
            ((IQueryable<Uzytkownik>)mockSetUzytkownik).ElementType.Returns(daneUzytkownik.ElementType);
            ((IQueryable<Uzytkownik>)mockSetUzytkownik).GetEnumerator().Returns(daneUzytkownik.GetEnumerator());

            ((IQueryable<Kampania>)mockSetKampania).Provider.Returns(daneKampania.Provider);
            ((IQueryable<Kampania>)mockSetKampania).Expression.Returns(daneKampania.Expression);
            ((IQueryable<Kampania>)mockSetKampania).ElementType.Returns(daneKampania.ElementType);
            ((IQueryable<Kampania>)mockSetKampania).GetEnumerator().Returns(daneKampania.GetEnumerator());

            ((IQueryable<Klient>)mockSetKlient).Provider.Returns(daneKlient.Provider);
            ((IQueryable<Klient>)mockSetKlient).Expression.Returns(daneKlient.Expression);
            ((IQueryable<Klient>)mockSetKlient).ElementType.Returns(daneKlient.ElementType);
            ((IQueryable<Klient>)mockSetKlient).GetEnumerator().Returns(daneKlient.GetEnumerator());

            mockContext = Substitute.For<MarketingDataPredictionDbContext>();
            mockContext.Uzytkownik.Returns(mockSetUzytkownik);
            mockContext.Kampania.Returns(mockSetKampania);
            mockContext.Klient.Returns(mockSetKlient);

            controller = new UzytkownikController(mockContext);

            signingConfig = new SigningConfigurations();
            tokenConfig = new TokenConfigurations
            {
                Audience = "sampleAudience",
                Issuer = "sampleIssuer",
                Seconds = 66666
            };
        }

        [Fact]
        public void CzyZwracaStatystyki()
        {
            string response = controller.Statystyki().Value.ToString();

            Assert.NotEqual("", response);
        }

        [Fact]
        public void CzyRejestrujeUzytkownika()
        {
            var newUser = new UzytkownikBO()
            {
                Email = "f@domena.pl",
                Haslo = "haslo789",
                Imie = "Nowy",
                Nazwisko = "Uzytkownik"
            };

            var response = controller.Zarejestruj(newUser).Value.ToString();

            Assert.Equal("Dodano użytkownika", response);
        }

        [Fact]
        public void CzyZmieniaProfil()
        {
            var user = new ClaimsPrincipal();
            var identity = new GenericIdentity("f6c5b1a5-4516-4d77-ade0-c483bcbb9466", "Login");

            user.AddIdentity(identity);

            var httpContext = Substitute.For<HttpContext>();
            httpContext.User.Returns(user);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            var editedUser = new UzytkownikBO()
            {
                Imie = "Nowy",
                Nazwisko = "Uzytkownik",
                Email = "f@domena.pl",
                Haslo = "haslo789"
            };

            var response = controller.ZmienProfil(editedUser).Value.ToString();

            Assert.Equal("Zmodyfikowano użytkownika", response);
        }
    }
}
