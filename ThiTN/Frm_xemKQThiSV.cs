using DevExpress.XtraReports.UI;
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
    public partial class Frm_xemKQThiSV : Form
    {
        public Frm_xemKQThiSV()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mONHOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tN_CSDLPTDataSet);

        }

        // Hàm kiểm tra xem SV đã thi môn học, lần thi này chưa
        private bool checkDaThi(String maSV, String maMH, int lan)
        {
            String sql = "select * from BANGDIEM where MASV = @MASV and MAMH = @MAMH and LAN = @LAN AND DIEM IS NOT NULL";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@MASV", maSV);
                    cmd.Parameters.AddWithValue("@MAMH", maMH);
                    cmd.Parameters.AddWithValue("@LAN", lan);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    Program.myReader = cmd.ExecuteReader();
                    if (Program.myReader == null) return false;
                    if (Program.myReader.Read())
                    {
                        Program.myReader.Close();
                        return true;
                    }
                    Program.myReader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                Program.myReader.Close();
                return false;
            }
        }

        private void Frm_xemKQThiSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.tN_CSDLPTDataSet.MONHOC);
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.tN_CSDLPTDataSet.MONHOC);

        }

        private void btn_TimDeThi_Click(object sender, EventArgs e)
        {
            if(!checkDaThi(Program.maSV, cbb_monHoc.SelectedValue.ToString(), (int)se_Lan.Value))
            {
                MessageBox.Show("Sinh viên chưa thi môn học này, lần thi này.");
                return;
            }

            String maMH = cbb_monHoc.SelectedValue.ToString();
            String maSV = Program.maSV;
            int lan = (int)se_Lan.Value;
            Xrpt_xemKQThiSV rp = new Xrpt_xemKQThiSV(maSV, maMH, lan);

            string sql = "select TENMH from MONHOC where MAMH = @MAMH";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@MAMH", maMH);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    Program.myReader = cmd.ExecuteReader();
                    if (Program.myReader == null) return;
                    if (Program.myReader.Read())
                    {
                        rp.lb_monThi.Text =Program.myReader.GetString(0);
                    }
                    Program.myReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                Program.myReader.Close();
                return;
            }
            

            string sql1 = "select TENLOP from LOP join SINHVIEN on SINHVIEN.MALOP = LOP.MALOP where MASV = @MASV";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql1, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@MASV", maSV);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    Program.myReader = cmd.ExecuteReader();
                    if (Program.myReader == null) return;
                    if (Program.myReader.Read())
                    {
                        rp.lb_lop.Text = Program.myReader.GetString(0);
                    }
                    Program.myReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                Program.myReader.Close();
                return;
            }

            rp.lb_hoten.Text = Program.mHoten;

            string sql2 = "select NGAYTHI, DIEM from BANGDIEM where MAMH = @MAMH and LAN = @LAN and MASV = @MASV";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql2, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@MAMH", maMH);
                    cmd.Parameters.AddWithValue("@LAN", lan);
                    cmd.Parameters.AddWithValue("@MASV", maSV);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    Program.myReader = cmd.ExecuteReader();
                    if (Program.myReader == null) return;
                    if (Program.myReader.Read())
                    {
                        rp.lb_ngayThi.Text = Program.myReader.GetDateTime(0).ToString();
                        rp.lb_Diem.Text = Program.myReader.GetDouble(1).ToString();
                        Program.myReader.Close();
                    }
                    Program.myReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Môn này chưa thi. Vui lòng xem lại môn học/ lần thi. " + ex.Message);
                Program.myReader.Close();
                return;
            }

            
            

            Console.WriteLine(maMH + " " + maSV + " " + lan);

            rp.lb_LanThi.Text = lan.ToString();

            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }

        private void mONHOCBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.mONHOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tN_CSDLPTDataSet);

        }
    }
}
