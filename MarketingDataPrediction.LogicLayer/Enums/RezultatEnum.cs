using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarketingDataPrediction.LogicLayer.Enums
{
    public enum RezultatEnum
    {
        [Description("Porażka")]
        Porazka = 0,
        [Description("Sukces")]
        Sukces = 1,
        [Description("Nieznany")]
        Nieznany = 2
    }
}
