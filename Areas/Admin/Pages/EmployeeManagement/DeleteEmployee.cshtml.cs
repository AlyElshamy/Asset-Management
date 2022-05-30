using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.EmployeeManagement
{
    [Authorize]
    public class DeleteEmployeeModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Employee employee { get; set; }
        public DeleteEmployeeModel(AssetContext context,IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int? id)
        {
            try
            {
                employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    _toastNotification.AddErrorToastMessage("Something went error");
                    return RedirectToPage("EmployeeList");
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
            if (employee == null)
                return RedirectToPage("/EmployeeManagement/DeleteEmployee", new { id = employee.ID });
            try
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Employee Deleted Successfully");
                return RedirectToPage("EmployeeList");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
                return RedirectToPage("/EmployeeManagement/DeleteEmployee", new { id = employee.ID });

            }
           
            
        }
    }
}
