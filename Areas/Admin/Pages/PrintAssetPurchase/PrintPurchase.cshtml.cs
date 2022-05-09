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
        public int AssetId { get; set; }

        public void OnGet(int AssetId)
        {
            List<PuchaseListReportModel> ds = _context.Assets.Select(i => new PuchaseListReportModel
            {
                ItemTL = i.Item.ItemTitle,
                ItemId= i.ItemId,
                CategoryTL = i.Item.Category.CategoryTIAR,
                BrandTL = i.Item.Brand.BrandTitle,
                VendorTitle=i.Vendor.VendorTitle,
                StoreTitle= i.Store.StoreTitle,
                AssetTagId= i.AssetTagId,
                AssetCost= i.AssetCost,
                AssetSerialNo= i.AssetSerialNo,
                AssetPurchaseDate= i.AssetPurchaseDate,
                DepreciationMethod= i.DepreciationMethod.DepreciationMethodTitle,
                AssetLife= i.AssetLife,
                DepreciableCost= i.DepreciableCost,
                SalvageValue= i.SalvageValue
                //PurchaseSerial = i..PurchaseSerial,
                //Purchasedate = i.Purchase.Purchasedate,
                //Total = i.Total,
                //Discount = i.Purchase.Discount,
                //Net = i.Purchase.Net,
                //Quantity = i.Quantity,
                //Price = i.Price,
                //TotalPurchaseAsset = i.Total,
                //DiscountPurchaseAsset = i.Discount,
                //NetPurchaseAsset = i.Net

            }).ToList();
            Report = new rptPurchaseList();
            Report.DataSource = ds;
            //Report.Parameters[0].Value = AssetId;
            //Report.RequestParameters = false;
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
            

            
            List<PuchaseListReportModel> ds = _context.Assets.Select(i => new PuchaseListReportModel {

                ItemTL=i.Item.ItemTitle,
                ItemId = i.ItemId,
                StoreId= i.StoreId,
                VendorId=i.VendorId,
                CategoryTL = i.Item.Category.CategoryTIAR,
                BrandTL=i.Item.Brand.BrandTitle,
                VendorTitle = i.Vendor.VendorTitle,
                StoreTitle = i.Store.StoreTitle,
                AssetTagId = i.AssetTagId,
                AssetCost = i.AssetCost,
                AssetSerialNo = i.AssetSerialNo,
                AssetPurchaseDate = i.AssetPurchaseDate,
                DepreciationMethod = i.DepreciationMethod.DepreciationMethodTitle,
                AssetLife = i.AssetLife,
                DepreciableCost = i.DepreciableCost,
                SalvageValue = i.SalvageValue

            }).ToList();
            if(filterModel.FromDate!=null && filterModel.ToDate != null)
            {
                ds = ds.Where(e => e.AssetPurchaseDate >= filterModel.FromDate && e.AssetPurchaseDate <= filterModel.ToDate).ToList();
            }
            if (filterModel.ItemId != null)
            {
                ds = ds.Where(c => c.ItemId == filterModel.ItemId).ToList();
            }
            if (filterModel.VendorId != null)
            {
                ds = ds.Where(c => c.VendorId == filterModel.VendorId).ToList();
            }
            if (filterModel.StoreId != null)
            {
                ds = ds.Where(c => c.StoreId == filterModel.StoreId).ToList();
            }
            Report = new rptPurchaseList();
            Report.DataSource = ds;

           


        }
    }
}
