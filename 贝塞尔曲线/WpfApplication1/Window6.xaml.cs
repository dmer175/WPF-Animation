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
    /// Window6.xaml 的交互逻辑
    /// </summary>
    public partial class Window6 : Window
    {
        Border kz1;
        Border kz2;
        BezierSegment be;
        int kz1x = 300, kz1y = 150;
        int kz2x = 500, kz2y = 480;
        int startx = 500, starty = 150;
        int endx = 300, endy = 480;
        public Window6()
        {
            InitializeComponent();

            this.Top = this.Left = 0;
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Height = SystemParameters.FullPrimaryScreenHeight;

            Path mypath = new Path();
            mypath.Stroke = Brushes.DarkGray;
            mypath.StrokeThickness = 5;

            mypath.Fill = new SolidColorBrush(Colors.YellowGreen);

            PathFigure myf = new PathFigure();
            myf.StartPoint = new Point(startx, starty);

            be = new BezierSegment();
            be.Point1 = new Point(kz1x, kz1y);
            be.Point2 = new Point(kz2x, kz2y);
            be.Point3 = new Point(endx, endy);
            //be.IsStroked = false;
            myf.Segments.Add(be);

            PathGeometry mypa = new PathGeometry();
            mypa.Figures.Add(myf);

            mypath.Data = mypa;

            back.Children.Add(mypath);


            kz1 = new Border();
            kz1.Height = kz1.Width = 10;
            kz1.BorderBrush = Brushes.Black;
            kz1.BorderThickness = new Thickness(1);
            Canvas.SetLeft(kz1, kz1x);
            Canvas.SetTop(kz1, kz1y);
            back.Children.Add(kz1);

            kz1.MouseLeftButtonDown += kz1_MouseLeftButtonDown;
            kz1.MouseLeftButtonUp += kz1_MouseLeftButtonUp;

            kz2 = new Border();
            kz2.Height = kz2.Width = 10;
            kz2.BorderBrush = Brushes.Black;
            kz2.BorderThickness = new Thickness(1);
            Canvas.SetLeft(kz2, kz2x);
            Canvas.SetTop(kz2, kz2y);
            back.Children.Add(kz2);

            kz2.MouseLeftButtonDown += kz2_MouseLeftButtonDown;
            kz2.MouseLeftButtonUp += kz2_MouseLeftButtonUp;

            //画直线
            myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new Point(kz1x, kz1y);
            myLineGeometry.EndPoint = new Point(startx, starty);  
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;
            back.Children.Add(myPath);

            myLineGeometry2 = new LineGeometry();
            myLineGeometry2.StartPoint = new Point(endx, endy);
            myLineGeometry2.EndPoint = new Point(kz2x, kz2y);
            Path myPath2 = new Path();
            myPath2.Stroke = Brushes.Black;
            myPath2.StrokeThickness = 1;
            myPath2.Data = myLineGeometry2;
            back.Children.Add(myPath2);

            MouseMove += Window6_MouseMove;
        }
        bool isOn2 = false;
        void kz2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isOn2 = false;
        }

        void kz2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isOn2 = true;
        }
        LineGeometry myLineGeometry;  //直线
        LineGeometry myLineGeometry2;
        bool isOn = false;
        void kz1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isOn = false;
        }

        
        double MouseX, MouseY;
        void kz1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            
            isOn = true;
            //Canvas.SetLeft(kz1, MouseX );
            //Canvas.SetTop(kz1, MouseY );
            //double dis=Math.Sqrt(Math.Pow(MouseX-))
            
        }

        void Window6_MouseMove(object sender, MouseEventArgs e)
        {
            MouseX = e.GetPosition(back).X;
            MouseY = e.GetPosition(back).Y;
            if (isOn==true)
            {
                Canvas.SetLeft(kz1, MouseX);
                Canvas.SetTop(kz1, MouseY);
                myLineGeometry.StartPoint = new Point(MouseX, MouseY);
                be.Point1 = new Point(MouseX, MouseY);
            }            

            if (isOn2==true)
            {
                Canvas.SetLeft(kz2, MouseX);
                Canvas.SetTop(kz2, MouseY);
                myLineGeometry2.EndPoint = new Point(MouseX,MouseY);
                be.Point2 = new Point(MouseX, MouseY);
            }
        }
    }
}
