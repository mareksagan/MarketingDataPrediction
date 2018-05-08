using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Inne
    {
        public int IdInne { get; set; }
        public Guid IdKlient { get; set; }
        public int? IloscProbAkt { get; set; }
        public int? IloscDni { get; set; }
        public int? IloscProb { get; set; }
        public int? PopRezultat { get; set; }

        public Klient IdKlientNavigation { get; set; }
    }
}
