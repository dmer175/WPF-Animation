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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 曲线路径动画
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Top = this.Left = 0;
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Height = SystemParameters.FullPrimaryScreenHeight;

        //    var points =
        //      new List<Point>() 
        //{ 
        //  new Point(30, 30), 
        //  new Point(100, 30), 
        //  new Point(50, 80), 
        //  new Point(65, 10), 
        //  new Point(80, 80),
        //  new Point(30,30)
        //};
        //    var sb = new Storyboard();
        //    for (int i = 0; i < points.Count - 1; i++)
        //    {
        //        var lineGeometry = new LineGeometry(points[i], points[i]);
        //        var path =
        //          new Path()
        //          {
        //              Stroke = Brushes.Black,
        //              StrokeThickness = 2,
        //              Data = lineGeometry
        //          };
        //        back.Children.Add(path);
        //        var animation =
        //          new PointAnimation(points[i], points[i + 1], new Duration(TimeSpan.FromMilliseconds(1000)))
        //          {
        //              BeginTime = TimeSpan.FromMilliseconds(i * 1010)
        //          };
        //        sb.Children.Add(animation);
        //        RegisterName("geometry" + i, lineGeometry);
        //        Storyboard.SetTargetName(animation, "geometry" + i);
        //        Storyboard.SetTargetProperty(animation, new PropertyPath(LineGeometry.EndPointProperty));
        //    }
        //    MouseDown += (s, e) => { sb.Begin(this); };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //从XAML代码中获取移动路径数据  
            PathGeometry pg = this.layoutRoot.FindResource("movePath") as PathGeometry;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));

            Path pa = new Path();
            pa.Stroke = Brushes.Black;
            pa.StrokeThickness = 1;
            pa.Data = pg;
            layoutRoot.Children.Add(pa);
            //创建动画  
            DoubleAnimationUsingPath dpX = new DoubleAnimationUsingPath();
            dpX.Duration = duration;
            dpX.PathGeometry = pg;
            dpX.Source = PathAnimationSource.X;

            DoubleAnimationUsingPath dpY = new DoubleAnimationUsingPath();
            dpY.Duration = duration;
            dpY.PathGeometry = pg;
            dpY.Source = PathAnimationSource.Y;

            //dpX.AutoReverse = true;
            dpX.RepeatBehavior = RepeatBehavior.Forever;
            //dpY.AutoReverse = true;
            dpY.RepeatBehavior = RepeatBehavior.Forever;  
            //执行动画  
            this.tt.BeginAnimation(TranslateTransform.XProperty, dpX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, dpY);  
        }
    }
}
