using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHYS123_2
{
    class Assignment2
    {
        static void Main(string[] args)
        {
            double k = 10;
            double m = 1;
            double g = 10;
            double h = 1.75;

            Console.WriteLine("Euler Algorithm");
            TestAlgorithm(0.01, dt => EulerAlgorithm(dt, k, m, g, h));
            Console.WriteLine("\nFeynman Algorithm");
            TestAlgorithm(0.01, dt => FeynmanAlgorithm(dt, k, m, g, h));
            Console.WriteLine("\nAnalytic Solution");
            Assignment2Result analytic = Analytic(k, m, g, h);
            Console.WriteLine("\t\t{0}", analytic);
        }

        public static void TestAlgorithm(double dt, Func<double, Assignment2Result> algorithm)
        {
            Assignment2Result result1 = algorithm(dt);
            Assignment2Result result2 = algorithm(dt / 2);
            Assignment2Result result3 = new Assignment2Result { t = Estimate(result2.t, result1.t), v = Estimate(result2.v, result1.v) };

            Console.WriteLine("dt = {0}\t{1}", dt, result1);
            Console.WriteLine("dt = {0}\t{1}", dt / 2, result2);
            Console.WriteLine("Estimated\t{0}", result3);
        }

        public static double Estimate(double s1, double s2)
        {
            return s1 + (s1 - s2) / 3;
        }

        public static Assignment2Result EulerAlgorithm(double dt, double k, double m, double g, double h)
        {
            double t = 0;
            double x = 0;
            double v = 0;
            double a = g - k / m * x;

            while (x < h)
            {
                t += dt;
                x += v * dt;
                v += a * dt;
                a = g - k / m * x;
            }

            double tc = (x - h) / v;
            t -= tc;
            v -= a * tc;

            return new Assignment2Result { t = t, v = v };
        }

        public static Assignment2Result FeynmanAlgorithm(double dt, double k, double m, double g, double h)
        {
            double t = 0;
            double x = 0;
            double a = g - k / m * x;
            double v = a * dt / 2;

            while (x < h)
            {
                t += dt;
                x += v * dt;
                a = g - k / m * x;
                v += a * dt;
            }

            v -= a * dt / 2;

            double tc = (x - h) / v;
            t -= tc;
            v -= a * tc;

            return new Assignment2Result { t = t, v = v };
        }

        public static Assignment2Result Analytic(double k, double m, double g, double h)
        {
            double t = Math.Sqrt(m / k) * Math.Acos(1 - k * h / (m * g));
            double v = Math.Sqrt(m / k) * g * Math.Sin(Math.Sqrt(k / m) * t);

            return new Assignment2Result { t = t, v = v };
        }
    }

    public struct Assignment2Result
    {
        public double t { get; set; }
        public double v { get; set; }

        public override string ToString()
        {
            return string.Format("time = {0}\tvelocity={1}", this.t, this.v);
        }
    }
}
