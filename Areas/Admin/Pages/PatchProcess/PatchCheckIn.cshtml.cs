using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.PatchProcess
{
    public class PatchCheckInModel : PageModel
    {
        [BindProperty]
        public AssetMovement assetmovement { set; get; }
        AssetContext _context;
        public static List<Asset> SelectedAssets = new List<Asset>();
        private readonly IToastNotification _toastNotification;
        public PatchCheckInModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
            assetmovement = new AssetMovement();
        }
        public void OnGet()
        {
        }

        public IActionResult OnGetFillAssetList(string values)
        {
            var Assets = JsonConvert.DeserializeObject<List<Asset>>(values);
            SelectedAssets = Assets;
            return new JsonResult(Assets);
        }

        //public IActionResult OnPost()
        //{
        //    if (assetmovement.StoreId == 0)
        //    {
        //        ModelState.AddModelError("", "Please Select Store");
        //        return Page();
        //    }
           
        //    if (ModelState.IsValid)
        //    {
        //        if (SelectedAssets.Count != 0)
        //        {
        //            AssetMovement assetcheckIn = new AssetMovement
        //            {
        //                AssetMovementDirectionId = 2,
        //                TransactionDate = assetmovement.TransactionDate,
        //                Remarks = assetmovement.Remarks,
        //                StoreId = assetmovement.StoreId
        //                //ActionTypeId = LastAssetMovement.ActionTypeId,
        //                //EmpolyeeID = LastAssetMovement.EmpolyeeID,
        //                //LocationId = LastAssetMovement.LocationId,
        //                //DepartmentId = LastAssetMovement.DepartmentId,
        //            };
        //            _context.AssetMovements.Add(assetcheckIn);
        //            foreach (var asset in SelectedAssets)
        //            {
        //                //var LastAssetMovementDetails = _context.AssetMovementDetails.Where(a => a.AssetId == asset.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
        //                //AssetMovement LastAssetMovement = new AssetMovement();
        //                //if (LastAssetMovementDetails != null)
        //                //{
        //                //    LastAssetMovement = _context.AssetMovements.Find(LastAssetMovementDetails.AssetMovementId);
        //                //}
        //                asset.AssetStatusId = 1;
        //                var UpdatedAsset = _context.Assets.Attach(asset);
        //                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //                var assetMovementDetails = new AssetMovementDetails()
        //                {
        //                    AssetId = asset.AssetId,
        //                    AssetMovementId = assetcheckIn.AssetMovementId
        //                };
        //                _context.AssetMovementDetails.Add(assetMovementDetails);
        //            }
        //            try
        //            {
        //                _context.SaveChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                _toastNotification.AddErrorToastMessage("Something went Error,Try again");
        //                return Page();
        //            }
        //            _toastNotification.AddSuccessToastMessage("Asset Movements Added successfully");
        //            return RedirectToPage();
        //        }
        //        _toastNotification.AddErrorToastMessage("Please Select at Least one Asset");
        //        return Page();
        //    }
        //    _toastNotification.AddErrorToastMessage("Something went Error,Try again");
        //    return Page();
        //}

    }
}
