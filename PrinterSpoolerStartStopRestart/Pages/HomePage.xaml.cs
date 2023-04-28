using PrinterSpoolerStartStopRestart.Helpers;
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
using System.Windows.Threading;

namespace PrinterSpoolerStartStopRestart.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Wpf.Ui.Controls.UiPage
    {
        public DispatcherTimer RefreshTimer;

        public async void RefreshStatus()
        {
            bool spoolerStat =  await SpoolerHelper.IsSpoolerRunning();
            if (spoolerStat == true)
            {
                RunningCheck.Visibility = Visibility.Visible;
                NotRunningCheck.Visibility = Visibility.Collapsed;

                StatusBox.Text = "Running";
            }
            else
            {
                RunningCheck.Visibility = Visibility.Collapsed;
                NotRunningCheck.Visibility = Visibility.Visible;

                StatusBox.Text = "Stopped";
            }
        }

        public HomePage()
        {
            InitializeComponent();

            RefreshTimer = new DispatcherTimer();
            RefreshTimer.Interval = TimeSpan.FromMilliseconds(500);
            RefreshTimer.Tick += RefreshTimer_Tick;
            RefreshTimer.Start();
        }

        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            RefreshStatus();
        }

        private async void StartSpoolerAction_Click(object sender, RoutedEventArgs e)
        {
            await SpoolerHelper.StartSpooler();
        }

        private async void StopSpoolerAction_Click(object sender, RoutedEventArgs e)
        {
            await SpoolerHelper.StopSpooler();
        }

        private void RestartSpoolerAction_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
