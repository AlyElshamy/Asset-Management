using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.SetUp
{
    [Authorize]
    public class SubCategoryListModel : PageModel
    {
       
        AssetContext Context;
        private readonly IToastNotification _toastNotification;
        public List<SubCategory> subCategories;
        public int catId { set; get; }
        public SubCategoryListModel(AssetContext context, IToastNotification toastNotification)
        {
            Context = context;
            _toastNotification = toastNotification;
           
        }
        public void OnGet(int id)
        {
            catId = id; 
        }
    }
}
