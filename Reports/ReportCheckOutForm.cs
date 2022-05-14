﻿using AssetProject.Models;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AssetProject.Reports
{
    public partial class ReportCheckOutForm : DevExpress.XtraReports.UI.XtraReport
    {
        public Tenant TenantObj { get; set; }
        public ReportCheckOutForm(Tenant tenant)
        {
            InitializeComponent();
            TenantObj = tenant;
        }
        public void LoadTalent()
        {
            if (TenantObj != null)
            {
                txt_Address.Text = TenantObj.Address;
                Text_CN.Text = TenantObj.CompanyName;
                CompanyNo.Text = TenantObj.TenantId.ToString();
            }
            
        }



        private void rptCheckInForm_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            LoadTalent();
        }
    }
}