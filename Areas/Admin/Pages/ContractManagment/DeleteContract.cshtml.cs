using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ContractManagment
{
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
        public void OnGet(int id)
        {
            Contract = Context.Contracts.Where(c => c.ContractId == id).Include(c => c.Vendor).FirstOrDefault();
            VendorName = Contract.Vendor.VendorTitle;
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
                    return Page();
                }
            }

            return Redirect("../Error");


        }
    }
}
