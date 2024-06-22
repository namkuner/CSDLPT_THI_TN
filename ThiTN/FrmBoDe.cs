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
using ThiTN.Model;


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

            if (Program.mGroup.Equals("Giangvien") || Program.mGroup.Equals("CoSo"))
            {
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = true;
                btn_Ghi.Enabled = btn_Huy.Enabled = btn_undo.Enabled = btn_redo.Enabled = false;
                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.BODETableAdapter.FillByGV(this.TN_CSDLPTDataSet.BODE, Program.username);
                getMonHoc();
            }
            else
            {
                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.BODETableAdapter.Fill(this.TN_CSDLPTDataSet.BODE);
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled
                   = btn_Ghi.Enabled = btn_undo.Enabled = false;
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
                if (Program.mGroup.Equals("Giangvien") || Program.mGroup.Equals("CoSo"))
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
                var state = new QuestionState(
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
                PushToUndoStack(new ActionModel(ActionModel.ActionType.Add, state));
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
            btn_Ghi.Enabled = btn_Huy.Enabled = btn_undo.Enabled = false;
            if (checkThem == true || checkSua == true || checkXoa == true)
            {
                if (checkSua== true)
                {
                    undoStack.Pop();
                }
                // khi nhấn nút Hủy thì réset lại các giá trị
                setEnableEditCauHoi(false);
                setStatusButtonOption(true);
                bdsBoDe.CancelEdit();
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                bdsBoDe.ResetCurrentItem();
                BODEGridControl.Enabled = true;
                ccb_tenMonHoc.Enabled = true;
                UpdateUndoRedoButtonStates();

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

                    var oldState = new QuestionState(
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
                    var newState = oldState.Clone();
                    PushToUndoStack(new ActionModel(ActionModel.ActionType.Edit, oldState));
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
                    // Kiểm tra xem câu hỏi đã được thi hay chưa hoặc đã được đăng ký thi
                    String queryCheck = "select Top 1 1 from CT_BAITHI as ctbt join BANGDIEM as bd on ctbt.MABD = bd.MABD where CAUHOI = " + selectedRow.Row["CAUHOI"];
                    Program.myReader = Program.ExecSqlDataReader(queryCheck);
                    if (Program.myReader == null)
                    {
                        Program.myReader.Close();
                        Program.conn.Close();
                        return;
                    }
                    else
                    {
                        if (Program.myReader.HasRows)
                        {
                            MessageBox.Show("Câu hỏi đã được thi hoặc đã được đăng ký thi nên không thể xóa", "Thông báo", MessageBoxButtons.OK);
                            Program.myReader.Close();
                            Program.conn.Close();
                            return;
                        }
                        Program.myReader.Close();
                        Program.conn.Close();
                    }


                    // Nếu chưa thì xóa câu hỏi
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            var state = new QuestionState(
                                (int)selectedRow.Row["CAUHOI"],
                                selectedRow.Row["MAMH"].ToString(),
                                selectedRow.Row["TRINHDO"].ToString(),
                                selectedRow.Row["NOIDUNG"].ToString(),
                                selectedRow.Row["A"].ToString(),
                                selectedRow.Row["B"].ToString(),
                                selectedRow.Row["C"].ToString(),
                                selectedRow.Row["D"].ToString(),
                                selectedRow.Row["DAP_AN"].ToString(),
                                Program.username
                            );

                            bdsBoDe.RemoveCurrent();
                            this.BODETableAdapter.Update(this.TN_CSDLPTDataSet.BODE);
                            PushToUndoStack(new ActionModel(ActionModel.ActionType.Delete, state));
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
                undoStack.Clear();
                redoStack.Clear();
                UpdateUndoRedoButtonStates();

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
        // Phần undo redo thêm/sửa/xóa câu hỏi
        private Stack<ActionModel> undoStack = new Stack<ActionModel>();
        private Stack<ActionModel> redoStack = new Stack<ActionModel>();
        private void PushToUndoStack(ActionModel action)
        {
            undoStack.Push(action);
            redoStack.Clear(); // Clear redo stack whenever a new action is performed
            UpdateUndoRedoButtonStates();
        }

        private void UpdateUndoRedoButtonStates()
        {
            btn_undo.Enabled = undoStack.Count > 0;
            btn_redo.Enabled = redoStack.Count > 0;
        }
        private void AddQuestion(QuestionState state)
        {
            bdsBoDe.AddNew();
            se_MaCauHoi.Value = state.MaCauHoi;
            te_MAMH.Text = state.MaMH;
            cbb_TrinhDo.Text = state.TrinhDo;
            tb_NOIDUNG.Text = state.NoiDung;
            tb_A.Text = state.A;
            tb_B.Text = state.B;
            tb_C.Text = state.C;
            tb_D.Text = state.D;
            ccb_DapAn.Text = state.DapAn;
            te_MAGV.Text = state.MaGV;

            this.BODETableAdapter.Insert(
                state.MaCauHoi,
                state.MaMH,
                state.TrinhDo,
                state.NoiDung,
                state.A,
                state.B,
                state.C,
                state.D,
                state.DapAn,
                state.MaGV
            );
            UpdateUndoRedoButtonStates();
        }

        private void DeleteQuestion(int maCauHoi)
        {
            bdsBoDe.Position = bdsBoDe.Find("CAUHOI", maCauHoi);
            bdsBoDe.RemoveCurrent();
            this.BODETableAdapter.Update(this.TN_CSDLPTDataSet.BODE);
            UpdateUndoRedoButtonStates();
        }

        private void EditQuestion(QuestionState state)
        {
            bdsBoDe.Position = bdsBoDe.Find("CAUHOI", state.MaCauHoi);
            bdsBoDe.RemoveCurrent();
            this.BODETableAdapter.Update(this.TN_CSDLPTDataSet.BODE);

            bdsBoDe.AddNew();
            se_MaCauHoi.Value = state.MaCauHoi;
            te_MAMH.Text = state.MaMH;
            cbb_TrinhDo.Text = state.TrinhDo;
            tb_NOIDUNG.Text = state.NoiDung;
            tb_A.Text = state.A;
            tb_B.Text = state.B;
            tb_C.Text = state.C;
            tb_D.Text = state.D;
            ccb_DapAn.Text = state.DapAn;
            te_MAGV.Text = state.MaGV;

            this.BODETableAdapter.Insert(
                state.MaCauHoi,
                state.MaMH,
                state.TrinhDo,
                state.NoiDung,
                state.A,
                state.B,
                state.C,
                state.D,
                state.DapAn,
                state.MaGV
            );
            UpdateUndoRedoButtonStates();
        }

        private void Undo()
        {
            if (undoStack.Count > 0)
            {
                var action = undoStack.Pop();
                switch (action.Type)
                {
                    case ActionModel.ActionType.Add:
                        DeleteQuestion(action.State.MaCauHoi);
                        redoStack.Push(new ActionModel(ActionModel.ActionType.Delete, action.State));
                        break;
                    case ActionModel.ActionType.Edit:
                        var currentState = new QuestionState(
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
                        EditQuestion(action.State);
                        redoStack.Push(new ActionModel(ActionModel.ActionType.Edit, currentState));
                        break;
                    case ActionModel.ActionType.Delete:
                        AddQuestion(action.State);
                        redoStack.Push(new ActionModel(ActionModel.ActionType.Add, action.State));
                        break;
                }
                UpdateUndoRedoButtonStates();
            }
        }

        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                var action = redoStack.Pop();
                switch (action.Type)
                {
                    case ActionModel.ActionType.Add:
                        DeleteQuestion(action.State.MaCauHoi);
                        undoStack.Push(new ActionModel(ActionModel.ActionType.Delete, action.State));
                        break;
                    case ActionModel.ActionType.Edit:
                        var currentState = new QuestionState(
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
                        EditQuestion(action.State);
                        undoStack.Push(new ActionModel(ActionModel.ActionType.Edit, currentState));
                        break;
                    case ActionModel.ActionType.Delete:
                        AddQuestion(action.State);
                        undoStack.Push(new ActionModel(ActionModel.ActionType.Add, action.State));
                        break;
                }
                UpdateUndoRedoButtonStates();
            }
        }

        private void btn_undo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Undo();
        }

        private void btn_redo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Redo();
        }

        private void btn_Thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
