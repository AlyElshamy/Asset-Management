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
        private readonly AssetContext _context;
        public Tenant TenantObj { get; set; }
        public rptCheckOutForm(AssetContext context,Tenant tenant)
        {
            InitializeComponent();
            // _context = context;
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
            //var TenantObj = _context.Tenants.Find(Tenant);

            txt_Address.Text = TenantObj.Address;
            Text_CN.Text = TenantObj.CompanyName;
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
