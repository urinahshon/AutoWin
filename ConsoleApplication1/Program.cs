using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            AutoWin.HwndWrapper HW = AutoWin.Application.Run("notepad");
            var resMain = AutoWin.Win32.GetParent(HW.GetHwnd());
            HW.MaximizeWindow();
            Console.ReadKey();
            
        }
    }
}
