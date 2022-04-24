using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    public class AssetDetailsModel : PageModel
    {
        AssetContext Context;
        public  Asset Asset { set; get; } 
    
        public AssetDetailsModel(AssetContext context)
        {
            Context = context;
        }
        public void OnGet(int id)
        {
            Asset = Context.Assets.Where(a=>a.AssetId==id).Include(a=>a.Item ).Include(a=>a.DepreciationMethod).FirstOrDefault();
        }
    }
}
