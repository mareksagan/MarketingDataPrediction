using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer.BusinessObjects
{
    public class KlientUczenieBO
    {
        public string[][] Dane { get; set; }
        public int[] Wyniki { get; set; }
        public double Blad { get; set; }
    }
}
