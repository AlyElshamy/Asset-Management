using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.AlertsManagement
{
    public class MaintenanceDueModel : PageModel
    {
        private readonly IToastNotification _toastNotification;
        AssetContext Context;

        public AssetMaintainance AssetMaintainance { set; get; }
        public MaintenanceDueModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            AssetMaintainance = new AssetMaintainance();
            _toastNotification = toastNotification;

        }
        public void OnGet()
        {
        }
        public IActionResult OnPostEditAssetMaintainance(AssetMaintainance assetMaintainance)
        {
            if (assetMaintainance.AssetMaintainanceDateCompleted < assetMaintainance.ScheduleDate)
            {
                _toastNotification.AddErrorToastMessage("Schedule Date Must be less than Completed Date..");
                return RedirectToPage("/AlertsManagement/MaintenanceDue");
            }
            if (assetMaintainance.TechnicianId == null)
            {
                _toastNotification.AddErrorToastMessage("Technican Name Is Required..");
                return RedirectToPage("/AlertsManagement/MaintenanceDue");
            }
            if (assetMaintainance.MaintainanceStatusId == null)
            {
                _toastNotification.AddErrorToastMessage("Status  Name Is Required..");
                return RedirectToPage("/AlertsManagement/MaintenanceDue");
            }
            if (assetMaintainance.MaintainanceStatusId != 5)
            {
                assetMaintainance.AssetMaintainanceDateCompleted = null;
            }
            if (assetMaintainance.MaintainanceStatusId == 5 || assetMaintainance.MaintainanceStatusId == 4)
            {
                var assetobj = Context.Assets.Find(assetMaintainance.AssetId);

                assetobj.AssetStatusId = 1;
                var UpdatedAsset = Context.Assets.Attach(assetobj);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            if (!assetMaintainance.AssetMaintainanceRepeating)
            {
                assetMaintainance.AssetMaintainanceFrequencyId = null;
                assetMaintainance.WeekDayId = null;
                assetMaintainance.WeeklyPeriod = null;
                assetMaintainance.MonthlyDay = null;
                assetMaintainance.MonthlyPeriod = null;
                assetMaintainance.YearlyDay = null;
                assetMaintainance.MonthId = null;
            }
            else
            {
                if (assetMaintainance.AssetMaintainanceFrequencyId == 1)
                {
                    assetMaintainance.WeekDayId = null;
                    assetMaintainance.WeeklyPeriod = null;
                    assetMaintainance.MonthlyDay = null;
                    assetMaintainance.MonthlyPeriod = null;
                    assetMaintainance.YearlyDay = null;
                    assetMaintainance.MonthId = null;
                }
                if (assetMaintainance.AssetMaintainanceFrequencyId == 2)
                {
                    assetMaintainance.MonthlyDay = null;
                    assetMaintainance.MonthlyPeriod = null;
                    assetMaintainance.YearlyDay = null;
                    assetMaintainance.MonthId = null;
                    if (assetMaintainance.WeeklyPeriod == null || assetMaintainance.WeekDayId == null)
                    {
                        _toastNotification.AddErrorToastMessage("Week Frequency Informations Is Required..");
                        return RedirectToPage("/AlertsManagement/MaintenanceDue");
                    }
                }
                if (assetMaintainance.AssetMaintainanceFrequencyId == 3)
                {
                    assetMaintainance.WeekDayId = null;
                    assetMaintainance.WeeklyPeriod = null;
                    assetMaintainance.YearlyDay = null;
                    assetMaintainance.MonthId = null;
                    if (assetMaintainance.MonthlyPeriod == null || assetMaintainance.MonthlyDay == null)
                    {
                        _toastNotification.AddErrorToastMessage("Month Frequency Informations Is Required..");
                        return RedirectToPage("/AlertsManagement/MaintenanceDue");
                    }
                }
                if (assetMaintainance.AssetMaintainanceFrequencyId == 4)
                {
                    assetMaintainance.WeekDayId = null;
                    assetMaintainance.WeeklyPeriod = null;
                    assetMaintainance.MonthlyDay = null;
                    assetMaintainance.MonthlyPeriod = null;
                    if (assetMaintainance.YearlyDay == null || assetMaintainance.MonthId == null)
                    {
                        _toastNotification.AddErrorToastMessage("Year Frequency Informations Is Required..");
                        return RedirectToPage("/AlertsManagement/MaintenanceDue");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                var UpdatedMaintainance = Context.AssetMaintainances.Attach(assetMaintainance);
                UpdatedMaintainance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var Status = Context.MaintainanceStatuses.Find(assetMaintainance.MaintainanceStatusId).MaintainanceStatusTitle;

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 22,
                    AssetId = assetMaintainance.AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Edit Asset Maintainance with Status {Status}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Maintainance Edited successfully");
                return RedirectToPage("/AlertsManagement/MaintenanceDue");
            }
            _toastNotification.AddErrorToastMessage("Asset Maintainance Not Added ,Try again");
            return RedirectToPage("/AlertsManagement/MaintenanceDue");
        }
    }
    }

