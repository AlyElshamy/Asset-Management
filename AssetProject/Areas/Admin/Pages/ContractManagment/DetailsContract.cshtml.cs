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
        public void OnGet(int id)
        {
            Contract = Context.Contracts.Where(c => c.ContractId == id).Include(c => c.Vendor).FirstOrDefault();
            VendorName = Contract.Vendor.VendorTitle;
        }
    }
}
