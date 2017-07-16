using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PHYS123_3
{
    public static class Assignment3
    {
        public static IEnumerable<Point> Euler(double dt, double k, double m, double g, double duration)
        {
            double y = 0;
            double v = 0;
            double a = g - k / m * y;

            for (double t = 0; t <= duration; t += dt)
            {
                y += v * dt;
                v += a * dt;
                a = g - k / m * y;

                yield return new Point(t, y);
            }
        }

        public static IEnumerable<Point> Feynman(double dt, double k, double m, double g, double duration)
        {
            double y = 0;
            double a = g - k / m * y;
            double v = a * dt / 2;

            for (double t = 0; t <= duration; t += dt)
            {
                y += v * dt;
                a = g - k / m * y;
                v += a * dt;

                yield return new Point(t, y);
            }
        }

        public static IEnumerable<Point> Analytic(double dt, double k, double m, double g, double duration)
        {
            for (double t = 0; t <= duration; t += dt)
                yield return new Point(t, -(m * g / k) * (Math.Cos(Math.Sqrt(k / m) * t) - 1));
        }
    }
}
