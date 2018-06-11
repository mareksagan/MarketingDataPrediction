using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer.BusinessObjects
{
    public class UzytkownikListaBO
    {
        public Guid IdUzytkownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Admin { get; set; }
    }
}
