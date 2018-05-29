using Accord.MachineLearning.DecisionTrees;
using Accord.Math;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingDataPrediction.LogicLayer
{
    public class RandomForestHelper
    {
        private double IloscDanychModelu;
        private int[] KolumnaWynikow;
        private int[] Rezultaty;
        
        public RandomForestHelper(double iloscDanychModelu)
        {
            KolumnaWynikow = null;
            Rezultaty = null;
            IloscDanychModelu = iloscDanychModelu;
        }

        public void Uczenie(string[] naglowki, string[][] dane)
        {
            Codification kody = new Codification(naglowki, dane);

            int[][] symbole = kody.Transform(dane);
            int[][] daneWejsciowe = symbole.Get(null, 0, -1);

            KolumnaWynikow = symbole.GetColumn(-1);

            RandomForestLearning teacher = new RandomForestLearning()
            {
                SampleRatio = IloscDanychModelu
            };

            RandomForest forest = teacher.Learn(daneWejsciowe, KolumnaWynikow);

            Rezultaty = forest.Decide(daneWejsciowe);
        }

        public double PoliczBlad()
        {
            return new ZeroOneLoss(KolumnaWynikow).Loss(Rezultaty);
        }

        public int[] ZwrocWyniki()
        {
            return Rezultaty;
        }
    }
}
