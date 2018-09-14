using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Threading;

namespace 曲线路径动画
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置动画
        /// </summary>
        //void Run()
        //{
        //    //动画速率
        //    double speed = 0.0;
        //    //定时器，定时修改ImageInfo中各属性，从而实现动画效果
        //    DispatcherTimer timer = new DispatcherTimer();
        //    //时间间隔
        //    timer.Interval = TimeSpan.FromMilliseconds(100);
        //    timer.Tick += (ss, ee) =>
        //    {
        //        #region
        //        //设置圆心x,y
        //        double centerX = this.ActualWidth / 2;
        //        double centerY = this.ActualHeight / 2 - 50;//减去适当的值，因为会设置最下面的图片最大，上面的图片较小

        //        //设置图片最大的宽、高
        //        double maxWidth = 300;
        //        double maxHeight = 200;

        //        //设置椭圆的长边和短边
        //        double a = centerX - maxWidth / 2.0;
        //        double b = centerY - maxHeight / 2.0;

        //        //运动一周后恢复为0
        //        speed = speed < 360 ? speed : 0.0;
        //        //运运的速度 此“增值”和  timer.Interval对动画的流畅性有影响
        //        speed += 0.5;
        //        //运动距离，即运动的弧度数;
        //        var ainhd = speed * Math.PI / 180;
        //        //每个图片之间相隔的角度
        //        var angle = (360.0 / data.Count) * Math.PI / 180.0;
        //        //图片序号
        //        int index = 0;
        //        foreach (var img in data)
        //        {
        //            //最下面一张图ZIndex最大，Opacity最大，长宽最大

        //            img.ZIndex = (int)img.Top;
        //            //当前图片与最下面一张图片的Y的比值
        //            var allpers = img.Top / (centerY + b);
        //            //不要小于0.2，太小了就看不见了，可以适当调整
        //            allpers = Math.Max(0.2, allpers);
        //            //设置图片大小
        //            img.Width = allpers * maxWidth;
        //            img.Height = allpers * maxHeight;
        //            //设置透明度
        //            img.Opactity = Math.Max(allpers * 1.5, 0.4);

        //            //公式：x=sin * a //+ centerX因为默认wpf默认左上角为坐标原点；//- img.Width / 2.0是以图片中心点作为运动轨迹
        //            img.Left = Math.Sin((angle * index + ainhd)) * a + centerX - img.Width / 2.0;//x=sin * a
        //            //y=cos * b
        //            img.Top = Math.Cos((angle * index + ainhd)) * b + centerY - img.Height / 2.0;

        //            index++;
        //        }
        //        #endregion
        //    };
        //    //启动计时器，开始动画
        //    timer.Start();
        //}
        //ObservableCollection<ImageInfo> data;
        //private void lv_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //准备数据源 ObservableCollection<T>
        //    data = new ObservableCollection<ImageInfo>();
        //    //获取程序所在目录中的images文件夹
        //    DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "images");
        //    //添加此目录中的图片文件到data中
        //    foreach (var file in di.GetFiles())
        //    {
        //        //验证是否为图片文件 （可以写一个方法来进行验证，此处仅支持jpg和png）
        //        if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".png")
        //        {
        //            data.Add(new ImageInfo(file.FullName));
        //        }
        //    }
        //    //设置ListView的ItemsSource
        //    lv.ItemsSource = data;

        //    Run();
        //}


    }
}
