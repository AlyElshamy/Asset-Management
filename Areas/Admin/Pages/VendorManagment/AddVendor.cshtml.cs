using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.VendorManagment
{
    public class AddVendorModel : PageModel
    {
        [BindProperty]
        public Vendor Vendor { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;
        public AddVendorModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
           _toastNotification = toastNotification;
            Vendor = new Vendor();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Vendor.VendorId == null)
                {
                    ModelState.AddModelError("", "Please Select Vendor");
                    return Page();
                }
                Context.Vendors.Add(Vendor);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Vendor Added successfully");
                return RedirectToPage("/VendorManagment/VendorList");
            }
            return Page();
        }
    }
}
