using System;
using System.Collections.Generic;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class Parametry
    {
        public int IdParametry { get; set; }
        public int Ziarno { get; set; }
        public int? IloscParam { get; set; }
        public int? IloscDrzew { get; set; }
        public int? WielkoscLiscia { get; set; }
    }
}
