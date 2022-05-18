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

            var AssetsCheckOut = _context.AssetMovementDetails.Where(c=>c.AssetMovement.DueDate<DateTime.Now&&c.Asset.AssetStatus.AssetStatusId==2).Include(i=>i.Asset).Include(i=>i.AssetMovement).Select(i => new
            {
              i.AssetMovementDetailsId,
              i.AssetMovementId,
              i.Remarks,
              i.Asset,
              i.AssetMovement
            });
            return Json(await DataSourceLoader.LoadAsync(AssetsCheckOut, loadOptions));
        }
    }
}
