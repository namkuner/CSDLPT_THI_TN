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
    public partial class frmKhoaLop : Form
    {
        public frmKhoaLop()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKHOA.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void frmKhoaLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS1.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.dS1.LOP);
            // TODO: This line of code loads data into the 'dS1.KHOA' table. You can move, or remove it, as needed.
            this.KHOATableAdapter.Fill(this.dS1.KHOA);

        }
    }
}
