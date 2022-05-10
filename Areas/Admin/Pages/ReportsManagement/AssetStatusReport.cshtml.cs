using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class AssetStatusReportModel : PageModel
    {
        public AssetStatusReportModel(AssetContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptAssetStatus Report { get; set; }
        public AssetContext _context { get; }
        public void OnGet()
        {
            List<AssetReportsModel> ds = _context.Assets.Select(i => new AssetReportsModel
            {
                AssetCost = i.AssetCost,
                AssetSerialNo = i.AssetSerialNo,
                AssetStatusTL = i.AssetStatus.AssetStatusTitle,
                AssetTagId = i.AssetTagId,
                ItemTL = i.Item.ItemTitle,
                Photo = i.Photo,
                StoreTL = i.Store.StoreTitle,
                VendorTL = i.Vendor.VendorTitle,
                DepreciationMethodTL = i.DepreciationMethod.DepreciationMethodTitle
               

            }).ToList();
            Report = new rptAssetStatus();
            Report.DataSource = ds;

        }
        public void OnPost()
        {
            List<AssetReportsModel> ds = _context.Assets.Select(i => new AssetReportsModel
            {
                AssetCost = i.AssetCost,
                AssetSerialNo = i.AssetSerialNo,
                AssetStatusTL = i.AssetStatus.AssetStatusTitle,
                AssetTagId = i.AssetTagId,
                ItemTL = i.Item.ItemTitle,
                Photo = i.Photo,
                StoreTL = i.Store.StoreTitle,
                VendorTL = i.Vendor.VendorTitle,
                DepreciationMethodTL = i.DepreciationMethod.DepreciationMethodTitle,
                StatusId=i.AssetStatusId,



            }).ToList();
            if (filterModel.StatusId != 0)
            {
                ds = ds.Where(i => i.StatusId == filterModel.StatusId).ToList();
            }


            Report = new rptAssetStatus();
            Report.DataSource = ds;

        }
    }
    }
