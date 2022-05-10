using AssetProject.Data;
using DevExpress.XtraReports.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace AssetProject.Reports
{
    public partial class rptAssetReports : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAssetReports()
        {
            InitializeComponent();
        }

        private void showpic(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrPictureBox1.ImageUrl = "/" + GetCurrentColumnValue("Photo");
            //string value = GetCurrentColumnValue("Photo").ToString();
            //MemoryStream stream = new MemoryStream(Convert.FromBase64String(value));
            //(sender as XRPictureBox).Image = Image.FromStream(stream);
        }
    }
}
