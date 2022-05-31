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
            if (Contract.VendorId == null)
            {
                ModelState.AddModelError("", "Please Select Vendor");
                return Page();
            }
            if (Contract.EndDate <= Contract.StartDate)
            {
                ModelState.AddModelError("", "EndDate mustbe greater than StartDate  ");
                return Page();
            }
            if (ModelState.IsValid)
            {
                
               
                Context.Contracts.Add(Contract);
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Contract Added successfully");
                    return RedirectToPage("/ContractManagment/ContractList");
                }
               catch(Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/ContractManagment/ContractList");
                }
            }
            return Page();
        }
    }
}
