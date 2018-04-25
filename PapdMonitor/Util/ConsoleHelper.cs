using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace PapdMonitor.Util
{
    public class ConsoleHelper
    {
        [DllImport("Kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll",
            EntryPoint ="GetStdHandle",
            SetLastError =true,
            CharSet =CharSet.Auto,
            CallingConvention =CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        private const int STD_OUTPUT_HANDLE = -11;

        private static bool isInited = false;

        public static void Init()
        {
            if (isInited)
                return;
            AllocConsole();
            IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(Console.OutputEncoding.CodePage);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush =true;
            Console.SetOut(standardOutput);
            isInited = true;
        }
    }
}
