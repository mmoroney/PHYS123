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
        private List<IEnumerable<Point>> lines = new List<IEnumerable<Point>>();
        private List<CirclePlotData> circles = new List<CirclePlotData>();
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

        public void AddLinePlot(IEnumerable<Point> points)
        {
            this.lines.Add(points);
        }

        public void AddCirclePlot(IEnumerable<Point> points, double radius)
        {
            this.circles.Add(new CirclePlotData(points, radius));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            this.CreatePlots();
            base.OnRender(drawingContext);
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

        private void CreatePlots()
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

            for (int i = 0; i < this.lines.Count; i++)
                AddLinePlot(this.lines[i], Chart.colors[i % Chart.colors.Length]);

            for (int i = 0; i < this.circles.Count; i++)
                AddCirclePlot(this.circles[i]);
        }

        private void AddLinePlot(IEnumerable<Point> points, Color color)
        {
            Matrix matrix = this.GetMatrix();

            PointCollection pointCollection = new PointCollection();
            foreach (Point point in points)
                pointCollection.Add(matrix.Transform(point));

            Polyline polyLine = new Polyline();
            polyLine.Stroke = new SolidColorBrush(color);

            polyLine.Points = pointCollection;
            this.canvas.Children.Add(polyLine);
        }

        private void AddCirclePlot(CirclePlotData data)
        {
            Matrix matrix = this.GetMatrix();
            foreach(Point point in data.Points)
            {
                Point transformed = matrix.Transform(point);
                Ellipse ellipse = new Ellipse { Width = data.Radius * 2, Height = data.Radius * 2};
                Canvas.SetLeft(ellipse, transformed.X - data.Radius);
                Canvas.SetTop(ellipse, transformed.Y - data.Radius);
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.StrokeThickness = 2;
                this.canvas.Children.Add(ellipse);
            }
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

        private class CirclePlotData
        {
            public IEnumerable<Point> Points { get; private set; }
            public double Radius { get; private set; }

            public CirclePlotData(IEnumerable<Point> points, double radius)
            {
                this.Points = points;
                this.Radius = radius;
            }
        }
    }
}
