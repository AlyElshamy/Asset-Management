using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using System.Collections.Generic;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System;

namespace AssetProject.Areas.Admin.Pages.PatchProcess
{
    public class PatchTransferFromEmpolyeeModel : PageModel
    {
        [BindProperty]
        public AssetMovement assetmovement { set; get; }
        AssetContext _context;
        public List<Asset> EmpoyeeAssets = new List<Asset>();
        public static List<Asset> SelectedAssets = new List<Asset>();
        private readonly IToastNotification _toastNotification;

        public PatchTransferFromEmpolyeeModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
            assetmovement = new AssetMovement();
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetAssetsForEmpolyee(string values)
        {
            var EmpoyeeId = JsonConvert.DeserializeObject<int>(values);
            var movementsForDepartment = _context.AssetMovements.Where(a => a.EmpolyeeID == EmpoyeeId && a.AssetMovementDirectionId == 1).Include(a => a.AssetMovementDetails).ThenInclude(a => a.Asset);
            foreach (var item in movementsForDepartment)
            {
                foreach (var item2 in item.AssetMovementDetails)
                {
                    if (item2.Asset.AssetStatusId == 2)
                    {
                        var lastassetmovement = _context.AssetMovementDetails.Where(a => a.AssetId == item2.AssetId).Include(a => a.AssetMovement).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                        if (lastassetmovement.AssetMovement.EmpolyeeID == EmpoyeeId )
                        {
                            EmpoyeeAssets.Add(item2.Asset);
                        }
                    }
                }
            }

            return new JsonResult(EmpoyeeAssets);
        }
        public IActionResult OnGetGridData(DataSourceLoadOptions loadOptions)
        {

            return new JsonResult(DataSourceLoader.Load(EmpoyeeAssets, loadOptions));
        }

        public IActionResult OnGetFillAssetList(string values)
        {
            var Assets = JsonConvert.DeserializeObject<List<Asset>>(values);
            SelectedAssets = Assets;
            return new JsonResult(Assets);
        }

        public IActionResult OnPost()
        {
            if (assetmovement.LocationId == null)
            {
                ModelState.AddModelError("", "Please Select Location");
                return Page();
            }
            if (assetmovement.DepartmentId == null)
            {
                ModelState.AddModelError("", "Please Select Department");
                return Page();
            }
            if (assetmovement.EmpolyeeID == null)
            {
                ModelState.AddModelError("", "Please Select Empolyee");
                return Page();
            }

            if (assetmovement.StoreId == null)
            {
                ModelState.AddModelError("", "Please Select Store");
                return Page();
            }

            //Inert two movement

            //First move assets to store --> Check in
            if (SelectedAssets != null)
            {
                int CheckInID = checkinAssetsfromEmpolyeeTostore(assetmovement, SelectedAssets);
                if (CheckInID == 0)
                {
                    _toastNotification.AddErrorToastMessage("Something went Error,Try again");
                    return Page();
                }

                //Second move asset from store to department
                int CheckoutID = checkoutAssetsToDepartment(assetmovement, SelectedAssets);
                if (CheckoutID == 0)
                {
                    _toastNotification.AddErrorToastMessage("Something went Error,Try again");
                    return Page();
                }

                //Print check in form
                _toastNotification.AddSuccessToastMessage("Asset Movements Added successfully");
                return RedirectToPage("/ReportsManagement/CheckInFormRPT", new { AssetMovement = CheckInID });
                //Print check out form

            }
            _toastNotification.AddErrorToastMessage("Please Select at Least one Asset");
            return Page();
        }

