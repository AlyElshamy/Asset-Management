using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.CustomerManagement
{
    [Authorize]
    public class CustomerListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
