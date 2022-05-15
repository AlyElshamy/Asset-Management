using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.BrandManagment
{
    [Authorize]
    public class BrandDetailsModel : PageModel
    {
        public Brand Brand { set; get; }
        AssetContext Context;
    
        public BrandDetailsModel(AssetContext context)
        {
            Context = context;

        }
        public IActionResult OnGet(int id)
        {
           Brand = Context.Brands.Find(id);
            if (Brand == null)
            {
                return Redirect("../../Error");

            }
           
            return Page();
        }
    }
}
