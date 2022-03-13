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
            ///the first command(to stop)
            //command string
            string command = "/C net stop spooler";
            //start cmd with command
            Process.Start("cmd.exe", command);

            ///the second command (to start back up)
            //command string
            string command2 = "/C net start spooler";
            //start cmd with command
            Process.Start("cmd.exe", command2);
        }
    }
}
