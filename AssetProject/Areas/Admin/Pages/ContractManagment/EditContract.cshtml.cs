using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.ContractManagment
{
    public class EditContractModel : PageModel
    {
        [BindProperty]
        public Contract Contract { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;

        public EditContractModel(AssetContext context,IToastNotification toastNotification)
        {
            Context = context;
           _toastNotification = toastNotification;
        }
        public void OnGet(int id)
        {
           Contract =Context.Contracts.Find(id);
        }

        public IActionResult OnPost()
        {
            if (Contract.VendorId==null)
            {

                ModelState.AddModelError("", "Please select Vendor");
                return Page();
            }
            if (ModelState.IsValid)
            {
                var UpdatedContract = Context.Contracts.Attach(Contract);
                UpdatedContract.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Contract Edited successfully");
                return RedirectToPage("/ContractManagment/DetailsContract",new {id=Contract.ContractId});
            }
            return Page();
        }
    }
}
