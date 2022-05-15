using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.SetUp
{
    [Authorize]
    public class CategoryListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
