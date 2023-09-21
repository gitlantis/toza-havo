using System;
using System.Collections.Generic;

namespace StationMonnitorAPI.Models
{
    public class DynamicChartsDataModel
    {
        public List<double[]> BoxPlot { get; set; }
        public List<double[]> Heatmap { get; set; }
        public List<DateTime> Days { get; set; }
        public double? BoxplotMedian{ get; set; }

    }
}
