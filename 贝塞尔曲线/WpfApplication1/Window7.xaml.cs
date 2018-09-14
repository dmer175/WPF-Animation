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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Window7.xaml 的交互逻辑
    /// </summary>
    public partial class Window7 : Window
    {
        Border kz1;
        Border kz2;
        BezierSegment be;
        int kz1x = 300, kz1y = 150;
        int kz2x = 500, kz2y = 480;
        int startx = 500, starty = 150;
        int endx = 300, endy = 480;
        public Window7()
        {
            InitializeComponent();
            this.Top = this.Left = 0;
            this.Height = SystemParameters.FullPrimaryScreenHeight;
            this.Width = SystemParameters.FullPrimaryScreenWidth;

            BezierSegment be = new BezierSegment();
            be.Point1 = new Point(kz1x, kz1y);
            be.Point2 = new Point(kz2x, kz2y);
            be.Point3 = new Point(endx, endy);

            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(startx, starty);

            pf.Segments.Add(be);

            PathGeometry pg = new PathGeometry();
            pg.Figures.Add(pf);

            Path pa = new Path();
            pa.Data = pg;
            pa.Stroke = Brushes.Black;
            pa.StrokeThickness = 3;

            back.Children.Add(pa);

            LineGeometry lg1 = new LineGeometry();
            lg1.StartPoint = new Point(startx, starty);
            lg1.EndPoint = new Point(kz1x, kz1y);
            Path pa1 = new Path();
            pa1.Stroke = Brushes.Black;
            pa1.StrokeThickness = 1;
            pa1.Data = lg1;
            back.Children.Add(pa1);

        }
    }
}
