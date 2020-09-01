using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CH05_07.UnhandledExceptions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += OnUnhandledException;
        }

        void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Trace.WriteLine(string.Format("{0}: Error: {1}", DateTime.Now, e.Exception));
            MessageBox.Show("Error encountered! Please contact support." +
                Environment.NewLine + e.Exception.Message);
            Shutdown(1);
            e.Handled = true;
        }
    }
}
