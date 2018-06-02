using System;

namespace MarketingDataPrediction.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }

        public static implicit operator ValueTuple(TokenConfigurations v)
        {
            throw new NotImplementedException();
        }
    }
}
