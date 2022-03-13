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
    public class Start
    {
        public void StartExecute()
        {
            //command string
            string command2 = "/C net start spooler";
            //start cmd with command
            Process.Start("cmd.exe", command2);
        }
    }
}
