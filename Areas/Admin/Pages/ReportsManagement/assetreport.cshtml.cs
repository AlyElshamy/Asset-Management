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
    public class assetreportModel : PageModel
    {
        public assetreportModel(AssetContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int AssetId { get; set; }
        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptAssetReports Report { get; set; }
        public AssetContext _context { get; }

        public void OnGet()
        {
           

            Report = new rptAssetReports();

        }
        public void OnPost()
        {

            List<AssetReportsModel> ds = _context.Assets.Select(i => new AssetReportsModel
            {
                AssetCost = i.AssetCost,
                AssetDescription = i.AssetDescription,
                AssetLife = i.AssetLife,
                AssetPurchaseDate = i.AssetPurchaseDate,
                AssetSerialNo = i.AssetSerialNo,
                AssetStatusTL = i.AssetStatus.AssetStatusTitle,
                AssetTagId = i.AssetTagId,
                CategoryTL = i.Item.Category.CategoryTIAR,
                DateAcquired = i.DateAcquired,
                DepreciableCost = i.DepreciableCost,
                DepreciationMethodTL = i.DepreciationMethod.DepreciationMethodTitle,
                ItemTL = i.Item.ItemTitle,
                Photo = i.Photo,
                StoreTL = i.Store.StoreTitle,
                VendorTL = i.Vendor.VendorTitle,
                SalvageValue = i.SalvageValue,
                LocationTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()==null?null: _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationTitle,
                DepartmentTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentTitle,
                LocationId= _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationId,
                DepartmentId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()== null? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentId,
                CategoryId=i.Item.CategoryId
                
            }).ToList();
            

            if (filterModel.AssetTagId!=null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.LocationId!=null)
            {
                ds = ds.Where(i => i.LocationId == filterModel.LocationId).ToList();
            }
            if (filterModel.DepartmentId!=null)
            {
                ds = ds.Where(i => i.DepartmentId == filterModel.DepartmentId).ToList();
            }
            if (filterModel.CategoryId!=null)
            {
                ds = ds.Where(i => i.CategoryId == filterModel.CategoryId).ToList();
            }

            if (filterModel.AssetTagId == null && filterModel.LocationId == null && filterModel.DepartmentId == null && filterModel.CategoryId == null)
            {
                ds =new List<AssetReportsModel>();
            }

            Report = new rptAssetReports();
            Report.DataSource = ds;

        }
    }
}
