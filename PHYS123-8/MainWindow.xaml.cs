using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Common;

namespace PHYS123_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PointMass[] pointMasses = new PointMass[] {
                new PointMass(3, new Vector(2, 3)),
                new PointMass(1, new Vector(6, 3))
            };

            double[] radii = new double[] { 0.6, 0.2 };

            for (int i = 0; i < pointMasses.Length; i++)
                this.AddCircle(pointMasses[i], radii[i] * 100);

            double ds = 0.1;

            this.Chart.AddLinePlot(Assignment8.EquipotentialLine(pointMasses, new Vector(6.9, 3), ds).Select(v => new Point(v.X, v.Y)));

            for(int i = 1; i <= 6; i++)
            {
                double angle = 0.5 + i;
                Vector position = pointMasses[1].Position + new Vector(Math.Cos(angle), Math.Sin(angle)) * radii[1];
                this.Chart.AddLinePlot(
                    Assignment8.FieldLine(pointMasses, position, ds, this.Chart.XMin, this.Chart.XMax, this.Chart.YMin, this.Chart.YMax)
                    .Select(v => new Point(v.X, v.Y)));
            }
        }

        private void AddCircle(PointMass pointMass, double radius)
        {
            this.Chart.AddCirclePlot(new Point[] { new Point(pointMass.Position.X, pointMass.Position.Y) }, radius);
        }
    }
}
