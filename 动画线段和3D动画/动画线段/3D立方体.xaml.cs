using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace 动画线段
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.001);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();  
        }
        private int i = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (myAngleRotation.Angle + 5 == 360)
            {
                i++;
                if (i % 2 == 1)
                    myAngleRotation.Axis = new Vector3D(3, 3, 0);
                else
                    myAngleRotation.Axis = new Vector3D(0, 3, 3);
            }
            myAngleRotation.Angle = (myAngleRotation.Angle + 5) % 360;
        }  
        //private Vector3D ProjectToTrackball(Double width, Double height, Point point)
        //{
        //    Double x = point.X / (width / 2);    // Scale so bounds map to [0,0] - [2,2]
        //    Double y = point.Y / (height / 2);
        //    x = x - 1;                           // Translate 0,0 to the center
        //    y = 1 - y;                           // Flip so +Y is up instead of down
        //    Double z2 = 1 - x * x - y * y;       // z^2 = 1 - x^2 - y^2
        //    Double z = z2 > 0 ? Math.Sqrt(z2) : 0;
        //    return new Vector3D(x, y, z);
        //}
        //private void Rotate(Point currentPosition)
        //{
        //    Vector3D currentPosition3D = ProjectToTrackball(EventSource.ActualWidth, EventSource.ActualHeight, currentPosition);
        //    Vector3D axis = Vector3D.CrossProduct(_previousRotPosition3D, currentPosition3D);
        //    Double angle = Vector3D.AngleBetween(_previousRotPosition3D, currentPosition3D);
        //    Rotate(axis, angle);
        //    _previousRotPosition3D = currentPosition3D;
        //}

        //private void Rotate(Vector3D axis, Double angle)
        //{
        //    Quaternion delta = new Quaternion(axis, -angle * _rotScale);
        //    Quaternion q = new Quaternion(_axisAngleRotation3D.Axis, _axisAngleRotation3D.Angle);
        //    q *= delta;
        //    Vector3D zeorVec = new Vector3D(0.0, 0.0, 0.0);
        //    if (Vector3D.Equals(q.Axis, zeorVec))
        //        return;
        //    _axisAngleRotation3D.Axis = q.Axis;
        //    _axisAngleRotation3D.Angle = q.Angle;
        //}

        //private double lastPx = double.NaN;
        //   public double LastPx
        //   {
        //      get { return this.lastPx; }
        //      set { if (this.lastPx != value) { this.lastPx = value; this.OnPropertyChanged("LastPx"); } }
        //  }
  
        //  #region INotifyPropertyChanged 成员
  
        //  public event PropertyChangedEventHandler PropertyChanged;
        //  protected virtual void OnPropertyChanged(string propertyName)
        //  {
        //      if (this.PropertyChanged != null)
        //          this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //  }
        //  #endregion
    }
    //public class WriteableBitmapTrendLine : FrameworkElement
    // {
    //      #region DependencyProperties
  
    //      public static readonly DependencyProperty LatestQuoteProperty =
    //          DependencyProperty.Register("LatestQuote", typeof(MinuteQuoteViewModel), typeof(WriteableBitmapTrendLine),
    //          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnLatestQuotePropertyChanged));
  
    //      private static void OnLatestQuotePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //      {
    //          WriteableBitmapTrendLine trendLine = (WriteableBitmapTrendLine)d;
    //          MinuteQuoteViewModel latestQuote = (MinuteQuoteViewModel)e.NewValue;
    //          if (latestQuote != null)
    //          {
    //              trendLine.DrawTrendLine((float)latestQuote.LastPx);
    //          }
    //      }
  
    //      public MinuteQuoteViewModel LatestQuote
    //      {
    //          get { return (MinuteQuoteViewModel)GetValue(LatestQuoteProperty); }
    //          set { SetValue(LatestQuoteProperty, value); }
    //      }
  
    //      #endregion
  
    //      private int width = 0;
    //      private int height = 0;
  
    //      private WriteableBitmap bitmap;
  
    //      /// <summary>
    //      /// 两点之间的距离
    //      /// </summary>
    //      private int dx = 5;
  
    //      /// <summary>
    //      /// 当前区域所容纳的值
    //      /// </summary>
    //      private float[] prices;
  
    //      /// <summary>
    //      /// 在prices中的索引
    //      /// </summary>
    //      private int ordinal = 0;
  
    //      private GDI.Pen pen = new GDI.Pen(GDI.Color.Black);
  
    //      private void DrawTrendLine(float latestPrice)
    //      {
    //          if (double.IsNaN(latestPrice))
    //              return;
  
    //          ordinal++;
  
    //          if (ordinal > this.prices.Length - 1)
    //          {
    //              ordinal = 0;
    //          }
    //          this.prices[ordinal] = latestPrice;
  
    //          this.bitmap.Lock();
  
    //          using (GDI.Bitmap backBufferBitmap = new GDI.Bitmap(width, height,
    //              this.bitmap.BackBufferStride, GDI.Imaging.PixelFormat.Format24bppRgb,
    //              this.bitmap.BackBuffer))
    //          {
    //              using (GDI.Graphics backBufferGraphics = GDI.Graphics.FromImage(backBufferBitmap))
    //              {
    //                  backBufferGraphics.SmoothingMode = GDI.Drawing2D.SmoothingMode.HighSpeed;
    //                 backBufferGraphics.CompositingQuality = GDI.Drawing2D.CompositingQuality.HighSpeed;
 
 
    //                 if (ordinal == 0)
    //                 {
    //                     backBufferGraphics.Clear(GDI.Color.White);
    //                 }
 
    //                 for (int i = 0; i <= ordinal; i++)
    //                 {
    //                     if (ordinal > 0)
    //                     {
    //                         backBufferGraphics.DrawLine(pen,
    //                             new GDI.PointF((ordinal - 1) * dx, this.prices[ordinal - 1]),
    //                              new GDI.PointF(ordinal * dx, this.prices[ordinal]));
    //                    }
    //                 }
    //                 backBufferGraphics.Flush();
    //             }
    //         }
    //         this.bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
    //         this.bitmap.Unlock();
    //     }
 
    //     protected override void OnRender(DrawingContext dc)
    //     {
    //         if (bitmap == null)
    //         {
    //             this.width = (int)RenderSize.Width;
    //             this.height = (int)RenderSize.Height;
    //             this.bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
 
    //             this.bitmap.Lock();
    //             using (GDI.Bitmap backBufferBitmap = new GDI.Bitmap(width, height,
    //            this.bitmap.BackBufferStride, GDI.Imaging.PixelFormat.Format24bppRgb,
    //            this.bitmap.BackBuffer))
    //             {
    //                 using (GDI.Graphics backBufferGraphics = GDI.Graphics.FromImage(backBufferBitmap))
    //                 {
    //                     backBufferGraphics.SmoothingMode = GDI.Drawing2D.SmoothingMode.HighSpeed;
    //                     backBufferGraphics.CompositingQuality = GDI.Drawing2D.CompositingQuality.HighSpeed;
 
    //                     backBufferGraphics.Clear(GDI.Color.White);
 
    //                     backBufferGraphics.Flush();
    //                 }
    //             }
    //             this.bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
    //             this.bitmap.Unlock();
 
    //             this.prices = new float[(int)(this.width / this.dx)];
    //         }
    //         dc.DrawImage(bitmap, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
    //         base.OnRender(dc);
    //     }
}
