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
    public partial class FrmThi : Form
    {
        public FrmThi()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tN_CSDLPTDataSet);

        }

        private void FrmThi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Fill(this.tN_CSDLPTDataSet.BODE);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.CT_BAITHI' table. You can move, or remove it, as needed.
            this.cT_BAITHITableAdapter.Fill(this.tN_CSDLPTDataSet.CT_BAITHI);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.tN_CSDLPTDataSet.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.tN_CSDLPTDataSet.MONHOC);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.tN_CSDLPTDataSet.SINHVIEN);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.tN_CSDLPTDataSet.LOP);

        }

        private void tENLabel_Click(object sender, EventArgs e)
        {

        }

        private void tENTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
