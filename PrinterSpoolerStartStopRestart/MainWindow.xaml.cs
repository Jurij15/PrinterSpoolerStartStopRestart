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
using Wpf.Ui;
using PrinterSpoolerStartStopRestart.PrinterSpoolerClasses;
using Wpf.Ui.Controls;

namespace PrinterSpoolerStartStopRestart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            //initialize start class
            Start start = new Start();
            //execute start
            start.StartExecute();
        }
        //net5.0-windows10.0.19041.0
        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            //initialize stop class
            Stop stop = new Stop();
            //execute stop
            stop.StopExecute();
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            //initialize restart class
            Restart restart = new Restart();
            //execute restart
            restart.ExecuteRestart();
        }

        private void OpenGitHub_Click(object sender, RoutedEventArgs e)
        {
            var uri = "https://github.com/Jurij15/PrinterSpoolerStartStopRestart";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
