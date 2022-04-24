using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    public class AddAssetModel : PageModel
    {
        AssetContext Context;
        [BindProperty]
        public Asset Asset { set; get; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddAssetModel(AssetContext context, IWebHostEnvironment webHostEnvironment)
        {
            Context = context;
            _webHostEnvironment = webHostEnvironment;
            Asset = new Asset();
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
            if (Asset.DepreciableAsset )
            {
                if(Asset.DepreciationMethodId==0)
                {
                    ModelState.AddModelError("", "Please Select Depreciation Method");
                    return Page();
                }
               
            }
            
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string folder = "Images/AssetPhotos/";
                    Asset.Photo = await UploadImage(folder, file);
                }
                Context.Assets.Add(Asset);
                Context.SaveChanges();
                return RedirectToPage("AssetList");
            }
            return Page();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

    }
    }

