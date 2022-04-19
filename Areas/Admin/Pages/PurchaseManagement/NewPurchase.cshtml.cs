using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Collections.Generic;

namespace AssetProject.Areas.Admin.Pages.PurchaseManagement
{
    public class NewPurchaseModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Purchase purchase { get; set; }
        public List<PurchaseAsset> ltDetails  { get; set; }

        public NewPurchaseModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
            //purchase = new Purchase();
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            try
            {
                _context.Purchases.Add(purchase);
                _context.SaveChanges();
                //Save Detials

                _toastNotification.AddSuccessToastMessage("Purchase Created Successfully");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went wrong");
            }

            return RedirectToPage("PurchaseList");
        }
    }
}
