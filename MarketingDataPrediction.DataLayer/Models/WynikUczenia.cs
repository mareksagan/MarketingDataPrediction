using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class WynikUczenia
    {
        public int IdWynikUczenia { get; set; }
        public Guid IdKlient { get; set; }
        public int RezultatUczenia { get; set; }

        public Klient IdKlientNavigation { get; set; }
    }
}
