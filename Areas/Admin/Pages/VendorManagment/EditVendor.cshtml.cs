using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

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
        public void OnGet(int id)
        {
           Vendor =Context.Vendors.Find(id);
        }

        public IActionResult OnPost()
        {
            if (Vendor.VendorId==null)
            {

                ModelState.AddModelError("", "Please select Vendor");
                return Page();
            }
            if (ModelState.IsValid)
            {
                var UpdatedVendor = Context.Vendors.Attach(Vendor);
                UpdatedVendor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Vendor Edited successfully");
                return RedirectToPage("/VendorManagment/VendorList",new {id=Vendor.VendorId});
            }
            return Page();
        }
    }
}
