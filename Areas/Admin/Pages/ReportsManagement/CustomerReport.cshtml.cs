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
    public class CustomerReportModel : PageModel
    {
        private readonly AssetContext _context;

        public CustomerReportModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptCustomer Report { get; set; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }

        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptCustomer(tenant);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            List<CustomerModel> ds = _context.Customers.Select(i => new CustomerModel
            {
                CompanyName = i.CompanyName,
                City = i.City,
                Country = i.Country,
                CustomerId = i.CustomerId,
                Address1 = i.Address1,
                Address2 = i.Address2,
                Email = i.Email,
                FullName = i.FullName,
                Notes = i.Notes,
                Phone = i.Phone,
                PostalCode = i.PostalCode,
                State = i.State
            }).ToList();
            if (filterModel.CustomerName != null)
            {
                ds = ds.Where(i => i.FullName.Contains(filterModel.CustomerName)).ToList();
            }
            if (filterModel.CompanyName != null)
            {
                ds = ds.Where(i => i.CompanyName.Contains(filterModel.CompanyName)).ToList();
            }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptCustomer(tenant);
            Report.DataSource = ds;
            return Page();
        }
    }
}
