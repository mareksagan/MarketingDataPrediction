using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class WskazSocEkon
    {
        public Guid IdKlient { get; set; }
        public float Cev { get; set; }
        public float Cpi { get; set; }
        public float Cci { get; set; }
        public float Euribor3m { get; set; }
        public int IloscPrac { get; set; }

        public Klient IdKlientNavigation { get; set; }
    }
}
