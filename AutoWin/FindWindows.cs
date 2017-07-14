using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWin
{
    public class FindWindows
    {
        public static HwndWrapper GetHwndByProcess(string processName)
        {
            if (processName.Contains(".exe"))
            {
                processName = processName.Remove(processName.LastIndexOf("."));
            }
            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                int hwnd = proc.MainWindowHandle.ToInt32();
                string title = proc.MainWindowTitle;
                string className = Win32gui.GetClassName(proc.MainWindowHandle.ToInt32());
                return new HwndWrapper(hwnd, className, title);
            }
            return new HwndWrapper(0,"","");
        }

        public static HwndWrapper GetHwndByHwnd(int hwnd)
        {
            string className = Win32gui.GetClassName(hwnd);
            string title = Win32gui.GetTitle(hwnd);
            return new HwndWrapper(hwnd, className, title);
        }

        public static HwndWrapper GetHwndByClass(string className)
        {
            int hwnd = Win32gui.FindHwndByClass(className);
            string title = Win32gui.GetTitle(hwnd);
            return new HwndWrapper(hwnd, className, title);
        }

        public static HwndWrapper GetHwndByTitle(string TitleText)
        {
            int hwnd = Win32gui.FindHwndByTitle(TitleText);
            string className = Win32gui.GetClassName(hwnd);
            return new HwndWrapper(hwnd, className, TitleText);
        }

        public static HwndWrapper FindWindow(string className, string title)
        {
            int hwnd = Win32gui.FindWindow(className, title);
            return new HwndWrapper(hwnd, className, title);
        }
    }
}
