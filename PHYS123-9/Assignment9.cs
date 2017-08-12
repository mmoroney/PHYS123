using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PHYS123_9
{
    public static class Assignment9
    {
        public static IEnumerable<Point> BouncingBall(double e, double v, double dz, double zMax, double phiMin, double phiMax)
        {
            double phi = 0;
            double a = 0;
            double z = 0;

            while(z <= zMax && phi >= phiMin && phi <= phiMax)
            {
                phi += v * dz;
                z += dz;
                a = -Math.Pow(e, 3) * (1 - z) * phi;
                v += a * dz;
                yield return new Point(z, phi);
            }
        }
    }
}
