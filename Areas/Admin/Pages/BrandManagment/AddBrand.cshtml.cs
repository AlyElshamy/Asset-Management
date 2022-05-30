using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.BrandManagment
{
    [Authorize]
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
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Brand Added successfully");
                    return RedirectToPage("/BrandManagment/BrandList");
                }
               catch(Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/BrandManagment/BrandList");
                }
            }
            return Page();
        }
    }
}
