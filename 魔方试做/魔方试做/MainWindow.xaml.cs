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
using System.Windows.Media.Animation;

namespace 魔方试做
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //wpf的动画效果 查询
        public MainWindow()
        {
            InitializeComponent();
            this.Top = this.Left = 0;
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Height = SystemParameters.FullPrimaryScreenHeight;
            Loaded += MainWindow_Loaded;
        }
        int[] face = new int[45];
        int[] difface = new int[5];
        int[] newface = new int[45];
        //List<int> face = new List<int>();
        Random ra = new Random();
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ImageLayout();//图片布局

            ImageButtom();//按钮布局

            PanDuan();

            ImageBox();//边框

            Button btSuc = new Button();
            btSuc.Height = 30;
            btSuc.Width = 80;
            btSuc.Content = "点我有惊喜!";
            Canvas.SetLeft(btSuc, 100);
            Canvas.SetTop(btSuc, 150);
            back.Children.Add(btSuc);

            btSuc.Click += btSuc_Click;
        }
        Storyboard sbd = new Storyboard();
        void btSuc_Click(object sender, RoutedEventArgs e)
        {
            Image[] image = new Image[9];
            for (int i = 18; i < 27; i++)
            {
                image[i - 18] = Animal[i];
            }
            int co = 0;
            for (int i = 1; i < image.Length; i++)
            {
                if (image[0].Tag.ToString()==image[i].Tag.ToString())
                {
                    co++;
                }
            }
            if (co==8)
            {
                //MessageBox.Show("好累");
                for (int i = 0; i < image.Length; i++)
                {
                    RotateTransform rtf = new RotateTransform();
                    image[i].RenderTransform = rtf;
                    image[i].RenderTransformOrigin = new Point(0.5, 0.5);

                    DoubleAnimation da = new DoubleAnimation(-20, 20, new Duration(TimeSpan.FromMilliseconds(400)));
                    Storyboard.SetTarget(da, image[i]);
                    Storyboard.SetTargetProperty(da, new PropertyPath("RenderTransform.Angle"));
                    da.AutoReverse = true;
                    da.RepeatBehavior = RepeatBehavior.Forever;
                    sbd.Children.Add(da);
                    sbd.Begin();
                }
                
            }
        }

        private void ImageBox()
        {
            Border bd = new Border();
            bd.Width = bd.Height = 150;
            bd.BorderBrush = Brushes.Red;
            bd.BorderThickness = new Thickness(1);
            Canvas.SetLeft(bd, this.Width / 2 - im.Width / 2 * 3);
            Canvas.SetTop(bd, this.Height / 2 - im.Height / 2 * 3);
            back.Children.Add(bd);
        }

        private void PanDuan()
        {
            int count = 0;
            for (int i = 19; i < 27; i++)
            {
                //if (Animal[i].Tag == Animal[i + 1].Tag)
                //{
                //    count++;
                //}
                if (Animal[18].Tag.ToString()==Animal[i].Tag.ToString())
                {
                    count++;
                }
            }
            if (count == 8)
            {
                MessageBox.Show("完成");
            }
        }

        private void ImageButtom()
        {
            for (int i = 0; i < 3; i++)
            {
                Button btLeft = new Button();
                btLeft.Height = btLeft.Width = 35;
                btLeft.Content = "左";
                btLeft.VerticalContentAlignment = VerticalAlignment.Center;//文本位置
                btLeft.Tag = i;
                Canvas.SetLeft(btLeft, this.Width / 2 - im.Width / 2 * 9 - btLeft.Width);
                Canvas.SetTop(btLeft, this.Height / 2 - im.Height / 2 * 3 + 10 + i * im.Height);
                back.Children.Add(btLeft);

                btLeft.Click += btLeft_Click;
            }
            for (int i = 0; i < 3; i++)
            {
                Button btRight = new Button();
                btRight.Height = btRight.Width = 35;
                btRight.Content = "右";
                btRight.VerticalContentAlignment = VerticalAlignment.Center;//文本位置
                btRight.Tag = i;
                Canvas.SetLeft(btRight, this.Width / 2 + im.Width / 2 * 9);
                Canvas.SetTop(btRight, this.Height / 2 - im.Height / 2 * 3 + 10 + i * im.Height);

                back.Children.Add(btRight);
                btRight.Click += btRight_Click;
            }
            for (int i = 0; i < 3; i++)
            {
                Button btTop = new Button();
                btTop.Height = btTop.Width = 35;
                btTop.Content = "上";
                btTop.VerticalContentAlignment = VerticalAlignment.Center;//文本位置
                btTop.Tag = i;
                Canvas.SetLeft(btTop, this.Width / 2 - im.Width / 2 * 3 + 10 + i * im.Width);
                Canvas.SetTop(btTop, this.Height / 2 - im.Height / 2 * 9 - btTop.Height);
                back.Children.Add(btTop);

                btTop.Click += btTop_Click;
            }
            for (int i = 0; i < 3; i++)
            {
                Button btBottom = new Button();
                btBottom.Height = btBottom.Width = 35;
                btBottom.Content = "下";
                btBottom.VerticalContentAlignment = VerticalAlignment.Center;//文本位置
                btBottom.Tag = i;
                Canvas.SetLeft(btBottom, this.Width / 2 - im.Width / 2 * 3 + 10 + i * im.Width);
                Canvas.SetTop(btBottom, this.Height / 2 + im.Height / 2 * 9);
                back.Children.Add(btBottom);

                btBottom.Click += btBottom_Click;
            }
        }

        void btBottom_Click(object sender, RoutedEventArgs e)
        {
            Button bt4 = (Button)sender;
            if (Convert.ToInt32(bt4.Tag)==0)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 0)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 18; i < 27; i++)
                {
                    if (i % 3 == 0)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 36; i < 45; i++)
                {
                    if (i % 3 == 0)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im1 = new Image();
                im1.Source = move[8].Source;
                im1.Tag = move[8].Tag;
                for (int i = 8; i > 0; i--)
                {
                    move[i].Source = move[i - 1].Source;
                    move[i].Tag = move[i - 1].Tag;
                }
                move[0].Source = im1.Source;
                move[0].Tag = im1.Tag;
                move.Clear();
            }

            if (Convert.ToInt32(bt4.Tag) == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 1)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 18; i < 27; i++)
                {
                    if (i % 3 == 1)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 36; i < 45; i++)
                {
                    if (i % 3 == 1)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im2 = new Image();
                im2.Source = move[8].Source;
                im2.Tag = move[8].Tag;
                for (int i = 8; i > 0; i--)
                {
                    move[i].Source = move[i - 1].Source;
                    move[i].Tag = move[i - 1].Tag;
                }
                move[0].Source = im2.Source;
                move[0].Tag = im2.Tag;
                move.Clear();
            }

            if (Convert.ToInt32(bt4.Tag) == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 18; i < 27; i++)
                {
                    if (i % 3 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 36; i < 45; i++)
                {
                    if (i % 3 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im3 = new Image();
                im3.Source = move[8].Source;
                im3.Tag = move[8].Tag;
                for (int i = 8; i > 0; i--)
                {
                    move[i].Source = move[i - 1].Source;
                    move[i].Tag = move[i - 1].Tag;
                }
                move[0].Source = im3.Source;
                move[0].Tag = im3.Tag;
                move.Clear();
            }

            PanDuan();
        }

        void btTop_Click(object sender, RoutedEventArgs e)
        {
            Button bt3 = (Button)sender;
            if (Convert.ToInt32(bt3.Tag)==0)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i%3==0)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 18; i < 27; i++)
                {
                    if (i%3==0)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 36; i < 45; i++)
                {
                    if (i%3==0)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im1 = new Image();
                im1.Source = move[0].Source;
                im1.Tag = move[0].Tag;
                for (int i = 0; i < 8; i++)
                {
                    move[i].Source = move[i + 1].Source;
                    move[i].Tag = move[i + 1].Tag;
                }
                move[8].Source = im1.Source;
                move[8].Tag = im1.Tag;
                move.Clear();
            }

            if (Convert.ToInt32(bt3.Tag) == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 1)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 18; i < 27; i++)
                {
                    if (i % 3 == 1)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 36; i < 45; i++)
                {
                    if (i % 3 == 1)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im2 = new Image();
                im2.Source = move[0].Source;
                im2.Tag = move[0].Tag;
                for (int i = 0; i < 8; i++)
                {
                    move[i].Source = move[i + 1].Source;
                    move[i].Tag = move[i + 1].Tag;
                }
                move[8].Source = im2.Source;
                move[8].Tag = im2.Tag;
                move.Clear();
            }

            if (Convert.ToInt32(bt3.Tag) == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 18; i < 27; i++)
                {
                    if (i % 3 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                for (int i = 36; i < 45; i++)
                {
                    if (i % 3 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im3 = new Image();
                im3.Source = move[0].Source;
                im3.Tag = move[0].Tag;
                for (int i = 0; i < 8; i++)
                {
                    move[i].Source = move[i + 1].Source;
                    move[i].Tag = move[i + 1].Tag;
                }
                move[8].Source = im3.Source;
                move[8].Tag = im3.Tag;
                move.Clear();
            }

            PanDuan();
        }

        void btRight_Click(object sender, RoutedEventArgs e)
        {
            Button bt2 = (Button)sender;
            if (Convert.ToInt32(bt2.Tag)==0)
            {
                for (int i = 9; i < 36; i++)
                {
                    if (i % 9 == 0 || i % 9 == 1 || i % 9 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }
                Image im1 = new Image();
                im1.Source = move[8].Source;
                im1.Tag = move[8].Tag;
                for (int i = 8; i > 0; i--)
                {
                    move[i].Source = move[i - 1].Source;
                    move[i].Tag = move[i - 1].Tag;
                }
                move[0].Source = im1.Source;
                move[0].Tag = im1.Tag;
                move.Clear();
            }
            if (Convert.ToInt32(bt2.Tag)==1)
            {
                for (int i = 9; i < 36; i++)
                {
                    if (i % 9 == 3 || i % 9 == 4 || i % 9 == 5)
                    {
                        move.Add(Animal[i]);
                    }
                }

                Image im2 = new Image();
                im2.Source = move[8].Source;
                im2.Tag = move[8].Tag;
                for (int i = 8; i > 0; i--)
                {
                    move[i].Source = move[i - 1].Source;
                    move[i].Tag = move[i - 1].Tag;
                }
                move[0].Source = im2.Source;
                move[0].Tag = im2.Tag;
                move.Clear();
            }
            if (Convert.ToInt32(bt2.Tag)==2)
            {
                for (int i = 9; i < 36; i++)
                {
                    if (i % 9 == 6 || i % 9 == 7 || i % 9 == 8)
                    {
                        move.Add(Animal[i]);
                    }
                }

                Image im3 = new Image();
                im3.Source = move[8].Source;
                im3.Tag = move[8].Tag;
                for (int i = 8; i > 0; i--)
                {
                    move[i].Source = move[i - 1].Source;
                    move[i].Tag = move[i - 1].Tag;
                }
                move[0].Source = im3.Source;
                move[0].Tag = im3.Tag;
                move.Clear();
            }

            PanDuan();
        }
        List<Image> move = new List<Image>();//点击按钮时改行/列的图片存储
        void btLeft_Click(object sender, RoutedEventArgs e)
        {
            Button btl = (Button)sender;
            if (Convert.ToInt32(btl.Tag) == 0)
            {
                for (int i = 9; i < 36; i++)
                {
                    if (i % 9 == 0 || i % 9 == 1 || i % 9 == 2)
                    {
                        move.Add(Animal[i]);
                    }
                }

                Image im1 = new Image();
                im1.Source = move[0].Source;
                im1.Tag = move[0].Tag;
                for (int i = 0; i < 8; i++)
                {
                    move[i].Source = move[i + 1].Source;
                    move[i].Tag = move[i + 1].Tag;
                }
                move[8].Source = im1.Source;
                move[8].Tag = im1.Tag;
                move.Clear();
            }

            if (Convert.ToInt32(btl.Tag) == 1)
            {
                for (int i = 9; i < 36; i++)
                {
                    if (i % 9 == 3 || i % 9 == 4 || i % 9 == 5)
                    {
                        move.Add(Animal[i]);
                    }
                }

                Image im2 = new Image();
                im2.Source = move[0].Source;
                im2.Tag = move[0].Tag;
                for (int i = 0; i < 8; i++)
                {
                    move[i].Source = move[i + 1].Source;
                    move[i].Tag = move[i + 1].Tag;
                }
                move[8].Source = im2.Source;
                move[8].Tag = im2.Tag;
                move.Clear();
            }

            if (Convert.ToInt32(btl.Tag) == 2)
            {
                for (int i = 9; i < 36; i++)
                {
                    if (i % 9 == 6 || i % 9 == 7 || i % 9 == 8)
                    {
                        move.Add(Animal[i]);
                    }
                }

                Image im3 = new Image();
                im3.Source = move[0].Source;
                im3.Tag = move[0].Tag;
                for (int i = 0; i < 8; i++)
                {
                    move[i].Source = move[i + 1].Source;
                    move[i].Tag = move[i + 1].Tag;
                }
                move[8].Source = im3.Source;
                move[8].Tag = im3.Tag;
                move.Clear();
            }

            PanDuan();
        }
        Image im;
        Image[] Animal = new Image[45];
        private void ImageLayout()
        {
            //取五个不同的数
            for (int i = 0; i < difface.Length; i++)
            {
                difface[i] = ra.Next(1, 13);
                for (int j = 0; j < i; j++)
                {
                    if (difface[i] == difface[j])
                    {
                        i--;
                        break;
                    }
                }
            }
            //按顺序取9次5个不同的数 01234 01234 01234 ......
            for (int i = 0; i < face.Length; i++)
            {
                for (int j = 0; j < difface.Length; j++)
                {
                    if (i % 5 == j)
                    {
                        face[i] = difface[j];
                    }
                }
            }
            //打乱数组
            int k = 0;
            while (k < face.Length)
            {
                int temp = ra.Next(face.Length);
                if (face[temp] != 0)
                {
                    newface[k] = face[temp];
                    k++;
                    face[temp] = 0;
                }
            }

            for (int i = 0; i < Animal.Length; i++)
            {
                im = new Image();
                im.Width = im.Height = 50;
                im.Source = new BitmapImage(new Uri("Img/" + newface[i] + ".png", UriKind.Relative));
                im.Tag = newface[i];

                if (i >= 0 && i <= 8)
                {
                    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 3 + i % 3 * im.Width);
                    Canvas.SetTop(im, this.Height / 2 - im.Height / 2 * 9 + i / 3 * im.Height);
                }
                if (i >= 9 && i <= 17)
                {
                    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 9 + (i-9) % 3 * im.Width);
                    Canvas.SetTop(im, this.Height / 2 - im.Height / 2 * 3 + (i-9) / 3 * im.Height);
                }
                if (i>=18&&i<=26)
                {
                    //im.Source = new BitmapImage(new Uri("Img/6.png", UriKind.Relative));
                    //im.Tag = 6;
                    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 3 + (i - 18) % 3 * im.Width);
                    Canvas.SetTop(im, this.Height / 2 - im.Height / 2 * 3 + (i - 18) / 3 * im.Height);
                }
                if (i>=27&&i<=35)
                {
                    Canvas.SetLeft(im, this.Width / 2 + im.Width / 2 * 3 + (i - 27) % 3 * im.Width);
                    Canvas.SetTop(im, this.Height / 2 - im.Height / 2 * 3 + (i - 27) / 3 * im.Height);
                }
                if (i >= 36 && i <= 44)
                {
                    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 3 + (i-36) % 3 * im.Width);
                    Canvas.SetTop(im, this.Height / 2 + im.Height / 2 * 3 + (i-36) / 3 * im.Height);
                }
                Animal[i] = im;
                back.Children.Add(im);
            }

            //for (int i = 0; i < 9; i++)
            //{
            //    //int jl = ra.Next(face.Count);
            //    im = new Image();
            //    im.Width = im.Height = 50;
            //    im.Source = new BitmapImage(new Uri("Img/" + newface[i] + ".png", UriKind.Relative));
            //    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 3 + i % 3 * im.Width);
            //    Canvas.SetTop(im, this.Height / 2 - im.Height / 2 * 9 + i / 3 * im.Height);
            //    back.Children.Add(im);
            //    //face.Remove(face[jl]);
            //}

            //for (int i = 0; i < 27; i++)
            //{
            //    //int jl = ra.Next(face.Count);
            //    im = new Image();
            //    im.Width = im.Height = 50;
            //    im.Source = new BitmapImage(new Uri("Img/" + newface[i + 9] + ".png", UriKind.Relative));
            //    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 9 + i % 9 * im.Width);
            //    Canvas.SetTop(im, this.Height / 2 - im.Height / 2 * 3 + i / 9 * im.Height);
            //    back.Children.Add(im);
            //    //face.Remove(face[jl]);
            //}

            //for (int i = 0; i < 9; i++)
            //{
            //    //int jl = ra.Next(face.Count);
            //    im = new Image();
            //    im.Width = im.Height = 50;
            //    im.Source = new BitmapImage(new Uri("Img/" + newface[i + 36] + ".png", UriKind.Relative));
            //    Canvas.SetLeft(im, this.Width / 2 - im.Width / 2 * 3 + i % 3 * im.Width);
            //    Canvas.SetTop(im, this.Height / 2 + im.Height / 2 * 3 + i / 3 * im.Height);
            //    back.Children.Add(im);
            //    //face.Remove(face[jl]);
            //}
        }

    }
}
