using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    public partial class FrmInviteTip : FrmBase
    {
        public FrmInviteTip()
        {
            InitializeComponent();
            this.CancelButton = this.btnIKnow;
        }
    }
}
