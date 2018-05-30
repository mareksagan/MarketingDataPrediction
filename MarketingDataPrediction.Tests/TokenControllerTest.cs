using MarketingDataPrediction.LogicLayer.Controllers;
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
        public void CzyGenerujeToken()
        {
            var controller = new TokenController();

            //var response = controller.PobierzToken(null,null).ToString();

            Assert.NotEqual("", "");
        }
    }
}
