using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PHYS123_8
{
    public static class Assignment8
    {
        public static IEnumerable<Vector> FieldLine(PointMass[] pointMasses, Vector start, double ds, double xMin, double xMax, double yMin, double yMax)
        {
            Vector position = new Vector(start.X, start.Y);

            Vector g = Assignment8.g(pointMasses, start);
            Vector step = new Vector(-g.X, -g.Y) * ds / g.Length;

            while (position.X > xMin && position.X < xMax && position.Y > yMin && position.Y < yMax)
            {
                yield return position;
                position = position + step;
                g = Assignment8.g(pointMasses, position + step / 2);
                step = new Vector(-g.X, -g.Y) * ds / g.Length;
            }
        }

        public static IEnumerable<Vector> EquipotentialLine(PointMass[] pointMasses, Vector start, double ds)
        {
            Vector position = new Vector(start.X, start.Y);
            bool test = false;

            Vector g = Assignment8.g(pointMasses, start);
            Vector step = new Vector(g.Y, -g.X) * ds / g.Length;

            while (position.Y < start.Y + ds || !test)
            {
                yield return position;
                position = position + step;
                g = Assignment8.g(pointMasses, position + step / 2);
                step = new Vector(g.Y, -g.X) * ds / g.Length;
                if (position.Y < start.Y)
                    test = true;
            }
        }

        private static Vector g(PointMass[] pointMasses, Vector position)
        {
            Vector result = new Vector(0, 0);
            foreach (PointMass pointMass in pointMasses)
            {
                Vector displacement = pointMass.Position - position;
                result = result + displacement * pointMass.Mass /  (Math.Pow(displacement.Length, 3));
            }

            return result;
        }
    }

    public class PointMass
    {
        public double Mass { get; set; }
        public Vector Position { get; set; }

        public PointMass(double mass, Vector position)
        {
            this.Position = position;
            this.Mass = mass;
        }
    }
}
