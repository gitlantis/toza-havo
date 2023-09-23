using System.Collections.Generic;

namespace StationMonnitorAPI.Models
{
    public class StationInstantValueModel
    {
        public double? CurrentValue { get; set; }
        public double? SubCurrentValue { get; set; }
        public double? Min { get; set; }
        public double? Avg { get; set; }
        public double? Max { get; set; }
    }
}
