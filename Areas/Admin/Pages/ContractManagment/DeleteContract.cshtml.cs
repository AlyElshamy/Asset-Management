using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ContractManagment
{
    [Authorize]
    public class DeleteContractModel : PageModel
    {
     
        public Contract Contract { set; get; }
        AssetContext Context;
        public string VendorName;
        private readonly IToastNotification _toastNotification;
        public DeleteContractModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int id)
        {
            Contract = Context.Contracts.Where(c => c.ContractId == id).Include(c => c.Vendor).FirstOrDefault();
            if(Contract==null)
            {
                return Redirect("../../Error");
            }
            if (Contract.Vendor != null)
            {
                VendorName = Contract.Vendor.VendorTitle;
            }
          
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Contract = Context.Contracts.Find(id);
            if(Contract != null)
            {
            
                    Context.Contracts.Remove(Contract);
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Contract Deleted successfully");
                    return RedirectToPage("/ContractManagment/ContractList");
                }
                catch (Exception e)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/ContractManagment/DeleteContract", new { id = Contract.ContractId });
                }
            }

            return Redirect("../../Error");


        }
    }
}
