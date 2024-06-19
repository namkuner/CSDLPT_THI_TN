using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTN
{
    public partial class FrmBoDe : Form
    {
        private Boolean checkThem = false;
        private Boolean checkSua = false;
        private Boolean checkXoa = false;
        private Boolean lsMonHocMode = false;
        private Dictionary<String, String> listMonHoc = new Dictionary<String, String>();

        private void getMonHoc()
        {
            String queryMonHoc = "select MAMH,TENMH from MONHOC";
            Program.myReader = Program.ExecSqlDataReader(queryMonHoc);
            if (Program.myReader == null)
            {
                Program.myReader.Close();
                Program.conn.Close();
                return;
            }
            else
            {
                while (Program.myReader.Read())
                {
                    if (!listMonHoc.ContainsKey(Program.myReader.GetString(0)))
                    {
                        listMonHoc.Add(Program.myReader.GetString(0), Program.myReader.GetString(1));
                    }

                }
                Program.myReader.Close();
                Program.conn.Close();
            }
        }

        public FrmBoDe()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.TN_CSDLPTDataSet);

        }

        private void FrmBoDe_Load(object sender, EventArgs e)
        {

            TN_CSDLPTDataSet.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.BODE' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.TN_CSDLPTDataSet.MONHOC);

            if (Program.mGroup.Equals("GiangVien") || Program.mGroup.Equals("CoSo"))
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = true;
                btn_Ghi.Enabled = btn_Huy.Enabled = btn_PhucHoi.Enabled = false;
                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.BODETableAdapter.FillByGV(this.TN_CSDLPTDataSet.BODE, Program.username);
                getMonHoc();
            }
            else
            {
                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.BODETableAdapter.Fill(this.TN_CSDLPTDataSet.BODE);
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled
                   = btn_Ghi.Enabled = btn_PhucHoi.Enabled = false;
            }
            setEnableEditCauHoi(false);
        }

        private void setEnableEditCauHoi(bool enable)
        {
            cbbTenMonHoc1.Enabled = tb_NOIDUNG.Enabled
                = cbb_TrinhDo.Enabled = ccb_DapAn.Enabled = tb_A.Enabled = tb_B.Enabled = tb_C.Enabled = tb_D.Enabled = enable;
        }
        private void setStatusButtonOption(Boolean check)
        {
            checkThem = checkSua = checkXoa = !check;
            btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = check;
        }

        private void ccb_tenMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ccb_tenMonHoc.SelectedValue != null)
            {
                int index = ccb_tenMonHoc.SelectedIndex;
                cbbTenMonHoc1.SelectedIndex = index;
                if (Program.mGroup.Equals("GiangVien") || Program.mGroup.Equals("CoSo"))
                {
                    try
                    {
                        this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                        this.BODETableAdapter.FillByGV_MH(this.TN_CSDLPTDataSet.BODE, Program.username, ccb_tenMonHoc.SelectedValue.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (Program.mGroup.Equals("Truong"))
                {
                    this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                    this.BODETableAdapter.FillByMH(this.TN_CSDLPTDataSet.BODE, ccb_tenMonHoc.SelectedValue.ToString().Trim());
                }
            }
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_Ghi.Enabled = btn_Huy.Enabled = true;
            btn_Sua.Enabled = btn_Xoa.Enabled = false;
            if (checkStatusBtn())
            {
                if (checkThem == false)
                {
                    bdsBoDe.AddNew();
                }
                String maMH = te_MAMH.Text;
                te_MAMH_Backup.Text = maMH;
                ccb_tenMonHoc.Enabled = false;
                checkThem = true;
                BODEGridControl.Enabled = false;

                setEnableEditCauHoi(true);
                tb_NOIDUNG.Text = tb_A.Text = tb_B.Text = tb_C.Text = tb_D.Text = "";
                te_MAGV.Text = Program.username;
                String queryMaCauHoi = "select MAX(CAUHOI) from BODE";
                Program.myReader = Program.ExecSqlDataReader(queryMaCauHoi);
                if (Program.myReader == null)
                {
                    Program.myReader.Close();
                    Program.conn.Close();
                    return;
                }
                else
                {
                    while (Program.myReader.Read())
                    {
                        se_MaCauHoi.Value = Program.myReader.GetInt32(0) + 1;
                        break;
                    }
                    Program.myReader.Close();
                    Program.conn.Close();
                }
            }
        }

        private void BODEGridControl_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)gridView1.GetFocusedRow();
            if (selectedRow != null)
            {
                String queryMonHoc = "select * from MONHOC";
                Program.myReader = Program.ExecSqlDataReader(queryMonHoc);
                if (Program.myReader == null)
                {
                    Program.myReader.Close();
                    Program.conn.Close();
                    return;
                }
                else
                {
                    while (Program.myReader.Read())
                    {
                        if (selectedRow.Row["MAMH"].ToString().Trim() == Program.myReader.GetString(0).Trim())
                        {
                            cbbTenMonHoc1.Text = Program.myReader.GetString(1);
                            te_MAMH.Text = Program.myReader.GetString(0);

                            break;
                        }

                    }
                    Program.myReader.Close();
                    Program.conn.Close();
                }

            }
        }
        private void themDe()
        {
            try
            {
                bdsBoDe.EndEdit();
                bdsBoDe.ResetCurrentItem();
                this.BODETableAdapter.Insert(
                    (int)se_MaCauHoi.Value,
                    te_MAMH.Text,
                    cbb_TrinhDo.Text,
                    tb_NOIDUNG.Text,
                    tb_A.Text,
                    tb_B.Text,
                    tb_C.Text,
                    tb_D.Text,
                    ccb_DapAn.Text,
                    Program.username
                    );
                checkThem = false;
                BODEGridControl.Enabled = true;
                ccb_tenMonHoc.Enabled = true;
                setEnableEditCauHoi(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi câu hỏi. " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void suaDe()
        {
            try
            {
                bdsBoDe.EndEdit();
                bdsBoDe.ResetCurrentItem();
                this.BODETableAdapter.Update(this.TN_CSDLPTDataSet.BODE);
                checkSua = false;
                BODEGridControl.Enabled = true;
                ccb_tenMonHoc.Enabled = true;
                setEnableEditCauHoi(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi câu hỏi. " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btn_Ghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkThem == true)
            {
                if (checkGhiCauHoi())
                {
                    themDe();
                    setStatusButtonOption(true);
                    btn_Huy.Enabled = false;
                    gridView1.RefreshData();
                    this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                    this.BODETableAdapter.FillByGV_MH(this.TN_CSDLPTDataSet.BODE, Program.username, cbbTenMonHoc1.SelectedValue.ToString().Trim());
                    String maMH = cbbTenMonHoc1.SelectedValue.ToString().Trim();
                    for (int i = 0; i < listMonHoc.Count; i++)
                    {
                        if (listMonHoc.ElementAt(i).Key.Trim() == maMH)
                        {
                            ccb_tenMonHoc.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else if (checkSua == true)
            {
                if (checkGhiCauHoi())
                {
                    suaDe();
                    setStatusButtonOption(true);
                    btn_Huy.Enabled = false;
                    gridView1.RefreshData();
                    this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                    this.BODETableAdapter.FillByGV_MH(this.TN_CSDLPTDataSet.BODE, Program.username, cbbTenMonHoc1.SelectedValue.ToString().Trim());
                    String maMH = cbbTenMonHoc1.SelectedValue.ToString().Trim();
                    for (int i = 0; i < listMonHoc.Count; i++)
                    {
                        if (listMonHoc.ElementAt(i).Key.Trim() == maMH)
                        {
                            ccb_tenMonHoc.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn hành động", "Thông báo", MessageBoxButtons.OK);
            }
        }



        private void tENMHComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenMonHoc1.SelectedValue != null)
            {
                String maMH = "";
                if (cbbTenMonHoc1.SelectedValue.GetType() == typeof(KeyValuePair<string, string>))
                {
                    KeyValuePair<string, string> selected = (KeyValuePair<string, string>)cbbTenMonHoc1.SelectedValue;
                    maMH = selected.Key;
                }
                else
                {
                    maMH = cbbTenMonHoc1.SelectedValue.ToString();
                }

                te_MAMH_Backup.Text = maMH;
                if (lsMonHocMode == true)
                {
                    te_MAMH.Text = maMH;
                }
            }
        }

        private void btn_Huy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_Xoa.Enabled = btn_Sua.Enabled = btn_Them.Enabled = true;
            btn_Ghi.Enabled = btn_Huy.Enabled = btn_PhucHoi.Enabled = false;
            if (checkThem == true || checkSua == true || checkXoa == true)
            {
                // khi nhấn nút Hủy thì réset lại các giá trị
                setEnableEditCauHoi(false);
                setStatusButtonOption(true);
                bdsBoDe.CancelEdit();
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                bdsBoDe.ResetCurrentItem();
                BODEGridControl.Enabled = true;
                ccb_tenMonHoc.Enabled = true;
            }
        }

        private Boolean checkStatusBtn()
        {
            if (checkThem == true || checkSua == true || checkXoa == true)
            {
                // Thông báo phải Hủy hoặc hoàn thành hành động trước khi làm hành động khác
                MessageBox.Show("Hãy hoàn thành hành động hoặc Hủy trước khi thực hiện hành động khác", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_Them.Enabled = btn_Xoa.Enabled = false;
            btn_Ghi.Enabled = btn_Huy.Enabled = true;
            if (checkStatusBtn())
            {

                DataRowView selectedRow = (DataRowView)gridView1.GetFocusedRow();
                if (selectedRow != null)
                {
                    setEnableEditCauHoi(true);
                    se_MaCauHoi.Enabled = false;
                    checkSua = true;
                }
                else
                {
                    MessageBox.Show("Chưa chọn câu hỏi cần sửa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
        private Boolean checkGhiCauHoi()
        {
            if (se_MaCauHoi.Value == null)
            {
                MessageBox.Show("Vui lòng nhập mã câu hỏi", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (te_MAMH.Text == "")
            {
                te_MAMH.Focus();
                MessageBox.Show("Vui lòng chọn mã môn học", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (cbb_TrinhDo.Text == "")
            {
                cbb_TrinhDo.Focus();
                MessageBox.Show("Vui lòng chọn trình độ", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (tb_NOIDUNG.Text == "")
            {
                tb_NOIDUNG.Focus();
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (tb_A.Text == "")
            {
                tb_A.Focus();
                MessageBox.Show("Vui lòng nhập đáp án A", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (tb_B.Text == "")
            {
                tb_B.Focus();
                MessageBox.Show("Vui lòng nhập đáp án B", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (tb_C.Text == "")
            {
                tb_C.Focus();
                MessageBox.Show("Vui lòng nhập đáp án C", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (tb_D.Text == "")
            {
                tb_D.Focus();
                MessageBox.Show("Vui lòng nhập đáp án D", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (ccb_DapAn.Text == "")
            {
                ccb_DapAn.Focus();
                MessageBox.Show("Vui lòng chọn đáp án đúng", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (te_MAMH.Text == "")
            {
                te_MAMH.Focus();
                MessageBox.Show("Vui lòng chọn mã môn học", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkStatusBtn())
            {
                DataRowView selectedRow = (DataRowView)gridView1.GetFocusedRow();
                if (selectedRow != null)
                {
                    // Kiểm tra xem câu hỏi đã được thi hay chưa
                    // ...

                    // Nếu chưa thì xóa câu hỏi
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            bdsBoDe.RemoveCurrent();
                            this.BODETableAdapter.Update(this.TN_CSDLPTDataSet.BODE);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa câu hỏi. " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn câu hỏi cần xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btn_TaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkThem == true)
            {
                bdsBoDe.EndEdit();
                bdsBoDe.ResetCurrentItem();
                bdsBoDe.RemoveCurrent();
                bdsBoDe.AddNew();
                String maMH = te_MAMH.Text;
                te_MAMH_Backup.Text = maMH;
                ccb_tenMonHoc.Enabled = false;
                checkThem = true;
                BODEGridControl.Enabled = false;

                setEnableEditCauHoi(true);
                tb_NOIDUNG.Text = tb_A.Text = tb_B.Text = tb_C.Text = tb_D.Text = "";
                te_MAGV.Text = Program.username;
                String queryMaCauHoi = "select MAX(CAUHOI) from BODE";
                Program.myReader = Program.ExecSqlDataReader(queryMaCauHoi);
                if (Program.myReader == null)
                {
                    Program.myReader.Close();
                    Program.conn.Close();
                    return;
                }
                else
                {
                    while (Program.myReader.Read())
                    {
                        se_MaCauHoi.Value = Program.myReader.GetInt32(0) + 1;
                        break;
                    }
                    Program.myReader.Close();
                    Program.conn.Close();
                }
            }
            else if (checkSua == true)
            {
                DataRowView selectedRow = (DataRowView)gridView1.GetFocusedRow();
                if (selectedRow != null)
                {

                    String queryDe = "select * from BODE where CAUHOI = " + selectedRow.Row["CAUHOI"];
                    Program.myReader = Program.ExecSqlDataReader(queryDe);
                    if (Program.myReader == null)
                    {
                        Program.myReader.Close();
                        Program.conn.Close();
                        return;
                    }
                    else
                    {
                        String maMH = "";
                        while (Program.myReader.Read())
                        {
                            maMH = Program.myReader["MAMH"].ToString();
                            se_MaCauHoi.Value = (int)selectedRow.Row["CAUHOI"];

                            te_MAMH_Backup.Text = String.IsNullOrEmpty(Program.myReader["MAMH"].ToString()) ? "" : Program.myReader["MAMH"].ToString();
                            te_MAMH.Text = String.IsNullOrEmpty(Program.myReader["MAMH"].ToString()) ? "" : Program.myReader["MAMH"].ToString();

                            List<string> lsTrinhDo = cbb_TrinhDo.Items.Cast<string>().ToList();
                            cbb_TrinhDo.SelectedIndex = lsTrinhDo.IndexOf(Program.myReader["TRINHDO"].ToString());

                            tb_NOIDUNG.Text = Program.myReader["NOIDUNG"].ToString();

                            tb_A.Text = Program.myReader["A"].ToString();
                            tb_B.Text = Program.myReader["B"].ToString();
                            tb_C.Text = Program.myReader["C"].ToString();
                            tb_D.Text = Program.myReader["D"].ToString();

                            List<string> lsDapAn = ccb_DapAn.Items.Cast<string>().ToList();
                            ccb_DapAn.SelectedIndex = lsDapAn.IndexOf(Program.myReader["DAP_AN"].ToString());


                        }
                        Program.myReader.Close();
                        Program.conn.Close();
                        for (int i = 0; i < listMonHoc.Count; i++)
                        {
                            if (listMonHoc.ElementAt(i).Key == maMH)
                            {
                                lsMonHocMode = true;
                                setCBB(i);
                                break;
                            }
                        }
                    }


                }
            }
            else
            {
                this.Controls.Clear();
                this.InitializeComponent();
                FrmBoDe_Load(sender, e);
                /*this.Refresh();*/
            }
        }
        private void setCBB(int index)
        {

            var lsMonHoc = new BindingList<KeyValuePair<string, string>>();
            string queryMonHoc = "select MAMH,TENMH from MONHOC";
            Program.myReader = Program.ExecSqlDataReader(queryMonHoc);
            if (Program.myReader == null)
            {
                Program.myReader.Close();
                Program.conn.Close();
                return;
            }
            else
            {
                while (Program.myReader.Read())
                {
                    lsMonHoc.Add(new KeyValuePair<string, string>(Program.myReader.GetString(0), Program.myReader.GetString(1)));
                }
                cbbTenMonHoc1.DataSource = lsMonHoc;
                cbbTenMonHoc1.DisplayMember = "Value";
                cbbTenMonHoc1.ValueMember = "Key";
                cbbTenMonHoc1.SelectedIndex = index;
                Program.myReader.Close();
                Program.conn.Close();
            }

        }
    }
}
