using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MobileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AssetContext _context { get; set; }
        public MobileController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AssetContext Context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = Context;
        }
        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> Login([FromQuery] string Email, [FromQuery] string Password)
        {

            var user = await _userManager.FindByEmailAsync(Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, Password, true);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null && roles.FirstOrDefault() == "Company")
                    {
                        return Ok(new { Status = "Success", Message = "User Login successfully!", user });
                    }
                }
            }
            var invalidResponse = new { status = false };
            return Ok(invalidResponse);
        }
        [HttpGet]
        public  IActionResult Search([FromQuery] string Parcode)
        {   
            if (Parcode !=null)
            {
                var items = _context.Assets.Where(c => c.AssetTagId.Contains(Parcode)
                || c.AssetSerialNo.Contains(Parcode)
                ).Select(i => new
                {
                    i.AssetTagId,
                    i.AssetSerialNo,
                   i.ItemId,
                   i.AssetCost,
                   i.AssetDescription,
                   i.AssetContracts,
                   i.AssetPhotos,
                   i.AssetStatus.AssetStatusTitle,
                   i.DepreciationMethod.DepreciationMethodTitle,
                   i.Item.ItemTitle,
                   i.Store.StoreTitle,
                   i.Vendor.VendorTitle,
                   i.Warranty.Length
                });
                return Ok(new { items } );
            }
            else
            {
                //var items = _context.Assets.Where(c => c.AssetTagId.Contains(Parcode)
                // || c.AssetSerialNo.Contains(Parcode)
                // ).Select(i => new
                // {
                //     i.ItemId,
                //     i.AssetCost,
                //     i.AssetDescription,
                //     i.AssetContracts,
                //     i.AssetPhotos,
                //     i.AssetSerialNo,
                //     i.AssetStatus.AssetStatusTitle,
                //     i.DepreciationMethod.DepreciationMethodTitle,
                //     i.Item.ItemTitle,
                //     i.Store.StoreTitle,
                //     i.Vendor.VendorTitle,
                //     i.Warranty.Length,
                //     IsFav = false
                // });
                return Ok(null);
            }
        }
    }
}
