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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using ModernWpf;
using PrinterSpoolerStartStopRestart.PrinterSpoolerClasses;

namespace PrinterSpoolerStartStopRestart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Start start = new Start();
            start.StartExecute();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            Stop stop = new Stop();
            stop.StopExecute();
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            Restart restart = new Restart();
            restart.ExecuteRestart();
        }
    }
}
