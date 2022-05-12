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
            // StoreId=a.StoreId,
            // ItemId=a.ItemId,
            // VendorId=a.VendorId,
            //LocationTL = _context.AssetMovementDetails.Where(a => a.AssetId == a.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationTitle,
            //    DepartmentTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentTitle,
            //    LocationId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationId,
            //    DepartmentId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentId,
            //
            }).ToList();
            

            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.AssetPurchaseDate <= filterModel.ToDate && i.AssetPurchaseDate >= filterModel.FromDate).ToList();
            }
            if ( filterModel.FromDate == null && filterModel.ToDate == null )
            {
                ds = null;
            }
            if (filterModel.LocationId != null)
            {
                ds = ds.Where(i => i.LocationId == filterModel.LocationId).ToList();
            }
            if (filterModel.DepartmentId != null)
            {
                ds = ds.Where(i => i.DepartmentId == filterModel.DepartmentId).ToList();
            }
            if (filterModel.CategoryId != null)
            {
                ds = ds.Where(i => i.CategoryId == filterModel.CategoryId).ToList();
            }
            if (filterModel.VendorId != null)
            {
                ds = ds.Where(i => i.VendorId == filterModel.VendorId).ToList();
            }
            if (filterModel.StoreId != null)
            {
                ds = ds.Where(i => i.StoreId == filterModel.StoreId).ToList();
            }
            if (filterModel.ItemId != null)
            {
                ds = ds.Where(i => i.ItemId == filterModel.ItemId).ToList();
            }
            if (filterModel.AssetTagId == null && filterModel.LocationId == null && filterModel.DepartmentId == null && filterModel.CategoryId == null)
            {
                ds = new List<AssetReportsModel>();
            }

            Report = new rptAddAsset();
            Report.DataSource = ds;
        }
    }
}
