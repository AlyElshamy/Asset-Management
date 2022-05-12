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

namespace AssetProject.Controllers
{
    [Route("api/[controller]/[action]")]
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
            var contracts = _context.Contracts.Where(c=>c.EndDate.Date<DateTime.Now.Date).Select(i => new
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
    }
}
