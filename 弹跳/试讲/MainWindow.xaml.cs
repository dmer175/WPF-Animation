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

namespace 试讲
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Left = 0;
            //this.Top = 0;
            //this.Width = SystemParameters.FullPrimaryScreenWidth;
            //this.Height = SystemParameters.FullPrimaryScreenHeight;
        }

        private void bod_MouseDown(object sender, MouseButtonEventArgs e)
        {

            PathGeometry pg = this.lay.FindResource("movepath") as PathGeometry;
            Duration dr = new Duration(TimeSpan.FromMilliseconds(3600));
            //创建动画
            DoubleAnimationUsingPath x = new DoubleAnimationUsingPath();
            x.Duration = dr;//设置时间
            x.PathGeometry = pg;
            x.Source = PathAnimationSource.X;

            DoubleAnimationUsingPath y = new DoubleAnimationUsingPath();
            y.Duration = dr;
            y.PathGeometry = pg;
            y.Source = PathAnimationSource.Y;
            //执行动画
            this.tt.BeginAnimation(TranslateTransform.XProperty, x);
            this.tt.BeginAnimation(TranslateTransform.YProperty, y);



            ////弹跳
            //DoubleAnimation x = new DoubleAnimation();
            //DoubleAnimation y = new DoubleAnimation();
            ////设置反弹
            //BounceEase be = new BounceEase();
            ////反弹次数\
            //be.Bounces=8;
            ////弹性程度
            //be.Bounciness = 1;
            //y.EasingFunction = be;
            ////设置终点
            //x.To = 525-80;
            //y.To = 350-80;
            ////时间长度
            //Duration dr = new Duration(TimeSpan.FromMilliseconds(500));
            //x.Duration = dr;
            //y.Duration = dr;
            //this.tt.BeginAnimation(TranslateTransform.XProperty,x);
            //this.tt.BeginAnimation(TranslateTransform.YProperty,y);




        }
    }
}
