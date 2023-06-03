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
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();

            VersionBlock.Text = "Version " + Config.VersionString;
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem SelectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            if (SelectedItem.Name == "DarkCombo")
            {
                Config.Theme = 0;
                PersonalizationHelper h = new PersonalizationHelper(Window.Current);
                h.SetTheme();
            }
            else
            {
                Config.Theme = 1;
                PersonalizationHelper h = new PersonalizationHelper(Window.Current);
                h.SetTheme();
            }
        }
    }
}
