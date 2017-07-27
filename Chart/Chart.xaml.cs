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
        private IEnumerable<Point>[] data = new IEnumerable<Point>[] { };
        private IEnumerable<Point> circles = new Point[] { };
        private const int Radius = 12;

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
        public int NX { get; set; }
        public int NY { get; set; }

        public IEnumerable<Point>[] Data
        {
            set
            {
                this.data = value;
                this.Redraw();
            }
        }

        public IEnumerable<Point> Circles
        {
            set
            {
                this.circles = value;
                this.Redraw();
            }
        }

        private void Redraw()
        {
            this.canvas.Children.Clear();

            for (int i = 1; i < this.NX; i++)
            {
                double x = (this.XMax - this.XMin) * i / this.NX;
                this.AddLine(new Point(x, this.YMin), new Point(x, this.YMax));
            }

            for (int i = this.YMin + 1; i < this.YMax; i++)
            {
                double y = (this.YMax - this.YMin) * i / this.NY;
                this.AddLine(new Point(this.XMin, y), new Point(this.XMax, y));
            }

            Matrix matrix = this.GetMatrix();

            for (int i = 0; i < this.data.Length; i++)
            {
                PointCollection pointCollection = new PointCollection();
                foreach (Point point in this.data[i])
                    pointCollection.Add(matrix.Transform(point));

                Polyline polyLine = new Polyline();
                polyLine.Stroke = new SolidColorBrush(Chart.colors[i]);

                polyLine.Points = pointCollection;
                this.canvas.Children.Add(polyLine);
            }

            foreach (Point point in this.circles)
            {
                Ellipse ellipse = new Ellipse { Width = Chart.Radius, Height = Chart.Radius };
                Point transformed = matrix.Transform(point);
                Canvas.SetLeft(ellipse, transformed.X - Chart.Radius / 2);
                Canvas.SetTop(ellipse, transformed.Y - Chart.Radius / 2);
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.StrokeThickness = 2;
                this.canvas.Children.Add(ellipse);
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
