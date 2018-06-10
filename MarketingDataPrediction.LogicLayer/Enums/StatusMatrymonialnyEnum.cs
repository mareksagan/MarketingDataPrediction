using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarketingDataPrediction.LogicLayer.Enums
{
    public enum StatusMatrymonialnyEnum
    {
        [Description("Single")]
        Single = 0,
        [Description("Ślub")]
        Slub = 1,
        [Description("Rozwiedziony")]
        Rozwiedziony = 2,
        [Description("Nieznany")]
        Nieznany = 3
    }
}
