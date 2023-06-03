using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PrinterSpoolerStartStopRestartUniversal.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PrinterSpoolerStartStopRestartUniversal
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WinUIEx.WindowEx
    {
        void InitDesgin()
        {
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            this.SetWindowSize(795, 600);
            this.CenterOnScreen();
        }
        public MainWindow()
        {
            this.InitializeComponent();
            InitDesgin();

            MainNavigation.SelectedItem = PrintSpoolerNavItem;
            MainNavigation.Header = "Printer Spooler";
            RootFrame.Navigate(typeof(PrintSpoolerPage));
        }

        private void MainNavigation_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            //no need to do much here, there are only 2 pages to navigate to :)
            if (args.IsSettingsInvoked)
            {
                sender.Header = "Settings";
                RootFrame.Navigate(typeof(SettingsPage));
            }
            else 
            {
                RootFrame.Navigate(typeof(PrintSpoolerPage));
                sender.Header = "Printer Spooler";
            }
        }
    }
}
