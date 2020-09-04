using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CH07_02.MVVM.Commands
{
    class OpenImageFileCommand : ICommand
    {
        ImageData _data;
        public OpenImageFileCommand(ImageData data)
        {
            _data = data;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == true)
            {
                _data.ImagePath = dlg.FileName;
            }
        }
    }
}
