using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoWin
{
    public class Win32gui
    {
        public delegate bool EnumDelegate(IntPtr hWnd, int lParam);
        public delegate void Callback(int hWnd, int lParam);
        private static List<HwndWrapper> WindowChilds;
        public static int HWND = 0;
        public static string ClassName = "unknow_string";
        public static string WindowTitle = "unknow_string";
        public static string ContainsClassName = "unknow_string";
        public static string ContainsWindowTitle = "unknow_string";

        public static string GetClassName(int hwnd) 
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            int class_name = Win32.GetClassName(hwnd, stringBuilder, 256);
            return stringBuilder.ToString().Trim();
        }

        public static string GetTitle(int hwnd)
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            int class_name = Win32.GetWindowText (hwnd, stringBuilder, 256);
            return stringBuilder.ToString().Trim();
        }

        public static void EnumGetWindowChilds(int hWnd, int lParam)
        {
            string className = GetClassName(hWnd);
            string title = GetTitle(hWnd);
            WindowChilds.Add(new HwndWrapper(hWnd, className, title));
        }

        public static void EnumGetWindow(int hWnd, int lParam)
        {
            string className = GetClassName(hWnd);
            string title = GetTitle(hWnd);
            if (Win32gui.ClassName == className)
            {
                Win32gui.HWND = hWnd;
                return;
            }
            else if (Win32gui.WindowTitle == title)
            {
                Win32gui.HWND = hWnd;
                return;
            }
            else if (Win32gui.ClassName.Contains(className))
            {
                Win32gui.HWND = hWnd;
                return;
            }
            else if (Win32gui.WindowTitle.Contains(title))
            {
                Win32gui.HWND = hWnd;
                return;
            }
        }

        public static int GetHwndByProcess(string processName)
        {
            int hwnd = 0;
            if (processName.Contains(".exe"))
            {
                processName = processName.Remove(processName.LastIndexOf("."));
            }
            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                hwnd =  proc.MainWindowHandle.ToInt32();
            }
            return hwnd;
        }

        public static int FindWindow(string className, string title)
        {
            return Win32.FindWindow(className, title);
        }

        public static int FindWindowEx(int hWndParent, string className, string title)
        {
            return Win32.FindWindowEx(hWndParent, 0, className, title);
        }

        public static void CloseWindow(int hwnd)
        {
            try
            {
                // This is for close main window and wait for closing.
                // if you accidentally close Button, main window will be stuck.
                Win32.SendMessage(hwnd, Win32con.WM_CLOSE, 0, 0);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int FindHwndByClass(string className)
        {
            ClassName = className;
            Callback lpEnumFunc = new Callback(EnumGetWindow);
            Win32.EnumWindows(lpEnumFunc, 0);
            ClassName = "unknow_string";
            return Win32gui.HWND;
        }
        public static int FindHwndByTitle(String title)
        {
            WindowTitle = title;
            Callback lpEnumFunc = new Callback(EnumGetWindow);
            Win32.EnumWindows(lpEnumFunc, 0);
            WindowTitle = "unknow_string";
            return Win32gui.HWND;
        }
        public static int FindHwndByClassContains(string classNameMatch)
        {
            ContainsClassName = classNameMatch;
            Callback lpEnumFunc = new Callback(EnumGetWindow);
            Win32.EnumWindows(lpEnumFunc, 0);
            ContainsClassName = "unknow_string";
            return Win32gui.HWND;
        }

        public static int FindHwndByTitleContains(String titleMatch)
        {
            ContainsWindowTitle = titleMatch;
            Callback lpEnumFunc = new Callback(EnumGetWindow);
            Win32.EnumWindows(lpEnumFunc, 0);
            WindowTitle = "unknow_string";
            return Win32gui.HWND;
        }

        public static int FindChildHwndByClass(int hwnd, string className)
        {
            ClassName = className;
            Callback lpEnumFunc = new Callback(EnumGetWindow);
            Win32.EnumChildWindows(hwnd, lpEnumFunc, 0);
            ClassName = "temp_class_name";
            return Win32gui.HWND;
        }

        public static List<HwndWrapper> FindHwndChild(int hwnd)
        {
            WindowChilds = new List<HwndWrapper>();
            Callback lpEnumFunc = new Callback(EnumGetWindowChilds);
            Win32.EnumChildWindows(hwnd, lpEnumFunc, 0);
            return WindowChilds;
        }

        public static string GetWindowText(int hWnd)
        {
            const int MAXTITLE = 255;
            StringBuilder strbTitle = new StringBuilder(MAXTITLE);
            int nLength = Win32.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
            strbTitle.Length = nLength;
            return strbTitle.ToString();
        }

        public static void BringWindowToTop(int hwnd)
        {
            Win32.SetForegroundWindow(hwnd);
            Win32.SetActiveWindow(hwnd);
            Win32.BringWindowToTop(hwnd);
        }

        public static void SendkeyToWindow(int hwnd, uint vitrualKey)
        {
            Win32.PostMessage(hwnd, Win32con.WM_KEYDOWN, vitrualKey, 0);
            //Win32.PostMessage(hwnd, Win32con.WM_KEYUP, vitrualKey, 0);
        }
        public static void SendKeys(string text)
        {
            System.Windows.Forms.SendKeys.SendWait(text);
        }

        public static void SendTextToWindow(int hwnd, string text)
        {
            Win32.OpenClipboard(hwnd);
            Win32.EmptyClipboard();
            var txt = Marshal.StringToHGlobalUni(text);
            Win32.SetClipboardData(13, txt);
            Win32.CloseClipboard();
            Win32.SendMessage(hwnd, Win32con.WM_PASTE,0 ,0);
        }

        public static void MouseClickOnWindow(int hwnd)
        {
            Win32.RECT rct;
            Win32.GetWindowRect(hwnd, out rct);
            Win32api.MouseClickByPos(rct.Left + 1, rct.Top + 1);
        }

        public static void WaitForWindow(int hwnd, int timeOut=99999)
        {

        }

        public static string GetID(int hwnd)
        {
            int result;
            result = Win32.GetWindowLongPtr(hwnd, -16);
            return result.ToString();
        }

        public static bool IsWindowTopMost(int hwnd)
        {
            var res = Win32.GetWindowLong(hwnd, Win32con.GWL_STYLE) & Win32con.WS_MINIMIZE;
            return (Win32.GetWindowLong(hwnd, Win32con.GWL_EXSTYLE) & Win32con.WS_EX_TOPMOST) != 0;
        }
    }
}
