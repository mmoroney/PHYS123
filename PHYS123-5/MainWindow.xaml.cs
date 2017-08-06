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
using Common.PHYS121L;

namespace PHYS123_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Assignment5Result result = Assignment5.Analyze(PHYS121L.l, PHYS121L.h, PHYS121L.Measurements);
            this.textBlock.Text = string.Format("Slope is {0}\nIntercept is {1}\nGravity is {2} m/s^2\nStandard deviation is {3}", result.LeastSquaresFitResult.Slope,
                result.LeastSquaresFitResult.Intercept, result.g, result.StandardDeviation);

            Point[] points = new Point[]
            {
                new Point(this.Chart.XMin, result.LeastSquaresFitResult.Intercept),
                new Point(this.Chart.XMax, result.LeastSquaresFitResult.Intercept + result.LeastSquaresFitResult.Slope * this.Chart.XMax)
            };

            this.Chart.AddLinePlot(points);
            this.Chart.AddCirclePlot(PHYS121L.Measurements.Select(m => new Point(m.Distance, m.TimeValues.Average(t => t * t))), 12);
        }
    }
}
