using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.EmployeeManagement
{
    [Authorize]
    public class DeleteEmployeeModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Employee employee { get; set; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }
        public DeleteEmployeeModel(AssetContext context,IToastNotification toastNotification, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _toastNotification = toastNotification;
            UserManger = userManager;

        }
        public async Task <IActionResult> OnGet(int? id)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            try
            {
                employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    _toastNotification.AddErrorToastMessage("Something went error");
                    return RedirectToPage("EmployeeList");
                }
                 if (employee.TenantId != tenant.TenantId)
                {
                    return Redirect("../NotFound");
                }
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
                return RedirectToPage("EmployeeList");
            }
            return Page();

        }
        public IActionResult OnPost(int id)
        {
            employee = _context.Employees.Find(id);
            if (employee != null)
            {

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
            _toastNotification.AddErrorToastMessage("Something went error");
            return RedirectToPage("/EmployeeManagement/EmployeeList");

        }
    }
}
