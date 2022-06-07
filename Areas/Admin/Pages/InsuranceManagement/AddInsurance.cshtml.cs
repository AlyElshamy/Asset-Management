using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.InsuranceManagement
{
    [Authorize]
    public class AddInsuranceModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Insurance insurance { get; set; }
       
        public AddInsuranceModel(AssetContext context, IToastNotification toastNotification)
        {
            insurance = new Insurance();
            _context = context;
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (insurance.EndDate <= insurance.StartDate)
            {
                ModelState.AddModelError("", "EndDate mustbe greater than StartDate  ");
                return Page();
            }
            if (!ModelState.IsValid)
                return Page();
                try
                {
                    _context.Insurances.Add(insurance);
                    _context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Insurance Policy Created Successfully");
                }
                catch (Exception)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                }

            return RedirectToPage("InsuranceList");
        }
    }
}
