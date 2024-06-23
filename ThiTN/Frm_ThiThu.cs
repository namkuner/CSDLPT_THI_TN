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
    public partial class Frm_ThiThu : Form
    {
        private bool isStarted = false;
        private TimeSpan timeLeft;
        private int time;
        private int stt = 1;
        Dictionary<int, ExamQuestion> examQuestions;
        public Frm_ThiThu()
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

        private void Frm_ThiThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.LOP' table. You can move, or remove it, as needed.
            tN_CSDLPTDataSet.EnforceConstraints = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.FillByMAGV(this.tN_CSDLPTDataSet.LOP,Program.username);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.FillByMAGV(this.tN_CSDLPTDataSet.MONHOC, Program.username);

        }

        private void init()
        {
            pn_CauHoi.Visible = false;
            tb_CAUHOI.ReadOnly = true;
            tb_A.ReadOnly = true;
            tb_B.ReadOnly = true;
            tb_C.ReadOnly = true;
            tb_D.ReadOnly = true;
        }

        private void btn_TimDeThi_Click(object sender, EventArgs e)
        {
            String queryDeThi = "SELECT gvdk.THOIGIAN, gvdk.SOCAUTHI FROM GIAOVIEN_DANGKY as gvdk WHERE gvdk.MAMH = @MAMH AND gvdk.LAN = @LAN  and gvdk.MAGV = @MAGV and gvdk.MALOP = @MALOP ";

            using (SqlConnection conn = new SqlConnection(Program.connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(queryDeThi, conn))
                {
                    cmd.Parameters.AddWithValue("@MAMH", ccb_MonHoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@LAN", se_Lan.Value);
                    cmd.Parameters.AddWithValue("@MAGV", Program.username);
                    cmd.Parameters.AddWithValue("@MALOP", cbb_LOP.SelectedValue);

                    Console.WriteLine("MAMH: " + ccb_MonHoc.SelectedValue);
                    Console.WriteLine("LAN: " + se_Lan.Value);
                    Console.WriteLine("MAGV: " + Program.username);
                    Console.WriteLine("MALOP: " + cbb_LOP.SelectedValue);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Không tìm thấy đề thi. Vui lòng xem lại Môn Thi/ Lần/ Ngày Thi/Lớp", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }

                        listView1.Visible = true;

                        while (reader.Read())
                        {
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

                string queryExam = @"select bode.CAUHOI, bode.NOIDUNG, bode.A, bode.B, bode.C, bode.D, bode.DAP_AN
                                        from GIAOVIEN_DANGKY as gvdk
                                        join BODE_DANGKY as bddk
                                        on gvdk.MAGVDK = bddk.MAGVDK
                                        join BODE as bode
                                        on bode.CAUHOI = bddk.CAUHOI
                                        where gvdk.MAGV = @MAGV and gvdk.MALOP = @MALOP and gvdk.LAN = @LAN and gvdk.MAMH = @MAMH";

                examQuestions = new Dictionary<int, ExamQuestion>();

                using (SqlCommand cmdExam = new SqlCommand(queryExam, conn))
                {
                    cmdExam.Parameters.AddWithValue("@MAGV", Program.username);
                    cmdExam.Parameters.AddWithValue("@MALOP", cbb_LOP.SelectedValue);
                    cmdExam.Parameters.AddWithValue("@LAN", se_Lan.Value);
                    cmdExam.Parameters.AddWithValue("@MAMH", ccb_MonHoc.SelectedValue);

                    using (SqlDataReader reader = cmdExam.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Lỗi tải đề thi", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                        int STT = 1;
                        while (reader.Read())
                        {
                            
                            ExamQuestion examQuestion = new ExamQuestion
                            {
                                MABD = -1,
                                CAUHOI = reader.GetInt32(0),
                                A = null,
                                B = null,
                                C = null,
                                D = null,
                                DAP_AN_SV =null,
                                STT = STT,
                                NOIDUNG = reader.GetString(1),
                                A_NOIDUNG = reader.GetString(2),
                                B_NOIDUNG = reader.GetString(3),
                                C_NOIDUNG = reader.GetString(4),
                                D_NOIDUNG = reader.GetString(5),
                                DAP_AN = reader.GetString(6)
                            };
                            STT++;
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
        private void showQuestion(Dictionary<int, ExamQuestion> examQuestions, int stt)
        {
            if (examQuestions != null)
            {
                lb_stt.Text = stt.ToString();
                tb_CAUHOI.Text = examQuestions[stt].NOIDUNG;
                tb_A.Text = examQuestions[stt].A_NOIDUNG;
                tb_B.Text = examQuestions[stt].B_NOIDUNG;
                tb_C.Text = examQuestions[stt].C_NOIDUNG;
                tb_D.Text = examQuestions[stt].D_NOIDUNG;
                setRadioButton();
            }
        }

        private void UpdateButtonStates()
        {
            btn_truoc.Enabled = stt > 1;
            btn_tiep.Enabled = stt < examQuestions.Count;
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

        private void saveAndCountScore()
        {
            // Tính điểm và hiển thị
            int num_answer_corrects = 0;
            foreach (var question in examQuestions.Values)
            {
                if (question.DAP_AN_SV == question.DAP_AN)
                {
                    num_answer_corrects += 1;
                }
            }
            double score = (double)num_answer_corrects / examQuestions.Count * 10;
            // lấy sau dấu phẩy 2 chữ số
            score = Math.Round(score, 2);

            MessageBox.Show("Nộp bài thành công", "Thông báo", MessageBoxButtons.OK);
            MessageBox.Show("Số câu đúng: " + num_answer_corrects + "/" + examQuestions.Count + "\nĐiểm: " + score, "Kết quả", MessageBoxButtons.OK);


            // sau khi nộp bài thì thoát form thi và bật lại form Thi
            this.Close();
            Frm_ThiThu frm_ThiThu = new Frm_ThiThu();
            frm_ThiThu.MdiParent = Program.frmChinh;
            frm_ThiThu.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
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
    }
}
