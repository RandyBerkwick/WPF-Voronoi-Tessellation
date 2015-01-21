using Delaunay;
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

namespace Mapgen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingVisual VoronoiTesselation;
        DrawingVisual Dots;
        DrawingVisual Edges;
        DrawingVisual Colors;

        List<Color> colors = new[] { "#00FF00", "#0000FF", "#FF0000", "#01FFFE", "#FFA6FE", "#FFDB66", "#006401", "#010067", "#95003A", "#007DB5", "#FF00F6", "#FFEEE8", "#774D00", "#90FB92", "#0076FF", "#D5FF00", "#FF937E", "#6A826C", "#FF029D", "#FE8900", "#7A4782", "#7E2DD2", "#85A900", "#FF0056", "#A42400", "#00AE7E", "#683D3B", "#BDC6FF", "#263400", "#BDD393", "#00B917", "#9E008E", "#001544", "#C28C9F", "#FF74A3", "#01D0FF", "#004754", "#E56FFE", "#788231", "#0E4CA1", "#91D0CB", "#BE9970", "#968AE8", "#BB8800", "#43002C", "#DEFF74", "#00FFC6", "#FFE502", "#620E00", "#008F9C", "#98FF52", "#7544B1", "#B500FF", "#00FF78", "#FF6E41", "#005F39", "#6B6882", "#5FAD4E", "#A75740", "#A5FFD2", "#FFB167", "#009BFF", "#E85EBE" }
            .Select(c => (Color)ColorConverter.ConvertFromString(c)).ToList();

        public MainWindow()
        {
            InitializeComponent();

            VoronoiTesselation = new DrawingVisual() { };
            Dots = new DrawingVisual();
            Edges = new DrawingVisual();
            Colors = new DrawingVisual();

            VoronoiTesselation.Children.Add(Colors);
            VoronoiTesselation.Children.Add(Edges);
            VoronoiTesselation.Children.Add(Dots);

            brect.Fill = new VisualBrush(VoronoiTesselation) { Stretch = Stretch.UniformToFill, ViewboxUnits = BrushMappingMode.Absolute, Viewbox = new Rect(0, 0, 500, 500)};

        }

        private void Button_Click(object sender, RoutedEventArgs ea)
        {
            Random rand = new Random();
            List<Point> points = new List<Point>();

            for (int i = 0; i < 60; i++)
            {
                points.Add(new Point((float)(rand.NextDouble() * brect.ActualWidth), (rand.NextDouble() * brect.ActualHeight)));
            }


            Voronoi v = new Voronoi(points, colors, new Rect(0, 0, brect.ActualWidth, brect.ActualHeight));
            using (var r = Dots.RenderOpen())
            { 
                foreach (var p in points)
	            {
                    r.DrawEllipse(Brushes.Teal,null,p,3,3);
	            }
            }

            using (var r = Edges.RenderOpen())
            { 
                foreach (var l in v.VoronoiDiagram())
	            {
                    r.DrawLine(new Pen(Brushes.Black, 1), l.p0.Value, l.p1.Value);
	            }

                foreach (var l in v.DelaunayTriangulation())
                {
                    r.DrawLine(new Pen(Brushes.Azure, 1), l.p0.Value, l.p1.Value);
                }
            }

            using (var r = Colors.RenderOpen())
            {
                int indx = 0;
                foreach (var l in v.Regions())
                {
                    StreamGeometry poly = new StreamGeometry();
                    using(var g = poly.Open())
                    {
                        g.BeginFigure(l[0],true,true);
                        g.PolyLineTo(l.Select(p=>(Point)p).ToList(), false, false);
                    
                    }

                    r.DrawGeometry(new SolidColorBrush(colors[indx % colors.Count]), null, poly);
                    indx++;
                }
            }

        }
    }
}
