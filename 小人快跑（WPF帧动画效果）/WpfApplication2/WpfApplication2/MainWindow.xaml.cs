using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApplication2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //保存需要展示的图片数量
        ObservableCollection<BitmapImage> bmList;
        //记录索引，用来重复切换图片
        int index = 0;
        //是否刷新帧
        bool isRendering = false;
        public Speed Speed = new Speed();

        public MainWindow()
        {
            InitializeComponent();
            InitList();
            //调用系统默认的帧进行动画
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            OpenBackgroundWork();
            lblSpeed.SetBinding(Label.ContentProperty, new Binding("Speeds") { Source = Speed});
            Speed.Speeds = 100;
        }

        /// <summary>
        /// 开启一个后台线程，用来控制帧频率的刷新速度
        /// </summary>
        private void OpenBackgroundWork()
        {

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(
                (sender, e) =>
                {
                    while (true)
                    {
                        isRendering = true;
                        System.Threading.Thread.Sleep(Speed.Speeds); //停秒
                    }
                });
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// 找到系统图片存放的位置，并添加图片到bmList列表
        /// </summary>
        public void InitList()
        {
            bmList = new ObservableCollection<BitmapImage>();
            //图片是按照1，2，3这样的命名规则，所以循环添加图片
            for (int i = 1; i < 3; i++)
            {
                var path = GetImagePath(i);
                BitmapImage bmImg = new BitmapImage(new Uri(path));
                bmList.Add(bmImg);
            }
        }

        /// <summary>
        /// 获得图片存放位置的路径
        /// </summary>
        /// <param name="i">图片名称</param>
        /// <returns></returns>
        private static string GetImagePath(int i)
        {
            var path = "";
            var paths = System.Environment.CurrentDirectory.Split('\\');
            for (int j = 0; j < paths.Length - 2; j++)
            {
                path += paths[j] + "\\";
            }
            return path + "Image\\" + i.ToString() + ".bmp";
        }

        /// <summary>
        /// 刷新图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (isRendering)
            {
                if (index < bmList.Count)
                {
                    this.img1.Source = bmList[index];
                    this.img1.Width = this.img1.Source.Width;
                    this.img1.Height = this.img1.Source.Height;
                    ImgMove();
                    index++;
                }
                else
                {
                    index = 0;
                }
                isRendering = false;
            }
        }



        //设置画板上图片的初始坐标；
        Point location = new Point(0, 0);

        /// <summary>
        /// 利用坐标算出图片的位置，每次在横轴上增加50px，显示让图片往前走的效果
        /// </summary>
        private void ImgMove()
        {
            Canvas.SetLeft(img1, location.X);
            location.X = location.X + 50;
            //超过边界就回原点
            if (location.X > this.Width)
            {
                location.X = 0;
            }
        }

        private void btnSlow_Click(object sender, RoutedEventArgs e)
        {
            if (Speed.Speeds % 100 != 0)
                Speed.Speeds += 20;
            else
                Speed.Speeds += 100;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (Speed.Speeds > 100)
            {
                if (Speed.Speeds - 100 > 0)
                {
                    Speed.Speeds -= 100;
                }
            }
            else
            {
                if (Speed.Speeds - 20 > 0)
                {
                    Speed.Speeds -= 20;
                }
                else
                {
                    MessageBox.Show("已经最快了！");
                }
            }
        }
    }
}
