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
using ThiTN.Model;

namespace ThiTN
{
    public partial class FrmThi : Form
    {
        private bool isStarted = false;
        private TimeSpan timeLeft;
        private int time;
        private int stt = 1;
        Dictionary<int, ExamQuestion> examQuestions;
        public FrmThi()
        {
            InitializeComponent();
            init();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mONHOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tN_CSDLPTDataSet);

        }

        private void init()
        {
            tb_hoTen.Text = Program.mHoten;
            tb_maSV.Text = Program.maSV;
            pn_CauHoi.Visible = false;
            tb_CAUHOI.ReadOnly = true;
            tb_A.ReadOnly = true;
            tb_B.ReadOnly = true;
            tb_C.ReadOnly = true;
            tb_D.ReadOnly = true;
            // set giá trị mặc định cho datetimepicker
            dtp_NgayThi.Value = DateTime.Now;
        }

        private void FrmThi_Load(object sender, EventArgs e)
        {
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.FillByMASV(this.tN_CSDLPTDataSet.LOP, Program.maSV);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.FillByMASV(this.tN_CSDLPTDataSet.MONHOC, Program.maSV);

        }

        private void btn_TimDeThi_Click(object sender, EventArgs e)
        {
            int maBD = 0;
            String dateChoice = dtp_NgayThi.Value.ToString("yyyy-MM-dd");
            String queryDeThi = "SELECT gvdk.THOIGIAN, bd.MABD FROM GIAOVIEN_DANGKY as gvdk join BANGDIEM as bd on bd.MAGVDK = gvdk.MAGVDK WHERE gvdk.MAMH = @MAMH AND gvdk.LAN = @LAN AND CAST(gvdk.NGAYTHI AS DATE) = @NgayThi and bd.DIEM IS NULL and bd.MASV = @MASV";

            using (SqlConnection conn = new SqlConnection(Program.connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeThi, conn))
                {
                    cmd.Parameters.AddWithValue("@MAMH", ccb_MonHoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@LAN", se_Lan.Value);
                    cmd.Parameters.AddWithValue("@NgayThi", dateChoice);
                    cmd.Parameters.AddWithValue("@MASV", Program.maSV);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Không tìm thấy đề thi. Vui lòng xem lại Môn Thi/ Lần/ Ngày Thi", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }

                        listView1.Visible = true;

                        while (reader.Read())
                        {  
                            maBD = reader.GetInt32(1);
                            time = reader.GetInt16(0);
                            lb_ThoiGianHeader2.Text = time + " phút";
                            int hour = time / 60;
                            int minute = time % 60;
                            if (minute < 10)
                            {
                                if (hour < 10)
                                {
                                    lb_ThoiGian2.Text = "0" + hour + ":0" + minute + ":00";
                                }
                                else
                                {
                                    lb_ThoiGian2.Text = hour + ":0" + minute + ":00";
                                }
                            }
                            else
                            {
                                if (hour < 10)
                                {
                                    lb_ThoiGian2.Text = "0" + hour + ":" + minute + ":00";
                                }
                                else
                                {
                                    lb_ThoiGian2.Text = hour + ":" + minute + ":00";
                                }
                            }
                        }
                    }
                }

                string queryExam = @"SELECT ctbt.MABD, ctbt.CAUHOI, ctbt.A, ctbt.B, ctbt.C, ctbt.D, 
                                    ctbt.DAP_AN as DAP_AN_SV, ctbt.STT, 
                                    bode.NOIDUNG, bode.A as A_NOIDUNG, 
                                    bode.B as B_NOIDUNG, bode.C as C_NOIDUNG, 
                                    bode.D as D_NOIDUNG, bode.DAP_AN 
                             FROM CT_BAITHI as ctbt
                             JOIN BANGDIEM as bd ON ctbt.MABD = bd.MABD
                             JOIN BODE as bode ON bode.CAUHOI = ctbt.CAUHOI
                             WHERE bd.MASV = @MASV AND bd.MABD = @MABD
                             ORDER BY STT";

                examQuestions = new Dictionary<int, ExamQuestion>();

                using (SqlCommand cmdExam = new SqlCommand(queryExam, conn))
                {
                    cmdExam.Parameters.AddWithValue("@MASV", Program.maSV);
                    cmdExam.Parameters.AddWithValue("@MABD", maBD);

                    using (SqlDataReader reader = cmdExam.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Lỗi tải đề thi", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }

                        while (reader.Read())
                        {
                            ExamQuestion examQuestion = new ExamQuestion
                            {
                                MABD = reader.GetInt32(0),
                                CAUHOI = reader.GetInt32(1),
                                A = reader.GetString(2),
                                B = reader.GetString(3),
                                C = reader.GetString(4),
                                D = reader.GetString(5),
                                DAP_AN_SV = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                STT = reader.GetInt32(7),
                                NOIDUNG = reader.GetString(8),
                                A_NOIDUNG = reader.GetString(9),
                                B_NOIDUNG = reader.GetString(10),
                                C_NOIDUNG = reader.GetString(11),
                                D_NOIDUNG = reader.GetString(12),
                                DAP_AN = reader.GetString(13)
                            };
                            examQuestions.Add(examQuestion.STT, examQuestion);
                        }
                    }
                }

                if (examQuestions.Count > 0)
                {
                    btn_batDau.Visible = lb_ThoiGian1.Visible = lb_ThoiGian2.Visible = true;
                    pn_CauHoi.Visible = true;
                    lb_soCau2.Text = examQuestions.Count.ToString();
                    lb_soCau1.Visible = lb_soCau2.Visible = true;
                    lb_ThoiGianHeader1.Visible = lb_ThoiGianHeader2.Visible = true;
                }
            }
        }

        private void btn_batDau_Click(object sender, EventArgs e)
        {
            isStarted = true;
            gb_BaiThi.Enabled = false;
            // Hiện Thị đề và Thời gian bắt đầu giảm
            btn_batDau.Enabled = false;
            btn_NopBai.Visible = true;
            int hour = time / 60;
            int minute = time % 60;
            timeLeft = new TimeSpan(hour, minute, 0);
            lb_ThoiGian2.Text = timeLeft.ToString(@"hh\:mm\:ss");
            timer1.Start();
            // Hiện thị câu hỏi
            showQuestion(examQuestions, stt);
            UpdateButtonStates();
            PopulateListView();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                // Giảm thời gian còn lại 1 giây
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                // Cập nhật Label hiển thị
                lb_ThoiGian2.Text = timeLeft.ToString(@"hh\:mm\:ss");
            }
            else
            {
                // Dừng Timer khi hết giờ
                timer1.Stop();
                MessageBox.Show("Hết giờ!");
                saveAndCountScore();
            }
        }
        private void showQuestion(Dictionary<int, ExamQuestion> examQuestions, int stt)
        {
            if (examQuestions != null)
            {
                lb_stt.Text = stt.ToString();
                tb_CAUHOI.Text = examQuestions[stt].NOIDUNG;
                tb_A.Text = getAnswer(examQuestions[stt], examQuestions[stt].A);
                tb_B.Text = getAnswer(examQuestions[stt], examQuestions[stt].B);
                tb_C.Text = getAnswer(examQuestions[stt], examQuestions[stt].C);
                tb_D.Text = getAnswer(examQuestions[stt], examQuestions[stt].D);
                setRadioButton();
            }
        }

        private String getAnswer(ExamQuestion eq, String answer)
        {
            if (answer == "A")
            {
                return eq.A_NOIDUNG;
            }
            else if (answer == "B")
            {
                return eq.B_NOIDUNG;
            }
            else if (answer == "C")
            {
                return eq.C_NOIDUNG;
            }
            else
            {
                return eq.D_NOIDUNG;
            }
        }

        private void setRadioButton()
        {
            radio_A.Checked = radio_B.Checked = radio_C.Checked = radio_D.Checked = false;
            switch (examQuestions[stt].DAP_AN_SV)
            {
                case "A":
                    radio_A.Checked = true;
                    break;
                case "B":
                    radio_B.Checked = true;
                    break;
                case "C":
                    radio_C.Checked = true;
                    break;
                case "D":
                    radio_D.Checked = true;
                    break;
            }
        }

        private void btn_truoc_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (stt > 1)
            {
                stt--;
                showQuestion(examQuestions, stt);
                UpdateButtonStates();
            }
        }

        private void btn_tiep_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (stt < examQuestions.Count)
            {
                stt++;
                showQuestion(examQuestions, stt);
                UpdateButtonStates();
            }
        }

        private void UpdateButtonStates()
        {
            btn_truoc.Enabled = stt > 1;
            btn_tiep.Enabled = stt < examQuestions.Count;
        }

        private void SaveCurrentAnswer()
        {
            if (radio_A.Checked)
            {
                examQuestions[stt].DAP_AN_SV = "A";
            }
            else if (radio_B.Checked)
            {
                examQuestions[stt].DAP_AN_SV = "B";
            }
            else if (radio_C.Checked)
            {
                examQuestions[stt].DAP_AN_SV = "C";
            }
            else if (radio_D.Checked)
            {
                examQuestions[stt].DAP_AN_SV = "D";
            }
            else
            {
                examQuestions[stt].DAP_AN_SV = "";
            }
            PopulateListView();
        }

        private void PopulateListView()
        {
            listView1.Items.Clear();
            foreach (var question in examQuestions.Values)
            {
                ListViewItem item = new ListViewItem(question.STT.ToString());
                item.SubItems.Add(question.DAP_AN_SV);
                listView1.Items.Add(item);
            }
        }

        private void actionClickRadioButton(String answer)
        {
            examQuestions[stt].DAP_AN_SV = answer;
            PopulateListView();
        }

        private void radio_A_Click(object sender, EventArgs e)
        {
            actionClickRadioButton("A");
        }

        private void radio_B_Click(object sender, EventArgs e)
        {
            actionClickRadioButton("B");
        }

        private void radio_C_Click(object sender, EventArgs e)
        {
            actionClickRadioButton("C");
        }

        private void radio_D_Click(object sender, EventArgs e)
        {
            actionClickRadioButton("D");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedQuestionNumber = int.Parse(selectedItem.SubItems[0].Text);
                showQuestion(examQuestions, selectedQuestionNumber);
                stt = selectedQuestionNumber;
                UpdateButtonStates();
                setRadioButton();
            }
        }

        private void btn_NopBai_Click(object sender, EventArgs e)
        {
            // Nếu vẫn còn câu hỏi chưa trả lời, thông báo và hỏi có chắc nộp bài không
            if (examQuestions.Any(x => x.Value.DAP_AN_SV == ""))
            {
                DialogResult dialogResult = MessageBox.Show("Vẫn còn câu hỏi chưa trả lời, bạn có chắc chắn muốn nộp bài không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // Hỏi có chắc muốn nộp bài không
            DialogResult dialogResult2 = MessageBox.Show("Bạn có chắc chắn muốn nộp bài không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.No)
            {
                return;
            }
            // Dừng thời gian
            timer1.Stop();
            saveAndCountScore();

        }

        // hàm phụ trợ cho việc nộp bài
        private string GetAnswerContent(ExamQuestion question, string answer)
        {
            switch (answer)
            {
                case "A":
                    return question.A;
                case "B":
                    return question.B;
                case "C":
                    return question.C;
                case "D":
                    return question.D;
                default:
                    return string.Empty;
            }
        }
        private void saveAndCountScore()
        {
            // Tính điểm và hiển thị
            int num_answer_corrects = 0;
            foreach (var question in examQuestions.Values)
            {
                if (GetAnswerContent(question, question.DAP_AN_SV) == question.DAP_AN)
                {
                    num_answer_corrects += 1;
                }
            }
            double score = (double)num_answer_corrects / examQuestions.Count * 10;
            // lấy sau dấu phẩy 2 chữ số
            score = Math.Round(score, 2);


            // Nếu nộp bài, từ examQuestions cập nhật lại bảng CT_BAITHI
            foreach (var question in examQuestions.Values)
            {
                String query = "UPDATE CT_BAITHI SET DAP_AN = @DAP_AN WHERE MABD = @MABD AND CAUHOI = @CAUHOI";
                using (SqlConnection conn = new SqlConnection(Program.connstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DAP_AN", question.DAP_AN_SV);
                        cmd.Parameters.AddWithValue("@MABD", question.MABD);
                        cmd.Parameters.AddWithValue("@CAUHOI", question.CAUHOI);
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            // Cập nhật điểm vào BANGDIEM
            String queryBangDiem = "UPDATE BANGDIEM SET DIEM = @DIEM WHERE MASV = @MASV AND MAMH = @MAMH AND LAN = @LAN AND CAST(NGAYTHI AS DATE) = @NGAYTHI";
            using (SqlConnection conn = new SqlConnection(Program.connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(queryBangDiem, conn))
                {
                    cmd.Parameters.AddWithValue("@DIEM", score);
                    cmd.Parameters.AddWithValue("@MASV", Program.maSV);
                    cmd.Parameters.AddWithValue("@MAMH", ccb_MonHoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@LAN", se_Lan.Value);
                    cmd.Parameters.AddWithValue("@NGAYTHI", dtp_NgayThi.Value.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Nộp bài thành công", "Thông báo", MessageBoxButtons.OK);
            MessageBox.Show("Số câu đúng: " + num_answer_corrects + "/" + examQuestions.Count + "\nĐiểm: " + score, "Kết quả", MessageBoxButtons.OK);


            // sau khi nộp bài thì thoát form thi và bật lại form Thi
            this.Close();
            FrmThi frmThi = new FrmThi();
            frmThi.MdiParent = Program.frmChinh;
            frmThi.Show();
        }

        // xử lý khi thoát form thi
        private void FrmThi_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            /* if(isStarted)
             {
                 DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát không? Kết quả thi của bạn sẽ được lưu lại", "Thông báo", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.No)
                 {
                     e.Cancel = true;
                 }
                 else
                 {
                     saveAndCountScore();
                 }
             }*/
        }
    }
}
