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
    public class PrintAssetCheckOutModel : PageModel
    {
        private readonly AssetContext _context;

        public PrintAssetCheckOutModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int AssetId { get; set; }
        public rtpAssetCheckOut Report { get; set; }

        public void OnGet(int AssetId)
        {
            List<AssetCheckOutList> ds = _context.AssetMovements.Select(i => new AssetCheckOutList
            {
                TransactionDate= i.TransactionDate,
                EmployeeFullN= i.Employee.FullName,
                LocationTl= i.Location.LocationTitle,
                DepartmentTl=i.Department.DepartmentTitle,
                StoreTl=i.Store.StoreTitle,
                ActionTypeTl= i.ActionType.ActionTypeTitle,
                AssetMovementDirectionTl= i.AssetMovementDirection.AssetMovementDirectionTitle,
               
                

            }).ToList();
            Report = new rtpAssetCheckOut();
            Report.DataSource = ds;
            //Report.Parameters[0].Value = AssetId;
            //Report.RequestParameters = false;
        }
    }
}
