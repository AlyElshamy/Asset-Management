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
    public class PatchCheckOutModel : PageModel
    {
        [BindProperty]
        public AssetMovement assetmovement { set; get; }
        AssetContext _context;
        public static List<Asset> SelectedAssets=new List<Asset>();
        private readonly IToastNotification _toastNotification;
        public PatchCheckOutModel (AssetContext context, IToastNotification toastNotification)
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

        public IActionResult OnPost()
        {
            if (assetmovement.ActionTypeId == 0)
            {
                ModelState.AddModelError("", "Please Select Action");
                return Page();
            }
            if (assetmovement.LocationId == 0)
            {
                ModelState.AddModelError("", "Please Select Location");
                return Page();
            }
            if (assetmovement.DepartmentId == 0)
            {
                ModelState.AddModelError("", "Please Select Department");
                return Page();
            }
            if (assetmovement.ActionTypeId == 1)
            {
                if (assetmovement.EmpolyeeID == null)
                {
                    ModelState.AddModelError("", "Please Select Empolyee");
                    return Page();
                }
            }
            if (ModelState.IsValid)
            {
                if (SelectedAssets.Count != 0)
                {
                    foreach (var asset in SelectedAssets)
                    {
                        var LastAssetMovement = _context.AssetMovements.Where(a => a.AssetId == asset.AssetId).OrderByDescending(a => a.AssetMovementId).FirstOrDefault();

                        AssetMovement assetcheckout = new AssetMovement
                        {
                            AssetMovementDirectionId = 1,
                            ActionTypeId = assetmovement.ActionTypeId,
                            AssetId = asset.AssetId,
                            TransactionDate = assetmovement.TransactionDate,
                            EmpolyeeID = assetmovement.EmpolyeeID,
                            LocationId = assetmovement.LocationId,
                            DepartmentId = assetmovement.DepartmentId,
                            Remarks = assetmovement.Remarks,
                            StoreId = LastAssetMovement == null ? asset.StoreId : LastAssetMovement.StoreId
                       
                        };
                        _context.AssetMovements.Add(assetcheckout);
                    }
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch(Exception e)
                    {
                        _toastNotification.AddErrorToastMessage("Something went Error,Try again");
                        return Page();
                    }
                    _toastNotification.AddSuccessToastMessage("Asset Movements Added successfully");
                    return RedirectToPage();
                }
                _toastNotification.AddErrorToastMessage("Please Select at Least one Asset");
                return Page();
            }
            _toastNotification.AddErrorToastMessage("Something went Error,Try again");
            return Page();
        }
    }
}
