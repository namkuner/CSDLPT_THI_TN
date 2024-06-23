using DevExpress.XtraReports.UI;
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
    public partial class FrmBangDiemReport : Form
    {
        public FrmBangDiemReport()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void FrmBangDiemReport_Load(object sender, EventArgs e)
        {
            this.dS1.EnforceConstraints= false;
            // TODO: This line of code loads data into the 'dS1.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.dS1.MONHOC);
            // TODO: This line of code loads data into the 'dS1.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.dS1.LOP);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void preview_Click(object sender, EventArgs e)
        {
            BangDiemReport bangDiemReport = new BangDiemReport(cmbML.SelectedValue.ToString(), cmbMH.SelectedValue.ToString(), int.Parse(cmbLan.SelectedItem.ToString().Trim()));
            bangDiemReport.titleBangDiem.Text = "Bảng điểm lớp " + cmbML.Text.ToString() + " cho môn học " + cmbMH.Text.ToString() + " lần thi thứ " + cmbLan.Text.ToString();

            ReportPrintTool print = new ReportPrintTool(bangDiemReport);
            print.ShowPreviewDialog();
        }
    }
}
