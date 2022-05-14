using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class SellAssetReportModel : PageModel
    {
        private readonly AssetContext _context;

        public SellAssetReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptSellAsset Report { get; set; }

        public void OnGet()
        {
            
            Report = new rptSellAsset();
        }
        public void OnPost()
        {
            List<SellAssetModel> ds = _context.AssetSellDetails.Select(i => new SellAssetModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
               SaleAmount=i.SellAsset.SaleAmount,
               SaleDate=i.SellAsset.SaleDate,
               SellNotes=i.SellAsset.Notes,
               SoldTo=i.SellAsset.SoldTo

            }).ToList();

            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId.Contains(filterModel.AssetTagId)).ToList();
            }
            if (filterModel.SoldTo != null)
            {
                ds = ds.Where(i => i.SoldTo.Contains(filterModel.SoldTo)).ToList();
            }
            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.SaleDate <= filterModel.ToDate && i.SaleDate >= filterModel.FromDate).ToList();
            }
            if (filterModel.OnDay != null)
            {
                ds = ds.Where(i => i.SaleDate == filterModel.OnDay).ToList();
            }
            if (filterModel.OnDay == null && filterModel.FromDate == null && filterModel.ToDate == null && filterModel.SoldTo == null && filterModel.AssetTagId == null)
            {
                ds = null;
            }
            Report = new rptSellAsset();
            Report.DataSource = ds;
        }
    }
}
