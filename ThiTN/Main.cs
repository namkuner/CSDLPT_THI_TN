using DevExpress.CodeParser;
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
        private Boolean checkOpenDeThi = false;
        private FrmBoDe frmBoDe = null;

        public Main()
        {
            
            InitializeComponent();
            this.btnDangNhap.Enabled = true;
            this.btnDangXuat.Enabled = false;
            this.btn_MH.Enabled = false;
            this.btnKHOA.Enabled = false;
            this.btnSV.Enabled = false;
            this.btnGV.Enabled = false;
            this.DE_btn.Enabled = false;
            this.btn_Thi.Enabled = false;
            this.btn_Giaovien_Dangky.Enabled = false;
            this.btn_THITHU.Enabled = false;
            this.btnDangXuat.Enabled = false;
            this.btn_KQTHISV.Enabled = false;
            this.frmBangDiem.Enabled = false;
            this.barButtonItem3.Enabled = false;

            Console.WriteLine(Program.mGroup + "PRgram.m giy12321");
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            btnDangNhap_ItemClick(null, null);
        }
        public void buttons()
        {
            this.btnDangNhap.Enabled = false;
            this.btnDangXuat.Enabled = true;
            if (Program.mGroup == "Truong")
            {
                this.btn_MH.Enabled = true;
                this.btnKHOA.Enabled = true;
                this.btnSV.Enabled = true;
                this.btnGV.Enabled = true;
                this.DE_btn.Enabled = true;
                this.btn_Thi.Enabled = true;
                this.btn_Giaovien_Dangky.Enabled = true;
                this.btn_THITHU.Enabled = false;
                this.btnDangXuat.Enabled = true;
                this.btn_KQTHISV.Enabled = true;
                this.frmBangDiem.Enabled = true;
                this.barButtonItem3.Enabled = true;

            }
            else if (Program.mGroup == "CoSo")
            {
                this.btn_MH.Enabled = true;
                this.btnKHOA.Enabled = true;
                this.btnSV.Enabled = true;
                this.btnGV.Enabled = true;
                this.DE_btn.Enabled = true;
                this.btn_Thi.Enabled = true;
                this.btn_Giaovien_Dangky.Enabled = true;
                this.btn_THITHU.Enabled = false;
                this.btnDangXuat.Enabled = true;
                this.btn_KQTHISV.Enabled = true;
                this.frmBangDiem.Enabled = true;
                this.barButtonItem3.Enabled = true;
            }
            else if (Program.mGroup == "Giangvien")
            {
                this.btn_MH.Enabled = false;
                this.btnKHOA.Enabled = false;
                this.btnSV.Enabled = false;
                this.btnGV.Enabled = true;
                this.DE_btn.Enabled = true;
                this.btn_Thi.Enabled = false;
                this.btn_Giaovien_Dangky.Enabled = true;
                this.btn_THITHU.Enabled = true;
                this.btnDangXuat.Enabled = true;
                this.btn_KQTHISV.Enabled = false;
                this.frmBangDiem.Enabled = true;
                this.barButtonItem3.Enabled = false;
            }

            else if (Program.mGroup == "Sinhvien")
            {
                this.btn_MH.Enabled = false;
                this.btnKHOA.Enabled = false;
                this.btnSV.Enabled = false;
                this.btnGV.Enabled = false;
                this.DE_btn.Enabled = false;
                this.btn_Thi.Enabled = true;
                this.btn_Giaovien_Dangky.Enabled = false;
                this.btn_THITHU.Enabled = false;
                this.btnDangXuat.Enabled = true;
                this.btn_KQTHISV.Enabled = false;
                this.frmBangDiem.Enabled = false;
                this.barButtonItem3.Enabled = false;
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
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Gọi Application.Exit() để thoát toàn bộ ứng dụng
            Application.Exit();
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


        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FrmBoDe));
            if (form == null)
            {

                frmBoDe = new FrmBoDe();
                frmBoDe.MdiParent = this;

                frmBoDe.Show();
                checkOpenDeThi = true;
            }
            else form.Activate();
        }

        private void btn_Thi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FrmThi));
            if (form == null)
            {

                FrmThi frmThi = new FrmThi();
                frmThi.MdiParent = this;

                frmThi.Show();
            }
            else form.Activate();
        }

        private void frmBangDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FrmBangDiemReport));
            if (form == null)
            {
                FrmBangDiemReport frmBangDiemReport = new FrmBangDiemReport();
                frmBangDiemReport.MdiParent = this;
                frmBangDiemReport.Show();

            }
            else form.Activate();
        }

        private void btn_THITHU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(Frm_ThiThu));
            if (form == null)
            {

                Frm_ThiThu frm_ThiThu = new Frm_ThiThu();
                frm_ThiThu.MdiParent = this;

                frm_ThiThu.Show();
            }
            else form.Activate();
        }

        private void btn_KQTHISV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(Frm_xemKQThiSV));
            if (form == null)
            {

                Frm_xemKQThiSV frm_xemKQThiSV = new Frm_xemKQThiSV();
                frm_xemKQThiSV.MdiParent = this;

                frm_xemKQThiSV.Show();
            }
            else form.Activate();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            btnDangNhap.Enabled = true;
            btnDangXuat.Enabled = false;
            this.btn_MH.Enabled = false;
            this.btnKHOA.Enabled = false;
            this.btnSV.Enabled = false;
            this.btnGV.Enabled = false;
            this.DE_btn.Enabled = false;
            this.btn_Thi.Enabled = false;
            this.btn_Giaovien_Dangky.Enabled = false;
            this.btn_THITHU.Enabled = false;
            this.btnDangXuat.Enabled = false;
            this.btn_KQTHISV.Enabled = false;
            this.frmBangDiem.Enabled = false;
            this.barButtonItem3.Enabled = false;
            Program.frmChinh.MAGV.Text = "Mã GV: " ;
            Program.frmChinh.HOTEN.Text = "Họ và Tên: ";
            Program.frmChinh.NHOM.Text = "Nhóm: " ;
            Program.mloginDN = "";
            Program.passwordDN = "";
            Program.mGroup = "";
            Program.mHoten = "";
            Program.maSV = "";
            Program.servername = "";
            Program.username = "";
            Program.mlogin = "";
            Program.password = "";
            Form f = this.CheckExists(typeof(FrmDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FrmDangNhap form = new FrmDangNhap();
                form.Show();
            }


        }

        private void btnKHOA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmKhoaLop));
            if (form == null)
            {

                frmKhoaLop frmKhoaLop = new frmKhoaLop();
                frmKhoaLop.MdiParent = this;

                frmKhoaLop.Show();
            }
            else form.Activate();
        }

        private void btnSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmSinhVien));
            if (form == null)
            {

                frmSinhVien frmSinhVien = new frmSinhVien();
                frmSinhVien.MdiParent = this;

                frmSinhVien.Show();
            }
            else form.Activate();
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(FrmDangNhap));
            if (form == null)
            {

                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.MdiParent = this;

                frmDangNhap.Show();
            }
            else form.Activate();   

        }
    }
}
