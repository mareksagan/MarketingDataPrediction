using MarketingDataPrediction.LogicLayer;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarketingDataPrediction.Tests
{
    public class AdminControllerTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            var someClass = Substitute.For<RandomForest>("hello world");

            Assert.Equal("hello world", someClass.returnValue());
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
