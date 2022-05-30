using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace AssetProject.Areas.Admin.Pages.ItemManagement
{
    [Authorize]
    public class DeleteItemModel : PageModel
    {
        public Item Item { set; get; }
        AssetContext Context;
        public string BrandName;
        public string CategoryName;
        private readonly IToastNotification _toastNotification;
        public DeleteItemModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int id)
        {
            Item = Context.Items.Where(c => c.ItemId == id).Include(c => c.Brand).Include(c=>c.Category).FirstOrDefault();
            if (Item == null)
            {
                return Redirect("../../Error");
            }
            if (Item.Brand != null&&Item.Category!=null)
            {
                BrandName = Item.Brand.BrandTitle;
                CategoryName = Item.Category.CategoryTIAR;

            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Item = Context.Items.Find(id);
            if (Item != null)
            {

                Context.Items.Remove(Item);
                try
                {
                    Context.SaveChanges();
                    _toastNotification.AddSuccessToastMessage("Item Deleted successfully");
                    return RedirectToPage("/ItemManagement/ItemList");
                }
                catch (Exception)
                {
                    _toastNotification.AddErrorToastMessage("Something went wrong");
                    return RedirectToPage("/ItemManagement/DeleteItem", new { id=Item.ItemId});
                }
            }

            return Redirect("../../Error");


        }
    }
}
