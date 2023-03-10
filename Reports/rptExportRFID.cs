using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AssetProject.Reports
{
    public partial class rptExportRFID : DevExpress.XtraReports.UI.XtraReport
    {
        public string tagid { get; set; }
        public string serialno { get; set; }
        public rptExportRFID(string _tagid,string _serialno)
        {
            serialno = _serialno;
            tagid = _tagid;
            InitializeComponent();
        }

        private void rptExportRFID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            taglable.Text = tagid;
            seriallable.Text = serialno;
        }
    }
}
