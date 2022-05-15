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
    public class InsuranceReportModel : PageModel
    {
        private readonly AssetContext _context;

        public InsuranceReportModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptInsurance Report { get; set; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }

        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptInsurance(tenant);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            List<InsuranceModel> ds = _context.AssetsInsurances.Select(i => new InsuranceModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                ItemTL = i.Asset.Item.ItemTitle,
                Photo = i.Asset.Photo,
                ContactPerson = i.Insurance.ContactPerson,
                EndDate = i.Insurance.EndDate,
                StartDate = i.Insurance.StartDate,
                Description = i.Insurance.Description,
                Phone = i.Insurance.Phone,
                Deductible = i.Insurance.Deductible,
                InsuranceCompany = i.Insurance.InsuranceCompany,
                IsActive = i.Insurance.IsActive,
                Permium = i.Insurance.Permium,
                PolicyNo = i.Insurance.PolicyNo,
                Title = i.Insurance.Title,
                InsuranceId=i.InsuranceId
                
            }).ToList();
            if (filterModel.InsuranceId != null)
            {
                ds = ds.Where(i => i.InsuranceId == filterModel.InsuranceId).ToList();
            }
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptInsurance(tenant);
            Report.DataSource = ds;
            return Page();
        }
    }
}
    
