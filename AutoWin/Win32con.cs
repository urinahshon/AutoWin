using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoWin
{
    public class Win32con
    {
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_USERDATA = -21;
        public const int GWL_ID = -12;
        public const uint TBSTYLE_BUTTON = 0; // Variable c_int
        public const uint TB_GETSTYLE = 1081; // Variable c_int
        public const uint WS_OVERLAPPED = 0;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_DISABLED = 0x8000000;
        public const uint WS_CLIPSIBLINGS = 0x4000000;
        public const uint WS_CLIPCHILDREN = 0x2000000;
        public const uint WS_MAXIMIZE = 0x1000000;
        public const uint WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
        public const uint WS_BORDER = 0x800000;
        public const uint WS_DLGFRAME = 0x400000;
        public const uint WS_VSCROLL = 0x200000;
        public const uint WS_HSCROLL = 0x100000;
        public const uint WS_SYSMENU = 0x80000;
        public const uint WS_THICKFRAME = 0x40000;
        public const uint WS_GROUP = 0x20000;
        public const uint WS_TABSTOP = 0x10000;
        public const uint WS_MINIMIZEBOX = 0x20000;
        public const uint WS_MAXIMIZEBOX = 0x10000;
        public const uint WS_TILED = WS_OVERLAPPED;
        public const uint WS_ICONIC = WS_MINIMIZE;
        public const uint WS_SIZEBOX = WS_THICKFRAME;

        // Extended Window Styles 
        public const uint WS_EX_DLGMODALFRAME = 0x0001;
        public const uint WS_EX_NOPARENTNOTIFY = 0x0004;
        public const uint WS_EX_TOPMOST = 0x0008;
        public const uint WS_EX_ACCEPTFILES = 0x0010;
        public const uint WS_EX_TRANSPARENT = 0x0020;
        public const uint WS_EX_MDICHILD = 0x0040;
        public const uint WS_EX_TOOLWINDOW = 0x0080;
        public const uint WS_EX_WINDOWEDGE = 0x0100;
        public const uint WS_EX_CLIENTEDGE = 0x0200;
        public const uint WS_EX_CONTEXTHELP = 0x0400;
        public const uint WS_EX_RIGHT = 0x1000;
        public const uint WS_EX_LEFT = 0x0000;
        public const uint WS_EX_RTLREADING = 0x2000;
        public const uint WS_EX_LTRREADING = 0x0000;
        public const uint WS_EX_LEFTSCROLLBAR = 0x4000;
        public const uint WS_EX_RIGHTSCROLLBAR = 0x0000;
        public const uint WS_EX_CONTROLPARENT = 0x10000;
        public const uint WS_EX_STATICEDGE = 0x20000;
        public const uint WS_EX_APPWINDOW = 0x40000;
        public const uint WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        public const uint WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        public const uint WS_EX_LAYERED = 0x00080000;
        public const uint WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
        public const uint WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
        public const uint WS_EX_COMPOSITED = 0x02000000;
        public const uint WS_EX_NOACTIVATE = 0x08000000;

        public const long BS_PUSHBUTTON   =    0x00000000L;
        //public const long BS_DEFPUSHBUTTON   = 0x00000001L;
        //public const long BS_CHECKBOX     =    0x00000002L;
        //public const long BS_AUTOCHECKBOX   =  0x00000003L;
        //public const long BS_RADIOBUTTON   =   0x00000004L;
        //public const long BS_3STATE       =    0x00000005L;
        //public const long BS_AUTO3STATE   =    0x00000006L;
        //public const long BS_GROUPBOX     =    0x00000007L;
        //public const long BS_USERBUTTON   =    0x00000008L;
        //public const long BS_AUTORADIOBUTTON = 0x00000009L;
        //public const long BS_PUSHBOX      =    0x0000000AL;
        //public const long BS_OWNERDRAW   =     0x0000000BL;
        //public const long BS_TYPEMASK    =     0x0000000FL;
        //public const long BS_LEFTTEXT   =      0x00000020L;

        //public const long BS_TEXT      =       0x00000000L;
        //public const long BS_ICON      =       0x00000040L;
        //public const long BS_BITMAP   =        0x00000080L;
        //public const long BS_LEFT     =        0x00000100L;
        //public const long BS_RIGHT    =        0x00000200L;
        //public const long BS_CENTER   =        0x00000300L;
        //public const long BS_TOP     =         0x00000400L;
        //public const long BS_BOTTOM   =        0x00000800L;
        //public const long BS_VCENTER  =        0x00000C00L;
        //public const long BS_PUSHLIKE =        0x00001000L;
        //public const long BS_MULTILINE   =     0x00002000L;
        //public const long BS_NOTIFY     =      0x00004000L;
        //public const long BS_FLAT          =   0x00008000L;

        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;   //The left button was pressed
        public const uint KEYEVENTF_KEYUP = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;   //The left button was released.
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x08;     //The right button was pressed
        public const uint WM_CLOSE = 0x10;
        //public const uint WM_CLOSE = 0x0010;
        public const uint MOUSEEVENTF_RIGHTUP = 0x10;     //The left button was released.
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;   //The middle button was pressed
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040; 
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const uint BN_CLICKED = 245;

        public const uint VK_LBUTTON = 0x01;
        public const uint VK_RBUTTON = 0x02;
        public const uint VK_CANCEL = 0x03;
        public const uint VK_MBUTTON = 0x04;
        public const uint VK_BACK = 0x08;
        public const uint VK_TAB = 0x09;
        public const uint VK_CLEAR = 0x0C;
        public const uint VK_RETURN = 0x0D;
        public const uint VK_LSHIFT = 0xA0;
        public const uint VK_RSHIFT = 0xA1;
        public const uint VK_LCONTROL = 0xA2;
        public const uint VK_RCONTROL = 0xA3;
        public const uint VK_PAUSE = 0x13;
        public const uint VK_CAPITAL = 0x14;
        public const uint VK_ESCAPE = 0x1B;
        public const uint VK_CONVERT = 28;
        public const uint VK_SPACE = 0x20;
        public const uint VK_NEXT = 0x22;
        public const uint VK_END = 0x70;
        public const uint VK_HOME = 0x24;
        public const uint VK_LEFT = 0x25;
        public const uint VK_UP = 0x26;
        public const uint VK_RIGHT = 0x27;
        public const uint VK_DOWN = 0x28;
        public const uint VK_PRINT = 0x2A;
        public const uint VK_EXECUTE = 0x2B;
        public const uint VK_SNAPSHOT = 0x2C;
        public const uint VK_INSERT = 0x2D;
        public const uint VK_DELETE = 0x2E;
        public const uint VK_HELP = 0x2F;
        public const uint VK_LWIN = 0x5B;
        public const uint VK_RWIN = 0x5C;
        public const uint VK_NUMPAD0 = 0x60;
        public const uint VK_NUMPAD1 = 0x61;
        public const uint VK_NUMPAD2 = 0x62;
        public const uint VK_NUMPAD3 = 0x63;
        public const uint VK_NUMPAD4 = 0x64;
        public const uint VK_NUMPAD5 = 0x65;
        public const uint VK_NUMPAD6 = 0x66;
        public const uint VK_NUMPAD7 = 0x67;
        public const uint VK_NUMPAD8 = 0x68;
        public const uint VK_NUMPAD9 = 0x69;
        public const uint VK_DECIMAL = 0x6E;
        public const uint VK_DIVIDE = 0x6F;
        public const uint VK_F1 = 0x70;
        public const uint VK_F2 = 0x71;
        public const uint VK_F3 = 0x72;
        public const uint VK_F4 = 0x73;
        public const uint VK_F5 = 0x74;
        public const uint VK_F6 = 0x75;
        public const uint VK_F7 = 0x76;
        public const uint VK_F8 = 0x77;
        public const uint VK_F9 = 0x78;
        public const uint VK_F10 = 0x79;
        public const uint VK_F11 = 0x7A;
        public const uint VK_F12 = 0x7B;
        public const uint VK_NUMLOCK = 0x90;
        public const uint VK_SCROLL = 145;
        public const uint VK_LMENU = 0xA0;
        public const uint VK_RMENU = 0xA5;
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x101;
        public const uint MOD_SHIFT = 0x4;
        public const uint MOD_CONTROL = 0x2;
        public const uint MOD_ALT = 0x1;
        public const uint MOD_WIN = 0x8;
        public const uint WM_HOTKEY = 0x312;
        public const uint WM_MOUSEWHEEL = 0x020A;
        public const uint WM_PASTE = 0x0302;
        public const uint N0 = 0x30;
        public const uint N1 = 0x31;
        public const uint N2 = 0x32;
        public const uint N3 = 0x33;
        public const uint N4 = 0x34;
        public const uint N5 = 0x35;
        public const uint N6 = 0x36;
        public const uint N7 = 0x37;
        public const uint N8 = 0x38;
        public const uint N9 = 0x39;

        public enum GWL
        {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12)
        }

        public static Dictionary<string, int> Keyboard = new Dictionary<string, int>()
        {  
            {"0", 0x60},
            {"1", 0x61},
            {"2", 0x62},
            {"3", 0x63},
            {"4", 0x64},
            {"5", 0x65},
            {"6", 0x66},
            {"7", 0x67},
            {"8", 0x68},
            {"9", 0x69},
            {"A", 0x41},
            {"B", 0x42},
            {"C", 0x43},
            {"D", 0x44},
            {"E", 0x45},
            {"F", 0x46},
            {"G", 0x47},
            {"H", 0x48},
            {"I", 0x49},
            {"J", 0x4A},
            {"K", 0x4B},
            {"L", 0x4C},
            {"M", 0x4D},
            {"N", 0x4E},
            {"O", 0x4F},
            {"P", 0x50},
            {"Q", 0x51},
            {"R", 0x52},
            {"S", 0x53},
            {"T", 0x54},
            {"U", 0x55},
            {"V", 0x56},
            {"W", 0x57},
            {"X", 0x58},
            {"Y", 0x59},
            {"Z", 0x5A},
            {" ", 0x20},
            {",", 0xBC},
            {"-", 0xBD},
            {".", 0x6E},
            {"'", 0xDE},
            {"/", 0x6F},
            {";", 0xBA},
            {"+", 0x6B},
            {"*", 0x6A}
        };
    }
}
