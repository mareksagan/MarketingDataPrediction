using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer
{
    public class RandomForest
    {
        string value;

        public string returnValue()
        {
            return value;
        }

        public RandomForest(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                value = "yuhu";
            }
            else if (!String.IsNullOrEmpty(input))
            {
                value = input;
            }
        }

        public string ZwrocWyniki()
        {
            return "";
        }
    }
}
