using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class AddAssetRPTModel : PageModel
    {

        public AddAssetRPTModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptAddAsset Report { get; set; }
        public AssetContext _context { get; }
        public void OnGet()
        {
            Report = new rptAddAsset();
        }
        public void OnPost()
        {
            List<AssetReportsModel> ds = _context.Assets.Select(a => new AssetReportsModel
            {
             AssetTagId=a.AssetTagId,
             AssetSerialNo=a.AssetSerialNo,
             AssetPurchaseDate=a.AssetPurchaseDate,
             AssetStatusTL=a.AssetStatus.AssetStatusTitle,
             ItemTL=a.Item.ItemTitle,
             VendorTL=a.Vendor.VendorTitle,
             StoreTL=a.Store.StoreTitle
            }).ToList();

            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.AssetPurchaseDate <= filterModel.ToDate && i.AssetPurchaseDate >= filterModel.FromDate).ToList();
            }
            if ( filterModel.FromDate == null && filterModel.ToDate == null )
            {
                ds = null;
            }

            Report = new rptAddAsset();
            Report.DataSource = ds;
        }
    }
}
