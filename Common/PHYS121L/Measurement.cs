using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PHYS121L
{
    public class Measurement
    {
        public double Distance;
        public double[] TimeValues;

        public override string ToString()
        {
            return string.Format("{0}\t\t{1}", this.Distance.ToString("000.0"), string.Join("\t", this.TimeValues));
        }
    }
}
