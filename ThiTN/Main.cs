using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThiTN
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
        }
   


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FrmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                FrmMonHoc f = new FrmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
