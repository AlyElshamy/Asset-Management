using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    public class SearchAssetModel : PageModel
    {
        
        private readonly AssetContext _context ;
        private readonly IToastNotification _toastNotification;
        [BindProperty]
        public AssetSerachVM AssetSerachVM { get; set; }
        public SearchAssetModel(AssetContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            bool CheckSearchItem=false;
            int SearchItem = 0;
            CheckSearchItem = int.TryParse(AssetSerachVM.AssetSearchItem, out SearchItem);
            
            if (ModelState.IsValid)
            {
                List<Asset> ListOfAssets = _context.Assets
                    .Where(x => x.AssetTagId == AssetSerachVM.AssetSearchItem || x.AssetSerialNo == AssetSerachVM.AssetSearchItem || x.AssetCost == SearchItem||x.AssetLife== SearchItem||x.Item.ItemTitle ==AssetSerachVM.AssetSearchItem).ToList();
                if (ListOfAssets.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("This Asset Not Found");
                    return Page();
                }
                return RedirectToPage("/AssetManagment/AssetProfile",new { AssetId = ListOfAssets[0].AssetId});
            }
            return Page();
        }
    }
}
