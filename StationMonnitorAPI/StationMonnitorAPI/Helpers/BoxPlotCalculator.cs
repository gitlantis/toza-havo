using System;
using System.Linq;

namespace StationMonnitorAPI.Helpers
{
    public class BoxPlotCalculator
    {
        public static BoxPlotStatistics CalculateBoxPlotStatistics(double[] data)
        {
            var statistics = new BoxPlotStatistics();

            if (data.Length < 5)
                return statistics;

            // Sort the data
            Array.Sort(data);

            // Calculate the median
            statistics.Median = CalculateMedian(data);

            // Calculate the lower quartile (Q1)
            int lowerQuartileIndex = data.Length / 4;
            statistics.LowerQuartile = CalculateMedian(data.Take(lowerQuartileIndex).ToArray());

            // Calculate the upper quartile (Q3)
            int upperQuartileIndex = data.Length * 3 / 4;
            statistics.UpperQuartile = CalculateMedian(data.Skip(upperQuartileIndex).ToArray());

            // Calculate the minimum and maximum
            statistics.Minimum = data.First();
            statistics.Maximum = data.Last();

            return statistics;
        }

        public static double CalculateBoxPlotsMedian(double[][] data)
        {
            var result = 0.0;

            var i = 0;
            foreach(var item in data)
            {
                result += item[2];
                i++;
            }

            return result/i;
        }

        static double CalculateMedian(double[] data)
        {
            int middle = data.Length / 2;
            if (data.Length % 2 == 0)
            {
                return (data[middle - 1] + data[middle]) / 2.0;
            }
            else
            {
                return data[middle];
            }
        }
    }
}

public class BoxPlotStatistics
{
    public double Minimum { get; set; }
    public double Maximum { get; set; }
    public double Median { get; set; }
    public double LowerQuartile { get; set; }
    public double UpperQuartile { get; set; }
}