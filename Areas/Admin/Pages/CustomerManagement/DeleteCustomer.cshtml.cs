using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.CustomerManagement
{
    [Authorize]
    public class DeleteCustomerModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Customer customer { get; set; }
        public DeleteCustomerModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int? id)
        {
            try
            {
                customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    _toastNotification.AddErrorToastMessage("Something went error");
                    return RedirectToPage("CustomerList");
                }

            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went errro");
            }
            return Page();

        }
        public IActionResult OnPost()
        {
            if (customer == null)
                return Page();
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Customer Deleted Successfully");
                return RedirectToPage("CustomerList");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
                return RedirectToPage("/CustomerManagement/DeleteCustomer", new { id = customer.CustomerId });

            }
        }
    }
}

