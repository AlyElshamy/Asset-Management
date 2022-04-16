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

    }
}