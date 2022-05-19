using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    [Authorize]
    public class Transactions_HistoryRPTModel : PageModel
    {

        public Transactions_HistoryRPTModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }
        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptTransactionsHistory Report { get; set; }
        public AssetContext _context { get; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }

        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            Report = new rptTransactionsHistory(tenant);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            List<TransactionHistoryRM> ds = _context.AssetLogs.Select(a => new TransactionHistoryRM
            {
                ActionDate=a.ActionDate,
                Remark=a.Remark,
                AssetLogId=a.AssetLogId,
                ActionLogTitle=a.ActionLog.ActionLogTitle,
                AssetId=a.AssetId,
                ActionLogId=a.ActionLogId,
                AssetCost=a.Asset.AssetCost,
                AssetDescription=a.Asset.AssetDescription,
                AssetSerialNo=a.Asset.AssetSerialNo,
                AssetTagId=a.Asset.AssetTagId,
                photo=a.Asset.Photo
            }).ToList();

            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.ActionLogId != null)
            {
                ds = ds.Where(i => i.ActionLogId == filterModel.ActionLogId).ToList();
            }
            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.ActionDate <= filterModel.ToDate && i.ActionDate >= filterModel.FromDate).ToList();
            }
           
            if (filterModel.AssetTagId == null && filterModel.FromDate == null && filterModel.ToDate == null && filterModel.ActionLogId == null)
            {
                ds = null;
            }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            Report = new rptTransactionsHistory(tenant);
            Report.DataSource = ds;
            return Page();

        }
    }
}
