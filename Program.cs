using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AffinitySetter_Console
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool SetProcessAffinityMask(IntPtr hProcess, IntPtr dwProcessAffinityMask);

        static void Main(string[] args)
        {
            var processName = "audiodg";  // replace with the desired process name
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length == 0)
            {
                Console.WriteLine("No process with name '{0}' was found.", processName);
                return;
            }

            var process = processes[0];  // assumes only one process with that name is running
            var processHandle = process.Handle;

            var processAffinityMask = new IntPtr(4);  // set CPU affinity to 2

            if (SetProcessAffinityMask(processHandle, processAffinityMask))
            {
                Console.WriteLine("Successfully set process affinity.");
            }
            else
            {
                Console.WriteLine("Failed to set process affinity.");
            }
        }
    }
}
