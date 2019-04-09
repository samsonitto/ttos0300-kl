using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using JAMK.IT;
using Newtonsoft.Json;

namespace WpfJunat
{
    public class TrainsViewModel
    {
        public static List<Train> GetTrainsAT(string station)
        {
            //haetaan tai luodaan lista junia
            List<Train> trains = new List<Train>();
            if(station == "test" || station == "")
            {
                //keksitään pari junaa testiä varten
                Train t = new Train();
                t.TrainNumber = "666";
                t.Pvm = new DateTime(2019, 4, 9);
                t.TargetStation = "Highway to Hell";
                trains.Add(t);
                return trains;
            }
            else
            {
                //muutetaan json Train-olioiksi
                string json = GetJsonFromAPI(station);
                trains = JsonConvert.DeserializeObject<List<Train>>(json);
                return trains;
            }
        }
        private static string GetJsonFromAPI(string what)
        {
            try
            {
                string url = "";
                if (what == "stations")
                    url = @"http://rata.digitraffic.fi/api/v1/metadata/station";
                else
                    url = @"http://rata.digitraffic.fi/api/v1/live-trains?station=" + what;
                //käytetään webbiclientia tiedon hakuun
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(url);
                    return json;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
