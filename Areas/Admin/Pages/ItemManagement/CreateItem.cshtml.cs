using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.ItemManagement
{
    [Authorize]
    public class CreateItemModel : PageModel
    {
        [BindProperty]
        public Item Item { set; get; }
        AssetContext Context;
        private readonly IToastNotification _toastNotification;
        public CreateItemModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
            Item = new Item();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Item.CategoryId == null)
                {
                    ModelState.AddModelError("", "Please Select Category");
                    return Page();
                }
                if (Item.BrandId == null)
                {
                    ModelState.AddModelError("", "Please Select Brand");
                    return Page();
                }
                Context.Items.Add(Item);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Item Added successfully");
                return RedirectToPage("/ItemManagement/ItemList");
            }
            return Page();
        }
    }
}
