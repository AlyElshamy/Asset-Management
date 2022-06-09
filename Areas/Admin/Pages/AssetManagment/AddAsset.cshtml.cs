using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    [Authorize]
    public class AddAssetModel : PageModel
    {
        AssetContext Context;
        [BindProperty]
        public Asset Asset { set; get; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }

        public AddAssetModel(AssetContext context, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            Context = context;
            _webHostEnvironment = webHostEnvironment;
            Asset = new Asset();
            UserManger = userManager;

        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(IFormFile file)
        {
           

            if (Asset.ItemId == 0)
            {
                ModelState.AddModelError("", "Please Select Item");
                return Page();
            }
            if (Asset.StoreId == null)
            {
                ModelState.AddModelError("", "Please Select Store");
                return Page();
            }
            if (Asset.VendorId == null)
            {
                ModelState.AddModelError("", "Please Select Vendor");
                return Page();
            }
            if (Asset.DepreciableAsset )
            {
                if(Asset.DepreciationMethodId==null)
                {
                    ModelState.AddModelError("", "Please Select Depreciation Method");
                    return Page();
                }
               
            }
            if (!Asset.DepreciableAsset)
            {
                Asset.DepreciableCost = null;
                Asset.DateAcquired = null;
                Asset.DepreciationMethodId = null;
                Asset.SalvageValue = null;
                Asset.AssetLife = null;
            }
            
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string folder = "Images/AssetPhotos/";
                    Asset.Photo = await UploadImage(folder, file);
                }
              
                Asset.AssetStatusId = 1;
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await UserManger.FindByIdAsync(userid);
                tenant = Context.Tenants.Find(user.TenantId);
                Asset.TenantId = tenant.TenantId;
                Context.Assets.Add(Asset);
                string Str = "purchase Date : "; 
                string AssetPurchaseDate = Asset.AssetPurchaseDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 1,
                    Asset = Asset,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"{Str}{AssetPurchaseDate}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return  folderPath;
        }

    }
    }

