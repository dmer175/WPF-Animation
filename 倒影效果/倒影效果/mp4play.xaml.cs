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
using System.Windows.Shapes;
using System.Windows.Navigation;


namespace 倒影效果
{
    //List<ListBoxKeyValue> list = new List<ListBoxKeyValue>();  
  
        //int curList; 
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void top_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)  
  
        {  
  
        this.DragMove();  
  
// TODO: Add event handler implementation here.  
  
        }  
  
  
  
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)  
  
        {  
  
//this.Unloaded();  
  
            this.Close();  
  
// TODO: Add event handler implementation here.  
  
        }  
  
  
  
//        private void btnOpenFile_Click(object sender, RoutedEventArgs e)  
  
//        {  
  
//            ShellContainer selectedFolder = null;  
  
//            selectedFolder = KnownFolders.SampleVideos as ShellContainer;  
  
//            CommonOpenFileDialog cfd = new CommonOpenFileDialog(); // 需要添加Microsoft.WindowsAPICodePack.dll的引用，在源码中  
  
//                                                                                                              //有，有需要可以下载。  
  
//            cfd.Multiselect = true;  
  
//            cfd.InitialDirectoryShellContainer = selectedFolder;  
  
//            cfd.EnsureReadOnly = true;  
  
//            cfd.Filters.Add(new CommonFileDialogFilter("MP3 Files", "*.mp3"));  
  
//            cfd.Filters.Add(new CommonFileDialogFilter("WMA Files", "*.wma"));  
  
//            cfd.Filters.Add(new CommonFileDialogFilter("WMV Files", "*.wmv"));  
  
//            cfd.Filters.Add(new CommonFileDialogFilter("AVI Files", "*.avi"));  
  
  
  
  
  
//            if (cfd.ShowDialog() == CommonFileDialogResult.OK)  
  
//            {  
  
//                //mediaElement.Source = new Uri(cfd.FileName, UriKind.Relative);  
  
//                foreach (string path in cfd.FileNames)  
  
//                {  
  
//                    int soundNameIndex = path.LastIndexOf(@"\");  
  
//                    string strSoundName = path.Substring(soundNameIndex + 1);  
  
//                    ListBoxKeyValue l = new ListBoxKeyValue();  
  
//                    l.Key = path;  
  
//                    l.Value = strSoundName;  
  
//                    list.Add(l);  
  
//                    //this.lbMediaList.Items.Add(path);  
  
//                }  
  
//                //playBtn.IsEnabled = true;  
  
//            }  
  
//            ShowNameInLB();  
  
//        }  
  
////实现往播放列表托文件的功能  
  
//        private void lbMediaList_Drop(object sender, DragEventArgs e)  
  
//        {  
  
//            mediaElement.Close();  
  
//            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);  
  
             
  
//            int i;  
  
//            for (i = 0; i < s.Length; i++)  
  
//            {  
  
//                string reg = s[i].Substring(s[i].Length - 3);  
  
//                if (reg.ToLower() == "mp3" || reg.ToLower() == "wma" || reg.ToLower() == "avi" || reg.ToLower() == "rm" || reg.ToLower() == "wmv")  
  
//                {  
  
//                    ListBoxKeyValue l = new ListBoxKeyValue();  
  
//                    l.Key = s[i];  
  
//                    int soundNameIndex = s[i].LastIndexOf(@"\");  
  
//                    string strSoundName = s[i].Substring(soundNameIndex + 1);  
  
//                    l.Value = strSoundName;  
  
//                    list.Add(l);  
  
//                }  
  
//            }  
  
//            ShowNameInLB();  
  
//        }  
  
////双击播放列表中的媒体文件播放  
  
//        private void lbMediaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)  
  
//        {  
  
//            //string value = this.lbMediaList.SelectedItem.ToString();  
  
//            mediaElement.Source = new Uri(FullPath(this.lbMediaList.SelectedItem.ToString()), UriKind.Relative);  
  
//            mediaElement.Play();  
  
//        }  
  
  
  
//        private void mediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)  
  
//        {  
  
  
  
//        }  
  
  
  
//        private void tbtnBack_Checked(object sender, RoutedEventArgs e)  
  
//        {  
  
//            mediaElement.Position = mediaElement.Position - TimeSpan.FromSeconds(10);  
  
//        }  
  
  
  
//        private void tbtnForword_Checked(object sender, RoutedEventArgs e)  
  
//        {  
  
//            mediaElement.Position = mediaElement.Position + TimeSpan.FromSeconds(10);  
  
//        }  
  
  
  
//        private void btnStop_Click(object sender, RoutedEventArgs e)  
  
//        {  
  
//            mediaElement.Stop();  
  
//        }  
  
////全屏  
  
//        private void btnMaxSrc_Click(object sender, RoutedEventArgs e)  
  
//        {  
  
//            this.Top = 0;  
  
//            this.Left = 0;  
  
//            this.Height= SystemParameters.FullPrimaryScreenHeight;  
  
//            this.Width = SystemParameters.FullPrimaryScreenWidth;  
  
//            //MaxWidth = SystemParameters.FullPrimaryScreenWidth;  
  
              
  
//        }  
  
  
  
//        private void mediaElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  
  
//        {  
  
//            this.DragMove();  
  
//        }  
  
  
  
//        private void btnPlay_Click(object sender, RoutedEventArgs e)  
  
//        {  
  
//            if (lbMediaList.SelectedItem != null)  
  
//            {  
  
//                mediaElement.Source = new Uri(FullPath(this.lbMediaList.SelectedItem.ToString()), UriKind.Relative);  
  
//                mediaElement.Play();  
  
//                // System.Windows.Input.MediaCommands.FastForward;  
  
//            }  
  
//            else  
  
//            {  
  
//                MessageBox.Show("请从列表中选择音频文件", "提示", MessageBoxButton.OK, MessageBoxImage.Information);  
  
//            }  
  
//        }  
  
//        //返回列表框中文件的全路径  
  
//        string FullPath(string value)  
  
//        {  
  
//            string fullPath;  
  
//            foreach (ListBoxKeyValue key in list)  
  
//            {  
  
//                if (key.Value == value)  
  
//                {  
  
//                    fullPath = key.Key;  
  
//                    return fullPath;  
  
//                }  
  
//            }  
  
//            return null;  
  
//        }  
  
//        //在列表框中显示文件 名  
  
//        void ShowNameInLB()  
  
//        {  
  
//            this.lbMediaList.Items.Clear();  
  
//            foreach (ListBoxKeyValue value in list)  
  
//            {  
  
//                this.lbMediaList.Items.Add(value.Value);  
  
//            }  
  
//        }  
  
  
  
//        private void lbMediaList_DragEnter(object sender, DragEventArgs e)  
  
//        {  
  
//            mediaElement.Close();  
  
//            if (e.Data.GetDataPresent(DataFormats.FileDrop))  
  
//                e.Effects = DragDropEffects.All;  
  
//            else  
  
//                e.Effects = DragDropEffects.None;   
  
//        }  
  
    }
}
