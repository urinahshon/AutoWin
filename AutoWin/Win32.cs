using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Drawing;

namespace AutoWin
{
    public class Win32
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        [DllImport("User32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        public static extern int FindWindowEx(int hWndParent, int hwndChildAfter, string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        public static extern bool EnumChildWindows(int hWndParent, Delegate lpEnumFunc, int lParam);

        [DllImport("User32.dll")]
        public static extern bool EnumWindows(Delegate lpEnumFunc, int lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, long wParam, long lParam);

        [DllImport("User32.dll")]
        public static extern bool PostMessage(int hWnd, uint Msg, long wParam, long lParam);

        [DllImport("User32.dll")]
        public static extern int GetClassName(int hWnd, StringBuilder s, int nMaxCount);

        [DllImport("User32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder s, int nMaxCount);

        //[DllImport("user32.dll", EntryPoint = "GetWindowText", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern int GetWindowText(int hWnd, StringBuilder lpWindowText, int nMaxCount);

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(int hWnd);

        [DllImport("User32.dll")]
        public static extern bool SetActiveWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(int hWnd);

        [DllImport("user32.dll")]
        public static extern bool AllowSetForegroundWindow(int dwProcessId);

        [DllImport("User32.dll")]
        public static extern bool IsWindowVisible(int hWnd);

        [DllImport("User32.dll")]
        public static extern bool IsWindowEnabled(int hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(int hWnd, uint nCmdShow);
        //int SW_HIDE = 0;
        //int SW_SHOW = 5;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(int hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(int hWnd, IntPtr ProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(int hwnd, out RECT lpRect);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string lpString);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SendMessageTimeout(int hwnd, int msg, int wParam, int lParam, int fuFlags, int uTimeout, ref int lpdwResult);
        
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(int hWnd, IntPtr TOPMOST, int X, int Y, int cx, int cy, uint uFlags);
        
        [DllImport("User32.dll")]
        public static extern void keybd_event(uint bVk, uint bScan, long dwFlags, long dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool EmptyClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool CloseClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool OpenClipboard(int hWndNewOwner);

        [DllImport("user32.dll")]
        public static extern int SetClipboardData(uint uFormat, IntPtr hMem);

        [DllImport("user32.dll")]
        public static extern int GetClipboardOwner();

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLongPtr32(int hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(int hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern int GetWindowLongPtr64(int hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern int GetParent(int hWnd);

        // This static method is required because Win32 does not support
        // GetWindowLongPtr directly
        public static int GetWindowLongPtr(int hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }

    }
}
