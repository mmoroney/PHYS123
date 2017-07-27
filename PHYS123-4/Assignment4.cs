using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.PHYS121L;

namespace PHYS123_4
{
    class Assignment4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distance\t5 time values");
            Console.WriteLine();

            foreach (Measurement measurement in PHYS121L.Measurements)
                Console.WriteLine(measurement);

            Console.WriteLine();

            Console.WriteLine("Distance\tAverage t^2\t\tStandard deviation");
            Console.WriteLine();

            foreach (Measurement measurement in PHYS121L.Measurements)
            {
                double mean = measurement.TimeValues.Average(t => t * t);
                double stddev = Math.Sqrt(measurement.TimeValues.Sum(t => Math.Pow(t * t - mean, 2)) / (measurement.TimeValues.Length - 1));
                Console.WriteLine(string.Join("\t\t", measurement.Distance.ToString("000.0"), mean.ToString("00.00000000"), stddev));
            }
        }
    }
}
