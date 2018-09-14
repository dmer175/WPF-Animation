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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace 曲线路径动画
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.001);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Viewport3D V3D = new Viewport3D();
            PerspectiveCamera PC = new PerspectiveCamera();
            PC.FarPlaneDistance = 20; //不知
            PC.FieldOfView = 50;  //越小 3d图反而越大
            PC.NearPlaneDistance = 0;  //改为6 中间会空  好看
            PC.Position = new Point3D(-5, 2, 3);  //面向的位置
            PC.LookDirection = new Vector3D(5, -2, -3);  //背面的位置
            PC.UpDirection = new Vector3D(1, 1, 1);  //倾斜度

            

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
    }
}
