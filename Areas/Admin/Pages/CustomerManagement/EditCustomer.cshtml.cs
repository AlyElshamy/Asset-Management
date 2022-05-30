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
    public class EditCustomerModel : PageModel
    {
        private readonly AssetContext _context;
        [BindProperty]
        public Customer customer { get; set; }
        private readonly IToastNotification _toastNotification;
        public EditCustomerModel(AssetContext context, IToastNotification toastNotification)
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
                _toastNotification.AddErrorToastMessage("Something went error");
            }
            return Page();



        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            try
            {
                _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Customer Update Successfuly");
                return RedirectToPage("/CustomerManagement/CustomerDetails", new { id = customer.CustomerId });

            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
                return RedirectToPage("/CustomerManagement/EditCustomer", new { id = customer.CustomerId });

            }
        }
    }
}

