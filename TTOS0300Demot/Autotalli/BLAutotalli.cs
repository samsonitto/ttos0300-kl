using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
            try
            {
                //haetaan autoja tietokannasta DB-kerroksesta ja muutetaan ne olioiksi (ORM)
                List<Auto> autot = new List<Auto>();
                DataTable dt = JAMK.IT.TTOS0300.DB2.GetAutos();
                //ORM tietueet muutetaan olioiksi
                foreach(DataRow dr in dt.Rows)
                {
                    Auto auto = new Auto();
                    auto.Merkki = dr[0].ToString();
                    auto.Malli = dr[1].ToString();
                    auto.VM = int.Parse(dr[2].ToString());
                    auto.KM = int.Parse(dr[3].ToString());
                    auto.Hinta = float.Parse(dr[4].ToString());
                    auto.URL = dr[5].ToString();
                    autot.Add(auto);
                }
                return autot;
            }
            catch
            {
                throw;
            }
        }
        public static List<Auto> HaeTestiAutot()
        {
            List<Auto> autot = new List<Auto>();
            autot.Add(new Auto("Tesla", "Model S", 2016, 50000, 80000F, "teslaS.jpg"));
            autot.Add(new Auto("Tesla", "Model 3", 2019, 10000, 35000F, "tesla3.jpg"));
            autot.Add(new Auto("Tesla", "Model X", 2018, 20000, 120000F, "teslaX.jpg"));
            autot.Add(new Auto("Tesla", "Model Y", 2020, 0, 50000F, "teslaY.jpg"));
            autot.Add(new Auto("Audi", "A4", 2017, 20000, 39900F, "audiA4.jpg"));
            autot.Add(new Auto("Lada", "Niva", 2018, 5000, 30000F, "ladaNiva.jpg"));
            autot.Add(new Auto("Renault", "Clio", 2012, 200000, 5000F,""));
            return autot;
        }
    }
}
