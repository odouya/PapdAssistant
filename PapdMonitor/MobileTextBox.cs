using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PapdMonitor
{
    /// <summary>
    /// 手机号输入框
    /// </summary>
    class MobileTextBox : TextBox
    {
        /// <summary>
        /// 格式化后的手机号
        /// </summary>
        public string FzPhoneNumberFormatted
        {
            get
            {
                if (this.Text.Length == 11)
                {
                    return string.Format("{0}-{1}-{2}",
                        this.Text.Substring(0, 3),
                        this.Text.Substring(3, 4),
                        this.Text.Substring(7, 4));
                }
                return string.Empty;
            }
        }

        public MobileTextBox()
        {
            /*事件顺序：
             *  OnKeyDown
                OnKeyPress
                OnKeyUp
             */
            //System.Reflection.MethodBase.GetCurrentMethod()获取当前函数所在的方法
            //注：此处不能使用KeyDown处理

            this.KeyPress += OnKeyPress;
            this.MaxLength = 11;//手机号的长度
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            #region 快捷键处理

            //退格键
            if (e.KeyChar == (char)Keys.Back)
                return;

            //Ctrl+A全选
            if ((int)e.KeyChar == 1)
            {
                this.SelectAll();
                e.Handled = true;
                return;
            }

            //Ctrl+C复制
            if ((int)e.KeyChar == 3)
            {
                if (this.SelectedText.Length>0)
                {
                    Clipboard.SetText(this.SelectedText);//参数长度不能为0 
                }
                e.Handled = true;
                return;
            }

            //Ctrl+V粘贴
            if ((int) e.KeyChar == 22)
            {
                string clipboardData = Clipboard.GetText(TextDataFormat.Text).Trim();
                string[] patterns = new[]
                {
                    "1[0-9]{10}",
                    "1[0-9]{2} [0-9]{4} [0-9]{4}",
                    "1[0-9]{2}-[0-9]{4}-[0-9]{4}"
                };
                foreach (var pattern in patterns)
                {
                    if (Regex.IsMatch(clipboardData, pattern))
                    {
                        //如果匹配任何一种手机号模式都可以进行粘贴
                        clipboardData = clipboardData.Replace("-", "");
                        clipboardData = clipboardData.Replace(" ", "");
                        if (clipboardData.Length == 11)
                        {
                            this.Text = clipboardData; 
                        }
                        break;
                    }
                }
                e.Handled = true;
                return;
            }

            #endregion

            #region 字符处理
            //输入的字符只能为数字
            if (!Char.IsNumber((char)e.KeyChar))
            {
                e.Handled = true;
                return;
            } 
            #endregion

            #region 第一个字符串处理
            if (this.Text.Length == 0)
            {
                //第一个数字必须为1
                if (e.KeyChar != '1')
                {
                    e.Handled = true;
                    return;
                }
            } 
            #endregion
        }
    }
}
