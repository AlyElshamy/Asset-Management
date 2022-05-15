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
    public class PatchLeaseModel : PageModel
    {
        [BindProperty]
        public AssetLeasing assetLeasing { set; get; }
        private readonly AssetContext _context;
        public static List<Asset> SelectedAssets = new List<Asset>();
        private readonly IToastNotification _toastNotification;
        public PatchLeaseModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
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

            if (ModelState.IsValid)
            {
                if (SelectedAssets.Count != 0)
                {
                    assetLeasing.AssetLeasingDetails = new List<AssetLeasingDetails>();
                    string StartLeasingDate = assetLeasing.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    string EndLeasingDate = assetLeasing.EndDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                    foreach (var asset in SelectedAssets)
                    {

                        asset.AssetStatusId = 6;
                        var UpdatedAsset = _context.Assets.Attach(asset);
                        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        assetLeasing.AssetLeasingDetails.Add(new AssetLeasingDetails() { AssetId = asset.AssetId, Remarks = "" });

                        AssetLog assetLog = new AssetLog()
                        {
                            ActionLogId = 15,
                            AssetId = asset.AssetId,
                            ActionDate = DateTime.Now,
                            Remark = string.Format($"Leasing Asset Date is Between {StartLeasingDate} and {EndLeasingDate}")
                        };
                        _context.AssetLogs.Add(assetLog);
                    }
                    _context.AssetLeasings.Add(assetLeasing);

                
                try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        _toastNotification.AddErrorToastMessage("Something went Error,Try again");
                        return Page();
                    }
                    _toastNotification.AddSuccessToastMessage("Asset Leasing Patched Added successfully");
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
