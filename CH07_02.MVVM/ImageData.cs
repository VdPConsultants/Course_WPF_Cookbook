using CH07_02.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CH07_02.MVVM
{
    class ImageData : INotifyPropertyChanged
    {
        ICommand _openImageFileCommand, _zoomCommand;
        public ICommand OpenImageFileCommand
        {
            get { return _openImageFileCommand; }
        }

        public ICommand ZoomCommand
        {
            get { return _zoomCommand; }
        }
        string _imagePath;
        double _zoom = 1.0;
        public double Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                OnPropertyChanged("Zoom");
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public ImageData() 
        { 
            _openImageFileCommand = new OpenImageFileCommand(this);
            _zoomCommand = new ZoomCommand(this);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