        public int checkinAssetsfromEmpolyeeTostore(AssetMovement assetMovementObj, List<Asset> selectedAssetsList)
        {
            AssetMovement newAssetMovement = null;
            if (selectedAssetsList.Count != 0)
            {
                var LastassetmovementForEmpolyee = _context.AssetMovements.Where(a => a.EmpolyeeID == assetMovementObj.EmpolyeeID && a.AssetMovementDirectionId == 1).OrderByDescending(a => a.AssetMovementId).FirstOrDefault();
                newAssetMovement = new AssetMovement()
                {
                    AssetMovementDirectionId = 2,
                    ActionTypeId = 1,
                    DepartmentId = LastassetmovementForEmpolyee.DepartmentId,
                    LocationId = LastassetmovementForEmpolyee.LocationId,
                    TransactionDate = assetMovementObj.TransactionDate,
                    //DueDate=assetMovementObj.DueDate,
                    Remarks = assetMovementObj.Remarks,
                    StoreId = assetMovementObj.StoreId,
                    EmpolyeeID=assetMovementObj.EmpolyeeID
                };


                newAssetMovement.AssetMovementDetails = new List<AssetMovementDetails>();
                string DirectionTitle = "Direction Title : ";
                string TransDate = "Transaction Date : ";
                AssetMovementDirection Direction = _context.AssetMovementDirections.Find(newAssetMovement.AssetMovementDirectionId);
                string TransactionDate = assetMovementObj.TransactionDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                foreach (var asset in selectedAssetsList)
                {
                    asset.AssetStatusId = 1;
                    var UpdatedAsset = _context.Assets.Attach(asset);
                    UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    newAssetMovement.AssetMovementDetails.Add(new AssetMovementDetails() { AssetId = asset.AssetId, Remarks = "" });
                    AssetLog assetLog = new AssetLog()
                    {
                        ActionLogId = 16,
                        AssetId = asset.AssetId,
                        ActionDate = DateTime.Now,
                        Remark = string.Format($"{TransDate}{TransactionDate} and {DirectionTitle}{Direction.AssetMovementDirectionTitle} Transfered")
                    };
                    _context.AssetLogs.Add(assetLog);
                }

                _context.AssetMovements.Add(newAssetMovement);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            return newAssetMovement.AssetMovementId;
        }

        public int checkoutAssetsToDepartment(AssetMovement assetMovementObj, List<Asset> selectedAssetsList)
        {
            AssetMovement newAssetMovement=null;
            if (selectedAssetsList.Count != 0)
            {
                newAssetMovement = new AssetMovement()
                {
                    AssetMovementDirectionId = 1,
                    ActionTypeId = 2,
                    DepartmentId=assetMovementObj.DepartmentId,
                    LocationId=assetMovementObj.LocationId,
                    StoreId=assetMovementObj.StoreId,
                    Remarks=assetMovementObj.Remarks,
                    TransactionDate=assetMovementObj.TransactionDate
                    //DueDate=assetMovementObj.DueDate
                };

              newAssetMovement.AssetMovementDetails = new List<AssetMovementDetails>();
                string ActionTitle = "Action Title : ";
                string TransDate = "Transaction Date : ";
                string DirectionTitle = "Direction Title : ";
                ActionType SelectedActionType = _context.ActionTypes.Find(newAssetMovement.ActionTypeId);
                AssetMovementDirection Direction = _context.AssetMovementDirections.Find(newAssetMovement.AssetMovementDirectionId);
                string TransactionDate = assetMovementObj.TransactionDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                foreach (var asset in selectedAssetsList)
                {
                    asset.AssetStatusId = 2;
                    var UpdatedAsset = _context.Assets.Attach(asset);
                    UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    newAssetMovement.AssetMovementDetails.Add(new AssetMovementDetails() { AssetId = asset.AssetId, Remarks = "" });

                    AssetLog assetLog = new AssetLog()
                    {
                        ActionLogId = 17,
                        AssetId = asset.AssetId,
                        ActionDate = DateTime.Now,
                        Remark = string.Format($"{TransDate}{TransactionDate} and {ActionTitle}{SelectedActionType.ActionTypeTitle} and {DirectionTitle}{Direction.AssetMovementDirectionTitle} Transfered")
                    };
                    _context.AssetLogs.Add(assetLog);
                }
                _context.AssetMovements.Add(newAssetMovement);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            return newAssetMovement.AssetMovementId;
        }
    }
}
