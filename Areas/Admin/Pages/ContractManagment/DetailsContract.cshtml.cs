using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ContractManagment
{
    public class DetailsContractModel : PageModel
    {
        public Contract Contract { set; get; }
        AssetContext Context;
        public string VendorName;
        public DetailsContractModel(AssetContext context)
        {
            Context = context;

        }
        public IActionResult OnGet(int id)
        {
            Contract = Context.Contracts.Where(c => c.ContractId == id).Include(c => c.Vendor).FirstOrDefault();
            if(Contract==null)
            {
                return Redirect("../../Error");

            }
            if(Contract.Vendor!=null)
            {
                VendorName = Contract.Vendor.VendorTitle;
            }
           
            return Page();
        }
    }
}
