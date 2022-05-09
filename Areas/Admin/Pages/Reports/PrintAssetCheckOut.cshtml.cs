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

        //public void OnGet(int AssetId)
        //{
        //    List<AssetCheckOutList> ds = _context.AssetMovements.Where(a=>a.AssetId==AssetId).Select(i => new AssetCheckOutList
        //    {
        //        TransactionDate= i.TransactionDate,
        //        EmployeeFullN= i.Employee.FullName,
        //        LocationTl= i.Location.LocationTitle,
        //        DepartmentTl=i.Department.DepartmentTitle,
        //        StoreTl=i.Store.StoreTitle,
        //        ActionTypeTl= i.ActionType.ActionTypeTitle,
        //        AssetMovementDirectionTl= i.AssetMovementDirection.AssetMovementDirectionTitle,
        //        AssetDescription= i.Asset.AssetDescription,
        //        AssetCost= i.Asset.AssetCost,
        //        AssetPurchaseDate=i.Asset.AssetPurchaseDate,
        //        AssetSerialNo=i.Asset.AssetSerialNo,
        //        AssetStatusTl=i.Asset.AssetStatus.AssetStatusTitle,
        //        AssetTagId=i.Asset.AssetTagId,
        //        ItemTl=i.Asset.Item.ItemTitle,
        //        AssetId= i.Asset.AssetId
                

        //    }).ToList();
        //    Report = new rtpAssetCheckOut();
        //    Report.DataSource = ds;
        //    //Report.Parameters[0].Value = AssetId;
        //    //Report.RequestParameters = false;
        //}
    }
}
