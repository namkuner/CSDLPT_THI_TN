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
            if (Program.mGroup == "Truong")
            {
                this.btn_MH.Enabled = true;
                this.btnGV.Enabled = true;
                this.btn_Giaovien_Dangky.Enabled = false;

            }
            else if (Program.mGroup == "Giangvien")
            {
                this.btn_MH.Enabled = true;
                this.btnGV.Enabled = false;
                this.btn_Giaovien_Dangky.Enabled = true;
            }
            else if (Program.mGroup == "CoSo")
            {
                this.btn_MH.Enabled = false;
                this.btnGV.Enabled = false;
                this.btn_Giaovien_Dangky.Enabled = true;
            }
            else if (Program.mGroup == "Sinhvien")
            {
                this.btn_MH.Enabled = false;
                this.btnGV.Enabled = false;
                this.btn_Giaovien_Dangky.Enabled = false;
            }
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
        public void HienThiMenu()
        {
            MAGV.Text = "Mã GV: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoten;
            NHOM.Text = "Nhóm: " + Program.mGroup;
            

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FrmGiaoVien));
            if (frm != null) frm.Activate();
            else
            {
                FrmGiaoVien f = new FrmGiaoVien();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btn_Giaovien_Dangky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FrmGiaovien_Dangky));
            if (form != null) form.Activate();
            else
            {
                FrmGiaovien_Dangky f = new FrmGiaovien_Dangky();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
