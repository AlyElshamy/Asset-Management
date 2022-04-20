using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.ItemManagement
{
    public class EditItemModel : PageModel
    {
        [BindProperty]
        public Item Item { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;

        public EditItemModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int id)
        {
            Item = Context.Items.Find(id);
            if (Item == null)
            {
                return Redirect("../../Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Item.ItemId == null)
            {

                ModelState.AddModelError("", "Please select Item");
                return Page();
            }
            if (ModelState.IsValid)
            {
                var UpdatedContract = Context.Items.Attach(Item);
                UpdatedContract.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Item Edited successfully");
                return RedirectToPage("/itemManagement/Detailsitem", new { id = Item.ItemId });
            }
            return Page();
        }
    }
}
