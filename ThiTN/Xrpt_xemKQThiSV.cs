using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ThiTN
{
    public partial class Xrpt_xemKQThiSV : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_xemKQThiSV()
        {
            InitializeComponent();
        }
        public Xrpt_xemKQThiSV(String maSV, String maMH, int lan)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maSV;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = maMH;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lan;
            this.sqlDataSource1.Fill();
        }

    }
}
