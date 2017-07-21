using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHYS123_4
{
    class Assignment4
    {
        private static Assignment4Data[] Data121L = new Assignment4Data[]
        {
            new Assignment4Data { Distance = 150.2, TimeValues = new double[] { 7.38, 7.38, 7.38, 7.4, 7.38 }},
            new Assignment4Data { Distance = 200, TimeValues = new double[] { 8.33, 8.25, 8.39, 8.4, 8.58 }},
            new Assignment4Data { Distance = 119.9, TimeValues = new double[] { 6.51, 6.52, 6.5, 6.48, 6.47 }},
            new Assignment4Data { Distance = 20.2, TimeValues = new double[] { 2.49, 2.59, 2.56, 2.54, 2.56 }},
            new Assignment4Data { Distance = 75.1, TimeValues = new double[] { 5.06, 5.08, 5.1, 5.09, 5.08 }},
            new Assignment4Data { Distance = 100, TimeValues = new double[] { 5.98, 5.92, 5.97, 5.95, 5.89 }},
            new Assignment4Data { Distance = 50, TimeValues = new double[] { 4.01, 3.98, 4.02, 4.04, 3.99 }},
            new Assignment4Data { Distance = 175, TimeValues = new double[] { 7.76, 7.81, 7.75, 7.78, 7.76 }},
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Distance\t5 time values");
            Console.WriteLine();

            foreach (Assignment4Data data in Assignment4.Data121L)
                Console.WriteLine(data);

            Console.WriteLine();

            Console.WriteLine("Distance\tAverage t^2\t\tStandard deviation");
            Console.WriteLine();

            foreach (Assignment4Data data in Assignment4.Data121L)
            {
                double mean = data.TimeValues.Average(t => t * t);
                double stddev = Math.Sqrt(data.TimeValues.Sum(t => Math.Pow(t * t - mean, 2)) / (data.TimeValues.Length - 1));
                Console.WriteLine(string.Join("\t\t", data.Distance.ToString("000.0"), mean.ToString("00.00000000"), stddev));
            }
        }
    }

    public struct Assignment4Data
    {
        public double Distance;
        public double[] TimeValues;

        public override string ToString()
        {
            return string.Format("{0}\t\t{1}", this.Distance.ToString("000.0"), string.Join("\t", this.TimeValues));
        }
    }
}
