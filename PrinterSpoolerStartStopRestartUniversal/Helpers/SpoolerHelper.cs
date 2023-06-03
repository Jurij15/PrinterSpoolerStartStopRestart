using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrinterSpoolerStartStopRestartUniversal.Helpers
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
                SpoolerPageHelper.SetInfoBar(SpoolerPageHelper.InfoBarStatus.Info,"Already running", "Printer Spooler service is already running");
            }
            else
            {
                SpoolerPageHelper.SetInfoBar(SpoolerPageHelper.InfoBarStatus.Success, "Started", "Printer Spooler service started successfully");
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
                SpoolerPageHelper.SetInfoBar(SpoolerPageHelper.InfoBarStatus.Info, "Not Running", "Printer Spooler service is not running");
            }
            else
            {
                SpoolerPageHelper.SetInfoBar(SpoolerPageHelper.InfoBarStatus.Error, "Stopped", "Printer Spooler service stopped successfully");
            }
        }
    }
}
