using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PrinterSpoolerStartStopRestart.PrinterSpoolerClasses
{
    public class Restart
    {
        public void ExecuteRestart()
        {
            string command = "/C net stop spooler";
            Process.Start("cmd.exe", command);

            string command2 = "/C net start spooler";
            Process.Start("cmd.exe", command2);
        }
    }
}
