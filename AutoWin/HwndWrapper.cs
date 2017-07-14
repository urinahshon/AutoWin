using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoWin
{
    public class HwndWrapper
    {
        int hwnd;
        string className = "";
        string Title = "";

        public HwndWrapper(int hwnd, string className, string title)
        {
            this.hwnd = hwnd;
            this.className = className;
            this.Title = title;
        }

        private void SetHwnd(int hwnd)
        {
            this.hwnd = hwnd;
        }

        private void SetClassName(string className)
        {
            this.className = className;
        }

        private void SetTitle(string title)
        {
            this.Title = title;
        }

        public int GetHwnd()
        {
            return this.hwnd;
        }

        public string GetClassName()
        {
            return this.className;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public void CloseWindow()
        {
            Win32gui.CloseWindow(hwnd);
        }

        public bool IsVisible()
        {
            return Win32.IsWindowVisible(hwnd);
        }

        public void BringWindowToTop()
        {
            Win32gui.BringWindowToTop(hwnd);
        }

        public void SendTextToWindow(string text)
        {
            Win32gui.SendTextToWindow(hwnd, text);
        }

        public string GetWindowText(string text)
        {
            return Win32gui.GetWindowText(hwnd);
        }
        
        public void SendKeysToWindow(string text)
        {
            char[] charArray = text.ToCharArray();
            foreach (char ch in charArray)
            {
                Win32gui.SendkeyToWindow(hwnd, (uint)Win32con.Keyboard[ch.ToString().ToUpper()]);
            }
        }

        public void SendKeys(string text)
        {
            Win32gui.BringWindowToTop(hwnd);
            Thread.Sleep(500);
            System.Windows.Forms.SendKeys.SendWait(text);
        }

        public HwndWrapper GetChildByClass(string className)
        {
            hwnd = Win32gui.FindChildHwndByClass(hwnd, className);
            return FindWindows.GetHwndByHwnd(hwnd);
        }

        public Win32.RECT GetPosition()
        {
            Win32.RECT rct;
            Win32.GetWindowRect(hwnd, out rct);
            return rct;
        }

        public void ControlClick()
        {
            Win32.SendMessage(hwnd, Win32con.BN_CLICKED, 0, 0);
        }

        public void MouseClick()
        {
            Win32gui.MouseClickOnWindow(hwnd);
        }

        public List<HwndWrapper> GetChilds()
        {
            List<HwndWrapper> HW = Win32gui.FindHwndChild(this.hwnd);
            return HW;
        }

        public int GetParentHwnd()
        {
            return Win32.GetParent(this.hwnd);
        }

        public void MaximizeWindow()
        {
            Win32.ShowWindow(this.hwnd, Win32con.WS_MAXIMIZE);
        }

    }
}
