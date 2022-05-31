using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.BrandManagment
{
  
    public class EditBrandModel : PageModel
    {
        [BindProperty]
        public Brand Brand { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;

        public EditBrandModel(AssetContext context, IToastNotification toastNotification)
        {
             Context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int id)
        {
            Brand = Context.Brands.Find(id);
            if (Brand== null)
            {
                return Redirect("../../Error");

            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var UpdatedBrand = Context.Brands.Attach(Brand);
                UpdatedBrand.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Brand Edited successfully");
                    return RedirectToPage("/BrandManagment/BrandDetails", new { id = Brand.BrandId });
                }
                catch (Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/BrandManagment/EditBrand", new { id = Brand.BrandId });
                }
            }
            return Page();
        }
    }
}
