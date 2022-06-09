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
    public class DeleteBrandModel : PageModel
    {
        public Brand Brand { set; get; }
        AssetContext Context;
      
        private readonly IToastNotification _toastNotification;
        public DeleteBrandModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
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

        public IActionResult OnPost(int id)
        {
           Brand = Context.Brands.Find(id);
            if (Brand != null)
            {

                Context.Brands.Remove(Brand);
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Brand Deleted successfully");
                    return RedirectToPage("/BrandManagment/BrandList");
                }
                catch (Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/BrandManagment/DeleteBrand", new { id = Brand.BrandId});

                }
            }

            _toastNotification.AddErrorToastMessage("Something went wrong");
            return RedirectToPage("/BrandManagment/BrandList");
        }
    }
}
