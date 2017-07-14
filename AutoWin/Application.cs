using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWin
{
    public class Application
    {
        public static HwndWrapper Run(string cmd_line, string args="")
        {
            Process p = new Process();
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.FileName = cmd_line;
            p.StartInfo.Arguments = args;
            try
            {
                p.Start();
                p.WaitForInputIdle();
                int hwnd = p.MainWindowHandle.ToInt32();
                string Title = p.MainWindowTitle;
                string className = Win32gui.GetClassName(p.MainWindowHandle.ToInt32());
                return new HwndWrapper(hwnd, className, Title);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new HwndWrapper(0, "", "");
        }

        public static void RunWait(string cmd_line, string args = "")
        {
            Process p = new Process();
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.FileName = cmd_line;
            p.StartInfo.Arguments = args;
            try
            {
                p.Start();
                p.WaitForInputIdle();
                p.WaitForExit();
            }
            catch (SystemException ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}
