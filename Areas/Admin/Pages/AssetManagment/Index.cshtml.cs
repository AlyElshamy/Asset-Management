using AssetProject.Data;
using AssetProject.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    [Authorize]
    public class IndexModel : PageModel
    {


        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Asset Asset { set; get; }
        public IndexModel(AssetContext context, IToastNotification toastNotification, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _toastNotification = toastNotification;
            _hostEnvironment = hostEnvironment;
            Asset = new Asset();
        }

        public IActionResult OnGetGridData(DataSourceLoadOptions loadOptions)
        {
            var categories = _context.Assets;
            return new JsonResult(DataSourceLoader.Load(categories, loadOptions));
        }
        public IActionResult OnGetSingleAssetForView(int AssetId)
        {
            var Result = _context.Assets.Where(c=>c.AssetId==AssetId).Include(a=>a.Item).Include(a=>a.DepreciationMethod).FirstOrDefault();
            return new JsonResult(Result);
        }
        public IActionResult OnGetSingleAssetForEdit(int AssetId)
        {
            var Result = _context.Assets.Where(c => c.AssetId == AssetId).FirstOrDefault();
            return new JsonResult(Result);

        }

        public async Task<IActionResult> OnPostEditAsset(Asset instance,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (instance.Photo != null)
                    {
                        var ImagePath = Path.Combine(_hostEnvironment.WebRootPath, instance.Photo);
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }

                    string folder = "Images/AssetPhotos/";
                    instance.Photo = await UploadImage(folder, file);
                }
                if (instance.DepreciableAsset)
                {
                    if (Asset.DepreciationMethodId == null)
                    {
                        ModelState.AddModelError("", "Please Select Depreciation Method");
                        return Page();
                    }

                }
               else 
                {
                    Asset.DepreciableCost = null;
                    Asset.DateAcquired = null;
                    Asset.DepreciationMethodId = null;
                    Asset.SalvageValue = null;
                    Asset.AssetLife = null;
                }
                var UpdatedAsset = _context.Assets.Attach(instance);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 19,
                    AssetId = instance.AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format("Asset Edited")
                };
                _context.AssetLogs.Add(assetLog);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Edited successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = instance.AssetId });
            }
            return Page();

            //return new JsonResult(instance);
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return  folderPath;
        }
    }
}
