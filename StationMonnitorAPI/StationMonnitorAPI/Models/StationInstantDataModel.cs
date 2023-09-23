using System.Collections.Generic;

namespace StationMonnitorAPI.Models
{
    public class StationInstantDataModel
    {
        public List<StationLocationModel> StationLocations { get; set; }
        public int Aqi { get; set; }
        public double? Pm1_0 { get; set; }
        public double? Pm2_5 { get; set; }
        public double? Pm10 { get; set; }
        public double? Co2 { get; set; }
        public StationInstantValueModel Temperature { get; set; }
        public StationInstantValueModel Humadity { get; set; }
        public StationInstantValueModel Pressure { get; set; }
        public StationInstantValueModel WindSpeed { get; set; }
        public StationInstantValueModel SolarRadiation { get; set; }
    }
}
