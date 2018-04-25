using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdMonitor.Util
{
    class StringTool
    {
        public static bool IsNullOrWhitespace(string str)
        {
            return str == null || str.Trim().Length < 1;
        }
    }
}
