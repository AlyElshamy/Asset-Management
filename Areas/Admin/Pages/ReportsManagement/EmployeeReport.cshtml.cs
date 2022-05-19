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
    public class EmployeeReportModel : PageModel
    {
        
        private readonly AssetContext _context;

        public EmployeeReportModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptEmployee Report { get; set; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }

        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            Report = new rptEmployee(tenant);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            List<EmployeeModel> ds = _context.Employees.Select(i => new EmployeeModel
                {
                    FullName = i.FullName,
                    EmployeeId = i.EmployeeId,
                    Email = i.Email,
                    Phone = i.Phone,
                    Title = i.Title,
                    Notes = i.Notes,
                    Remark = i.Remark,
                    

                }).ToList();

                if (filterModel.ShowAll != false)
                {
                    ds = ds.ToList();
                }
                if (filterModel.EmployeeFullName != null)
                {
                    ds = ds.Where(i => i.FullName.Contains(filterModel.EmployeeFullName)).ToList();
                }
                if (filterModel.EmployeeIdStr != null)
                {
                    ds = ds.Where(i => i.EmployeeId.Contains(filterModel.EmployeeIdStr)).ToList();
                }
                if(filterModel.EmployeeFullName==null&& filterModel.EmployeeIdStr == null&& filterModel.ShowAll == false)
                {
                    ds = new List<EmployeeModel>();
                }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            Report = new rptEmployee(tenant);
            Report.DataSource = ds;
            return Page();

        }
    }
}

