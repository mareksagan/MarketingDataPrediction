using MarketingDataPrediction.DataLayer.Models;
using MarketingDataPrediction.LogicLayer.BusinessObjects;
using MarketingDataPrediction.LogicLayer.Controllers;
using MarketingDataPrediction.Security;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MarketingDataPrediction.Tests
{
    public class AdminControllerTest
    {
        public AdminController controller { get; set; }
        public MarketingDataPredictionDbContext mockContext { get; set; }
        public TokenConfigurations tokenConfig { get; set; }
        public SigningConfigurations signingConfig { get; set; }

        public AdminControllerTest()
        {
            IQueryable<Uzytkownik> dane = new List<Uzytkownik>
            {
                new Uzytkownik { IdUzytkownik = 1, Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "a@a.pl", Haslo = "haslo", Admin = true},
                new Uzytkownik { IdUzytkownik = 2, Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "b@a.pl", Haslo = "haslo", Admin = false},
                new Uzytkownik { IdUzytkownik = 3, Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "c@a.pl", Haslo = "haslo", Admin = false}
            }.AsQueryable();

            var mockSet = Substitute.For<DbSet<Uzytkownik>, IQueryable<Uzytkownik>>();

            ((IQueryable<Uzytkownik>)mockSet).Provider.Returns(dane.Provider);
            ((IQueryable<Uzytkownik>)mockSet).Expression.Returns(dane.Expression);
            ((IQueryable<Uzytkownik>)mockSet).ElementType.Returns(dane.ElementType);
            ((IQueryable<Uzytkownik>)mockSet).GetEnumerator().Returns(dane.GetEnumerator());

            mockContext = Substitute.For<MarketingDataPredictionDbContext>();
            mockContext.Uzytkownik.Returns(mockSet);

            controller = new AdminController(mockContext);

            signingConfig = new SigningConfigurations();
            tokenConfig = new TokenConfigurations
            {
                Audience = "sampleAudience",
                Issuer = "sampleIssuer",
                Seconds = 66666
            };
        }

        [Fact]
        public void CzyDodajeUzytkownika()
        {
            var newUser = new AdminBO()
            {
                Email = "f@domena.pl",
                Haslo = "haslo789",
                Imie = "Nowy",
                Nazwisko = "Uzytkownik",
                Admin = true
            };

            var response = controller.DodajUzytkownika(newUser).Value.ToString();

            Assert.Equal("User added", response);
        }

        [Fact]
        public void CzyEdytujeUzytkownika()
        {
            var editedUser = new Uzytkownik()
            {
                IdUzytkownik = 666,
                Email = "f@domena.pl",
                Haslo = "haslo789",
                Imie = "Nowy",
                Nazwisko = "Uzytkownik",
                Admin = false
            };

            var response = controller.EdytujUzytkownika(editedUser).Value.ToString();

            Assert.Equal("User updated", response);
        }

        [Fact]
        public void CzyUsuwaUzytkownika()
        {
            int userId = 2;

            var response = controller.UsunUzytkownika(userId).Value.ToString();

            Assert.Equal("User deleted", response);
        }

        [Fact]
        public void CzyZwracaStatystykiSystemu()
        {
            var response = controller.StatystykiSystemu().Value.ToString();

            Assert.NotEqual("", response);
        }
    }
}
