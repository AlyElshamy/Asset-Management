using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class AssetEditedReportModel : PageModel
    {
        private readonly AssetContext _context;
        public AssetEditedReportModel(AssetContext context)
        {
            _context = context;
        }
       
      
        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptAssetEdited Report { get; set; }
        static List<AssetReportsModel> ShowAllList = new List<AssetReportsModel>();

        public void OnGet()
        {

            ShowAllList = _context.AssetLogs.Where(l => l.ActionLogId == 19).Select(i => new AssetReportsModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetLife = i.Asset.AssetLife,
                AssetPurchaseDate = i.Asset.AssetPurchaseDate,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetStatusTL = i.Asset.AssetStatus.AssetStatusTitle,
                AssetTagId = i.Asset.AssetTagId,
                CategoryTL = i.Asset.Item.Category.CategoryTIAR,
                ItemTL = i.Asset.Item.ItemTitle,
                Photo = i.Asset.Photo,
                StoreTL = i.Asset.Store.StoreTitle,
                LocationTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationTitle,
                DepartmentTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentTitle,
                LocationId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationId,
                DepartmentId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentId,
                CategoryId = i.Asset.Item.CategoryId,
                LogActionDate = i.ActionDate



            }).ToList();
            Report = new rptAssetEdited();

        }
        public void OnPost()
        {

            List<AssetReportsModel> ds = _context.AssetLogs.Where(l => l.ActionLogId == 19).Select(i => new AssetReportsModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetLife = i.Asset.AssetLife,
                AssetPurchaseDate = i.Asset.AssetPurchaseDate,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetStatusTL = i.Asset.AssetStatus.AssetStatusTitle,
                AssetTagId = i.Asset.AssetTagId,
                CategoryTL = i.Asset.Item.Category.CategoryTIAR,  
                ItemTL = i.Asset.Item.ItemTitle,
                Photo = i.Asset.Photo,
                StoreTL = i.Asset.Store.StoreTitle,
                LocationTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationTitle,
                DepartmentTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentTitle,
                LocationId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationId,
                DepartmentId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentId,
                CategoryId = i.Asset.Item.CategoryId,
                LogActionDate = i.ActionDate



            }).ToList();
            if (filterModel.ShowAll != false)
            {
                ds = ShowAllList.ToList();
            }
            if (filterModel.FromDate != null&& filterModel.ToDate != null)
            {
                ds = ds.Where(i => (i.LogActionDate.Value.Date) > filterModel.FromDate.Value.Date&& i.LogActionDate.Value.Date< filterModel.ToDate.Value.Date).ToList();
            }
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId.Contains(filterModel.AssetTagId)).ToList();
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

            if (filterModel.AssetTagId == null && filterModel.LocationId == null && filterModel.DepartmentId == null && filterModel.CategoryId == null&& filterModel.OnDay == null&& filterModel.ShowAll == false)
            {
                ds = new List<AssetReportsModel>();
            }

            Report = new rptAssetEdited();
            Report.DataSource = ds;

        }
    }
}

