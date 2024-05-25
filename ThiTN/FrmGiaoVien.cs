using DevExpress.Data.Filtering;
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
    public partial class FrmGiaoVien : Form
    {
        int vitri = 0;
        public FrmGiaoVien()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {

            this.dS1.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS1.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS1.GIAOVIEN);
            this.gIAOVIENTableAdapter.Update(this.dS1.GIAOVIEN);
            
            // TODO: This line of code loads data into the 'dS1.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS1.GIAOVIEN_DANGKY);
            this.gIAOVIEN_DANGKYTableAdapter.Update(this.dS1.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS1.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;

            
            this.bODETableAdapter.Fill(this.dS1.BODE);
            this.bODETableAdapter.Update(this.dS1.BODE);
            // TODO: This line of code loads data into the 'dS1.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS1.KHOA);
            this.kHOATableAdapter.Update(this.dS1.KHOA);
            cmbCoSoFrmGiaoVien.DataSource = Program.bds_dspm;
            cmbCoSoFrmGiaoVien.DisplayMember = "TENCN";
            cmbCoSoFrmGiaoVien.ValueMember = "TENSERVER";
            cmbCoSoFrmGiaoVien.SelectedIndex = Program.mChinhanh;
            System.Console.Out.WriteLine(Program.mChinhanh);
            if (Program.mGroup == "Truong")
            {
                cmbCoSoFrmGiaoVien.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;

            }

            else if (Program.mGroup == "CoSo")
            {
                cmbCoSoFrmGiaoVien.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;
            }
            else
            {
                cmbCoSoFrmGiaoVien.Enabled = false;
            }

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGV.Position;
            bdsGV.AddNew();
            txtMAGV.Focus();
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcGV.Enabled = false;
            panelControl2.Enabled = true;
            txtMAGV.Enabled = true;
            cmbMAKH.Enabled = true;
            if (Program.mGroup == "Truong")
            {
                quyen.Items.Add("Truong");
            }
            else if(Program.mGroup=="CoSo")
            {
                quyen.Items.Add("CoSo");
                quyen.Items.Add("Giangvien");
            }

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã giáo viên không được để trống", "", MessageBoxButtons.OK);
                txtMAGV.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ giáo viên không được để trống", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên giáo viên không được để trống", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            try
            {
                bdsGV.EndEdit();
                bdsGV.ResetCurrentItem();
                this.gIAOVIENTableAdapter.Update(this.dS1.GIAOVIEN);
                this.gIAOVIENTableAdapter.Fill(this.dS1.GIAOVIEN);
                this.gIAOVIENTableAdapter.Update(this.dS1.GIAOVIEN);
                gcGV.Enabled = true;
                panelControl2.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                String cauTruyVan =
                   "EXEC sp_TaoTaiKhoan '" + this.txtMAGV + "' , '" + matKhau + "', '"
                   + this.txtMAGV + "', '" + quyen + "'";

                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                try
                {

                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    /*khong co ket qua tra ve thi ket thuc luon*/
                    if (Program.myReader == null)
                    {
                        return;
                    }

                    MessageBox.Show("Đăng kí tài khoản thành công\n\nTài khoản: " + txtMAGV + "\nMật khẩu: " + matKhau + "\n Mã Nhân Viên: " + matKhau + "\n Vai Trò: " + quyen, "Thông Báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    return;
                }

            


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi giáo viên. " + ex.Message, "", MessageBoxButtons.OK);
            }
            

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa Giảng viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            string maGV = "";
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Giáo viên đã có đăng ký, không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBODE.Count > 0)
            {
                MessageBox.Show("Giáo viên đã có bộ đề, không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }

            if (result == DialogResult.Yes)
            {
                try
                {
                    maGV = ((DataRowView)bdsGV[bdsGV.Position])["MAGV"].ToString();
                    bdsGV.RemoveCurrent();
                    this.gIAOVIENTableAdapter.Update(this.dS1.GIAOVIEN);
                    String cauTruyVan =
                                "EXEC sp_TaoTaiKhoan '" + maGV +"' , '" +maGV +"'";
                    SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giáo viên. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.gIAOVIENTableAdapter.Fill(this.dS1.GIAOVIEN);
                    bdsGV.Position = bdsGV.Find("MAGV", maGV);
                    return;
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGV.Position;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcGV.Enabled = false;
            panelControl2.Enabled = true;
            txtMAGV.Enabled = false;
            cmbMAKH.Enabled = true;

        }
    }
}
