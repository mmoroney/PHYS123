using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHYS123_7
{
    public static class Assignment7
    {
        static void Main(string[] args)
        {
            const int id = 88089707;
            const int Intervals = 80;
            const int degrees = 50 + (id % 100);
            const double radians = Math.PI * degrees / 180;

            double s = SmallAngleIntegral(Intervals);
            double l = LargeAngleIntegral(radians, Intervals);
            double increase = (l - s) / s  * 100;

            Console.WriteLine("Small angle integral: {0}", s);
            Console.WriteLine("Integral for angle = {0} degrees: {1}", degrees, l);
            Console.WriteLine("Percentage is {0}", increase);
        }

        private static double LargeAngleIntegral(double amplitude, int intervals)
        {
            return IntegrateReciprocal(x => Math.Sqrt(Math.Max(Math.Cos(x) - Math.Cos(amplitude), 0)), 0, amplitude, intervals);
        }

        private static double SmallAngleIntegral(int intervals)
        {
            return Math.Sqrt(2) * IntegrateReciprocal(x => Math.Sqrt(1.0 - x * x), 0, 1, intervals);
        }

        private static double IntegrateReciprocal(Func<double, double> f, double start, double end, int intervals)
        {
            double dx = (end - start) / intervals;
            double sum = 0;

            for (int i = 0; i < intervals; i++)
            {
                double x = start + dx * i;
                sum += dx * 2.0 / (f(x) + f(x + dx));
            }

            return sum;
        }
    }
}
