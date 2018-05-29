using MarketingDataPrediction.LogicLayer;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarketingDataPrediction.Tests
{
    public class TokenControllerTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            var someClass = Substitute.For<RandomForestHelper>("hello world");

            Assert.Equal("hello world", someClass.PoliczBlad().ToString());
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
