using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class CheckoutFormRPTModel : PageModel
    {
        public CheckoutFormRPTModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public ReportCheckOutForm Report { get; set; }
        public AssetContext _context { get; }
        public Tenant tenant { set; get; }
        UserManager<ApplicationUser> UserManger;

        public async Task<IActionResult> OnGet(int AssetMovement)
        {
            List<AssetMovement> ds = _context.AssetMovements.Include(a=>a.Employee).Include(a=>a.Location).Include(a=>a.Store).
                Include(a=>a.Department).Include(a=>a.AssetMovementDetails).ThenInclude(a=>a.Asset).ThenInclude(a=>a.Item)
                .ToList();
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);

            Report = new ReportCheckOutForm(tenant);
            Report.DataSource = ds;
            //Report.objectDataSource1.DataSource = ds;
            //Report.objectDataSource2.DataSource = tenant;
            Report.Parameters[0].Value = AssetMovement;
            
            //Report.Parameters[1].Value = tenant.TenantId;
            Report.RequestParameters = false;
            return Page();

        }
       
    }
}
