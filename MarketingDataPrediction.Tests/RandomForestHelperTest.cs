using MarketingDataPrediction.LogicLayer;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarketingDataPrediction.Tests
{
    public class RandomForestHelperTest
    {
        public RandomForestHelper rfh { get; set; }

        public string[] naglowki = { "naglowek1", "naglowek2" };

        public string[][] dane =
        {
            new string[] {"a1","a2"},
            new string[] {"a3","a4"}
        };

        public RandomForestHelperTest()
        {
            rfh = new RandomForestHelper(0.75);
            rfh.Uczenie(naglowki, dane);
        }

        [Fact]
        public void CzyZwracaPopIloscWynikow()
        {
            var wyniki = rfh.ZwrocWyniki();

            Assert.Equal(2, wyniki.Length);
        }

        [Fact]
        public void CzyBladZerowy()
        {
            var blad = rfh.PoliczBlad();

            Assert.NotEqual(0.0, blad);
        }
    }
}
