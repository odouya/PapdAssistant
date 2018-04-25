using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PapdMonitor.Util
{
    class ApiUtil
    {

        [DllImport("user32.dll")]
        public static extern bool MessageBeep(BeepType uType);

        /// <summary>
        /// MessageBeep声音类型
        /// </summary>
        public enum BeepType : long
        {
            /// <summary>
            /// Information信息声
            /// </summary>
            MB_ICONASTERISK = 0x00000040L,

            /// <summary>
            /// Warnning警告声
            /// </summary>
            MB_ICONEXCLAMATION = 0x00000030L,

            /// <summary>
            /// Error错误声
            /// </summary>
            MB_ICONHAND = 0x00000010L,

            /// <summary>
            /// 系统提问声（不响）
            /// </summary>
            MB_ICONQUESTION = 0x00000020L
        }

    }
}
