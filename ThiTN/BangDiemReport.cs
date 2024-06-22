using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ThiTN
{
    public partial class BangDiemReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BangDiemReport(string MALOP, string MAMH, int lan)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = MALOP;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = MAMH;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lan;
            this.sqlDataSource1.Fill();


        }

    }
}
