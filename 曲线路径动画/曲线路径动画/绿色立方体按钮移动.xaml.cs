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

namespace 曲线路径动画
{
    /// <summary>
    /// Window5.xaml 的交互逻辑
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            transform.OffsetX--;
        }

        private void out_Click(object sender, RoutedEventArgs e)
        {
            transform.OffsetZ--;
        }

        private void in_Click(object sender, RoutedEventArgs e)
        {
            transform.OffsetZ++;
        }

        private void right_Click(object sender, RoutedEventArgs e)
        {
            transform.OffsetX++;
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            transform.OffsetY--;
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            transform.OffsetY++;
        }
    }
}
