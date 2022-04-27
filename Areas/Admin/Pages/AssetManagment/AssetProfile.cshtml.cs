using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
  
    public class AssetProfileModel : PageModel
    {
        AssetContext Context;
        public Asset Asset { set; get; }
        public string AssetPhoto { set; get; }
        public AssetProfileModel(AssetContext context)
        {
            Context = context;
        }
        public IActionResult OnGet(int AssetId)
        {
           Asset = Context.Assets.Where(a => a.AssetId == AssetId).Include(a => a.Item).Include(a => a.DepreciationMethod).FirstOrDefault();
            if (Asset == null)
            {
                return Redirect("../../Error");

            }
            AssetPhoto = "/" + Asset.Photo;
            return Page();
        }
    }
}
