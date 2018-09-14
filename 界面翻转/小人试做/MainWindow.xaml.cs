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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 小人试做
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RowDefinition rd = new RowDefinition();
            

            //var rd = new RowDefinition()
            //{
            //    Height="3*"
            //}
            
        }

        //public void Transform1()
        //{
        //    RotateTransform rtf = new RotateTransform();
        //    trans.RenderTransform = rtf;
        //    DoubleAnimation dbAscending = new DoubleAnimation(0, 360, new Duration

        //    (TimeSpan.FromSeconds(1)));
        //    dbAscending.RepeatBehavior = RepeatBehavior.Forever;
        //    rtf.BeginAnimation(RotateTransform.AngleProperty, dbAscending);
        //}

        //public void Transform2()
        //{
        //    RotateTransform rtf = new RotateTransform();
        //    trans.RenderTransform = rtf;
        //    DoubleAnimation dbAscending = new DoubleAnimation(0, 360, new Duration(TimeSpan.FromSeconds(1)));
        //    Storyboard storyboard = new Storyboard();
        //    dbAscending.RepeatBehavior = RepeatBehavior.Forever;
        //    storyboard.Children.Add(dbAscending);
        //    Storyboard.SetTarget(dbAscending, trans);
        //    Storyboard.SetTargetProperty(dbAscending, new PropertyPath("RenderTransform.Angle"));
        //    storyboard.Begin();
        //}

        //private void trans_Click(object sender, RoutedEventArgs e)
        //{
        //    Transform2();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            if (btn != null)
            {
                string s = btn.Content.ToString();
                if (s == "关闭")
                {
                    this.Close();
                }
                DoubleAnimation da = new DoubleAnimation();
                da.Duration = new Duration(TimeSpan.FromSeconds(1));
                if (s == "向前")
                {
                    da.To = 0d;
                }
                else if (s == "向后")
                {
                    da.To = 180d;
                }
                this.axr.BeginAnimation(AxisAngleRotation3D.AngleProperty, da);
            }
        }
    }
}
