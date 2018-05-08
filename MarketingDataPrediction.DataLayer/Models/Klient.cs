using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Inne = new HashSet<Inne>();
            Kampania = new HashSet<Kampania>();
            WskazSocEkon = new HashSet<WskazSocEkon>();
            Wynik = new HashSet<Wynik>();
            WynikUczenia = new HashSet<WynikUczenia>();
        }

        public Guid IdKlient { get; set; }
        public int? Wiek { get; set; }
        public int? Stanowisko { get; set; }
        public int? Smatrymonialny { get; set; }
        public int? Wyksztalcenie { get; set; }
        public int? Kzadluzenie { get; set; }
        public int? Khipoteczny { get; set; }
        public int? Kkonsumencki { get; set; }

        public ICollection<Inne> Inne { get; set; }
        public ICollection<Kampania> Kampania { get; set; }
        public ICollection<WskazSocEkon> WskazSocEkon { get; set; }
        public ICollection<Wynik> Wynik { get; set; }
        public ICollection<WynikUczenia> WynikUczenia { get; set; }
    }
}
