using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Wynik
    {
        public int IdWynik { get; set; }
        public Guid IdKlient { get; set; }
        public int? Rezultat { get; set; }

        public Klient IdKlientNavigation { get; set; }
    }
}
