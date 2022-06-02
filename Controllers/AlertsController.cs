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
            var AssetsCheckOut = _context.Assets.Include(i => i.AssetMovementDetails).ThenInclude(i => i.AssetMovement).Where(c => c.AssetStatus.AssetStatusId == 2 && c.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.DueDate<DateTime.Now.Date).Select(i => new AssetReportsModel
            {
                AssetID=i.AssetId,
                AssetCost = i.AssetCost,
                AssetSerialNo = i.AssetSerialNo,
                AssetTagId = i.AssetTagId,
                Photo = i.Photo,
                TransactionDate= i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.TransactionDate,
                DueDate= i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.DueDate,
                LocationTL = _context.Locations.Where(a => a.LocationId == i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.LocationId).FirstOrDefault().LocationTitle,
                DepartmentTL = _context.Departments.Where(a => a.DepartmentId == i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.DepartmentId).FirstOrDefault().DepartmentTitle,
                EmployeeFullName = i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.EmpolyeeID==null?null: _context.Employees.Where(a => a.ID == i.AssetMovementDetails.OrderByDescending(e => e.AssetMovementDetailsId).FirstOrDefault().AssetMovement.EmpolyeeID).FirstOrDefault().FullName,

            }) ;

            return Json(await DataSourceLoader.LoadAsync(AssetsCheckOut, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetInsurancesExpiring(DataSourceLoadOptions loadOptions)
        {
            var insurances = _context.Insurances.Where(c => c.EndDate.Date<DateTime.Now.Date).Select(i => new
            {
                i.InsuranceId,
                i.Title,
                i.ContactPerson,
                i.InsuranceCompany,
                i.StartDate,
                i.EndDate,
                i.PolicyNo
               
            });
            return Json(await DataSourceLoader.LoadAsync(insurances, loadOptions));
        }
        public async Task<IActionResult> GetLeasesExpiring(DataSourceLoadOptions loadOptions)
        {
            var leasing = _context.Assets.Include(i => i.AssetLeasingDetails).ThenInclude(i => i.AssetLeasing).ThenInclude(e => e.Customer).Where(c => c.AssetStatusId == 6 && c.AssetLeasingDetails.OrderByDescending(e => e.AssetLeasingDetailsId).FirstOrDefault().AssetLeasing.EndDate.Date < DateTime.Now.Date).Select(i => new LeasingModel
            {
                AssetId = i.AssetId,
                AssetCost = i.AssetCost,
                AssetSerialNo = i.AssetSerialNo,
                AssetTagId = i.AssetTagId,
                photo = i.Photo,
                
                LeasingEndDate = i.AssetLeasingDetails.OrderByDescending(e => e.AssetLeasingDetailsId).FirstOrDefault().AssetLeasing.EndDate,
                LeasingStartDate= i.AssetLeasingDetails.OrderByDescending(e => e.AssetLeasingDetailsId).FirstOrDefault().AssetLeasing.StartDate,
                LeasingCost= i.AssetLeasingDetails.OrderByDescending(e => e.AssetLeasingDetailsId).FirstOrDefault().AssetLeasing.LeasedCost,
                CustomerTL = _context.Customers.Where(a => a.CustomerId == i.AssetLeasingDetails.OrderByDescending(e => e.AssetLeasingDetailsId).FirstOrDefault().AssetLeasing.CustomerId).FirstOrDefault().FullName,


            });
            return Json(await DataSourceLoader.LoadAsync(leasing, loadOptions));
        }
        public async Task<IActionResult> GetWarrantiesExpiring(DataSourceLoadOptions loadOptions)
        {
            var warranty = _context.AssetWarranties.Where(c => c.ExpirationDate.Date < DateTime.Now.Date).Include(i => i.Asset).Select(i => new
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
            var Maintainances = _context.AssetMaintainances.Include(e=>e.Asset).Where(c => c.ScheduleDate.Date==DateTime.Now.Date && c.MaintainanceStatus.MaintainanceStatusId==1&&c.Asset.AssetStatusId==9).Include(i => i.Asset).Include(i=>i.Technician).Select(i => new
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
            var Maintainances = _context.AssetMaintainances.Include(e => e.Asset).Where(c => c.ScheduleDate.Date<DateTime.Now.Date && c.MaintainanceStatus.MaintainanceStatusId == 1 && c.Asset.AssetStatusId == 9).Include(i => i.Asset).Include(i => i.Technician).Select(i => new
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
