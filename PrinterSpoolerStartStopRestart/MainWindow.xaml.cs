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
using Wpf.Ui.Controls;

namespace PrinterSpoolerStartStopRestart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public static Snackbar StatusSnack { get; set; }

        public static async void ShowSnackbar(string Header, string Content, Wpf.Ui.Common.ControlAppearance Appearance)
        {
            //StatusSnack.Title = Header;
            StatusSnack.Content = Content;
            StatusSnack.Appearance = Appearance;
            StatusSnack.Timeout = 2000;

            StatusSnack.Visibility = Visibility.Visible;

            await StatusSnack.ShowAsync();

            StatusSnack.Visibility= Visibility.Collapsed;
        }
        public MainWindow()
        {
            InitializeComponent();

            StatusSnack = ContentSnack;
        }
    }
}
