using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AssetProject.Areas.Admin.Pages.PrintAssetPurchase
{
    public class PrintPurchaseModel : PageModel
    {
        private readonly AssetContext _context;

        public PrintPurchaseModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptPurchaseList Report { get; set; }
        public int PurchaseId { get; set; }

        public void OnGet()
        {
            //Report = new rptPurchaseList();
            //List<PuchaseListReportModel> ds = _context.PurchaseAssets.Select(i => new PuchaseListReportModel
            //{
            //    ItemTL = i.Item.ItemTitle,
            //    CategoryTL = i.Item.Category.CategoryTIAR,
            //    BrandTL = i.Item.Brand.BrandTitle,
            //    PurchaseSerial = i.Purchase.PurchaseSerial,
            //    Purchasedate = i.Purchase.Purchasedate,
            //    Total = i.Purchase.Total,
            //    Discount = i.Purchase.Discount,
            //    Net = i.Purchase.Net,
            //    Quantity = i.Quantity,
            //    Price = i.Price,
            //    TotalPurchaseAsset = i.Total,
            //    DiscountPurchaseAsset = i.Discount,
            //    NetPurchaseAsset = i.Net

            //}).ToList();

            //Report.DataSource = ds;
            //Report.Parameters[0].Value = 4;
            //Report.RequestParameters = false;
            //var ds = _context.Purchases.Include(a => a.PurchaseAssets).ThenInclude(a => a.Item).ThenInclude(a => a.Category).ToList();


            //if (filterModel.AssetTagId != null)
            //{
            //    ds = ds.Where(c => c.AssetTagId == filterModel.AssetTagId).ToList();
            //}
            //if (filterModel.AssetTagId != null)
            //{
            //    ds = ds.Where(c => c.AssetTagId == filterModel.AssetTagId).ToList();
            //}

        }
        public void OnPost()
        {
            Report = new rptPurchaseList();
            List<PuchaseListReportModel> ds = _context.PurchaseAssets.Where(e => e.Purchase.PurchaseSerial == filterModel.PurchaseSerial).Select(i => new PuchaseListReportModel {
                ItemTL=i.Item.ItemTitle,
                CategoryTL=i.Item.Category.CategoryTIAR,
                BrandTL=i.Item.Brand.BrandTitle,
                PurchaseSerial=i.Purchase.PurchaseSerial,
                Purchasedate= i.Purchase.Purchasedate,
                Total= i.Purchase.Total,
                Discount= i.Purchase.Discount,
                Net= i.Purchase.Net,
                Quantity= i.Quantity,
                Price= i.Price,
                TotalPurchaseAsset= i.Total,
                DiscountPurchaseAsset= i.Discount,
                NetPurchaseAsset= i.Net

            }).ToList();

            Report.DataSource = ds;

            //var ds = _context.Purchases.Include(a => a.PurchaseAssets).ThenInclude(a => a.Item).ThenInclude(a => a.Category).ToList();
            //if (filterModel.PurchaseSerial != null)
            //{
            //    ds = ds.Where(c => c.PurchaseSerial == filterModel.PurchaseSerial).ToList();
            //    //}
            //    //if (filterModel.AssetTagId != null)
            //    //{
            //    //    ds = ds.Where(c => c.AssetTagId == filterModel.AssetTagId).ToList();
            //    //}

            //    Report.DataSource = ds;

            //}


        }
    }
}
