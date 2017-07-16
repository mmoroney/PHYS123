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

namespace PHYS123_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double dt = 0.01;
            double k = 10;
            double m = 1;
            double g = -9.8;
            double duration = 6;

            IEnumerable<Point>[] data = new IEnumerable<Point>[]
            {
                Assignment3.Euler(dt, k, m, g, duration),
                Assignment3.Feynman(dt, k, m, g, duration),
                Assignment3.Analytic(dt, k, m, g, duration)
            };

            this.Chart.Data = data;
        }
    }
}
