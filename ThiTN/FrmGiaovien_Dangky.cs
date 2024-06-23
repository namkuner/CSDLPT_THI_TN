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
    public partial class FrmGiaovien_Dangky : Form
    {
        int vitri = 0;
        public FrmGiaovien_Dangky()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void FrmGiaovien_Dangky_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dS1.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.dS1.MONHOC);
            this.dS1.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS1.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.FillByMAGV(this.dS1.GIAOVIEN_DANGKY, Program.username);
            // TODO: This line of code loads data into the 'dS1.BODE_DANGKY' table. You can move, or remove it, as needed.
            
            
            this.bODE_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            
            this.bODE_DANGKYTableAdapter.Fill(this.dS1.BODE_DANGKY);
            // TODO: This line of code loads data into the 'dS1.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.dS1.LOP);
            cmbTRINHDO.Items.Add("A");
            cmbTRINHDO.Items.Add("B");
            cmbTRINHDO.Items.Add("C");


             btnThem.Enabled = true;
 
            this.panelControl2.Enabled = false;
            this.btnGhi.Enabled = false;




        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGVDK.Position;
            panelControl2.Enabled = true;
            btnThem.Enabled  = false;
            btnGhi.Enabled  = true;

            bdsGVDK.AddNew();
            txtMAGV.Text = Program.username;
            txtMAGV.Enabled = false;
            cmbMAMH.Focus();


        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu!", "", MessageBoxButtons.OK);
                cmbMAMH.Focus();
                return;
            }
            if (cmbTRINHDO.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ không được thiếu!", "", MessageBoxButtons.OK);
                cmbTRINHDO.Focus();
                return;
            }
            if (txtSOCAUTHI.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng thi không được thiếu!", "", MessageBoxButtons.OK);
                txtSOCAUTHI.Focus();
                return;
            }
            if (txtSOCAUTHI.Text.Trim() == "")
            {
                MessageBox.Show("Số câu thi không được thiếu!", "", MessageBoxButtons.OK);
                txtSOCAUTHI.Focus();
                return;
            }
            if (txtTHOIGIAN.Text.Trim() == "")
            {
                MessageBox.Show("Thời gian không được thiếu!", "", MessageBoxButtons.OK);
                txtTHOIGIAN.Focus();
                return;
            }
            
            if (cmbMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu!", "", MessageBoxButtons.OK);
                cmbMAMH.Focus();
                return;
            }
            try
            {
                bdsGVDK.EndEdit();
                bdsGVDK.ResetCurrentItem();

                using (SqlConnection conn = new SqlConnection(Program.connstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DK_TAODESV", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        int thoigian = int.Parse(txtTHOIGIAN.Text.Trim().Replace(".", ""));
                        int socau = int.Parse(txtSOCAUTHI.Text.Trim().Replace(".", ""));
                        int lan = int.Parse(txtLAN.Text.Trim().Replace(".", "")); 

                        // Thêm các tham số đầu vào
                        Console.WriteLine(1);
                        cmd.Parameters.AddWithValue("@MAGV", txtMAGV.Text);
                        Console.WriteLine(2);
                        cmd.Parameters.AddWithValue("@MALOP", cmbMALOP.SelectedValue.ToString());
                        Console.WriteLine(3);
                        cmd.Parameters.AddWithValue("@MaMonHoc", cmbMAMH.SelectedValue.ToString());
                        Console.WriteLine(4);   
                        cmd.Parameters.AddWithValue("@TrinhDo", cmbTRINHDO.Text);
                        Console.WriteLine(5);
                        cmd.Parameters.AddWithValue("@LanThi", lan);
                        Console.WriteLine(6);
                        cmd.Parameters.AddWithValue("@SoCauThi", socau);
                        Console.WriteLine(7);
                        cmd.Parameters.AddWithValue("@NgayThi", txtNGAYTHI.DateTime.ToString("yyyy-MM-dd HH:mm"));
                        Console.WriteLine(8);
                        cmd.Parameters.AddWithValue("@ThoiGian", thoigian);
                        Console.WriteLine(9);

                        int returnCode = Convert.ToInt32(cmd.ExecuteScalar());

                        if (returnCode == 0)
                        {
                            MessageBox.Show("Đăng ký thi thành công!", "", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thi thất bại!", "", MessageBoxButtons.OK);
                        }

                        panelControl2.Enabled = false;
                        btnThem.Enabled = true;
                        btnGhi.Enabled = false;
                        this.gIAOVIEN_DANGKYTableAdapter.ClearBeforeFill = true;
                        this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.gIAOVIEN_DANGKYTableAdapter.FillByMAGV(this.dS1.GIAOVIEN_DANGKY, Program.username);
                       

                    }
                }

                
            }
            catch (Exception ex)
                
            {   
                Console.WriteLine(ex.Message);
                MessageBox.Show("Lỗi ghi đăng ký thi!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }


        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void btn_thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Lấy mã đăng ký thi
            string maDK = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAGVDK"].ToString();
            // Kiểm tra đã chọn dòng hay chưa
            if (maDK == "")
            {
                MessageBox.Show("Chưa chọn đăng ký thi cần xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa đăng ký thi này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Program.connstr))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_XoaGiangVienDK", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MAGVDK", maDK);

                            int returnCode = Convert.ToInt32(cmd.ExecuteScalar());

                            if (returnCode == 0)
                            {
                                MessageBox.Show("Xóa đăng ký thi thành công!", "", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("Xóa đăng ký thi thất bại!", "", MessageBoxButtons.OK);
                            }

                            this.gIAOVIEN_DANGKYTableAdapter.ClearBeforeFill = true;
                            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.gIAOVIEN_DANGKYTableAdapter.FillByMAGV(this.dS1.GIAOVIEN_DANGKY, Program.username);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa đăng ký thi!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }   
        }
    }
}
