using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer
{
    public class RandomForestHelper
    {
        DbContext _db;

        public RandomForestHelper(DbContext db)
        {
            _db = db;
        }

        public string RozpocznijUczenie()
        {
            return "";
        }

        public string PoliczStatystyki()
        {
            return "";
        }

        public string ZwrocWyniki()
        {
            return "";
        }
    }
}
