using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Globalization;

namespace AssetProject.Areas.Admin.Pages.InsuranceManagement
{
    [Authorize]

    public class DeleteInsuranceModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [BindProperty]
        public Insurance insurance { get; set; }
        public DeleteInsuranceModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int ?id)
        {
            try
            {
                insurance = _context.Insurances.Find(id);
                if (insurance == null)
                {
                    _toastNotification.AddErrorToastMessage("Something went error");
                    return RedirectToPage("InsuranceList");
                }
                StartDate = insurance.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                EndDate = insurance.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
                if (insurance == null)
                    return Page();
                
            
                try
                {
                    _context.Insurances.Remove(insurance);
                    _context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Insurance Policy Deleted Successfuly");
                     return RedirectToPage("InsuranceList");
                }
                catch (Exception)
                {
                    _toastNotification.AddErrorToastMessage("Something went error");
                }
            return Page();

            
        }
    }
    
}
