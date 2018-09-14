using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace 曲线路径动画
{
    /// <summary>
    /// CPU曲线图.xaml 的交互逻辑
    /// </summary>
    public partial class CPU曲线图 : Window
    {

        //[StructLayout(LayoutKind.Sequential)]
        //public struct MARGINS
        //{
        //    public int cxLeftWidth;
        //    public int cxRightWidth;
        //    public int cyTopHeight;
        //    public int cyBottomHeight;
        //};

        //[DllImport("DwmApi.dll")]
        //public static extern int DwmExtendFrameIntoClientArea(
        //    IntPtr hwnd,
        //    ref MARGINS pMarInset);
        public CPU曲线图()
        {
            InitializeComponent();
        }

        //private void ExtendAeroGlass(Window window)
        //{
        //    try
        //    {
        //        // 为WPF程序获取窗口句柄
        //        IntPtr mainWindowPtr = new WindowInteropHelper(window).Handle;
        //        HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
        //        mainWindowSrc.CompositionTarget.BackgroundColor = Colors.Transparent;

        //        // 设置Margins
        //        MARGINS margins = new MARGINS();

        //        // 扩展Aero Glass
        //        margins.cxLeftWidth = -1;
        //        margins.cxRightWidth = -1;
        //        margins.cyTopHeight = -1;
        //        margins.cyBottomHeight = -1;

        //        int hr = DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
        //        if (hr < 0)
        //        {
        //            MessageBox.Show("DwmExtendFrameIntoClientArea Failed");
        //        }
        //    }
        //    catch (DllNotFoundException)
        //    {
        //        Application.Current.MainWindow.Background = Brushes.White;
        //    }
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        //private void checkBox_Click(object sender, RoutedEventArgs e)
        //{
        //    if (checkBox.IsChecked.Value)
        //    {
        //        this.Background = Brushes.Transparent;
        //        ExtendAeroGlass(this);
        //    }
        //    else
        //    {
        //        this.Background = Brushes.White;
        //    }
        //}

        
    }
}
