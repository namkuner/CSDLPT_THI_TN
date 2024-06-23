using DevExpress.XtraEditors;
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
    public partial class frmKhoaLop : Form
    {
        int vitri = 0;
        string macs = "";
        Stack undoList = new Stack();
        BindingSource bds = null;
        GridControl gc = null;
        string currMode = "";
        bool dangThem = false;
        public frmKhoaLop()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKHOA.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void frmKhoaLop_Load(object sender, EventArgs e)
        {
            this.dS1.EnforceConstraints = false;

            this.gIAOVIENTableAdapter.Fill(this.dS1.GIAOVIEN);
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS1.GIAOVIEN_DANGKY);

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

            //dung luoi nua
            txtMACS.Enabled = txtMAKH.Enabled = txtTENKH.Enabled = false;

            txtMALOP.Enabled = txtTENLOP.Enabled = false;

            gcKHOA.Enabled = false;
            gcLOP.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;
            if (Program.mGroup == "Truong")
            {
                cmbCS.Enabled = true;
            }
            else { cmbCS.Enabled = false; } 
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
        private void phanQuyen()
        {
            btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            if (Program.mGroup == "CoSo")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            }
            else
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
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

                this.txtMALOP.Enabled = true;
                this.txtTENLOP.Enabled = true;
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

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bds.Position;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcLOP.Enabled = false;
            gcKHOA.Enabled = false;
            if (currMode == "Khoa")
            {
                txtMAKH.Enabled = false;
                txtTENKH.Enabled = true;
            }
            if (currMode == "Lớp")
            {
                txtMALOP.Enabled = false;
                txtTENLOP.Enabled = true;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bds.CancelEdit();
            
            if (btnThem.Enabled == false)
            {
                //dangThem = false;
                bds.ResetCurrentItem();
            }
            
            bds.Position = vitri;
            
            txtMAKH.Enabled = txtTENKH.Enabled = txtMALOP.Enabled = txtTENLOP.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            gcLOP.Enabled = true;
            gcKHOA.Enabled = true;
            //this.KHOATableAdapter.Fill(this.dS1.KHOA);
            //this.LOPTableAdapter.Fill(this.dS1.LOP);
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
            //MessageBox.Show("querry " + q + "'s result: " + result, "", MessageBoxButtons.OK);
            Program.myReader.Close();

            if (result == 1 && dangThem == true)
            {
                if (currMode == "Khoa")
                {
                    MessageBox.Show("Mã khoa đã tồn tại!", "", MessageBoxButtons.OK);
                    txtMAKH.Focus();
                    return;
                }
                else if (currMode == "Lớp")
                {
                    MessageBox.Show("Mã lớp đã tồn tại!", "", MessageBoxButtons.OK);
                    txtMALOP.Focus();
                    return;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi vào cơ sở dữ liệu?","", 
                    MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        bdsKHOA.EndEdit();
                        bdsLOP.EndEdit();
                        this.KHOATableAdapter.Update(this.dS1.KHOA);
                        this.LOPTableAdapter.Update(this.dS1.LOP);
                        MessageBox.Show("Đã ghi thành công!", "", MessageBoxButtons.OK);

                        //chore
                        gcKHOA.Enabled = gcLOP.Enabled = true;
                        btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Lỗi ghi " + currMode + "!\n\n"
                            + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;
            dangThem = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {    
            if (MessageBox.Show("Bạn có thật sự muốn xóa " + currMode +" này?",
                    "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (currMode == "Khoa")
                {
                    if (bdsLOP.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa khoa đã có lớp!", "", MessageBoxButtons.OK);
                        return;
                    }
                    if (bdsGV.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa khoa đã có giáo viên!", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (currMode == "Lớp")
                {
                    if (bdsSV.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa lớp đã có sinh viên!", "", MessageBoxButtons.OK);
                        return;
                    }
                    if (bdsGVDK.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa lớp đã được đăng ký thi!", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                try
                {
                    vitri = bds.Position;
                    bds.RemoveCurrent();
                    this.KHOATableAdapter.Update(this.dS1.KHOA);
                    this.LOPTableAdapter.Update(this.dS1.LOP);
                    MessageBox.Show("Đã xóa " + currMode + " thành công!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa " + currMode + ". Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.KHOATableAdapter.Update(this.dS1.KHOA);
                    this.LOPTableAdapter.Update(this.dS1.LOP);
                    bds.Position = vitri;
                    return;
                }
            }
        }
    }
}
