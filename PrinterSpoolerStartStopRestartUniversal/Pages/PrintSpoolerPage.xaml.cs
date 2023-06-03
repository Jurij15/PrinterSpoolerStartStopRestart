using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PrinterSpoolerStartStopRestartUniversal.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PrinterSpoolerStartStopRestartUniversal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrintSpoolerPage : Page
    {
        public PrintSpoolerPage()
        {
            this.InitializeComponent();

            SpoolerPageHelper.PrintSpoolerPageInfoBar = StatusBar;
            UpdateStatus();
        }

        async void UpdateStatus()
        {
            bool value = await SpoolerHelper.IsSpoolerRunning();

            if (value)
            {
                RunningStatus.Visibility = Visibility.Visible;
                NotRunningStatus.Visibility = Visibility.Collapsed;
            }
            else
            {
                NotRunningStatus.Visibility = Visibility.Visible;
                RunningStatus.Visibility = Visibility.Collapsed;
            }
        }

        private void StartSpoolerBtn_Click(object sender, RoutedEventArgs e)
        {
            Start();
            UpdateStatus();
        }

        private void StopSpoolerBtn_Click(object sender, RoutedEventArgs e)
        {
            Stop();
            UpdateStatus();
        }

        private void RestartSpoolerBtn_Click(object sender, RoutedEventArgs e)
        {
            Restart();
            UpdateStatus();
        }

        async void Start()
        {
            await SpoolerHelper.StartSpooler();
        }

        async void Stop()
        {
            await SpoolerHelper.StopSpooler();
        }

        async void Restart()
        {
            await SpoolerHelper.StopSpooler();
            await SpoolerHelper.StartSpooler();
            UpdateStatus();
        }
    }
}
