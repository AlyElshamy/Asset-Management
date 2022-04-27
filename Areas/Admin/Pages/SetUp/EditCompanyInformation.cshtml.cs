using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetProject.Pages
{
    [Authorize]
    public class EditCompanyInformationModel : PageModel
    {
        AssetContext Context;
        UserManager<ApplicationUser> UserManger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
         public  Tenant tenant { set; get; }
        public SelectList countries { get; set; }

        public EditCompanyInformationModel(AssetContext context,
           
             IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            Context = context;
            UserManger = userManager;
           _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await  UserManger.FindByIdAsync(userid);
             tenant = Context.Tenants.Find(user.TenantId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (tenant.CountryId == 0)
            {
               
                ModelState.AddModelError("", "Please select country");
                return Page();
            }
            if (ModelState.IsValid)

            {
                if(file != null)
                {
                    if(tenant.Logo != null)
                    {
                        var ImagePath = Path.Combine(_webHostEnvironment.WebRootPath, tenant.Logo);
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }
                    
                    string folder = "Images/Logo/";
                    tenant.Logo = await UploadImage(folder, file);
                }
                var Updatedtenant = Context.Tenants.Attach(tenant);
                Updatedtenant.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();
                return RedirectToPage("/Index");
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

