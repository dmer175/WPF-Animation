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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            Path mypath = new Path();
            mypath.Stroke = Brushes.DarkGray;
            mypath.StrokeThickness = 5;
            
            //mypath.Fill = new SolidColorBrush(Colors.YellowGreen);

            PathFigure myf = new PathFigure();
            myf.StartPoint = new Point(10, 110);

            BezierSegment be = new BezierSegment();
            be.Point1 = new Point(10, 30);
            be.Point2 = new Point(80, 140);
            be.Point3 = new Point(100, 20);
            //be.IsStroked = false;
            myf.Segments.Add(be);

            PathGeometry mypa = new PathGeometry();
            mypa.Figures.Add(myf);
            
            mypath.Data = mypa;

            back.Children.Add(mypath);

            



        }
    }
}
