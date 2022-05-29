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
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult OnPostFillAssetList([FromBody] List<Asset> assets)
        {

            SelectedAssets = assets;
            return new JsonResult(assets);
        }
        public IActionResult OnGetGridData(DataSourceLoadOptions loadOptions)
        {
            var Assets = _context.Assets.Where(a => a.AssetStatusId == 2||a.AssetStatusId==6|| a.AssetStatusId ==9|| a.AssetStatusId ==3).Select(i => new {
                i.AssetId,
                i.AssetDescription,
                i.AssetTagId,
                i.AssetCost,
                i.AssetSerialNo,
                i.AssetPurchaseDate,
                i.ItemId,
                i.Photo,
                i.DepreciableAsset,
                i.DepreciableCost,
                i.SalvageValue,
                i.AssetLife,
                i.DateAcquired,
                i.Item.ItemTitle,
                i.DepreciationMethodId,
                i.VendorId,
                i.StoreId,
                i.AssetStatusId
            });

            return new JsonResult(DataSourceLoader.Load(Assets, loadOptions));
        }

        public IActionResult OnPost()
        {
            if (assetmovement.StoreId == null)
            {
                ModelState.AddModelError("", "Please Select Store");
                SelectedAssets = null;
                return Page();
            }
            if (assetmovement.ActionTypeId == null)
            {
                ModelState.AddModelError("", "Please Select Action");
                SelectedAssets = null;

                return Page();
            }
            if (assetmovement.LocationId == null)
            {
                ModelState.AddModelError("", "Please Select Location");
                SelectedAssets = null;

                return Page();
            }
            if (assetmovement.DepartmentId == null)
            {
                ModelState.AddModelError("", "Please Select Department");
                SelectedAssets = null;

                return Page();
            }
            if (assetmovement.ActionTypeId == 1)
            {
                if (assetmovement.EmpolyeeID == null)
                {
                    ModelState.AddModelError("", "Please Select Empolyee");
                    SelectedAssets = null;

                    return Page();
                }
            }

            if (ModelState.IsValid)
            {
                if (SelectedAssets != null)
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
                    string TransactionDate = assetmovement.TransactionDate.Value.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
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
                            SelectedAssets = null;

                        }
                        catch (Exception e)
                    {
                        _toastNotification.AddErrorToastMessage("Something went Error,Try again");
                            SelectedAssets = null;
                        return Page();
                    }
                    _toastNotification.AddSuccessToastMessage("Asset Movements Added successfully");
                        SelectedAssets = null;

                        return RedirectToPage("/ReportsManagement/CheckInFormRPT", new { AssetMovement = assetmovement.AssetMovementId });
                }
                }

                _toastNotification.AddErrorToastMessage("Please Select at Least one Asset");
                return Page();
            }
            _toastNotification.AddErrorToastMessage("Something went Error,Try again");
            SelectedAssets = null;
            return Page();
        }

    }
}
