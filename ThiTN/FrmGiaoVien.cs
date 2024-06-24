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
        private void hienthi()
        {
            panelControl2.Enabled = false;
            if (Program.mGroup == "Truong")
            {
                string cs = "CS" + (Program.mChinhanh + 1).ToString();
                // TODO: This line of code loads data into the 'dS1.GIAOVIEN' table. You can move, or remove it, as needed.
                this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIENTableAdapter.Fill(dS1.GIAOVIEN);
                cmbCoSoFrmGiaoVien.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;
                

            }

            else if (Program.mGroup == "CoSo")
            {
                // TODO: This line of code loads data into the 'dS1.GIAOVIEN' table. You can move, or remove it, as needed.
                this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIENTableAdapter.Fill(dS1.GIAOVIEN);

                cmbCoSoFrmGiaoVien.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;
            }
            else if (Program.mGroup == "Giangvien")
            {
                // TODO: This line of code loads data into the 'dS1.GIAOVIEN' table. You can move, or remove it, as needed.
                this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIENTableAdapter.FillByGV(dS1.GIAOVIEN, Program.username);
                cmbCoSoFrmGiaoVien.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;
            }
            else
            {
                cmbCoSoFrmGiaoVien.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;

            }
        }

        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {

            this.dS1.EnforceConstraints = false;

            

            cmbCoSoFrmGiaoVien.DataSource = Program.bds_dspm;
            cmbCoSoFrmGiaoVien.DisplayMember = "TENCN";
            cmbCoSoFrmGiaoVien.ValueMember = "TENSERVER";
            cmbCoSoFrmGiaoVien.SelectedIndex = Program.mChinhanh;
            System.Console.Out.WriteLine(Program.mChinhanh);

            this.gIAOVIEN_DANGKYTableAdapter.ClearBeforeFill = true;
            hienthi();

            // TODO: This line of code loads data into the 'dS1.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS1.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS1.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;

            
            this.bODETableAdapter.Fill(this.dS1.BODE);
            // TODO: This line of code loads data into the 'dS1.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS1.KHOA);

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
            panelControl2.Enabled = true;
            if (Program.mGroup == "Truong")
            {
                quyen.Items.Add("Truong");
            }
            else if(Program.mGroup=="CoSo")
            {
                quyen.Items.Add("CoSo");
                quyen.Items.Add("Giangvien");
                quyen.Items.Add("Sinhvien");
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
                this.gIAOVIENTableAdapter.Insert(
                        txtMAGV.Text.Trim(),
                        txtHo.Text.Trim(),
                        txtTen.Text.Trim(),
                        txtDiaChi.Text.Trim(),
                                                                                              
                        cmbMAKH.SelectedValue.ToString().Trim());

                gcGV.Enabled = true;
                panelControl2.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                String cauTruyVan =
                   "EXEC sp_TaoTaiKhoan '" + this.txtMAGV.Text.Trim() + "' , '" + matKhau.Text + "', '"
                   + this.txtMAGV.Text.Trim() + "', '" + quyen.SelectedItem.ToString().Trim() + "'";
                Console.WriteLine(cauTruyVan);
                
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                try
                {

                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    /*khong co ket qua tra ve thi ket thuc luon*/
                    if (Program.myReader == null)
                    {
                        return;
                    }
                    Program.myReader.Close();
                    cauTruyVan =
                       "EXEC Link1.TN_CSDLPT.DBO.sp_TaoTaiKhoan '" + this.txtMAGV.Text.Trim() + "' , '" + matKhau.Text + "', '"
                       + this.txtMAGV.Text.Trim() + "', '" + quyen.SelectedItem.ToString().Trim() + "'";
                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    Program.myReader.Close();
                    hienthi();
                    MessageBox.Show("Đăng kí tài khoản thành công\n\nTài khoản: " + this.txtMAGV.Text.Trim() + "\nMật khẩu: " + matKhau.Text + "\n Mã Nhân Viên: " + this.txtMAGV.Text.Trim() + "\n Vai Trò: " + quyen.SelectedItem.ToString().Trim(), "Thông Báo", MessageBoxButtons.OK);
                    
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
                    Console.WriteLine("mã giáo viên"+ maGV);
                    String cauTruyVan =
                                "EXEC sp_XoaLoginVaGiaoVien '" + maGV.Trim() +"' , '" +Program.username +"'";
                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    Console.WriteLine("cauTruyVan"+cauTruyVan);
                    if (Program.myReader == null)
                    {
                        return;
                    }
                    Program.myReader.Close();
                    cauTruyVan =
            "EXEC Link1.TN_CSDLPT.DBO.sp_XoaLoginVaGiaoVien '" + maGV.Trim() + "' , '" + Program.username + "'";

                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    if (Program.myReader == null)
                    {
                        return;
                    }
                    Program.myReader.Close();
                    bdsGV.RemoveCurrent();
                    this.gIAOVIENTableAdapter.Update(this.dS1.GIAOVIEN);
                    MessageBox.Show("Xóa Thành công:");
                    hienthi();
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

        private void mAKHLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // give code
            bdsGV.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsGV.RemoveCurrent();
            }
            bdsGV.Position = vitri;

            gcGV.Enabled = true;
            panelControl2.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;


        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                hienthi();
                bdsGV.Position = vitri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Refresh: " + ex.Message, "", MessageBoxButtons.OK);
            }
            
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
