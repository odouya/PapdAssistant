using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    public partial class FrmList : FrmBase
    {
        public object SelecteItem;

        public FrmList(IEnumerable list)
        {
            InitializeComponent();
            List2Control(list);
        }

        private void List2Control(IEnumerable list)
        {
            if (list == null)
                return;
            var ienumerator = list.GetEnumerator();
            while (ienumerator.MoveNext())
            {
                this.listBox1.Items.Add(ienumerator.Current);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedItems.Count < 1)
                return;
            this.SelecteItem = this.listBox1.SelectedItem;
            this.DialogResult = DialogResult.OK;
        }
    }
}
