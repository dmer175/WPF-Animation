using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace PartWPFModel
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private Point3D _center;
		public MainWindow()
		{
			this.InitializeComponent();
		    MeasureModel(RootGeometryContainer);
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
		}

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            Yaw(false, 2);
            YawWithDefaultCenter(false, 2);
        }

        public void MeasureModel(ModelVisual3D model)
        {
            var rect3D = Rect3D.Empty;
            UnionRect(model, ref rect3D);

            _center = new Point3D((rect3D.X + rect3D.SizeX / 2), (rect3D.Y + rect3D.SizeY / 2),
                                  (rect3D.Z + rect3D.SizeZ / 2));

            double radius = (_center - rect3D.Location).Length;
            Point3D position = _center;
            position.Z += radius * 2;
            position.X = position.Z;
            camera.Position = position;
            camera.LookDirection = _center - position;
            camera.NearPlaneDistance = radius / 100;
            camera.FarPlaneDistance = radius * 100;
        }

        private void UnionRect(ModelVisual3D model, ref Rect3D rect3D)
        {
            for (int i = 0; i < model.Children.Count; i++)
            {
                var child = model.Children[i] as ModelVisual3D;
                UnionRect(child, ref rect3D);

            }
            if (model.Content != null)
                rect3D.Union(model.Content.Bounds);
        }

        public void Yaw(bool leftRight, double angleDeltaFactor)
        {
            var axis = new AxisAngleRotation3D(camera.UpDirection, leftRight ? angleDeltaFactor : -angleDeltaFactor);
            var rt3D = new RotateTransform3D(axis) { CenterX = _center.X, CenterY = _center.Y, CenterZ = _center.Z };
            Matrix3D matrix3D = rt3D.Value;
            Point3D point3D = camera.Position;
            Point3D position = matrix3D.Transform(point3D);
            camera.Position = position;
            camera.LookDirection = camera.LookDirection = _center - position;
        }

        public void YawWithDefaultCenter(bool leftRight, double angleDeltaFactor)
        {
            var axis = new AxisAngleRotation3D(camera1.UpDirection, leftRight ? angleDeltaFactor : -angleDeltaFactor);
            var rt3D = new RotateTransform3D(axis);
            Matrix3D matrix3D = rt3D.Value;
            Point3D point3D = camera1.Position;
            Point3D position = matrix3D.Transform(point3D);
            camera1.Position = position;
            camera1.LookDirection = camera1.LookDirection = _center - position;
        }
	}
}