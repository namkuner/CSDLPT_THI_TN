using System;
using System.CodeDom;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThiTN
{
    public partial class FrmDangNhap : Form
    {
        private SqlConnection conn_pulisher = new SqlConnection();
        private int ketNoi_CSDLGOC()
        {
            if (conn_pulisher != null && conn_pulisher.State == ConnectionState.Open)
                conn_pulisher.Close();
            try
            {
                conn_pulisher.ConnectionString = Program.connstr_publisher;
                conn_pulisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu gốc.\n" + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public FrmDangNhap()
        {
            InitializeComponent();
            checkGV.Checked = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void coSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = coSo.SelectedValue.ToString();
            }
            catch (Exception)
            {
            }
        }
        private void layDSPM(string cmd)
        {
            DataTable dt = new DataTable();
            if (conn_pulisher.State == ConnectionState.Closed) conn_pulisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_pulisher);
            da.Fill(dt);
            conn_pulisher.Close();
            Program.bds_dspm.DataSource = dt;
            coSo.DataSource = Program.bds_dspm;
            coSo.DisplayMember = "TENCN";
            coSo.ValueMember = "TENSERVER";

        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            if (ketNoi_CSDLGOC() == 0) return;
            layDSPM("SELECT * FROM  V_DS_PHANMANH");
            coSo.SelectedIndex = 0;


        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (checkSV.Checked)
            {
                if (MASV.Text.Trim() == "")
                {
                    MessageBox.Show("Mã sinh viên không được để trống", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mlogin = "SV";
                Program.password = "123456";
                Program.servername = coSo.SelectedValue.ToString();
                if (Program.KetNoi() == 0)
                {
                    return;
                }
                Program.mChinhanh = coSo.SelectedIndex;
                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                string strLenh = "EXEC SP_LAY_THONG_TIN_GV '" + Program.mlogin + "'";
                System.Console.Out.WriteLine(strLenh);
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null)
                {
                    return;
                }
                Program.myReader.Read();

                Program.username = Program.myReader.GetString(0);
                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn không có quyền truy cập dữ liệu\nBạn xem lại username và password", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();

                string strlenh1 = "SELECT * FROM SINHVIEN WHERE MASV = '" + MASV.Text + "'";
                System.Console.Out.WriteLine(strlenh1);

                Program.myReader = Program.ExecSqlDataReader(strlenh1);
                if (Program.myReader == null)
                {
                    return;
                }
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Sinh viên không tồn tại", "", MessageBoxButtons.OK);
                    return;
                }
                Program.myReader.Read();


                    if (Program.myReader.GetString(6).Trim() == matKhau.Text.Trim())
                    {
                        MessageBox.Show("Đăng nhập thành công", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng", "", MessageBoxButtons.OK);
                        return;
                    }
                Program.maSV = Program.myReader.GetString(0);
                Program.mHoten =  Program.myReader.GetString(1) + " " + Program.myReader.GetString(2);
                Program.frmChinh.MAGV.Text ="Mã SV: " + Program.maSV;
                Program.frmChinh.HOTEN.Text = "Họ và tên: " + Program.mHoten;
                
                Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;
                Program.myReader.Close();
                Program.conn.Close();
                Program.frmChinh.buttons();


                return;
            }
            else
            {
                if (taiKhoan.Text.Trim() == "" || matKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Tài khoản và mật khẩu không được để trống", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mlogin = taiKhoan.Text;
                Program.password = matKhau.Text;
                Program.servername = coSo.SelectedValue.ToString();
                Console.WriteLine(Program.servername);
                if (Program.KetNoi() == 0)
                {
                    return;
                }

                Program.mChinhanh = coSo.SelectedIndex;
                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                string strLenh = "EXEC SP_LAY_THONG_TIN_GV '" + Program.mlogin + "'";
                System.Console.Out.WriteLine(strLenh);
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null)
                {
                    return;
                }
                Program.myReader.Read();

                Program.username = Program.myReader.GetString(0);
                Console.WriteLine(Program.myReader.GetString(0));
                Console.WriteLine(Program.username);
                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn không có quyền truy cập dữ liệu\nBạn xem lại username và password", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mHoten = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();
                Program.conn.Close();
                Program.frmChinh.MAGV.Text ="Mã GV: " + Program.username;
                Program.frmChinh.HOTEN.Text ="Họ và Tên: " + Program.mHoten;
                Program.frmChinh.NHOM.Text ="Nhóm: " + Program.mGroup;
                Program.frmChinh.buttons();

            }


        }

        private void checkGV_CheckedChanged(object sender, EventArgs e)
        {
            this.grbMASV.Enabled = false;
            this.taiKhoan.Enabled = true;
        }

        private void checkSV_CheckedChanged(object sender, EventArgs e)
        {
            this.grbMASV.Enabled = true;
            this.taiKhoan.Enabled = false;
        }

        private void MASV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
