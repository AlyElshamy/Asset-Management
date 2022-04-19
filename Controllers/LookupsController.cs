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


    }
}