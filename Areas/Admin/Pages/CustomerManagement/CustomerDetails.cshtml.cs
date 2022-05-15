using AssetProject.Data;
using AssetProject.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.CustomerManagement
{
    [Authorize]
    public class CustomerDetailsModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        public Customer customer { get; set; }
        public CustomerDetailsModel(AssetContext context, IToastNotification toastNotification)
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
        public IActionResult OnGetGridData(DataSourceLoadOptions loadOptions, int customerId)
        {
            var assetLeasing = _context.AssetLeasings.Where(e => e.CustomerId == customerId).Select(e => new
            {

                e.StartDate,
                e.EndDate
            }) ;
            return new JsonResult(DataSourceLoader.Load(assetLeasing, loadOptions));
        }
    }
}

