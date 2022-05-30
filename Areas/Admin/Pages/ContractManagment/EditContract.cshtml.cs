using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.ContractManagment
{
    [Authorize]
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
        public IActionResult OnGet(int id)
        {
           Contract =Context.Contracts.Find(id);
            if(Contract==null)
            {
                return Redirect("../../Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Contract.VendorId==null)
            {

                ModelState.AddModelError("", "Please select Vendor");
                return Page();
            }
            if (Contract.EndDate <= Contract.StartDate)
            {
                ModelState.AddModelError("", "EndDate mustbe greater than StartDate  ");
                return Page();
            }
            if (ModelState.IsValid)
            {
                var UpdatedContract = Context.Contracts.Attach(Contract);
                UpdatedContract.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Contract Edited successfully");
                    return RedirectToPage("/ContractManagment/DetailsContract", new { id = Contract.ContractId });
                }
                catch(Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/ContractManagment/EditContract", new { id = Contract.ContractId });
                }
              
            }
            return Page();
        }
    }
}
