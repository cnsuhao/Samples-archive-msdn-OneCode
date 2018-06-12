using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CSMDbgTargetApp
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, 
            SetLastError = true, CharSet=CharSet.Auto, ExactSpelling = true)]
        internal static extern uint GetCurrentThreadId();

    }
}
