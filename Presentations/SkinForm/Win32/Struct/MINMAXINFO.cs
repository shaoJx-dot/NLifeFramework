using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CCWin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public Point reserved;
        public Size maxSize;
        public Point maxPosition;
        public Size minTrackSize;
        public Size maxTrackSize;
    }
}
