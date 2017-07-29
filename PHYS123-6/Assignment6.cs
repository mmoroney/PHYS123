using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHYS123_6
{
    class Assignment6
    {
        private const double g = 9.8;
        private const double m = 80;
        private const double re = 6.37e6;

        static void Main(string[] args)
        {
            double expected = 0.8;
            double result80 = TestIntegral(80, expected);
            double result40 = TestIntegral(40, expected);

            Console.WriteLine("Using error correction formula:");
            double corrected = result80 + (result80 - result40) / 3;
            PrintResults(corrected, 0.8);

            Console.WriteLine("Analytic solution:");
            PrintResults(expected, expected);

            Console.WriteLine("Error correction reduced the 80 interval error by a factor of {0}", (result80 - expected) / (corrected - expected));
        }

        private static double TestIntegral(int intervals, double expected)
        {
            Console.WriteLine("Using {0} trapezoids:", intervals);
            double result = Integrate(z => Math.Pow(z, -2), 1, 5, intervals);
            PrintResults(result, expected);
            return result;
        }

        private static double Integrate(Func<double, double> f, double start, double end, int intervals)
        {
            double dx = (end - start) / intervals;
            double sum = dx * (f(start) + f(end)) / 2;

            for (int i = 1; i < intervals; i++)
                sum += f(start + dx * i) * dx;

            return sum;
        }

        private static void PrintResults(double result, double expected)
        {
            Console.WriteLine("Dimensionless integral:{0}\nError:{1}", result, result - expected);
            Console.WriteLine("Work done: {0} joules", result * m * g * re);
            Console.WriteLine();
        }
    }
}
