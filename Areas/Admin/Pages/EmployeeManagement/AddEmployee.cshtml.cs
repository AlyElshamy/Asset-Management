using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.EmployeeManagement
{

    public class AddEmployeeModel : PageModel
    {
        private readonly AssetContext _context;
        [BindProperty]
        public Employee employee { get; set; }
        private readonly IToastNotification _toastNotification;
        public AddEmployeeModel(IToastNotification toastNotification,AssetContext context)
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
                _context.Employees.Add(employee);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Employee Created Successfuly");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
            }
            return RedirectToPage("EmployeeList");
            
        }
    }
}
