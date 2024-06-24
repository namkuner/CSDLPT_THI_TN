using DevExpress.Data.Helpers;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTN
{
    public partial class FrmMonHoc : Form
    {
        int vitri = 0;
        bool dangthem = false;
        public FrmMonHoc()
        {
            InitializeComponent();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMH.Position;
            txtpanel.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcMH.Enabled = false;

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.mONHOCTableAdapter.Fill(this.dS1.MONHOC);
                this.mONHOCTableAdapter.Update(this.dS1.MONHOC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Refresh: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }   
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            this.dS1.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS1.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS1.MONHOC);
            this.mONHOCTableAdapter.Update(this.dS1.MONHOC);

            // TODO: This line of code loads data into the 'dS1.BANGDIEM' table. You can move, or remove it, as needed.
            this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.bANGDIEMTableAdapter.Fill(this.dS1.BANGDIEM);
            // TODO: This line of code loads data into the 'dS1.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS1.BODE);
            // TODO: This line of code loads data into the 'dS1.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS1.GIAOVIEN_DANGKY);
            
            cmbCoSoFrmMonHoc.DataSource = Program.bds_dspm;
            cmbCoSoFrmMonHoc.DisplayMember = "TENCN";
            cmbCoSoFrmMonHoc.ValueMember = "TENSERVER";
            cmbCoSoFrmMonHoc.SelectedIndex = Program.mChinhanh;
            System.Console.Out.WriteLine( Program.mChinhanh);
            if (Program.mGroup == "Truong")
            {
                cmbCoSoFrmMonHoc.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;
            }
            else if (Program.mGroup == "GiangVien")
            {
                cmbCoSoFrmMonHoc.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;
            }
            else if (Program.mGroup == "CoSo")
            {
                cmbCoSoFrmMonHoc.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;
            }
            else if (Program.mGroup == "SinhVien")
            {
                cmbCoSoFrmMonHoc.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = false;
            }
            else
            {
                cmbCoSoFrmMonHoc.Enabled = false;
            }


        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            vitri = bdsMH.Position;
            dangthem = true;
            txtpanel.Enabled = true;
            bdsMH.AddNew();
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled =  false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcMH.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMH.CancelEdit();
            if (dangthem == true) 
            {
                bdsMH.RemoveCurrent();
            }
            bdsMH.Position = vitri;
            gcMH.Enabled = true;
            txtpanel.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            dangthem = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String mamh = "";
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Môn học đã có giáo viên đăng ký, không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Môn học đã có bảng điểm, không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Môn học đã có bộ đề, không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    mamh = ((DataRowView)bdsMH[bdsMH.Position])["MAMH"].ToString(); // giữ lại để khi xóa bij lỗi thì ta sẽ quay về lại
                    bdsMH.RemoveCurrent();
                    this.mONHOCTableAdapter.Update(this.dS1.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa môn học. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.mONHOCTableAdapter.Fill(this.dS1.MONHOC);
                    bdsMH.Position = bdsMH.Find("MAMH", mamh);
                    return;
                }
            }
            if (bdsMH.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (txtMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu!", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return;
            }
            if (txtTENMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được thiếu!", "", MessageBoxButtons.OK);
                txtTENMH.Focus();
                return;
            }
            try
            {
                bdsMH.EndEdit();
                bdsMH.ResetCurrentItem();
                this.mONHOCTableAdapter.Update(this.dS1.MONHOC);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcMH.Enabled = true;
            txtpanel.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;

        }

        private void cmbCoSoFrmMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCoSoFrmMonHoc.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbCoSoFrmMonHoc.SelectedValue.ToString();
            System.Console.Out.WriteLine(Program.servername);
            if (cmbCoSoFrmMonHoc.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                return;
            }
            else
            {   
                this.dS1.EnforceConstraints = false;
                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS1.GIAOVIEN_DANGKY);
                this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.bODETableAdapter.Fill(this.dS1.BODE);
                this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                this.bANGDIEMTableAdapter.Fill(this.dS1.BANGDIEM);


                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.dS1.MONHOC);
                this.mONHOCTableAdapter.Update(this.dS1.MONHOC);


            }   

        }

        private void gcMH_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //close form
            this.Close();

        }
    }
}
