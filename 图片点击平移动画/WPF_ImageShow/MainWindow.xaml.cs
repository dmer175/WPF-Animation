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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ImageShow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 图片列表
        /// </summary>
        List<SmallImageEntity> ImageList = new List<SmallImageEntity>();

        /// <summary>
        /// 向左移动撤出
        /// </summary>
        private DoubleAnimation _MiddleToLeftAnimation;
        /// <summary>
        /// 向左移动进入
        /// </summary>
        private DoubleAnimation _RightToMiddelAnimation;
        /// <summary>
        /// 向右移动撤出
        /// </summary>
        private DoubleAnimation _MiddleToRightAnimation;

        /// <summary>
        /// 向右移动进入
        /// </summary>
        private DoubleAnimation _LeftToMiddleAnimation;

        /// <summary>
        /// 当前显示的图片
        /// </summary>
        int CurrentIndex = 0;

        /// <summary>
        /// 动画是否完成
        /// </summary>
        bool AnimationCompleted = false;



        public MainWindow()
        {
            InitializeComponent();
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("1.png", UriKind.RelativeOrAbsolute)) });
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("2.png", UriKind.RelativeOrAbsolute)) });
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("3.png", UriKind.RelativeOrAbsolute)) });
            ImageList.Add(new SmallImageEntity() { ImageSource = new BitmapImage(new Uri("4.jpg", UriKind.RelativeOrAbsolute)) });

            this.lst.ItemsSource = ImageList;


            this.Loaded += MainWindow_Loaded;

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Image image = new Image();
            image.Width = this.canvas.ActualWidth;
            image.Height = this.canvas.ActualHeight;
            image.Source = ImageList[0].ImageSource;
            canvas.Children.Add(image);

            double i = this.canvas.ActualWidth;

            _MiddleToLeftAnimation = new DoubleAnimation(0, -i, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.Stop);
            _RightToMiddelAnimation = new DoubleAnimation(i, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);

            _MiddleToLeftAnimation.Completed += _MiddleToLeftAnimation_Completed;
            _RightToMiddelAnimation.Completed += _RightToMiddelAnimation_Completed;

            _LeftToMiddleAnimation = new DoubleAnimation(-i, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
            _MiddleToRightAnimation = new DoubleAnimation(0, i, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);

            _LeftToMiddleAnimation.Completed += _LeftToMiddleAnimation_Completed;
            _MiddleToRightAnimation.Completed += _MiddleToRightAnimation_Completed;


            this.lst.SelectionChanged += lst_SelectionChanged;
        }

        void _MiddleToRightAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
        }

        void _LeftToMiddleAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }

        void _MiddleToLeftAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
        }
        //动画结束，删除第一张
        void _RightToMiddelAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }

        ///右侧选择时，左侧进行相应的改变

        void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int t_index = this.lst.SelectedIndex;


            Image image = new Image();
            image.Width = this.canvas.ActualWidth;
            image.Height = this.canvas.ActualHeight;
            image.Source = ImageList[t_index].ImageSource;

            if (t_index > CurrentIndex)
            {
                MoveToLeftAnimate(image, t_index);
            }
            else if (t_index < CurrentIndex)
            {
                MoveToRightAnimate(image, t_index);
            }

        }


        private void MoveToLeftAnimate(Image image, int t_index)
        {
            if (!AnimationCompleted)
            {
                CurrentIndex = t_index;
                AnimationCompleted = true;

                canvas.Children.Add(image);
                canvas.Children[0].BeginAnimation(Canvas.LeftProperty, _MiddleToLeftAnimation);
                canvas.Children[1].BeginAnimation(Canvas.LeftProperty, _RightToMiddelAnimation);
            }
            else
            {
                this.lst.SelectedItem = this.lst.Items[CurrentIndex];
                // this.lst.SelectedIndex = CurrentIndex;
            }


        }
        private void MoveToRightAnimate(Image image, int t_index)
        {
            if (!AnimationCompleted)
            {
                CurrentIndex = t_index;
                AnimationCompleted = true;

                canvas.Children.Add(image);
                canvas.Children[0].BeginAnimation(Canvas.LeftProperty, _MiddleToRightAnimation);
                canvas.Children[1].BeginAnimation(Canvas.LeftProperty, _LeftToMiddleAnimation);
            }

            else
            {
                this.lst.SelectedItem = this.lst.Items[CurrentIndex];
                // this.lst.SelectedIndex = CurrentIndex;
            }

        }
    }

    /// <summary>
    /// 缩略图实体类
    /// </summary>
    //public class SmallImageEntity
    //{
    //    /// <summary>
    //    /// 图片
    //    /// </summary>
    //    public BitmapImage ImageSource { get; set; }
    //    /// <summary>
    //    /// 索引
    //    /// </summary>
    //    public int ImageIndex { get; set; }
    //}
}
