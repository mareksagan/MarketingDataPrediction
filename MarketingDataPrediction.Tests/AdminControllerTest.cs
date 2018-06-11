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
                new Uzytkownik { IdUzytkownik = Guid.Parse("2f15b775-a345-4445-b91b-c4cb965c12b8"), Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "a@a.pl", Haslo = "haslo", Admin = true},
                new Uzytkownik { IdUzytkownik = Guid.Parse("3726ab5d-89bf-45ac-a3cc-191dbd200274"), Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "b@a.pl", Haslo = "haslo", Admin = false},
                new Uzytkownik { IdUzytkownik = Guid.Parse("f6c5b1a5-4516-4d77-ade0-c483bcbb9466"), Imie = "PrzykladoweImie", Nazwisko = "PrzykladoweNazwisko", Email = "c@a.pl", Haslo = "haslo", Admin = false}
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

            Assert.Equal("Dodano użytkownika", response);
        }

        [Fact]
        public void CzyEdytujeUzytkownika()
        {
            var editedUser = new Uzytkownik()
            {
                IdUzytkownik = Guid.NewGuid(),
                Email = "f@domena.pl",
                Haslo = "haslo789",
                Imie = "Nowy",
                Nazwisko = "Uzytkownik",
                Admin = false
            };

            var response = controller.EdytujUzytkownika(editedUser).Value.ToString();

            Assert.Equal("Zmodyfikowano użytkownika", response);
        }

        [Fact]
        public void CzyPobieraUzytkownika()
        {
            var response = controller.PobierzUzytkownika(Guid.Parse("2f15b775-a345-4445-b91b-c4cb965c12b8")).Value.ToString();

            Assert.NotEqual("", response);
        }

        [Fact]
        public void CzyZwracaListeUzytkownikow()
        {
            var response = controller.ListaUzytkownikow().Value.ToString();

            Assert.NotEqual("", response);
        }

        [Fact]
        public void CzyUsuwaUzytkownika()
        {
            Guid userId = Guid.Parse("2f15b775-a345-4445-b91b-c4cb965c12b8");

            var response = controller.UsunUzytkownika(userId).Value.ToString();

            Assert.Equal("Usunięto użytkownika", response);
        }

        [Fact]
        public void CzyZwracaStatystykiSystemu()
        {
            var response = controller.StatystykiSystemu().Value.ToString();

            Assert.NotEqual("", response);
        }
    }
}
