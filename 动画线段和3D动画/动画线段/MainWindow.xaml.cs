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
using System.Windows.Media.Animation;

namespace 动画线段
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Storyboard sb;
        public MainWindow()
        {
            InitializeComponent();

          //  Canvas ca = new Canvas();
          //  Content = ca;
          //  List<Point> points = new List<Point>(){new Point(10, 10), 
          //new Point(90, 90), 
          //new Point(60, 10), 
          //new Point(250, 90), 
          //new Point(10, 10) };
            
          //  var sb = new Storyboard();
            //var canvas = new Canvas();
            //Content = canvas;
            var points =
              new List<Point>() 
        { 
          new Point(30, 30), 
          new Point(100, 30), 
          new Point(50, 80), 
          new Point(65, 10), 
          new Point(80, 80),
          new Point(30,30)
        };
            sb = new Storyboard();
            for (int i = 0; i < points.Count - 1; i++)
            {
                var lineGeometry = new LineGeometry(points[i], points[i]);
                var path =
                  new Path()
                  {
                      Stroke = Brushes.Black,
                      StrokeThickness = 2,
                      Data = lineGeometry
                  };
                back.Children.Add(path);
                var animation =
                  new PointAnimation(points[i], points[i + 1], new Duration(TimeSpan.FromMilliseconds(1000)))
                  {
                      BeginTime = TimeSpan.FromMilliseconds(i * 1010)
                  };
                sb.Children.Add(animation);
                RegisterName("geometry" + i, lineGeometry);
                Storyboard.SetTargetName(animation, "geometry" + i);
                Storyboard.SetTargetProperty(animation, new PropertyPath(LineGeometry.EndPointProperty));
            }
            MouseDown += (s, e) => { sb.Begin(this); };
           // MouseDown += MainWindow_MouseDown;
        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sb.Begin(this);
            
        }
    }
}
