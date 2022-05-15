using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.Dashboards
{
    [Authorize]
    public class DashboardSummaryModel : PageModel
    {
     
        public int totalAssetCount { get; set; }
        public void OnGet()
        {
            totalAssetCount = 125;
        }
    }
}
