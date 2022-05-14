using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.Reports
{
    public class AssetCheckInModel : PageModel
    {
        private readonly AssetContext _context;

        public AssetCheckInModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rtpAssetCheckIn Report { get; set; }

        public void OnGet()
        {
            List<AssetCheckOutList> ds = _context.AssetMovementDetails.Where(e => e.Asset.AssetStatusId == 1).Select(i => new AssetCheckOutList
            {
                TransactionDate = i.AssetMovement.TransactionDate,
                EmployeeFullN = i.AssetMovement.Employee.FullName,
                LocationTl = i.AssetMovement.Location.LocationTitle,
                DepartmentTl = i.AssetMovement.Department.DepartmentTitle,
                StoreTl = i.Asset.Store.StoreTitle,
                ActionTypeTl = i.AssetMovement.ActionType.ActionTypeTitle,
                AssetMovementDirectionTl = i.AssetMovement.AssetMovementDirection.AssetMovementDirectionTitle,
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetPurchaseDate = i.Asset.AssetPurchaseDate,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetStatusTl = i.Asset.AssetStatus.AssetStatusTitle,
                ItemTl = i.Asset.Item.ItemTitle,
                Remarks = i.Remarks,
                AssetTagId = i.Asset.AssetTagId

            }).ToList();
            Report = new rtpAssetCheckIn();
            Report.DataSource = ds;
        }
        public void OnPost()
        {
            List<AssetCheckOutList> ds = _context.AssetMovementDetails.Where(e => e.Asset.AssetStatusId == 1).Select(i => new AssetCheckOutList
            {
                TransactionDate = i.AssetMovement.TransactionDate,
                EmployeeFullN = i.AssetMovement.Employee.FullName,
                LocationTl = i.AssetMovement.Location.LocationTitle,
                DepartmentTl = i.AssetMovement.Department.DepartmentTitle,
                StoreTl = i.Asset.Store.StoreTitle,
                ActionTypeTl = i.AssetMovement.ActionType.ActionTypeTitle,
                AssetMovementDirectionTl = i.AssetMovement.AssetMovementDirection.AssetMovementDirectionTitle,
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetPurchaseDate = i.Asset.AssetPurchaseDate,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetStatusTl = i.Asset.AssetStatus.AssetStatusTitle,
                ItemTl = i.Asset.Item.ItemTitle,
                Remarks = i.Remarks,
                AssetTagId = i.Asset.AssetTagId,
                AssetMovementId = i.AssetMovement.AssetMovementId,
                EmployeeId = i.AssetMovement.Employee.ID,
                LocationId = i.AssetMovement.Location.LocationId

            }).ToList();
            if (filterModel.employeeId != null)
            {
                ds = ds.Where(e => e.EmployeeId == filterModel.employeeId).ToList();
            }
            if (filterModel.LocationId != null)
            {
                ds = ds.Where(e => e.LocationId == filterModel.LocationId).ToList();
            }
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.TransactionDate <= filterModel.ToDate && i.TransactionDate >= filterModel.FromDate).ToList();
            }
            if (filterModel.OnDay != null)
            {
                ds = ds.Where(i => i.TransactionDate == filterModel.OnDay).ToList();
            }
            if (filterModel.OnDay == null && filterModel.FromDate == null && filterModel.ToDate == null && filterModel.LocationId == null && filterModel.AssetTagId == null && filterModel.employeeId == null)
            {
                ds = null;
            }
            Report = new rtpAssetCheckIn();
            Report.DataSource = ds;
        }
    }
}
