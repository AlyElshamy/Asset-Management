using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;

namespace AssetProject.Areas.Admin.Pages.InsuranceManagement
{
    public class EditInsuranceModel : PageModel
    {

        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public Insurance insurance { get; set; }
        public EditInsuranceModel(AssetContext context,IToastNotification toastNotification)
        {
            this._context = context;
            this._toastNotification = toastNotification;
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
                _context.Entry(insurance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Insurance Policy Update Successfuly");
               
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Something went error");
            }
            return RedirectToPage("InsuranceList");
        }
    }
}
