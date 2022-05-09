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
                    foreach (var asset in SelectedAssets)
                    {

                        AssetLeasing assetLeasingObj = new AssetLeasing
                        {
                            StartDate=assetLeasing.StartDate,
                            EndDate=assetLeasing.EndDate,
                            Notes=assetLeasing.Notes,
                            CustomerId= assetLeasing.CustomerId,
                            //AssetId=asset.AssetId
                        };
                        _context.AssetLeasings.Add(assetLeasingObj);
                    }
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
