using System;
using Newtonsoft.Json;

namespace JAMK.IT
{
    public class Train
    {
        public string TrainNumber { get; set; }
        [JsonProperty("cancelled")]
        public bool Peruutettu { get; set; }
        [JsonProperty("departureDate")]
        public DateTime Pvm { get; set; }
        public string TargetStation { get; set; }
    }
    public class Station
    {
        [JsonProperty("stationName")]
        public string Name { get; set; }
        [JsonProperty("stationShortCode")]
        public string Code { get; set; }
        public Station(string koodi, string kaupunki)
        {
            this.Code = koodi;
            this.Name = kaupunki;
        }
    }

}