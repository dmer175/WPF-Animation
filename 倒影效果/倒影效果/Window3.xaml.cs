using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 倒影效果
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        Canvas canvas_board = new Canvas();
        Image image1 = new Image();
        Image image2 = new Image();

        List<BitmapImage> ls_images = new List<BitmapImage>(); //存放图片组
        int n_index = 0;    //滚动索引
        double n_height;   //滚动高度
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] img_files = Directory.GetFiles(string.Format("{0}../../Images", AppDomain.CurrentDomain.SetupInformation.ApplicationBase), "*.png");
            
            
            foreach (string img_path in img_files)
            {
                ls_images.Add(new BitmapImage(new Uri(img_path, UriKind.Absolute)));
            }
            n_height = this.canvas_board.Height;
            this.image1.Source = ls_images[n_index++ % ls_images.Count];
            this.image2.Source = ls_images[n_index % ls_images.Count];

            this.StoryLoad();

        }
        Storyboard storyboard_imgs = new Storyboard();

        void StoryLoad()
        {
            DoubleAnimationUsingKeyFrames daukf_img1 = new DoubleAnimationUsingKeyFrames();
            LinearDoubleKeyFrame k1_img1 = new LinearDoubleKeyFrame(0.0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)));
            LinearDoubleKeyFrame k2_img1 = new LinearDoubleKeyFrame(-n_height, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)));
            daukf_img1.KeyFrames.Add(k1_img1);
            daukf_img1.KeyFrames.Add(k2_img1);
            storyboard_imgs.Children.Add(daukf_img1);
            Storyboard.SetTarget(daukf_img1, image1);
            Storyboard.SetTargetProperty(daukf_img1, new PropertyPath("(Canvas.Top)"));

            DoubleAnimationUsingKeyFrames daukf_img2 = new DoubleAnimationUsingKeyFrames();
            LinearDoubleKeyFrame k1_img2 = new LinearDoubleKeyFrame(n_height, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)));
            LinearDoubleKeyFrame k2_img2 = new LinearDoubleKeyFrame(0.0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)));
            daukf_img2.KeyFrames.Add(k1_img2);
            daukf_img2.KeyFrames.Add(k2_img2);
            storyboard_imgs.Children.Add(daukf_img2);
            Storyboard.SetTarget(daukf_img2, image2);
            Storyboard.SetTargetProperty(daukf_img2, new PropertyPath("(Canvas.Top)"));

            storyboard_imgs.FillBehavior = FillBehavior.Stop;
            storyboard_imgs.Completed += new EventHandler(storyboard_imgs_Completed);
            storyboard_imgs.Begin();
        }

        void storyboard_imgs_Completed(object sender, EventArgs e)
        {
            image1.SetValue(Canvas.TopProperty, 0.0);
            image2.SetValue(Canvas.TopProperty, n_height);
            image1.Source = ls_images[n_index++ % ls_images.Count];
            image2.Source = ls_images[n_index % ls_images.Count];
            storyboard_imgs.Begin();
        }

        void GridLayout()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Width = 300;
            this.Height = 300;

            canvas_board.VerticalAlignment = VerticalAlignment.Top;
            canvas_board.HorizontalAlignment = HorizontalAlignment.Left;
            canvas_board.Margin = new Thickness(10, 10, 0, 0);
            canvas_board.Width = 200;
            canvas_board.Height = 200;
            //canvas_board.Background = new SolidColorBrush(Colors.LightBlue);
            canvas_board.ClipToBounds = true;
            this.grid_main.Children.Add(canvas_board);

            image1.Stretch = Stretch.Fill;
            image1.Width = 200;
            image1.Height = 200;
            this.canvas_board.Children.Add(image1);
            image1.SetValue(Canvas.TopProperty, 0.0);
            image1.SetValue(Canvas.LeftProperty, 0.0);

            image2.Stretch = Stretch.Fill;
            image2.Width = 200;
            image2.Height = 200;
            this.canvas_board.Children.Add(image2);
            image2.SetValue(Canvas.TopProperty, 200.0);
            image2.SetValue(Canvas.LeftProperty, 0.0);
        }
    }
}
