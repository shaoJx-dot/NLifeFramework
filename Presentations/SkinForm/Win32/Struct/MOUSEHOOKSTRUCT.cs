﻿using System;
using System.Runtime.InteropServices;

namespace CCWin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEHOOKSTRUCT
    {
        public POINT Pt;
        public IntPtr hwnd;
        public uint wHitTestCode;
        public IntPtr dwExtraInfo;
    }
}
