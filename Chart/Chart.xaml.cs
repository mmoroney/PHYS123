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

namespace Chart
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Chart : UserControl
    {
        private static Color[] colors = new Color[]
        {
            Colors.Red,
            Colors.Green,
            Colors.Blue
        };

        public int XMin { get; set; }
        public int XMax { get; set; }
        public int YMin { get; set; }
        public int YMax { get; set; }

        public IEnumerable<Point>[] Data
        {
            set
            {
                for (int i = this.XMin + 1; i < this.XMax; i++)
                    this.AddLine(new Point(i, this.YMin), new Point(i, this.YMax));

                for (int i = this.YMin + 1; i < this.YMax; i++)
                    this.AddLine(new Point(this.XMin, i), new Point(this.XMax, i));

                Matrix matrix = this.GetMatrix();

                for (int i = 0; i < value.Length; i++)
                {
                    PointCollection pointCollection = new PointCollection();
                    foreach (Point point in value[i])
                        pointCollection.Add(matrix.Transform(point));

                    Polyline polyLine = new Polyline();
                    polyLine.Stroke = new SolidColorBrush(Chart.colors[i]);

                    polyLine.Points = pointCollection;
                    this.canvas.Children.Add(polyLine);
                }

            }
        }

        private Matrix GetMatrix()
        {
            double scaleX = this.Width / (this.XMax - this.XMin);
            double scaleY = -this.Height / (this.YMax - this.YMin);
            Matrix matrix = new Matrix();
            matrix.Scale(scaleX, scaleY);
            matrix.OffsetX = this.XMin * scaleX;
            matrix.OffsetY = -this.YMax * scaleY;

            return matrix;
        }

        private void AddLine(Point point1, Point point2)
        {
            Matrix matrix = this.GetMatrix();
            point1 = matrix.Transform(point1);
            point2 = matrix.Transform(point2);

            Line line = new Line();
            line.X1 = point1.X;
            line.X2 = point2.X;
            line.Y1 = point1.Y;
            line.Y2 = point2.Y;
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 1;

            this.canvas.Children.Add(line);
        }

        public Chart()
        {
            InitializeComponent();
        }
    }
}
