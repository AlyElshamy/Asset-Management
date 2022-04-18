using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.VendorManagment
{
    public class DeleteVendorModel : PageModel
    {
     
        public Vendor Vendor { set; get; }
        AssetContext Context;
        //public string VendorName;
        private readonly IToastNotification _toastNotification;
        public DeleteVendorModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
        }
        public void OnGet(int id)
        {
            Vendor = Context.Vendors.Where(c => c.VendorId == id).FirstOrDefault();
        }

        public IActionResult OnPost(int id)
        {
            Vendor = Context.Vendors.Find(id);
            if (Vendor != null)
            {

                Context.Vendors.Remove(Vendor);
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Vendor Deleted successfully");
                    return RedirectToPage("/VendorManagment/VendorList");
                }
                catch (Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return Page();
                }
            }
            return Redirect("../Error");


        }
    }
}
