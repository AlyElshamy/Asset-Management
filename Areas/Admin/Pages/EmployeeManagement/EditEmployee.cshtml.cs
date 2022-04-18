using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.EmployeeManagement
{
    public class EditEmployeeModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Employee employee { get; set; }
        public EditEmployeeModel(AssetContext context,IToastNotification toastNotification)
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
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Employee Update Successfuly");

            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
            }
            return RedirectToPage("EmployeeList");
        }
    }
}
