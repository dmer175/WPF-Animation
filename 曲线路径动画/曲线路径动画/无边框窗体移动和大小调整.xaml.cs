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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 曲线路径动画
{
    /// <summary>
    /// 无边框窗体移动和大小调整.xaml 的交互逻辑
    /// </summary>
    public partial class 无边框窗体移动和大小调整 : Window
    {
        public 无边框窗体移动和大小调整()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
            {
                hwndSource.AddHook(new HwndSourceHook(this.WndProc));
            }
        }

        private const int WM_NCHITTEST = 0x0084;
        private readonly int agWidth = 12; //拐角宽度  
        private readonly int bThickness = 4; // 边框宽度  
        private Point mousePoint = new Point(); //鼠标坐标  
        public enum HitTest : int
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = HTGROWBOX,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = HTMINBUTTON,
            HTZOOM = HTMAXBUTTON,
            HTSIZEFIRST = HTLEFT,
            HTSIZELAST = HTBOTTOMRIGHT,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21,
        }
        protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_NCHITTEST:
                    {
                        this.mousePoint.X = (lParam.ToInt32() & 0xFFFF);
                        this.mousePoint.Y = (lParam.ToInt32() >> 16);

                        //告诉系统你已经处理过该消息，不然设置为false  
                        handled = true;
                        #region 测试鼠标位置
                        // 窗口左上角  
                        if (this.mousePoint.Y - this.Top <= this.agWidth
                                         && this.mousePoint.X - this.Left <= this.agWidth)
                        {
                            return new IntPtr((int)HitTest.HTTOPLEFT);
                        }
                        // 窗口左下角　　  
                        else if (this.ActualHeight + this.Top - this.mousePoint.Y <= this.agWidth
                                         && this.mousePoint.X - this.Left <= this.agWidth)
                        {
                            return new IntPtr((int)HitTest.HTBOTTOMLEFT);
                        }
                        // 窗口右上角  
                        else if (this.mousePoint.Y - this.Top <= this.agWidth
                         && this.ActualWidth + this.Left - this.mousePoint.X <= this.agWidth)
                        {
                            return new IntPtr((int)HitTest.HTTOPRIGHT);
                        }
                        // 窗口右下角  
                        else if (this.ActualWidth + this.Left - this.mousePoint.X <= this.agWidth
                         && this.ActualHeight + this.Top - this.mousePoint.Y <= this.agWidth)
                        {
                            return new IntPtr((int)HitTest.HTBOTTOMRIGHT);
                        }
                        // 窗口左侧  
                        else if (this.mousePoint.X - this.Left <= this.bThickness)
                        {
                            return new IntPtr((int)HitTest.HTLEFT);
                        }
                        // 窗口右侧  
                        else if (this.ActualWidth + this.Left - this.mousePoint.X <= this.bThickness)
                        {
                            return new IntPtr((int)HitTest.HTRIGHT);
                        }
                        // 窗口上方  
                        else if (this.mousePoint.Y - this.Top <= this.bThickness)
                        {
                            return new IntPtr((int)HitTest.HTTOP);
                        }
                        // 窗口下方  
                        else if (this.ActualHeight + this.Top - this.mousePoint.Y <= this.bThickness)
                        {
                            return new IntPtr((int)HitTest.HTBOTTOM);
                        }
                        else // 窗口移动(也可在窗体MouseLeftButtonDown事件中调用DragMove()方法)，双击最大化，所有剩余鼠标操作映射到标题栏  
                        {
                            return new IntPtr((int)HitTest.HTCAPTION);
                        }
                        #endregion
                    }
            }
            return IntPtr.Zero;
        }  
    }
}
