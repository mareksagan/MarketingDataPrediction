using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer.BusinessObjects
{
    public class StatystykiBO
    {
        public int SredniWiekKlienta { get; set; }
        public MiesiacKontaktBO[] MiesiaceKontaktu { get; set; }
        public int SredniaDlugoscKontaktu { get; set; }
    }
}
