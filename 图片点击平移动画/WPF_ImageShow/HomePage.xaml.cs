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
using System.Windows.Shapes;

namespace WPF_ImageShow
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Window
    {
        #region 轮播图变量
        /// <summary>
        /// 图片列表
        /// </summary>
        List<SmallImageEntity> ImageList = new List<SmallImageEntity>();

        /// <summary>
        /// 向左移动撤出
        /// </summary>
        private DoubleAnimation MiddleToLeft;
        /// <summary>
        /// 向左移动进入
        /// </summary>
        private DoubleAnimation RightToMiddle;
        /// <summary>
        /// 向右移动撤出
        /// </summary>
        private DoubleAnimation MiddleToRight;
        /// <summary>
        /// 向右移动进入
        /// </summary>
        private DoubleAnimation LeftToMiddle;
        /// <summary>
        /// 当前显示的图片
        /// </summary>
        int CurrentIndex = 0;
        /// <summary>
        /// 动画是否完成
        /// </summary>
        bool AnimationCompleted = false;
        #endregion
        public HomePage()
        {
            InitializeComponent();

            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("images/back/1.jpg", UriKind.RelativeOrAbsolute)) });
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("images/back/2.jpg", UriKind.RelativeOrAbsolute)) });
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("images/back/3.jpg", UriKind.RelativeOrAbsolute)) });
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("images/back/4.jpg", UriKind.RelativeOrAbsolute)) });
            lst.ItemsSource = ImageList;

            Loaded += HomePage_Loaded;

        }
        void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            #region 轮播图加载处理
            Image im = new Image(); im.Stretch = Stretch.Fill;
            im.Width = ImageCanvas.ActualWidth;
            im.Height = ImageCanvas.ActualHeight;
            im.Source = ImageList[0].ImageSource;
            ImageCanvas.Children.Add(im);

            //记录canvas宽度
            double CaWidth = ImageCanvas.ActualWidth;

            //设置4个动画
            MiddleToLeft = new DoubleAnimation(0, -CaWidth, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.Stop);
            RightToMiddle = new DoubleAnimation(CaWidth, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            MiddleToLeft.Completed += MiddleToLeft_Completed;
            RightToMiddle.Completed += RightToMiddle_Completed;

            LeftToMiddle = new DoubleAnimation(-CaWidth, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            MiddleToRight = new DoubleAnimation(0, CaWidth, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            LeftToMiddle.Completed += LeftToMiddle_Completed;
            MiddleToRight.Completed += MiddleToRight_Completed;

            lst.SelectionChanged += lst_SelectionChanged;
            #endregion
        }
        #region 轮播图效果
        void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int tindex = lst.SelectedIndex;

            Image im = new Image(); im.Stretch = Stretch.Fill;
            im.Width = ImageCanvas.ActualWidth;
            im.Height = ImageCanvas.ActualHeight;
            im.Source = ImageList[tindex].ImageSource;
            if (tindex > CurrentIndex)
            {
                if (!AnimationCompleted)
                {
                    CurrentIndex = tindex;
                    AnimationCompleted = true;
                    ImageCanvas.Children.Add(im);
                    ImageCanvas.Children[0].BeginAnimation(Canvas.LeftProperty, MiddleToLeft);
                    ImageCanvas.Children[1].BeginAnimation(Canvas.LeftProperty, RightToMiddle);
                }
                else
                {
                    lst.SelectedItem = lst.Items[CurrentIndex];
                }
            }
            else if (tindex < CurrentIndex)
            {
                if (!AnimationCompleted)
                {
                    CurrentIndex = tindex;
                    AnimationCompleted = true;
                    ImageCanvas.Children.Add(im);
                    ImageCanvas.Children[0].BeginAnimation(Canvas.LeftProperty, MiddleToRight);
                    ImageCanvas.Children[1].BeginAnimation(Canvas.LeftProperty, LeftToMiddle);
                }
                else
                {
                    lst.SelectedItem = this.lst.Items[CurrentIndex];
                }
            }

        }

        //void bor_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Border bor = (Border)sender;
        //    bor.Width = bor.Height = 30;

        //    int tindex = Convert.ToInt32(bor.Tag);

        //    Image im = new Image();
        //    im.Width = ImageCanvas.ActualWidth;
        //    im.Height = ImageCanvas.ActualHeight;
        //    im.Source = ImageList[tindex].ImageSource;

        //    if (tindex > CurrentIndex)
        //    {
        //        if (!AnimationCompleted)
        //        {
        //            CurrentIndex = tindex;
        //            AnimationCompleted = true;

        //            ImageCanvas.Children.Add(im);
        //            ImageCanvas.Children[0].BeginAnimation(Canvas.LeftProperty, MiddleToLeft);
        //            ImageCanvas.Children[1].BeginAnimation(Canvas.LeftProperty, RightToMiddle);
        //        }
        //        else
        //        {

        //        }
        //    }
        //    else if (tindex < CurrentIndex)
        //    {
        //        if (!AnimationCompleted)
        //        {
        //            CurrentIndex = tindex;
        //            AnimationCompleted = true;
        //            ImageCanvas.Children.Add(im);
        //            ImageCanvas.Children[0].BeginAnimation(Canvas.LeftProperty, MiddleToRight);
        //            ImageCanvas.Children[1].BeginAnimation(Canvas.LeftProperty, LeftToMiddle);
        //        }
        //    }

        //}

        void MiddleToRight_Completed(object sender, EventArgs e)
        {
            if (this.ImageCanvas != null && ImageCanvas.Children.Count > 1)
            {
                this.ImageCanvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }
        void LeftToMiddle_Completed(object sender, EventArgs e)
        {
            if (this.ImageCanvas != null && ImageCanvas.Children.Count > 1)
            {
                this.ImageCanvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }

        void RightToMiddle_Completed(object sender, EventArgs e)
        {
            if (this.ImageCanvas != null && ImageCanvas.Children.Count > 1)
            {
                this.ImageCanvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }

        void MiddleToLeft_Completed(object sender, EventArgs e)
        {
            if (this.ImageCanvas != null && ImageCanvas.Children.Count > 1)
            {
                this.ImageCanvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }
        #endregion

        private void TitleBor_MouseEnter(object sender, MouseEventArgs e)
        {
            TitleBor.Background = Brushes.Lavender;
        }

        private void TitleBor_MouseLeave(object sender, MouseEventArgs e)
        {
            TitleBor.Background = Brushes.White;
        }
    }

    /// <summary>
    /// 缩略图实体类
    /// </summary>
    public class SmallImageEntity
    {
        /// <summary>
        /// 图片设置
        /// </summary>
        public BitmapImage ImageSource { get; set; }

        /// <summary>
        /// 图片索引
        /// </summary>
        public int ImageIndex { get; set; }
    }
}
