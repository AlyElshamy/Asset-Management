using AssetProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.Dashboards
{
    [Authorize]
    public class DashboardSummaryModel : PageModel
    {

        private readonly AssetContext _context;
        public int TotalAssetCount { get; set; }
        public double TotalAssetValue { get; set; }
        public int TotalAssetAvaliable { get; set; }
        public int TotalAssetActive { get; set; }
        public int TotalAssetBrocken { get; set; }
        public double TotalAssetBrockenValue { get; set; }
        public double TotalSellAsst { get; set; }
        public double TotalSellAsstValue { get; set; }
        public int TotalAssetUnderRepair { get; set; }
        public double TotalAssetUnderRepairCost { get; set; }
        public int TotalAssetLeased { get; set; }
        public double TotalLeasedAssetCost { get; set; }
        public int TotalAssetLost { get; set; }
        public double TotalAssetLostCost { get; set; }
        public int TotalAssetDispose { get; set; }
        public double TotalAssetDisposeCost { get; set; }
        public int TotalAssetMaint { get; set; }
        public double TotalAssetMaintCost { get; set; }
        public int TotalAssetCheckOut { get; set; }
        public double TotalAssetCheckOutCost { get; set; }
        public int TotalAssetLinkInsurance { get; set; }
        public int TotalAssetLinkWarrenty { get; set; }
        public int TotalAssetLinkContract { get; set; }
        public int TotalAssetPurchaseCY { get; set; }
        public double TotalAssetPurchaseCostCY { get; set; }
        

        public DashboardSummaryModel(AssetContext context)
        {
            _context = context;

        }
        public void OnGet()
        {

            TotalAssetCount = _context.Assets.Count();
            TotalAssetValue = _context.Assets.Sum(a=>a.AssetCost);
            TotalAssetActive = _context.Assets.Where(a => a.AssetStatusId == 2|| a.AssetStatusId==1).Count();//Aya M
            TotalAssetAvaliable = _context.Assets.Where(a => a.AssetStatusId ==1).Count();
            TotalAssetBrocken = _context.Assets.Where(a => a.AssetStatusId ==8).Count();
            TotalAssetBrockenValue = _context.Assets.Where(a => a.AssetStatusId ==8).Sum(a => a.AssetCost);
            TotalSellAsst = _context.Assets.Where(a => a.AssetStatusId == 7).Count();
            TotalSellAsstValue = _context.sellAssets.Sum(a => a.SaleAmount);
            TotalAssetUnderRepair = _context.Assets.Where(a => a.AssetStatusId == 3).Count();
            TotalAssetUnderRepairCost = _context.AssetRepairs.Sum(a => a.RepairCost);
            TotalAssetLeased = _context.Assets.Where(a => a.AssetStatusId == 6).Count();
            TotalLeasedAssetCost = _context.AssetLeasings.Sum(a => a.LeasedCost);
            TotalAssetLost = _context.Assets.Where(a => a.AssetStatusId == 4).Count();
            TotalAssetLostCost = _context.Assets.Where(a => a.AssetStatusId == 4).Sum(a=>a.AssetCost);
            TotalAssetDispose = _context.Assets.Where(a => a.AssetStatusId == 5).Count();
            TotalAssetMaint = _context.Assets.Where(a => a.AssetStatusId == 9).Count();
            TotalAssetMaintCost = _context.AssetMaintainances.Sum(a=>a.AssetMaintainanceRepairesCost);
            TotalAssetDisposeCost = _context.Assets.Where(a => a.AssetStatusId == 5).Sum(a=>a.AssetCost);
            TotalAssetCheckOut = _context.Assets.Where(a => a.AssetStatusId == 2).Count();
            TotalAssetCheckOutCost = _context.Assets.Where(a => a.AssetStatusId == 2).Sum(a => a.AssetCost);
            TotalAssetLinkInsurance = _context.AssetsInsurances.Count();
            TotalAssetLinkWarrenty = _context.AssetWarranties.Count();
            TotalAssetLinkContract = _context.AssetContracts.Count();
            TotalAssetPurchaseCY = _context.Assets.Where(A=>A.AssetPurchaseDate.Date.Year==DateTime.Now.Year).Count();
            TotalAssetPurchaseCostCY = _context.Assets.Where(A=>A.AssetPurchaseDate.Date.Year==DateTime.Now.Year).Sum(a=>a.AssetCost);




        }
    }
}
