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

namespace AssetProject.Areas.Admin.Pages.ItemManagement
{
    [Authorize]
    public class DetailsItemModel : PageModel
    {
        public Item Item { set; get; }
        AssetContext Context;
        public string BrandName;
        public string CategoryName;
        public DetailsItemModel(AssetContext context)
        {
            Context = context;

        }
        public IActionResult OnGet(int id)
        {
            Item = Context.Items.Where(c => c.ItemId == id).Include(c => c.Brand).Include(c => c.Category).FirstOrDefault();
            if (Item == null)
            {
                return Redirect("../../Error");
            }
            if (Item.Brand != null && Item.Category != null)
            {
                BrandName = Item.Brand.BrandTitle;
                CategoryName = Item.Category.CategoryTIAR;

            }

            return Page();
        }
    }
}
