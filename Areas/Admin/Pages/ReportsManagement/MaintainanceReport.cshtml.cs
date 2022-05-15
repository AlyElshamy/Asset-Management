using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    [Authorize]
    public class MaintainanceReportModel : PageModel
    {
        private readonly AssetContext _context;

        public MaintainanceReportModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptMaintainance Report { get; set; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }

        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptMaintainance(tenant);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            List<MaintainanceModel> ds = _context.AssetMaintainances.Select(i => new MaintainanceModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                AssetMaintainanceDateCompleted = i.AssetMaintainanceDateCompleted,
                AssetMaintainanceDueDate = i.AssetMaintainanceDueDate,
                AssetMaintainanceFrequencyTl = i.AssetMaintainanceFrequency.AssetMaintainanceFrequencyTitle,
                AssetMaintainanceRepairesCost = i.AssetMaintainanceRepairesCost,
                AssetMaintainanceTitle = i.AssetMaintainanceTitle,
                MaintainanceStatusTL = i.AssetMaintainanceTitle,
                TechnicianName = i.Technician.FullName,
                MonthTl = i.Month.MonthTitle,
                WeekDayTl = i.WeekDay.WeekDayTitle,
                TechnicianId = i.TechnicianId
            }).ToList();
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.TechnicianId != null)
            {
                ds = ds.Where(i => i.TechnicianId == filterModel.TechnicianId).ToList();
            }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptMaintainance(tenant);
            Report.DataSource = ds;
            return Page();
        }
    }
}
