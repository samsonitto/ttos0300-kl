﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTOS0300
{
    public class Auto
    {
        //PROPERTIES
        public string Merkki { get; set; }
        public string Malli { get; set; }
        public int VM { get; set; }
        public int KM { get; set; }
        public float Hinta { get; set; }
        public string URL { get; set; }

        //CONSTRUCTORS
        public Auto()
        {

        }
        public Auto(string merkki, string malli, int vm, int km, float hinta, string url)
        {
            Merkki = merkki;
            Malli = malli;
            VM = vm;
            KM = km;
            Hinta = hinta;
            URL = url;
        }

        //METHODS
        public override string ToString()
        {
            return $"{Merkki} {Malli} {VM} {KM} {Hinta} {URL}";
        }
    }

    public static class Autotalli
    {
        public static List<Auto> HaeAutot()
        {
            List<Auto> autot = new List<Auto>();
            autot.Add(new Auto("Tesla", "Model S", 2016, 50000, 80000F, "teslaS.jpg"));
            autot.Add(new Auto("Tesla", "Model 3", 2019, 10000, 35000F, "tesla3.jpg"));
            autot.Add(new Auto("Tesla", "Model X", 2018, 20000, 120000F, "teslaX.jpg"));
            autot.Add(new Auto("Tesla", "Model Y", 2020, 0, 50000F, "teslaY.jpg"));
            autot.Add(new Auto("Audi", "A4", 2017, 20000, 39900F, "audiA4.jpg"));
            autot.Add(new Auto("Lada", "Niva", 2018, 5000, 30000F, "ladaNiva.jpg"));
            return autot;
        }
    }
}
