using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
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

namespace AssetProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LookupsController : Controller
    {
        private AssetContext _context;

        public LookupsController(AssetContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CountriesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = _context.Countries;
                         
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }


        [HttpGet]
        public async Task<IActionResult> VendorsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Vendors
                         orderby i.VendorTitle
                         select new
                         {
                             Value = i.VendorId,
                             Text = i.VendorTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> ItemsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Items
                         orderby i.ItemTitle
                         select new
                         {
                             Value = i.ItemId,
                             Text = i.ItemTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> LocationsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Locations
                         orderby i.LocationTitle
                         select new
                         {
                             Value = i.LocationId,
                             Text = i.LocationTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> BrandsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Brands
                         orderby i.BrandTitle
                         select new
                         {
                             Value = i.BrandId,
                             Text = i.BrandTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CategoriesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Categories
                         orderby i.CategoryTIAR
                         select new
                         {
                             Value = i.CategoryId,
                             Text = i.CategoryTIAR
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> StoresLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Stores
                         orderby i.StoreTitle
                         select new
                         {
                             Value = i.StoreId,
                             Text = i.StoreTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> DepreciationMethodsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.DepreciationMethods
                         orderby i.DepreciationMethodTitle
                         select new
                         {
                             Value = i.DepreciationMethodId,
                             Text = i.DepreciationMethodTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        
        [HttpGet]
        public async Task<IActionResult> ContractsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Contracts
                         orderby i.ContractId
                         select new
                         {
                             Value = i.ContractId,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> InsurancesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Insurances
                         orderby i.InsuranceId
                         select new
                         {
                             Value = i.InsuranceId,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> ActionTypesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.ActionTypes
                         orderby i.ActionTypeId
                         select new
                         {
                             Value = i.ActionTypeId,
                             Text = i.ActionTypeTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> EmpolyeesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Employees
                         orderby i.ID
                         select new
                         {
                             Value = i.ID,
                             Text = i.FullName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Departments
                         orderby i.DepartmentId
                         select new
                         {
                             Value = i.DepartmentId,
                             Text = i.DepartmentTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> TechniciansLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Technicians
                         orderby i.TechnicianId
                         select new
                         {
                             Value = i.TechnicianId,
                             Text = i.FullName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CustomersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Customers
                         orderby i.CustomerId
                         select new
                         {
                             Value = i.CustomerId,
                             Text = i.FullName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> MaintainanceStatusesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.MaintainanceStatuses
                         orderby i.MaintainanceStatusId
                         select new
                         {
                             Value = i.MaintainanceStatusId,
                             Text = i.MaintainanceStatusTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }


        [HttpGet]
        public async Task<IActionResult> AssetMaintainanceFrequenciesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.AssetMaintainanceFrequencies
                         orderby i.AssetMaintainanceFrequencyId
                         select new
                         {
                             Value = i.AssetMaintainanceFrequencyId,
                             Text = i.AssetMaintainanceFrequencyTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> WeekDaysLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.WeekDays
                         orderby i.WeekDayId
                         select new
                         {
                             Value = i.WeekDayId,
                             Text = i.WeekDayTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> MonthsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Months
                         orderby i.MonthId
                         select new
                         {
                             Value = i.MonthId,
                             Text = i.MonthTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> AssetMovementDirectionsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.AssetMovementDirections
                         orderby i.AssetMovementDirectionId
                         select new
                         {
                             Value = i.AssetMovementDirectionId,
                             Text = i.AssetMovementDirectionTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> AssetStatusesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.AssetStatuses
                         orderby i.AssetStatusId
                         select new
                         {
                             Value = i.AssetStatusId,
                             Text = i.AssetStatusTitle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> AssetWarrantyLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.AssetWarranties
                         orderby i.WarrantyId
                         select new
                         {
                             Value = i.WarrantyId,
                             Text = i.Length
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        //[HttpGet]
        //public async Task<IActionResult> ActionLogsLookup(DataSourceLoadOptions loadOptions)
        //{
        //    var lookup = from i in _context.ActionLogs
        //                 orderby i.ActionLogTitle
        //                 select new
        //                 {
        //                     Value = i.ActionLogId,
        //                     Text = i.ActionLogTitle
        //                 };
        //    return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        //}
    }
}