using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PapdLib;
using PapdLib.Info;
using PapdMonitor.Util;
using System.Threading;

namespace PapdMonitor
{
    public partial class FrmBase : Form
    {
        #region Private字段
        private PapdHelper m_papdHelper = new PapdHelper(); 
        #endregion

        #region Protected字段
        protected PapdHelper PH { get { return m_papdHelper; } }

        protected string MyCookie { get { return GlobalContext.CurrentCookieString; } }

        protected UserInfo MyUserInfo { get { return GlobalContext.CurrentUserInfo; } }

        protected string MyCertPath { get { return GlobalContext.CurrentCertPath; } } 
        #endregion

        #region 构造函数
        public FrmBase()
        {
            PH.OutputEvent += (sender, args) => Logger.Write(sender as string);
        }
        #endregion

        #region 检测登录状态
        protected bool CheckLoginState()
        {
            return GlobalContext.CheckLoginState();
        }

        protected bool IsLogin()
        {
            return GlobalContext.IsLogin();
        }
        #endregion

        #region 设置当前用户证书路径
        protected void SetMyCertPath(string path)
        {
            GlobalContext.CurrentCertPath = path;
        } 
        #endregion

        #region 启用Esc关闭窗体功能
        protected void EnableCancelButton()
        {
            Button btn = new Button();
            btn.Click += (sender, args) =>
            {
                if (this.Modal)
                    this.DialogResult = DialogResult.Cancel;
                else
                {
                    this.Close();
                }
            };
            this.CancelButton = btn;
        } 
        #endregion

        #region 设置控件Text属性
        protected void SetControlText(NotifyIcon control, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<NotifyIcon, string>(SetControlText), control, text);
                return;
            }
            control.Text = text;
        }

        protected void SetControlText(ToolStripItem control, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ToolStripItem, string>(SetControlText), control, text);
                return;
            }
            control.Text = text;
        }

        protected void SetControlText(Control control, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Control, string>(SetControlText), control, text);
                return;
            }
            control.Text = text;
        } 
        #endregion

        #region 获取控件Text属性
        protected string GetControlText(Control control)
        {
            if (this.InvokeRequired)
            {
                return (string)this.Invoke(new Func<Control, string>(GetControlText), control);
            }
            return control.Text;
        } 
        #endregion

        #region 设置控件Enabled属性
        protected void SetControlEnabled(Control control, bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Control, bool>(SetControlEnabled), control, enabled);
                return;
            }
            control.Enabled = enabled;
        } 
        #endregion

        #region ListView操作

        protected void ClearListView(ListView lv)
        {
            UpdateUI(() => lv.Items.Clear());
        }

        protected void SetListViewItemTag(ListView lv, int row, object value)
        {
            UpdateUI(() => lv.Items[row].Tag = value);
        }

        protected T GetListViewItemTag<T>(ListView lv, int row)
        {
            return (T)UpdateUI(() => lv.Items[row].Tag);
        }

        protected void AddListViewmItem(ListView lv, params object[] objs)
        {
            if (objs == null || objs.Length < 1)
                return;

            UpdateUI(() =>
            {
                List<string> values = new List<string>();
                for (int i = 0; i < objs.Length; i++)
                {
                    values.Add(objs[i] == null ? string.Empty : objs[i].ToString());
                }
                var left = lv.Columns.Count - values.Count;
                for (int i = 0; i < left; i++)
                {
                    values.Add(string.Empty);
                }
                lv.Items.Add(new ListViewItem(values.ToArray()));
            });
        }

        protected void SetListViewItemValue(ListView lv, int row, int col, object value)
        {
            UpdateUI(() => lv.Items[row].SubItems[col].Text = value == null ? string.Empty : value.ToString());
        }

        protected string GetListViewItemValue(ListView lv, int row, int col)
        {
            return UpdateUI(() => lv.Items[row].SubItems[col].Text);
        }

        protected void SetListViewItemChecked(ListView lv, int row, bool isChecked)
        {
            UpdateUI(() => lv.Items[row].Checked = isChecked);
        }

        /// <summary>
        /// 用颜色标记ListView中的某行
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="rowIndex"></param>
        protected void HighlightListViewRow(ListView lv, int rowIndex)
        {
            HighlightListViewRow(lv, rowIndex, Color.PaleVioletRed);
        }

        /// <summary>
        /// 用颜色标记ListView中的某行
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="rowIndex"></param>
        /// <param name="color"></param>
        protected void HighlightListViewRow(ListView lv, int rowIndex, Color color)
        {
            UpdateUI(() =>
                {
                    for (int i = 0; i < lv.Columns.Count; i++)
                    {
                        lv.Items[rowIndex].SubItems[0].BackColor = color;
                    }
                });
        }
        #endregion

        protected void UpdateUI(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
                return;
            }
            action();
        }

        protected T UpdateUI<T>(Func<T> func)
        {
            if (this.InvokeRequired)
            {
                return (T) this.Invoke(func);
            }
            return (T) func();
        }

        protected void DoOutput(string str)
        {
            if (GlobalContext.MainForm != null)
            {
                GlobalContext.MainForm.Output(str);
            }
        }

        protected void DoOutput(string format, params object[] paras)
        {
            if (GlobalContext.MainForm != null)
            {
                GlobalContext.MainForm.Output(string.Format(format, paras));
            }
        }

        #region 清除控件数据
        protected void ClearControl(TabControl tc)
        {
            foreach (TabPage tabPage in tc.Controls)
            {
                ClearControl(tabPage);
            }
        }

        protected void ClearControl(TabPage tabPage)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is ListView)
                {
                    (control as ListView).Items.Clear();
                }
                else if (control is PictureBox)
                {
                    ClearControl(control as PictureBox);
                }
                else if (control is TabControl)
                {
                    ClearControl(control as TabControl);
                }
            }
        }

        protected void ClearControl(PictureBox pb)
        {
            using (var g = pb.CreateGraphics())
            {
                g.Clear(Color.White);
            }
        } 
        #endregion

        protected void DoTask(Action action, string errorHeader)
        {
            DoTask(action, errorHeader, false);
        }

        protected void DoTask(Action action, string errorHeader, bool isSTA)
        {
            Thread t = new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo(errorHeader + "," + ex.Message);
                }
            });
            t.IsBackground = true;
            if (isSTA)
            {
                t.ApartmentState = ApartmentState.STA;
            }
            t.Start();
        }

    }
}
