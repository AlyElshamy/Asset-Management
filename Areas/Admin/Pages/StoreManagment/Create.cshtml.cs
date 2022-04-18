using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssetProject.Data;
using AssetProject.Models;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.StoreManagment
{
    public class CreateModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification toastNotification;

        public CreateModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            this.toastNotification = toastNotification;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Store Store { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stores.Add(Store);
            await _context.SaveChangesAsync();
            toastNotification.AddSuccessToastMessage("Store Added successfully");
            return RedirectToPage("./List");
        }
    }
}
