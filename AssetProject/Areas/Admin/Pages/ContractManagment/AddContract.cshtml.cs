using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.ContractManagment
{
    public class AddContractModel : PageModel
    {
        [BindProperty]
        public Contract Contract { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;
        public AddContractModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
           _toastNotification = toastNotification;
            Contract = new Contract();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Contract.VendorId == null)
                {
                    ModelState.AddModelError("", "Please Select Vendor");
                    return Page();
                }
                Context.Contracts.Add(Contract);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Contract Added successfully");
                return RedirectToPage("/ContractManagment/ContractList");
            }
            return Page();
        }
    }
}
