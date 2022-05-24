using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;

namespace AssetProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AlertsController : Controller
    {

        private AssetContext _context;

        public AlertsController(AssetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpiringContracts(DataSourceLoadOptions loadOptions)
        {
            var contracts = _context.Contracts.Where(c => c.EndDate.Date < DateTime.Now.Date).Select(i => new
            {
                i.ContractId,
                i.Title,
                i.Description,
                i.ContractNo,
                i.Cost,
                i.StartDate,
                i.EndDate,
                i.VendorId
            });
            return Json(await DataSourceLoader.LoadAsync(contracts, loadOptions));

        }
        [HttpGet]
        public async Task<IActionResult> GetExpiringCheckOut(DataSourceLoadOptions loadOptions)
        {

            //     var AssetsCheckOut = _context.AssetMovementDetails.GroupBy(p => p.AssetId)
            //     .Select(p => p.FirstOrDefault(w => w.AssetMovementDetailsId == p.Max(m => m.AssetMovementDetailsId)))
            //.OrderBy(p => p.AssetId);

            //var AssetsCheckOut = _context.AssetMovementDetails.GroupBy(x => x.AssetId)
            //          .Select(x => x.OrderByDescending(y => y.AssetMovementDetailsId).First());
            var AssetsCheckOut = _context.Assets.Include(i => i.AssetMovementDetails).ThenInclude(i => i.AssetMovement).Where(c => c.AssetStatus.AssetStatusId == 2 && c.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.DueDate < DateTime.Now).Select(i => new
            {
                i.AssetId,
                i.AssetCost,
                i.AssetSerialNo,
                i.AssetTagId,
                i.Photo,
                i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.TransactionDate,
                i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.DueDate,
                i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.DepartmentId,
                i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.LocationId,
                i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.EmpolyeeID
            });
            return Json(await DataSourceLoader.LoadAsync(AssetsCheckOut, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetInsurancesExpiring(DataSourceLoadOptions loadOptions)
        {
            var insurances = _context.AssetsInsurances.Where(c => c.Insurance.EndDate<DateTime.Now).Include(i => i.Asset).Include(i=>i.Insurance).Select(i => new
            {
                i.InsuranceId,
                i.AssetsInsuranceId,
                i.Asset,
                i.Insurance
            });
            return Json(await DataSourceLoader.LoadAsync(insurances, loadOptions));
        }
        public async Task<IActionResult> GetLeasesExpiring(DataSourceLoadOptions loadOptions)
        {
            var leasing = _context.AssetLeasingDetails.Where(c => c.AssetLeasing.EndDate < DateTime.Now && c.Asset.AssetStatus.AssetStatusId ==6 ).Include(i => i.Asset).Include(i => i.AssetLeasing).Select(i => new
            {
                i.AssetLeasingDetailsId,
                i.AssetLeasingId,
                i.Asset,
                i.AssetLeasing,

            });
            return Json(await DataSourceLoader.LoadAsync(leasing, loadOptions));
        }
        public async Task<IActionResult> GetWarrantiesExpiring(DataSourceLoadOptions loadOptions)
        {
            var warranty = _context.AssetWarranties.Where(c => c.ExpirationDate < DateTime.Now).Include(i => i.Asset).Select(i => new
            {
                i.WarrantyId,
                i.AssetId,
                i.ExpirationDate,
                i.Length,
                i.Notes,
                i.Asset,
            });
            return Json(await DataSourceLoader.LoadAsync(warranty, loadOptions));
        }
        public async Task<IActionResult> GetMaintenanceDue(DataSourceLoadOptions loadOptions)
        {
            var Maintainances = _context.AssetMaintainances.Where(c => c.ScheduleDate==DateTime.Now && c.MaintainanceStatus.MaintainanceStatusId==1).Include(i => i.Asset).Include(i=>i.Technician).Select(i => new
            {
                i.AssetMaintainanceId,
                i.AssetMaintainanceTitle,
                i.ScheduleDate,
                i.AssetMaintainanceDetails,
                i.Technician,
                i.AssetId,
                i.Asset,
            });
            return Json(await DataSourceLoader.LoadAsync(Maintainances, loadOptions));
        }
        public async Task<IActionResult> GetMaintenanceoverDue(DataSourceLoadOptions loadOptions)
        {
            var Maintainances = _context.AssetMaintainances.Where(c => c.ScheduleDate<DateTime.Now && c.MaintainanceStatus.MaintainanceStatusId == 1).Include(i => i.Asset).Include(i => i.Technician).Select(i => new
            {
                i.AssetMaintainanceId,
                i.AssetMaintainanceTitle,
                i.ScheduleDate,
                i.AssetMaintainanceDetails,
                i.Technician,
                i.AssetId,
                i.Asset,
            });
            return Json(await DataSourceLoader.LoadAsync(Maintainances, loadOptions));
        }
    }
}
