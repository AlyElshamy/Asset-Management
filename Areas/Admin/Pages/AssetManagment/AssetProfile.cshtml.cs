using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{

    public class AssetProfileModel : PageModel
    {
        AssetContext Context;
        public Asset Asset { set; get; }
        public string AssetPhoto { set; get; }
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IToastNotification _toastNotification;
        public AssetProfileModel(AssetContext context, IWebHostEnvironment hostEnvironment, IToastNotification toastNotification)
        {
            Context = context;
            _hostEnvironment = hostEnvironment;
            _toastNotification = toastNotification;
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

        public async Task<IActionResult> OnPostAddAssetPhotot(IFormFile file, AssetPhotos photos)
        {
            if (file != null)
            {
                string folder = "Images/AssetPhotos/";
                photos.PhotoUrl = await UploadImage(folder, file);
            }
            if (photos.AssetId!=0)
            {
                Context.AssetPhotos.Add(photos);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Photo Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = photos.AssetId });
            }
            _toastNotification.AddErrorToastMessage("Asset Photo Not ADDED ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = photos.AssetId });
        }
        public IActionResult OnGetDeletePhoto(int AssetId,int AssetPhotoId)
        {
            var Result = Context.AssetPhotos.Where(a => a.AssetId == AssetId && a.AssetPhotoId == AssetPhotoId).FirstOrDefault();

            Context.AssetPhotos.Remove(Result);
            Context.SaveChanges();
            if (Result.PhotoUrl != null)
            {
                var ImagePath = Path.Combine(_hostEnvironment.WebRootPath, Result.PhotoUrl);
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }
            }

            return new JsonResult(Result);
        }
        public async Task<IActionResult> OnPostAddAssetDocument(AssetDocument instance, IFormFile file)
        {

            if (file != null)
            {

                string folder = "Documents/AssetDocuments/";
                instance.DocumentType = await UploadImage(folder, file);
            }


            Context.assetDocuments.Add(instance);
            Context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Asset Document Added successfully");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = instance.AssetId });

        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return folderPath;
        }

        public IActionResult OnpostAddAssetContract(AssetContract assetcontract)
        {

            if (assetcontract.ContractId != 0 && assetcontract.AssetId != 0)
            {
                var Assetcont = new AssetContract { AssetId = assetcontract.AssetId, ContractId = assetcontract.ContractId };
                Context.AssetContracts.Add(Assetcont);
                Context.SaveChanges();
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetcontract.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetcontract.AssetId });
        }
        public IActionResult OnpostAddAssetInsurance(AssetsInsurance assetsInsurance)
        {

            if (assetsInsurance.InsuranceId != 0 && assetsInsurance.AssetId != 0)
            {
                AssetsInsurance Assetcont = new AssetsInsurance { AssetId = assetsInsurance.AssetId, InsuranceId = assetsInsurance.InsuranceId };
                Context.AssetsInsurances.Add(Assetcont);
                Context.SaveChanges();
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetsInsurance.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetsInsurance.AssetId });
        }
    }
}