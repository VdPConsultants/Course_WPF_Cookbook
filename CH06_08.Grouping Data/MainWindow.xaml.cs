using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CH06_08.Grouping_Data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var processes = Process.GetProcesses().Where(CanAccess);
            var view = CollectionViewSource.GetDefaultView(processes);
            view.GroupDescriptions.Add(new PropertyGroupDescription("PriorityClass"));
            DataContext = processes;
        }

        public static bool CanAccess(Process process)
        {
            try
            {
                var h = process.Handle;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
