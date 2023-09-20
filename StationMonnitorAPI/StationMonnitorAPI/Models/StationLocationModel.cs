using System;

namespace StationMonnitorAPI.Models
{
    public class StationLocationModel
    {
        public Guid Id { get; set; }
        public string LocationName { get; set; }
        public double? Latitude { get; set; }
        public double? Langitude { get; set; }
        public double? Altitude { get; set; }
    }
}
