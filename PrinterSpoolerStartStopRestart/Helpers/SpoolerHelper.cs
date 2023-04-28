using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrinterSpoolerStartStopRestart.Helpers
{
    public class SpoolerHelper
    {
        public static async Task<bool> IsSpoolerRunning()
        {
            bool RetVal = false;

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C net start";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;

            p.Start();

            string output = await p.StandardOutput.ReadToEndAsync();

            if (output.Contains("Print Spooler"))
            {
                RetVal = true;
            }

            return RetVal;
        }

        public static async Task StartSpooler()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C net start spooler";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;

            p.Start();

            string output = await p.StandardOutput.ReadToEndAsync();

            if (output.Contains("already") || string.IsNullOrEmpty(output))
            {
                MainWindow.ShowSnackbar("Already running", "Printer Spooler service is already running", Wpf.Ui.Common.ControlAppearance.Danger);
            }
            else
            {
                MainWindow.ShowSnackbar("Started", "Printer Spooler service started successfully", Wpf.Ui.Common.ControlAppearance.Success);
            }
        }

        public static async Task StopSpooler()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C net stop spooler";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            p.Start();

            string output = await p.StandardOutput.ReadToEndAsync();

            if (output.Contains("not exist") || string.IsNullOrEmpty(output))
            {
                MainWindow.ShowSnackbar("Not Running", "Printer Spooler service is not running", Wpf.Ui.Common.ControlAppearance.Danger);
            }
            else
            {
                MainWindow.ShowSnackbar("Stopped", "Printer Spooler service stopped successfully", Wpf.Ui.Common.ControlAppearance.Success);
            }
        }
    }
}
