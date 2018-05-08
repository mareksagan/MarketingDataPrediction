using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Kampania
    {
        public int IdKampania { get; set; }
        public Guid IdKlient { get; set; }
        public int? RodzajKontaktu { get; set; }
        public int? MiesiacKontaktu { get; set; }
        public int? DzienKontaktu { get; set; }
        public int? DlugoscKontaktu { get; set; }

        public Kampania IdKampaniaNavigation { get; set; }
        public Klient IdKlientNavigation { get; set; }
        public Kampania InverseIdKampaniaNavigation { get; set; }
    }
}
