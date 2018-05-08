using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Uzytkownik
    {
        public Guid IdUzytkownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public DateTime? OstLogowanie { get; set; }
    }
}
