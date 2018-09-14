using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 曲线路径动画
{
    public class ImageInfo : INotifyPropertyChanged
    {
        private int _zIndex;

        public int ZIndex
        {
            get { return _zIndex; }
            set
            {
                if (value != _zIndex)
                {
                    _zIndex = value;
                    this.NotifyPropertyChanged("ZIndex");
                }
            }
        }
        private double _left;

        public double Left
        {
            get { return _left; }
            set
            {
                if (value != _left)
                {
                    _left = value;
                    this.NotifyPropertyChanged("Left");
                }
            }
        }
        private double _top;

        public double Top
        {
            get { return _top; }
            set
            {
                if (value != _top)
                {
                    _top = value;
                    this.NotifyPropertyChanged("Top");
                }
            }
        }
        private double _width;

        public double Width
        {
            get { return _width; }
            set
            {
                if (value != _width)
                {
                    _width = value;
                    this.NotifyPropertyChanged("Width");
                }
            }
        }
        private double _height;

        public double Height
        {
            get { return _height; }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    this.NotifyPropertyChanged("Height");
                }
            }
        }

        private double _opacity = 1.0;

        public double Opactity
        {
            get { return _opacity; }
            set
            {
                if (value != _opacity)
                {
                    _opacity = value;
                    this.NotifyPropertyChanged("Opactity");
                }
            }
        }

        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (value != _imagePath)
                {
                    _imagePath = value;
                    this.NotifyPropertyChanged("ImagePath");
                }
            }
        }

        public ImageInfo(string path)
        {
            this.ImagePath = path;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
