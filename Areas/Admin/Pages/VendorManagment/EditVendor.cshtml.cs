using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.VendorManagment
{
    [Authorize]
    public class EditVendorModel : PageModel
    {
        [BindProperty]
        public Vendor Vendor { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;

        public EditVendorModel(AssetContext context,IToastNotification toastNotification)
        {
            Context = context;
           _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int id)
        {
           Vendor =Context.Vendors.Find(id);
            if (Vendor == null)
            {
                return Redirect("../../Error");
            }
            return Page();

        }

        public IActionResult OnPost()
        {
            if (Vendor.VendorId==0)
            {

                ModelState.AddModelError("", "Please select Vendor");
                return Page();
            }
            if (ModelState.IsValid)
            {
                var UpdatedVendor = Context.Vendors.Attach(Vendor);
                UpdatedVendor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Vendor Edited successfully");
                    return RedirectToPage("/VendorManagment/DetailsVendor", new { id = Vendor.VendorId });
                }
               catch(Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/VendorManagment/EditVendor", new { id = Vendor.VendorId });
                }
            }
            return Page();
        }
    }
}
