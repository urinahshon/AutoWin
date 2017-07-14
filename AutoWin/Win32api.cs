using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWin
{
    class Win32api
    {

        public static Point GetCursorPosition()
        {
            Win32.POINT lpPoint;
            Win32.GetCursorPos(out lpPoint);
            return lpPoint;
        }

        public static void MouseLeftClick()
        {
            Win32.mouse_event(Win32con.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Win32.mouse_event(Win32con.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void MouseClickByPos(int X, int Y)
        {
            Win32.mouse_event(Win32con.MOUSEEVENTF_ABSOLUTE | Win32con.MOUSEEVENTF_LEFTDOWN | Win32con.MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        
    }
}
