using AssetProject.Data;
using AssetProject.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    public class IndexModel : PageModel
    {


        private readonly AssetContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IndexModel(AssetContext context, IToastNotification toastNotification, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _toastNotification = toastNotification;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult OnGetGridData(DataSourceLoadOptions loadOptions)
        {
            var categories = _context.Assets;
            return new JsonResult(DataSourceLoader.Load(categories, loadOptions));
        }
        public IActionResult OnGetSingleAssetForView(int AssetId)
        {
            var Result = _context.Assets.Where(c=>c.AssetId==AssetId).FirstOrDefault();
            return new JsonResult(Result);
        }
        public IActionResult OnGetSingleAssetForEdit(int AssetId)
        {
            var Result = _context.Assets.Where(c => c.AssetId == AssetId).FirstOrDefault();
            return new JsonResult(Result);
        }

        public IActionResult OnPostEditAsset(Asset instance)
        {
            var uniqeFileName = "";
            if (Response.HttpContext.Request.Form.Files.Count() > 0)
            {

                var ImagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/Brand/" + instance.Photo);
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }
                string uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/AssetPhotos");

                string ext = Path.GetExtension(Response.HttpContext.Request.Form.Files[0].FileName);

                uniqeFileName = Guid.NewGuid().ToString("N") + ext;

                string uploadedImagePath = Path.Combine(uploadFolder, uniqeFileName);

                using (FileStream fileStream = new FileStream(uploadedImagePath, FileMode.Create))
                {
                    Response.HttpContext.Request.Form.Files[0].CopyTo(fileStream);
                }
                instance.Photo = uniqeFileName;
            }

            return new JsonResult(instance);
        }
    }
}
