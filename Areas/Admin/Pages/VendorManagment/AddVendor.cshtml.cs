using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.VendorManagment
{
    [Authorize]
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
        //public void OnGet()
        //{
        //}

        public IActionResult OnGet()
        {
            return Page();
        }
        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Vendor.VendorId == null)
        //        {
        //            ModelState.AddModelError("", "Please Select Vendor");
        //            return Page();
        //        }

        //        Context.Vendors.Add(Vendor);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Vendor Added successfully");
        //        return RedirectToPage("/VendorManagment/VendorList");
        //    }
        //    return Page();
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Vendors.Add(Vendor);
            await Context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage("Vendor Added successfully");
            return RedirectToPage("/VendorManagment/VendorList");
        }
    }
}
