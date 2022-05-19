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

namespace AssetProject.Areas.Admin.Pages.PatchProcess
{
    [Authorize]
    public class PatchMaintModel : PageModel
    {
        [BindProperty]
        public AssetMaintainance assetMaintainance { set; get; }
        private readonly AssetContext _context;
        public static List<Asset> SelectedAssets = new List<Asset>();
        private readonly IToastNotification _toastNotification;
        public PatchMaintModel(AssetContext context, IToastNotification toastNotification)
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
               
                string DueDate = assetMaintainance.AssetMaintainanceDueDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                string CompletedDate = assetMaintainance.AssetMaintainanceDateCompleted.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                if (SelectedAssets.Count != 0)
                {
                    foreach (var asset in SelectedAssets)
                    {

                        AssetMaintainance assetMaintainanceObj = new AssetMaintainance
                        {
                            AssetMaintainanceDetails = assetMaintainance.AssetMaintainanceDetails,
                            AssetMaintainanceDateCompleted = assetMaintainance.AssetMaintainanceDateCompleted,
                            AssetMaintainanceDueDate = assetMaintainance.AssetMaintainanceDueDate,
                            AssetMaintainanceFrequencyId = assetMaintainance.AssetMaintainanceFrequencyId,
                            MaintainanceStatusId = assetMaintainance.MaintainanceStatusId,
                            AssetMaintainanceRepairesCost = assetMaintainance.AssetMaintainanceRepairesCost,
                            AssetMaintainanceTitle = assetMaintainance.AssetMaintainanceTitle,
                            MonthId = assetMaintainance.MonthId,
                            AssetMaintainanceId = assetMaintainance.AssetMaintainanceId,
                            WeekDayId = assetMaintainance.WeekDayId,
                            WeeklyPeriod = assetMaintainance.WeeklyPeriod,
                            MonthlyPeriod = assetMaintainance.MonthlyPeriod,
                            AssetMaintainanceRepeating = assetMaintainance.AssetMaintainanceRepeating,
                            MonthlyDay = assetMaintainance.MonthlyDay,
                            YearlyDay = assetMaintainance.YearlyDay,
                            AssetId = asset.AssetId,
                            TechnicianId=assetMaintainance.TechnicianId,
                            
                        };
                        asset.AssetStatusId = 9;
                        var UpdatedAsset = _context.Assets.Attach(asset);
                        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                        AssetLog assetLog = new AssetLog()
                        {
                            ActionLogId = 15,
                            AssetId = asset.AssetId,
                            ActionDate = DateTime.Now,
                            Remark = string.Format($"Maintainance Asset with Title {assetMaintainance.AssetMaintainanceTitle} and DueDate {DueDate} and Completed Date {CompletedDate}")
                        };
                        _context.AssetLogs.Add(assetLog);
                        _context.AssetMaintainances.Add(assetMaintainanceObj);
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
                    _toastNotification.AddSuccessToastMessage("Asset Maintainance Patched Added successfully");
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

