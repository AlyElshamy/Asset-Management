using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using System;
using System.Collections.Generic;

namespace AssetProject.Areas.Admin.Pages.PatchProcess
{
    public class PatchDisposeModel : PageModel
    {
        [BindProperty]
        public DisposeAsset disposeAsset { set; get; }
        private readonly AssetContext _context;
        public static List<Asset> SelectedAssets = new List<Asset>();
        private readonly IToastNotification _toastNotification;
        public PatchDisposeModel(AssetContext context, IToastNotification toastNotification)
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

                        DisposeAsset disposeAssetObj = new DisposeAsset
                        {
                            DateDisposed = disposeAsset.DateDisposed,
                            DisposeTo= disposeAsset.DisposeTo,
                            Notes=disposeAsset.Notes,
                            //AssetId = asset.AssetId
                        };
                        _context.DisposeAssets.Add(disposeAssetObj);
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
                    _toastNotification.AddSuccessToastMessage("Asset Disposd Patched Added successfully");
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
