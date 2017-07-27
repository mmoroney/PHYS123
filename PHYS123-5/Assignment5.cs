using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.PHYS121L;

namespace PHYS123_5
{
    public static class Assignment5
    {
        public static Assignment5Result Analyze(double l, double h, Measurement[] measurements)
        {
            Point[] points = measurements.Select(m => new Point(m.Distance, m.TimeValues.Average(t => t * t))).ToArray();
            LeastSquaresFitResult result = Assignment5.LeastSquaresFit(points);

            return new Assignment5Result
            {
                LeastSquaresFitResult = result,
                g = 2 * l /  (result.Slope * h) / 100,
                StandardDeviation = Assignment5.StandardDeviationY(points, result)
            };
        }

        public static LeastSquaresFitResult LeastSquaresFit(Point[] points)
        {
            double xMean = points.Average(p => p.X);
            double yMean = points.Average(p => p.Y);

            double slope = points.Sum(p => (p.X - xMean) * (p.Y - yMean)) / points.Sum(p => Math.Pow(p.X - xMean, 2));
            double intercept = yMean - slope * xMean;
            double standardDeviation = 0;

            return new LeastSquaresFitResult { Slope = slope, Intercept = intercept, StandardDeviation = standardDeviation };
        }

        public static double StandardDeviationY(Point[] points, LeastSquaresFitResult result)
        {
            return Math.Sqrt(points.Sum(p => Math.Pow(p.Y - (result.Intercept + result.Slope * p.X), 2)) / (points.Length - 2));
        }
    }

    public class Assignment5Result
    {
        public LeastSquaresFitResult LeastSquaresFitResult { get; set; }
        public double g { get; set; }
        public double StandardDeviation { get; set; }
    }

    public class LeastSquaresFitResult
    {
        public double Slope { get; set; }
        public double Intercept { get; set; }
        public double StandardDeviation { get; set; }
    }
}
