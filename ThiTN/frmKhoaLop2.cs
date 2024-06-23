using DevExpress.Data.Helpers;
using DevExpress.XtraGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTN
{
    public partial class frmKhoaLop2 : Form
    {
        int vitri = 0;
        string macs = "";
        Stack undoList = new Stack();
        BindingSource bds = null;
        GridControl gc = null;
        string currMode = "";
        bool dangThem = false;
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        public frmKhoaLop2()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKHOA.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void frmKhoaLop_Load(object sender, EventArgs e)
        {
            this.dS1.EnforceConstraints = false;

            this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHOATableAdapter.Fill(this.dS1.KHOA);
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dS1.LOP);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.dS1.SINHVIEN);

            cmbCS.DataSource = Program.bds_dspm;
            cmbCS.DisplayMember = "TENCN";
            cmbCS.ValueMember = "TENSERVER";
            cmbCS.SelectedIndex = Program.mChinhanh;
            System.Console.Out.WriteLine(Program.mChinhanh);
            macs = ((DataRowView)bdsKHOA[0])["MACS"].ToString();

            //moi load form chi duoc chon nut che do
            panelControl2.Enabled = false;
            
            //dung luoi nua
            txtMAKH.Enabled = false;
            txtTENKH.Enabled = false;
            txtMALOP.Enabled = false;
            txtTENLOP.Enabled = false;

            gcKHOA.Enabled = false;
            gcLOP.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;
        }

        private void cmbCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCS.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbCS.SelectedValue.ToString();

            if (cmbCS.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở mới", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dS1.KHOA);
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dS1.LOP);
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                macs = ((DataRowView)bdsKHOA[0])["MACS"].ToString();
            }
        }

        private void mACSTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void phanQuyen()
        {
            btnRefresh.Enabled = true;
            if (Program.mGroup == "Truong")
            {
                cmbCS.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;

            }

            else if (Program.mGroup == "CoSo")
            {
                cmbCS.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            }
            else
            {
                cmbCS.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            }
        }
        private void btnKhoa_ItemClicks(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnMenu.Links[0].Caption = "Khoa";
            currMode = "Khoa";
            bds = bdsKHOA;
            gc = gcKHOA;
            
            gcKHOA.Enabled = true;
            gcLOP.Enabled = true;
            phanQuyen();
        }

        private void btnLop_ItemClicks(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnMenu.Links[0].Caption = "Lớp";
            currMode = "Lớp";
            bds = bdsLOP;
            gc = gcLOP;

            //tat group box, enable gc va button
           
            gcKHOA.Enabled = true;
            gcLOP.Enabled = true;
            phanQuyen();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bds.Position;
            dangThem = true;

            bds.AddNew();
            if (currMode == "Khoa")
            {
                txtMAKH.Enabled = true;
                txtTENKH.Enabled = true;
                txtMAKH.Focus();
                txtMACS.Text = macs;
            }
            if (currMode == "Lớp")
            {
                ((DataRowView)(bdsLOP.Current))["MAKH"] = ((DataRowView)(bdsKHOA.Current))["MAKH"];
                txtMAKH1.Text = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();
                txtMAKH1.Enabled = false;

                txtMALOP.Enabled = true;
                txtTENLOP.Enabled = true;
                txtMALOP.Focus();
            }
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcKHOA.Enabled = false;
            gcLOP.Enabled = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.KHOATableAdapter.Fill(this.dS1.KHOA);
                this.LOPTableAdapter.Fill(this.dS1.LOP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Refresh: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DialogResult result = MessageBox.Show(
            //    "Bạn có chắc chắn muốn xóa Khoa này?",
            //    "Xác nhận xóa",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question
            //    );
            //string maKH = "";
            //if (bdsLOP.Count > 0)
            //{
            //    MessageBox.Show("Khoa đã có tạo lớp, không thể xóa!!", "", MessageBoxButtons.OK);
            //    return;
            //}

            //if (result == DialogResult.Yes)
            //{
            //    try
            //    {
            //        maKH = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();
            //        bdsKHOA.RemoveCurrent();
            //        this.KHOATableAdapter.Update(this.dS_Khoa_Lop.KHOA);
            //        MessageBox.Show("Đã xóa khoa thành công", "", MessageBoxButtons.OK);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi xóa khoa. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
            //        this.KHOATableAdapter.Fill(this.dS_Khoa_Lop.KHOA);
            //        bdsKHOA.Position = bdsKHOA.Find("MAKH", maKH);
            //        return;
            //    }
            //}
            //if (bdsKHOA.Count == 0) { btnXoa.Enabled = false; }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bds.Position;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcLOP.Enabled = false;
            gcKHOA.Enabled = false;
            if (currMode == "Khoa")
            {
                txtMAKH.Enabled = true;
                txtTENKH.Enabled = true;
            }
            if (currMode == "Lớp")
            {
                txtMAKH1.Enabled = false;
                txtMALOP.Enabled = true;
                txtTENLOP.Enabled = true;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnThem.Enabled == false)
            {                
                gc.Enabled = true;
                groupBox1.Enabled = false;
                
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                bds.CancelEdit();
                bds.RemoveCurrent();
                bds.Position = vitri;
                return;
            }
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không có thao tác để khôi phục", "", MessageBoxButtons.OK);
                btnPhucHoi.Enabled = false;
                return;
            }
            bds.CancelEdit();
            string q =  undoList.Pop().ToString();
            Console.WriteLine(q);
            int n = Program.ExecSqlNonQuery(q);

            this.KHOATableAdapter.Fill(this.dS1.KHOA);
            this.LOPTableAdapter.Fill(this.dS1.LOP);
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String ma = "";
            String q = "";
            if (currMode == "Khoa")
            {
                if (txtMAKH.Text.Trim() == "")
                {
                    MessageBox.Show("Mã khoa không được để trống", "", MessageBoxButtons.OK);
                    txtMAKH.Focus();
                    return;
                }
                if (txtTENKH.Text.Trim() == "")
                {
                    MessageBox.Show("Tên khoa không được để trống", "", MessageBoxButtons.OK);
                    txtTENKH.Focus();
                    return;
                }
                //neu bat mode khoa ta exec sp kiem tra ma khoa
                ma = txtMAKH.Text.Trim();
                q = "DECLARE @result int " +
                    "EXEC @result = sp_KiemTraMaKH '" +
                    ma + "' " +
                    "SELECT 'VALUE' = @result";
            }
            if (currMode == "Lớp")
            {
                if (txtMALOP.Text.Trim() == "")
                {
                    MessageBox.Show("Mã lớp không được để trống", "", MessageBoxButtons.OK);
                    txtMALOP.Focus();
                    return;
                }
                if (txtTENLOP.Text.Trim() == "")
                {
                    MessageBox.Show("Tên lớp không được để trống", "", MessageBoxButtons.OK);
                    txtTENLOP.Focus();
                    return;
                }
                ma = txtMALOP.Text.Trim();
                q = "DECLARE @result int " +
                    "EXEC @result = sp_KiemTraMaLOP '" +
                    ma + "' " +
                    "SELECT 'VALUE' = @result";
            }
            SqlCommand sqlCommand = new SqlCommand(q, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(q);
                if (Program.myReader == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
                return;
            }
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();


        }

    }
}
