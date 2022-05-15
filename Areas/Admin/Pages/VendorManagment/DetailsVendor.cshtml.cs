using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.VendorManagment
{
    [Authorize]
    public class DetailsVendorModel : PageModel
    {
        public Vendor Vendor { set; get; }
        AssetContext Context;
        public string VendorName;
        public DetailsVendorModel(AssetContext context)
        {
            Context = context;

        }
        public void OnGet(int id)
        {
            Vendor = Context.Vendors.Where(c => c.VendorId == id).FirstOrDefault();
            VendorName = Vendor.VendorTitle;
        }
    }
}
