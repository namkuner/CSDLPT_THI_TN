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
                string ngayThiString = $"'{txtNGAYTHI.DateTime.ToString("yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)}'";
                String cauTruyVan = "EXEC sp_ThemGiaovienDangky '" + txtMAGV.Text + "', '"  + txtMALOP.Text + "', '" + cmbMAMH.SelectedValue.ToString() + "', '" + cmbTRINHDO.Text + "', " +txtLAN.Text +", "+ txtSOCAUTHI.Text + ", " + ngayThiString + ", " + txtTHOIGIAN.Text;
                System.Console.Out.WriteLine(cauTruyVan);


                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                
                panelControl2.Enabled = false;
                btnThem.Enabled = true;
                btnGhi.Enabled = false;
                this.gIAOVIEN_DANGKYTableAdapter.ClearBeforeFill = true;
                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIEN_DANGKYTableAdapter.FillByMAGV(this.dS1.GIAOVIEN_DANGKY, Program.username);
                MessageBox.Show("Đăng ký thi thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi đăng ký thi!/n" + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}
