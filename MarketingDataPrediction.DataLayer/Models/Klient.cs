using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Klient
    {
        public Guid IdKlient { get; set; }
        public int Wiek { get; set; }
        public int Stanowisko { get; set; }
        public int Smatrymonialny { get; set; }
        public int Wyksztalcenie { get; set; }
        public int Kzadluzenie { get; set; }
        public int Khipoteczny { get; set; }
        public int Kkonsumencki { get; set; }

        public Inne Inne { get; set; }
        public Kampania Kampania { get; set; }
        public WskazSocEkon WskazSocEkon { get; set; }
        public Wynik Wynik { get; set; }
    }
}
