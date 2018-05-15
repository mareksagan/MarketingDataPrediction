using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MarketingDataPrediction.DataLayer.Enums
{
    public enum WyksztalcenieEnum
    {
        Analfabeta = 0,

        [Description("Kurs zawodowy")]
        KursZawodowy = 1,

        [Description("Podstawowe, 4-letnie")]
        Podstawowe4Letnie = 2,

        [Description("Podstawowe, 6-letnie")]
        Podstawowe6Letnie = 3,

        [Description("Podstawowe, 9-letnie")]
        Podstawowe9Letnie = 4,

        [Description("Średnie")]
        Srednie = 5,

        [Description("Po studiach")]
        Wyzsze = 6,

        Nieznane = 7
    }
}
