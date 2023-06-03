using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterSpoolerStartStopRestartUniversal.Helpers
{
    public class SpoolerPageHelper
    {
        public enum InfoBarStatus
        {
            Success, 
            Error,
            Info
        }
        public static InfoBar PrintSpoolerPageInfoBar { get; set; }

        public static void SetInfoBar(InfoBarStatus Status, string Title, string Message)
        {
            switch (Status)
            {
                case InfoBarStatus.Success:
                    PrintSpoolerPageInfoBar.Severity = InfoBarSeverity.Success;
                    break;
                    case InfoBarStatus.Error:
                    PrintSpoolerPageInfoBar.Severity = InfoBarSeverity.Error; break;
                    case InfoBarStatus.Info:
                    PrintSpoolerPageInfoBar.Severity = InfoBarSeverity.Informational; break;
            }

            PrintSpoolerPageInfoBar.Title = Title;
            PrintSpoolerPageInfoBar.Message = Message;

            PrintSpoolerPageInfoBar.IsOpen = true;
        }
    }
}
