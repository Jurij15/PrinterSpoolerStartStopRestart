using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace PrinterSpoolerStartStopRestart.PrinterSpoolerClasses
{
    public class Stop
    {
        public void StopExecute()
        {
            //command string
            string command = "/C net stop spooler";
            //start cmd with command
            Process.Start("cmd.exe", command);
        }
    }
}
