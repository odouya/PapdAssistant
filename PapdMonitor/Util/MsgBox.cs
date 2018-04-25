using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    /// <summary>
    /// 消息框
    /// </summary>
    class MsgBox
    {
        public static DialogResult ShowInfo(string text)
        {
            return ShowInfo(text, "提示");
        }

        public static DialogResult ShowInfo(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowYesNo(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowOkCancel(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowWarnning(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowYesNoCancel(string text)
        {
            return ShowYesNoCancel(text, "提示");
        }

        public static DialogResult ShowYesNoCancel(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowWarnning(string text)
        {
            return ShowWarnning(text, "警告");
        }
    }
}
