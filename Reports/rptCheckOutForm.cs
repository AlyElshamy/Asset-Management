using AssetProject.Data;
using AssetProject.Models;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AssetProject.Reports
{
    public partial class rptCheckOutForm : DevExpress.XtraReports.UI.XtraReport
    {
      
        public Tenant TenantObj { get; set; }
        public rptCheckOutForm(Tenant tenant)
        {
            InitializeComponent();
            TenantObj = tenant;
            //LoadTalent();
        }


        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void panel_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
     
        }
        public void LoadTalent()
        {
            txt_Address.Text = TenantObj.Address;
            Text_CN.Text = TenantObj.CompanyName;
            CompanyNo.Text = TenantObj.TenantId.ToString();

        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void rptCheckOutForm_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            LoadTalent();
        }
    }
}
