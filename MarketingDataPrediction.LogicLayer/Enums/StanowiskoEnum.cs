using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarketingDataPrediction.LogicLayer.Enums
{
    public enum StanowiskoEnum
    {
        [Description("Bezrobotny")]
        Bezrobotny = 0,
        [Description("Student")]
        Student = 1,
        [Description("Samozatrudniony")]
        Samozatrudniony = 2,
        [Description("Sprzątaczka")]
        Sprzataczka = 3,
        [Description("Robotnik")]
        Robotnik = 4,
        [Description("Technik")]
        Technik = 5,
        [Description("Usługi")]
        Uslugi = 6,
        [Description("Administracja")]
        Administracja = 7,
        [Description("Kierownik")]
        Kierownik = 8,
        [Description("Przedsiębiorca")]
        Przedsiebiorca = 9,
        [Description("Emeryt")]
        Emeryt = 10,
        [Description("Nieznany")]
        Nieznany = 11
    }
}
