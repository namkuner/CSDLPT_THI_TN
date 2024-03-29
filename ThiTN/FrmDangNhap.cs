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
            catch (Exception) { 
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
            coSo.SelectedIndex = 1;
            coSo.SelectedIndex = 0;


        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(taiKhoan.Text.Trim() == "" || matKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống", "", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = taiKhoan.Text;
            Program.password = matKhau.Text;
            if(Program.KetNoi() == 0)
            {
                return;
            }
            Program.servername = coSo.SelectedValue.ToString();
            Program.mChinhanh = coSo.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_LAY_THONG_TIN_USER '" + Program.mlogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if(Program.myReader == null)
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
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            Program.frmChinh.MAGV.Text = Program.username;
            Program.frmChinh.HOTEN.Text = Program.mHoten;
            Program.frmChinh.NHOM.Text = Program.mGroup;
            Program.frmChinh.HienThiMenu();

        }
    }
}
