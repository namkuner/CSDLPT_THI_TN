using DevExpress.XtraEditors;
using System;
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
    public partial class frmSinhVien : Form
    {
        int vitri = 0;
        bool dangThem = false;

        public frmSinhVien()
        {
            InitializeComponent();
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            this.dS1.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dS1.LOP);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.dS1.SINHVIEN);
            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BANGDIEMTableAdapter.Fill(this.dS1.BANGDIEM);

            cmbCS.DataSource = Program.bds_dspm;
            cmbCS.DisplayMember = "TENCN";
            cmbCS.ValueMember = "TENSERVER";
            cmbCS.SelectedIndex = Program.mChinhanh;
            System.Console.Out.WriteLine(Program.mChinhanh);

            groupBox1.Enabled = false;
            btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
            if (Program.mGroup == "Truong")
            {
                cmbCS.Enabled = true;
            }
            else if (Program.mGroup == "CoSo")
            {
                cmbCS.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            }
            else
            {
                cmbCS.Enabled = false;
            }
        }


        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

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
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.dS1.SINHVIEN);
                this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                this.BANGDIEMTableAdapter.Fill(this.dS1.BANGDIEM);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSV.Position;
            bdsSV.AddNew();
            txtMASV.Focus();
            dangThem = true;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcSV.Enabled = false;
            groupBox1.Enabled = true;
            txtMASV.Enabled = true;
            cmbMALOP.Enabled = true;
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSV.Position;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcSV.Enabled = false;
            groupBox1.Enabled = true;
            txtMASV.Enabled = false;
            cmbMALOP.Enabled = false;
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.SINHVIENTableAdapter.Fill(this.dS1.SINHVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Refresh: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa sinh viên này?",
                    "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (bdsBD.Count > 0)
                {
                    MessageBox.Show("Không thể xóa sinh viên đã tạo bảng điểm");
                    return;
                }
                try
                {
                    vitri = bdsSV.Position;
                    bdsSV.RemoveCurrent();
                    this.SINHVIENTableAdapter.Update(this.dS1.SINHVIEN);
                    MessageBox.Show("Đã xóa sinh viên thành công!", "", MessageBoxButtons.OK);
                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên! Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.SINHVIENTableAdapter.Fill(this.dS1.SINHVIEN);
                    bdsSV.Position = vitri;
                    return;
                }
            }                
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSV.CancelEdit();

            

            if (btnThem.Enabled == false)
            {
                bdsSV.ResetCurrentItem();
            }
            bdsSV.Position = vitri;
            gcSV.Enabled = true;
            groupBox1.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMASV.Text.Trim() == "")
                {
                    MessageBox.Show("Mã sinh viên không được để trống", "", MessageBoxButtons.OK);
                    txtMASV.Focus();
                    return;
                }
            if (txtHO.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được để trống", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return;
            }
            if (txtTEN.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được để trống", "", MessageBoxButtons.OK);
                txtTEN.Focus();
                return;
            }
            if (cmbMALOP.Text.Trim() == "") {
                MessageBox.Show("Mã lớp của sinh viên không được để trống", "", MessageBoxButtons.OK);
                cmbMALOP.Focus();
                return;
            }
            string masv = txtMASV.Text.Trim();
            string q = "DECLARE @result int " +
                    "EXEC @result = sp_KiemTraMaSV '" +
                    masv + "' " +
                    "SELECT 'VALUE' = @result";
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
            //MessageBox.Show("query " + q + "'s result: " + result, "", MessageBoxButtons.OK);
            Program.myReader.Close();

            if (result == 1 && dangThem ==true)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "", MessageBoxButtons.OK);
                txtMASV.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn ghi vào cơ sở dữ liệu?",
                    "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        bdsSV.EndEdit();
                        bdsSV.ResetCurrentItem();
                        this.SINHVIENTableAdapter.Update(this.dS1.SINHVIEN);
                        MessageBox.Show("Đã ghi thành công!", "", MessageBoxButtons.OK);

                        gcSV.Enabled = true;
                        groupBox1.Enabled = false;
                        btnGhi.Enabled = btnRefresh.Enabled = false;
                        btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi sinh viên !\n\n"
                            + ex.Message, "", MessageBoxButtons.OK);
                        gcSV.Enabled = true;
                        groupBox1.Enabled = false;
                        btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
                        return;
                    }
                }
            }
        }
    }
}
