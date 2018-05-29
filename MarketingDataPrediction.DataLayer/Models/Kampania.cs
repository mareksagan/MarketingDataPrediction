using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Kampania
    {
        public Guid IdKlient { get; set; }
        public int RodzajKontaktu { get; set; }
        public int MiesiacKontaktu { get; set; }
        public int DzienKontaktu { get; set; }
        public int DlugoscKontaktu { get; set; }

        public Klient IdKlientNavigation { get; set; }
    }
}
