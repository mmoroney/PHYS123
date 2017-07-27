using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PHYS121L
{
    public static class PHYS121L
    {
        public const double l = 218.4;
        public const double h = 1.255;

        public static Measurement[] Measurements = new Measurement[]
        {
            new Measurement { Distance = 150.2, TimeValues = new double[] { 7.38, 7.38, 7.38, 7.4, 7.38 }},
            new Measurement { Distance = 200, TimeValues = new double[] { 8.33, 8.25, 8.39, 8.4, 8.58 }},
            new Measurement { Distance = 119.9, TimeValues = new double[] { 6.51, 6.52, 6.5, 6.48, 6.47 }},
            new Measurement { Distance = 20.2, TimeValues = new double[] { 2.49, 2.59, 2.56, 2.54, 2.56 }},
            new Measurement { Distance = 75.1, TimeValues = new double[] { 5.06, 5.08, 5.1, 5.09, 5.08 }},
            new Measurement { Distance = 100, TimeValues = new double[] { 5.98, 5.92, 5.97, 5.95, 5.89 }},
            new Measurement { Distance = 50, TimeValues = new double[] { 4.01, 3.98, 4.02, 4.04, 3.99 }},
            new Measurement { Distance = 175, TimeValues = new double[] { 7.76, 7.81, 7.75, 7.78, 7.76 }},
        };
    }
}
