using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.PatchProcess
{
    [Authorize]
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

        public IActionResult OnPost()
        {
            if (assetmovement.StoreId == 0)
            {
                ModelState.AddModelError("", "Please Select Store");
                return Page();
            }
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

                    assetmovement.AssetMovementDirectionId = 2;
                    assetmovement.AssetMovementDetails = new List<AssetMovementDetails>();
                    //ActionTypeId = LastAssetMovement.ActionTypeId,
                    //EmpolyeeID = LastAssetMovement.EmpolyeeID,
                    //LocationId = LastAssetMovement.LocationId,
                    //DepartmentId = LastAssetMovement.DepartmentId,
                    string DirectionTitle = "Direction Title : ";
                    string TransDate = "Transaction Date : ";
                    AssetMovementDirection Direction = _context.AssetMovementDirections.Find(assetmovement.AssetMovementDirectionId);
                    string TransactionDate = assetmovement.TransactionDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    foreach (var asset in SelectedAssets)
                    {
                        //var LastAssetMovementDetails = _context.AssetMovementDetails.Where(a => a.AssetId == asset.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                        //AssetMovement LastAssetMovement = new AssetMovement();
                        //if (LastAssetMovementDetails != null)
                        //{
                        //    LastAssetMovement = _context.AssetMovements.Find(LastAssetMovementDetails.AssetMovementId);
                        //}
                        asset.AssetStatusId = 1;
                        var UpdatedAsset = _context.Assets.Attach(asset);
                        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        assetmovement.AssetMovementDetails.Add(new AssetMovementDetails() { AssetId = asset.AssetId, Remarks = "" });
                        AssetLog assetLog = new AssetLog()
                        {
                            ActionLogId = 16,
                            AssetId =asset.AssetId,
                            ActionDate = DateTime.Now,
                            Remark = string.Format($"{TransDate}{TransactionDate} and {DirectionTitle}{Direction.AssetMovementDirectionTitle}")
                        };
                        _context.AssetLogs.Add(assetLog);
                    }
                    _context.AssetMovements.Add(assetmovement);
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        _toastNotification.AddErrorToastMessage("Something went Error,Try again");
                        return Page();
                    }
                    _toastNotification.AddSuccessToastMessage("Asset Movements Added successfully");
                    return RedirectToPage("/ReportsManagement/CheckInFormRPT", new { AssetMovement = assetmovement.AssetMovementId });
                }
                _toastNotification.AddErrorToastMessage("Please Select at Least one Asset");
                return Page();
            }
            _toastNotification.AddErrorToastMessage("Something went Error,Try again");
            return Page();
        }

    }
}
