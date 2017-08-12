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

namespace PHYS123_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static double E1 = 2.3368632;
        private static double E2 = 4.07630700273639;

        public MainWindow()
        {
            InitializeComponent();

            double dz = 0.05;
            double v = 3;

            for(int i = -1; i < 2; i++)
                this.Chart.AddLinePlot(Assignment9.BouncingBall(E1 *(1 + 0.001 * i), v, dz, this.Chart.XMax, this.Chart.YMin, this.Chart.YMax));

            this.Chart.AddLinePlot(Assignment9.BouncingBall(E2, v, dz, this.Chart.XMax, this.Chart.YMin, this.Chart.YMax));

            this.textBlock.Text = string.Format("Ratio of E2/E1 is {0}", E2 / E1);
        }
    }
}
