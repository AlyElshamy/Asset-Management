using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetProject.Pages
{
    [Authorize]
    public class EditCompanyInformationModel : PageModel
    {
        AssetContext Context;
        ApplicationDbContext AppContext;
        UserManager<ApplicationUser> UserManger;

          [BindProperty]
         public  Tenant tenant { set; get; }
        public SelectList countries { get; set; }

        public EditCompanyInformationModel(AssetContext context,
            ApplicationDbContext appcontext,
            UserManager<ApplicationUser> userManager)
        {
            Context = context;
            AppContext = appcontext;
            UserManger = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await  UserManger.FindByIdAsync(userid);
           var countrieslist= Context.Countries.ToList();
            var countries1 = countrieslist.OfType<Country>();
            countries = new SelectList(countries1, "CountryId", "CountryTitle");
             tenant = Context.Tenants.Find(user.TenantId);
            return Page();
        }

        public  IActionResult OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var Updatedtenant = Context.Tenants.Attach(tenant);
                Updatedtenant.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
       
    }
}
