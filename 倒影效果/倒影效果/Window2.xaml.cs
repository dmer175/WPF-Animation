using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 倒影效果
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        /// <summary>  
        /// 委托声明：鼠标点击事件处理器  
        /// </summary>  
        /// <param name="sender">附加事件处理程序的对象</param>  
        /// <param name="e">事件数据</param>  
        public delegate void MyMouseDownEventHandler(object sender, System.Windows.Input.MouseButtonEventArgs e);

        /// <summary>  
        /// 返回指定目录中与指定的搜索模式匹配的文件的名称（包含它们的路径），并使用一个值以确定是否搜索子目录  
        /// </summary>  
        /// <param name="folderPath">将从其检索文件的目录</param>  
        /// <param name="filter">搜索模式匹配</param>  
        /// <param name="searchOption">指定搜索操作应包括所有子目录还是仅包括当前目录</param>  
        /// <returns>包含指定目录中与指定搜索模式匹配的文件的名称列表</returns>  
        public static String[] GetFiles(String folderPath, String filter, SearchOption searchOption)
        {   // 获取文件列表  
            String[] FileEntries = Directory.GetFiles(folderPath, "*", searchOption);
            if (FileEntries.Length == 0)
                return null;
            else if (String.IsNullOrEmpty(filter))
                return FileEntries;

            // 建立正则表达式  
            Regex rx = new Regex(filter, RegexOptions.IgnoreCase);

            // 过滤文件  
            List<String> FilterFileEntries = new List<String>(FileEntries.Length);
            foreach (String FileName in FileEntries)
            {
                if (rx.IsMatch(FileName))
                {
                    FilterFileEntries.Add(FileName);
                }
            }

            return (FilterFileEntries.Count == 0) ? null : FilterFileEntries.ToArray();
        }

        /// <summary>  
        /// 返回指定目录中图像文件列表，并使用一个值以确定是否搜索子目录  
        /// </summary>  
        /// <param name="folderPath">将从其检索文件的目录</param>  
        /// <param name="searchOption">指定搜索操作应包括所有子目录还是仅包括当前目录</param>  
        /// <returns>图像文件列表</returns>  
        public static String[] GetImages(String folderPath, SearchOption searchOption)
        {
            String filter = "\\.(bmp|gif|jpg|jpe|png|tiff|tif)$";
            return GetFiles(folderPath, filter, searchOption);
        }

        /// <summary>  
        /// 显示图像  
        /// </summary>  
        /// <param name="panel">放置图像控件的容器</param>  
        /// <param name="images">要显示的图像文件集合</param>  
        /// <param name="handler">图像控件点击事件处理器</param>  
        public static void DisplayImages(StackPanel panel, String[] images, MyMouseDownEventHandler handler)
        {   // 参数检测  
            if ((panel == null) || (images == null)) return;

            // 清空所有图像控件  
            panel.Children.Clear();

            // 增加新的图像控件  
            Double Stride = (panel.Orientation == Orientation.Horizontal) ? panel.Height : panel.Width;
            foreach (String FileName in images)
            {   // 设置边框                             
                Border border = new Border();
                border.Margin = new System.Windows.Thickness(4);            // 边框外边距  
                border.BorderThickness = new System.Windows.Thickness(4);   // 边框厚度  
                border.BorderBrush = new SolidColorBrush(Colors.DarkGreen); // 边框颜色  

                // 边框大小  
                if (panel.Orientation == Orientation.Horizontal)
                {
                    border.Height = border.Width = Stride - border.Margin.Top - border.Margin.Bottom;
                }
                else
                {
                    border.Height = border.Width = Stride - border.Margin.Left - border.Margin.Right;
                }

                // 设置图像控件  
                Image image = new Image();
                image.Width = border.Width - border.BorderThickness.Left - border.BorderThickness.Right;   // 图像控件宽度  
                image.Height = border.Height - border.BorderThickness.Top - border.BorderThickness.Bottom;  // 图像控件高度  
                image.Stretch = System.Windows.Media.Stretch.Uniform;
                image.Source = new BitmapImage(new Uri(FileName));

                // 图片点击事件  
                image.MouseDown += new System.Windows.Input.MouseButtonEventHandler(handler);

                // 设置控件布局  
                border.Child = image;
                panel.Children.Add(border);
            }
        }  
    }
}
