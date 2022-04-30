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
       public AssetMovement AssetCheckOutModel { set; get; }
        public AssetRepair AssetrepairModel { set; get; }
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

        public IActionResult OnPostAddAssetMovement(AssetMovement assetMovement)
        {
            if (ModelState.IsValid)
            {
                Context.AssetMovements.Add(assetMovement);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Movement Added Successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMovement.AssetId });
            }
            _toastNotification.AddErrorToastMessage("Asset Movement Not Added ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMovement.AssetId });
        }

        public IActionResult OnPostAddAssetRepair(AssetRepair assetRepair)
        {
            if (ModelState.IsValid)
            {
                Context.AssetRepairs.Add(assetRepair);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Repair Added Successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetRepair.AssetId });
            }
            _toastNotification.AddErrorToastMessage("Asset Repair Not Added ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetRepair.AssetId });
        }

        public IActionResult OnpostAddAssetLost(AssetLost assetlost)
        {
            if (assetlost.AssetId != 0)
            {
                var AssetLost = new AssetLost { AssetId = assetlost.AssetId, DateLost = assetlost.DateLost, Notes = assetlost.Notes, };
                Context.AssetLosts.Add(AssetLost);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Lost Added successfully");

                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetlost.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetlost.AssetId });
        }
        public IActionResult OnPostAddDisposeAsset(DisposeAsset disposeAsset)
        {
            if (disposeAsset.AssetId != 0)
            {
                var Disposeasset = new DisposeAsset { AssetId = disposeAsset.AssetId, DateDisposed = disposeAsset.DateDisposed, Notes = disposeAsset.Notes, DisposeTo = disposeAsset.DisposeTo };
                Context.DisposeAssets.Add(Disposeasset);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Dispose Asset Added successfully");

                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = disposeAsset.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = disposeAsset.AssetId });
        }

        public IActionResult OnpostAddAssetLeasing(AssetLeasing AssetLeasing)
        {
            AssetLeasing assetlea = new AssetLeasing { CustomerId = AssetLeasing.CustomerId, AssetId = AssetLeasing.AssetId, StartDate = AssetLeasing.StartDate, EndDate = AssetLeasing.EndDate, Notes = AssetLeasing.Notes };
            if (AssetLeasing.AssetId != 0)
            {
                Context.AssetLeasings.Add(assetlea);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Leasing Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetLeasing.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetLeasing.AssetId });
        }
        public IActionResult OnpostAddAssetsell(SellAsset Sellasset)
        {
            SellAsset assetsell = new SellAsset { AssetId = Sellasset.AssetId, Notes = Sellasset.Notes, SaleAmount = Sellasset.SaleAmount, SaleDate = Sellasset.SaleDate, SoldTo = Sellasset.SoldTo };
            if (Sellasset.AssetId != 0)
            {
                Context.sellAssets.Add(assetsell);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Selling Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Sellasset.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Sellasset.AssetId });
        }
        public IActionResult OnpostAddAssetBroken(AssetBroken assetBroken)
        {

            if (assetBroken.AssetId != 0)
            {
                AssetBroken assetBroke = new AssetBroken { AssetId = assetBroken.AssetId, DateBroken = assetBroken.DateBroken, Notes = assetBroken.Notes };
                Context.assetBrokens.Add(assetBroke);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Broken Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetBroken.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetBroken.AssetId });
        }
    }
}