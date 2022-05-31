using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssetProject.Data;
using AssetProject.Models;
using NToastNotify;
using Microsoft.AspNetCore.Authorization;

namespace AssetProject.Areas.Admin.Pages.StoreManagment
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AssetContext _context;
        private readonly IToastNotification toastNotification;

        public DeleteModel( AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            this.toastNotification = toastNotification;
        }

        [BindProperty]
        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Stores.FirstOrDefaultAsync(m => m.StoreId == id);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Stores.FindAsync(id);

            if (Store != null)
            {
                _context.Stores.Remove(Store);
                try { 
                await _context.SaveChangesAsync();
                toastNotification.AddSuccessToastMessage("Store Deleted successfully");
                return RedirectToPage("/StoreManagment/List");
                }
                catch (Exception e)
                {
                    toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/StoreManagment/Delete",new { id=Store.StoreId});
                }
            }

            return Redirect("../Error");
        }
    }
}
