using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Globalization;

namespace AssetProject.Areas.Admin.Pages.InsuranceManagement
{
    public class DetailsInsuranceModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
            public Insurance insurance { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }

        public DetailsInsuranceModel(AssetContext context,IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int? id)
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
    }
}
