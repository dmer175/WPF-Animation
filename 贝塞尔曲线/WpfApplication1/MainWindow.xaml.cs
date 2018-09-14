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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        struct direction
        {
            public double x1;
            public double y1;
            public double x2;
            public double y2;
            public double h;
            public double s;
            public double x3;
            public double y3;
            public double w;
            public double x4;
            public double y4;
            public double n;
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Top = this.Left = 0;
            this.Width = 800;
            this.Height = 700;
        }
        Image Myplane = new Image();
        DispatcherTimer dt = new DispatcherTimer();
        Ellipse ell = new Ellipse();
        Ellipse ell2 = new Ellipse();
        Ellipse ell3 = new Ellipse();
        List<direction> Ldir = new List<direction>();
        private void back_Loaded(object sender, RoutedEventArgs e)
        {
            //Myplane.Width = 70; Myplane.Height = 80;
            //Myplane.Stretch = Stretch.Fill;
            //Canvas.SetLeft(Myplane, back.Width / 2 - Myplane.Width / 2);
            //Canvas.SetTop(Myplane, back.Height - Myplane.Height);
            //Myplane.Source = new BitmapImage(new Uri("Images/plane/plane1.png", UriKind.Relative));
            ////Canvas.SetZIndex(Myplane, 5);
            //back.Children.Add(Myplane);
            
            ell.Width = ell.Height = 10;
            ell.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(ell, 50);
            Canvas.SetTop(ell, 50);
            back.Children.Add(ell);

            
            ell2.Width = ell2.Height = 10;
            ell2.Fill = new SolidColorBrush(Colors.Green);
            Canvas.SetLeft(ell2, 200);
            Canvas.SetTop(ell2, 270);
            back.Children.Add(ell2);

            
            ell3.Width = ell3.Height = 10;
            ell3.Fill = new SolidColorBrush(Colors.Orange);
            Canvas.SetLeft(ell3, 600);
            Canvas.SetTop(ell3, 400);
            back.Children.Add(ell3);

            

            ell4 = new Ellipse();
            ell4.Width = ell4.Height = 10;
            ell4.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(ell4, 50);
            Canvas.SetTop(ell4, 50);
            back.Children.Add(ell4);

            //direction dir = new direction();
            double ellx = Canvas.GetLeft(ell);
            double elly = Canvas.GetTop(ell);
            double ell2x = Canvas.GetLeft(ell2);
            double ell2y = Canvas.GetTop(ell2);
            double ell_ell2 = Math.Sqrt(Math.Pow(ellx-ell2x, 2) + Math.Pow(elly-ell2y, 2));
            double ell4x = Canvas.GetLeft(ell4);
            double ell4y = Canvas.GetTop(ell4);
            double ell_ell4 = Math.Sqrt(Math.Pow(ellx-ell4x, 2) + Math.Pow(elly-ell4y,2));
            double bizhi = ell_ell4/ell_ell2;
            double ell3x = Canvas.GetLeft(ell3);
            double ell3y = Canvas.GetTop(ell3);
            double ell2_ell3 = Math.Sqrt(Math.Pow(ell2x - ell3x, 2) + Math.Pow(ell2y - ell3y, 2));

            ell5 = new Ellipse();
            ell5.Width = ell5.Height = 10;
            ell5.Fill = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(ell5, Canvas.GetLeft(ell2) + (ell2x - ell3x) * bizhi);
            Canvas.SetTop(ell5, Canvas.GetTop(ell2) + (ell2y - ell3y) * bizhi);
            back.Children.Add(ell5);

            ell6 = new Ellipse();
            ell6.Width = ell6.Height = 10;
            ell6.Fill = new SolidColorBrush(Colors.Blue);
            Canvas.SetLeft(ell6,(Canvas.GetLeft(ell4)-Canvas.GetLeft(ell5))*bizhi);
            Canvas.SetTop(ell6,(Canvas.GetTop(ell4)-Canvas.GetTop(ell5))*bizhi);
            back.Children.Add(ell6);

            dt.Tick += dt_Tick;
            dt.Interval = TimeSpan.FromMilliseconds(200);
            dt.Start();
        }
        Ellipse ell4;
        Ellipse ell5;
        Ellipse ell6;
        int dd = 0;
        void dt_Tick(object sender, EventArgs e)
        {
            ell4 = new Ellipse();
            ell4.Width = ell4.Height = 10;
            ell4.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(ell4, 50);
            Canvas.SetTop(ell4, 50);
            back.Children.Add(ell4);

            //direction dir = new direction();
            double ellx = Canvas.GetLeft(ell);
            double elly = Canvas.GetTop(ell);
            double ell2x = Canvas.GetLeft(ell2);
            double ell2y = Canvas.GetTop(ell2);
            double ell_ell2 = Math.Sqrt(Math.Pow(ellx - ell2x, 2) + Math.Pow(elly - ell2y, 2));
            double ell4x = Canvas.GetLeft(ell4);
            double ell4y = Canvas.GetTop(ell4);
            double ell_ell4 = Math.Sqrt(Math.Pow(ellx - ell4x, 2) + Math.Pow(elly - ell4y, 2));
            double bizhi = ell_ell4 / ell_ell2;
            double ell3x = Canvas.GetLeft(ell3);
            double ell3y = Canvas.GetTop(ell3);
            double ell2_ell3 = Math.Sqrt(Math.Pow(ell2x - ell3x, 2) + Math.Pow(ell2y - ell3y, 2));

            
            dd += 5;
            Canvas.SetLeft(ell4, 50 + dd);
            Canvas.SetTop(ell4, 50 + dd);

            ell5 = new Ellipse();
            ell5.Width = ell5.Height = 10;
            ell5.Fill = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(ell5, Canvas.GetLeft(ell2) + (ell2x - ell3x) * bizhi);
            Canvas.SetTop(ell5, Canvas.GetTop(ell2) + (ell2y - ell3y) * bizhi);
            back.Children.Add(ell5);

            ell6 = new Ellipse();
            ell6.Width = ell6.Height = 10;
            ell6.Fill = new SolidColorBrush(Colors.Blue);
            Canvas.SetLeft(ell6, (Canvas.GetLeft(ell4) - Canvas.GetLeft(ell5)) * bizhi);
            Canvas.SetTop(ell6, (Canvas.GetTop(ell4) - Canvas.GetTop(ell5)) * bizhi);
            back.Children.Add(ell6);
        }
    }
}
