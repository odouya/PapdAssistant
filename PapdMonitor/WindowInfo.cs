using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdMonitor
{
    class WindowInfo
    {
        public string Name { get; set; }
        public IntPtr Hwnd { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
