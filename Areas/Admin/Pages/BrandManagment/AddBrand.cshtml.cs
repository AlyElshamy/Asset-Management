using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.BrandManagment
{
    public class AddBrandModel : PageModel
    {
        [BindProperty]
        public Brand Brand { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;
        public AddBrandModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
            Brand = new Brand();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Context.Brands.Add(Brand);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Brand Added successfully");
                return RedirectToPage("/BrandManagment/BrandList");
            }
            return Page();
        }
    }
}
