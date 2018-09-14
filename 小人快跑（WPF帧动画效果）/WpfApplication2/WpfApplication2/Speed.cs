using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication2
{
    public class Speed:INotifyPropertyChanged
    {
        private int _speed;
        public int Speeds
        {
            get { return _speed; }
            set
            {
                _speed = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Speeds"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
