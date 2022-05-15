using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssetProject.Areas.Admin.Pages.StoreManagment
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly AssetProject.Data.AssetContext _context;

        public DetailsModel(AssetProject.Data.AssetContext context)
        {
            _context = context;
        }

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
    }
}
