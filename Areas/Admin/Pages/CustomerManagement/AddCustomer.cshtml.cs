using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.CustomerManagement
{
    public class AddCustomerModel : PageModel
    {
        private readonly AssetContext _context;
        [BindProperty]
        public Customer customer { get; set; }
        private readonly IToastNotification _toastNotification;
        public AddCustomerModel(IToastNotification toastNotification, AssetContext context)
        {
            _context = context;
            _toastNotification = toastNotification;
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
                _context.Customers.Add(customer);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Customer Created Successfuly");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
            }
            return RedirectToPage("CustomerList");

        }
    }
}

