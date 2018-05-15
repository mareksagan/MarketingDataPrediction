using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer.DTOs
{
    public class KlientWynikUczeniaDTO
    {
        public string Id { get; set; }
        public int Wiek { get; set; }
        public string Wyksztalcenie { get; set; }
        public string Hipoteka { get; set; }
        public string Kredyt { get; set; }
        public string Wynik { get; set; }
}
}
