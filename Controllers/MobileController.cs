  using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                        return Ok(new { Status = "Success", Message = "User Login successfully!", user });
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
                || c.AssetSerialNo.Contains(Parcode)||c.AssetId.ToString()==Parcode
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
                    DepreciationMethod = i.DepreciationMethod == null ? null : i.DepreciationMethod.DepreciationMethodTitle,
                    i.Item.ItemTitle,
                   i.Store.StoreTitle,
                   i.Vendor.VendorTitle,
                    i.Warranty
                });
                if (items.Count() == 0)
                    return Ok("No Matches Found");
                else
                    return Ok(new { items });
            }
            else
                return Ok("Enter Parcode To Search");
        }
        [HttpGet]
        public IActionResult Getassetinfobyid([FromQuery] int AssetId)
        {
            if (AssetId != 0)
            {
                var items = _context.Assets.Where(c => c.AssetId == AssetId
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
                    DepreciationMethod = i.DepreciationMethod == null ? null : i.DepreciationMethod.DepreciationMethodTitle,
                    i.Item.ItemTitle,
                    i.Store.StoreTitle,
                    i.Vendor.VendorTitle,
                    i.Warranty
                });
                if (items.Count() == 0)
                    return Ok("Wrong AssetId");
                else
                    return Ok(new { items });
            }
            else
                return Ok("Enter AssetId");
        }
        [HttpGet]
        public IActionResult Getassetinfobyserial([FromQuery] string AssetSerialno)
        {
            if (AssetSerialno != null)
            {
                var items = _context.Assets.Where(c => c.AssetSerialNo == AssetSerialno
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
                    DepreciationMethod = i.DepreciationMethod == null ? null : i.DepreciationMethod.DepreciationMethodTitle,
                    i.Item.ItemTitle,
                    i.Store.StoreTitle,
                    i.Vendor.VendorTitle,
                    i.Warranty,

                });
                if (items.Count() == 0)
                    return Ok("Wrong Serial Number");
                else
                    return Ok(new { items });
            }
            else
                return Ok("Enter Serial Number");
        }
        [HttpGet]
        public IActionResult Getassetinfobytag([FromQuery] string AssetTag)
        {
            if (AssetTag != null)
            {
                var items = _context.Assets.Where(c => c.AssetTagId == AssetTag
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
                    DepreciationMethod=i.DepreciationMethod==null?null: i.DepreciationMethod.DepreciationMethodTitle,
                    i.Item.ItemTitle,
                    i.Store.StoreTitle,
                    i.Vendor.VendorTitle,
                    i.Warranty
                });
                if (items.Count()==0)
                    return Ok("Wrong AssetTag");
                else
                return Ok(new { items });
            }
            else
                return Ok("Enter AssetTag");
        }
        [HttpGet]
        public IActionResult Getcheckedoutassets([FromQuery] string Search)
        {
            if (Search != null)
            {
                var items = _context.AssetMovementDetails
                   .Where(c =>c.Asset.AssetStatusId == 2&&(c.AssetMovement.Department.DepartmentTitle.Contains(Search)||c.AssetMovement.Employee.FullName.Contains(Search)||c.AssetMovement.Location.LocationTitle.Contains(Search)))
                   .Include(a=>a.AssetMovement)                
                .Select(i => new
                {
                    i.Asset.AssetTagId,
                    i.Asset.AssetSerialNo,
                    i.Asset.ItemId,
                    i.Asset.AssetCost,
                    i.Asset.AssetDescription,
                    i.Asset.AssetContracts,
                    i.Asset.AssetPhotos,
                    i.Asset.AssetStatus.AssetStatusTitle,
                    DepreciationMethod = i.Asset.DepreciationMethod == null ? null : i.Asset.DepreciationMethod.DepreciationMethodTitle,
                    i.Asset.Item.ItemTitle,
                    i.Asset.Store.StoreTitle,
                    i.Asset.Vendor.VendorTitle,
                    i.Asset.Warranty,
                    i.AssetMovement.Location.LocationTitle,
                    i.AssetMovement.Employee.FullName,
                    i.AssetMovement.Department.DepartmentTitle,
                    i.AssetMovement.AssetMovementDirection.AssetMovementDirectionTitle
                        
                });

                if (items.Count() == 0)
                    return Ok("No Matches Found");
                else
                    return Ok( items );
            }
            else
                return Ok("Enter employee or location or department to search");
        }
        [HttpGet]
        public IActionResult Getcheckedoutassetsbylocation([FromQuery] int LocationId)
        {
            var checkedoutassets = new List<AssetModel>();
            if (LocationId!=0)
            {
                var movementsForLocation = _context.AssetMovements.Where(a => a.LocationId == LocationId && a.AssetMovementDirectionId == 1).Include(a => a.AssetMovementDetails).ThenInclude(a => a.Asset);
                foreach (var item in movementsForLocation)
                {
                    foreach (var item2 in item.AssetMovementDetails)
                    {
                        if (item2.Asset.AssetStatusId == 2)
                        {
                            var lastassetmovement = _context.AssetMovementDetails.Where(a => a.AssetId == item2.AssetId && a.AssetMovement.AssetMovementDirectionId == 1).Include(a => a.AssetMovement).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                            if (lastassetmovement.AssetMovement.LocationId == LocationId)
                            {
                                checkedoutassets.Add(new AssetModel() { 
                                    AssetCost= item2.Asset.AssetCost,
                                    AssetDescription= item2.Asset.AssetDescription,
                                    AssetId= item2.Asset.AssetId,
                                    AssetLife= item2.Asset.AssetLife,
                                    AssetPurchaseDate= item2.Asset.AssetPurchaseDate,
                                    AssetSerialNo= item2.Asset.AssetSerialNo,
                                    AssetStatus= item2.Asset.AssetStatus,
                                    AssetStatusId= item2.Asset.AssetStatusId,
                                    AssetTagId= item2.Asset.AssetTagId,
                                    DateAcquired= item2.Asset.DateAcquired,
                                    DepreciableAsset= item2.Asset.DepreciableAsset,
                                    DepreciableCost= item2.Asset.DepreciableCost,
                                    DepreciationMethod= item2.Asset.DepreciationMethod,
                                    DepreciationMethodId= item2.Asset.DepreciationMethodId,
                                    Item= item2.Asset.Item,
                                    ItemId= item2.Asset.ItemId,
                                    Photo= item2.Asset.Photo,
                                    Store= item2.Asset.Store,
                                    SalvageValue= item2.Asset.SalvageValue,
                                    StoreId= item2.Asset.StoreId,
                                    Vendor= item2.Asset.Vendor,
                                    VendorId= item2.Asset.VendorId
                                });
                            }
}
                    }
                }
            }
            return Ok(checkedoutassets.Distinct());
        }
        [HttpGet]
        public IActionResult GetcheckedoutassetsbyDepartment([FromQuery] int DepartmentId)
        {
            var checkedoutassets = new List<AssetModel>();
            if (DepartmentId != 0)
            {
                var movementsForDepartment = _context.AssetMovements.Where(a => a.DepartmentId == DepartmentId && a.AssetMovementDirectionId == 1&&a.EmpolyeeID==null).Include(a => a.AssetMovementDetails).ThenInclude(a => a.Asset);
                foreach (var item in movementsForDepartment)
                {
                    foreach (var item2 in item.AssetMovementDetails)
                    {
                        if (item2.Asset.AssetStatusId == 2)
                        {
                            var lastassetmovement = _context.AssetMovementDetails.Where(a => a.AssetId == item2.AssetId && a.AssetMovement.AssetMovementDirectionId == 1).Include(a => a.AssetMovement).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                            if (lastassetmovement.AssetMovement.EmpolyeeID == null && lastassetmovement.AssetMovement.DepartmentId == DepartmentId)
                            {
                                checkedoutassets.Add(new AssetModel()
                                {
                                    AssetCost = item2.Asset.AssetCost,
                                    AssetDescription = item2.Asset.AssetDescription,
                                    AssetId = item2.Asset.AssetId,
                                    AssetLife = item2.Asset.AssetLife,
                                    AssetPurchaseDate = item2.Asset.AssetPurchaseDate,
                                    AssetSerialNo = item2.Asset.AssetSerialNo,
                                    AssetStatus = item2.Asset.AssetStatus,
                                    AssetStatusId = item2.Asset.AssetStatusId,
                                    AssetTagId = item2.Asset.AssetTagId,
                                    DateAcquired = item2.Asset.DateAcquired,
                                    DepreciableAsset = item2.Asset.DepreciableAsset,
                                    DepreciableCost = item2.Asset.DepreciableCost,
                                    DepreciationMethod = item2.Asset.DepreciationMethod,
                                    DepreciationMethodId = item2.Asset.DepreciationMethodId,
                                    Item = item2.Asset.Item,
                                    ItemId = item2.Asset.ItemId,
                                    Photo = item2.Asset.Photo,
                                    Store = item2.Asset.Store,
                                    SalvageValue = item2.Asset.SalvageValue,
                                    StoreId = item2.Asset.StoreId,
                                    Vendor = item2.Asset.Vendor,
                                    VendorId = item2.Asset.VendorId
                                });
                            }
}
                    }
                }
            }
            return Ok(checkedoutassets.Distinct());
        }
        [HttpGet]
        public IActionResult GetcheckedoutassetsbyEmployee([FromQuery] int EmpolyeeID)
        {
            var checkedoutassets = new List<AssetModel>();

            if (EmpolyeeID != 0)
            {
                var movementsForEmpolyee = _context.AssetMovements.Where(a => a.EmpolyeeID == EmpolyeeID && a.AssetMovementDirectionId == 1).Include(a => a.AssetMovementDetails).ThenInclude(a => a.Asset);
                foreach (var item in movementsForEmpolyee)
                {
                    foreach (var item2 in item.AssetMovementDetails)
                    {
                        if (item2.Asset.AssetStatusId == 2)
                        {
                            var lastassetmovement = _context.AssetMovementDetails.Where(a => a.AssetId == item2.AssetId && a.AssetMovement.AssetMovementDirectionId == 1).Include(a => a.AssetMovement).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                            if (lastassetmovement.AssetMovement.EmpolyeeID == EmpolyeeID)
                            {
                                checkedoutassets.Add(new AssetModel()
                                {
                                    AssetCost = item2.Asset.AssetCost,
                                    AssetDescription = item2.Asset.AssetDescription,
                                    AssetId = item2.Asset.AssetId,
                                    AssetLife = item2.Asset.AssetLife,
                                    AssetPurchaseDate = item2.Asset.AssetPurchaseDate,
                                    AssetSerialNo = item2.Asset.AssetSerialNo,
                                    AssetStatus = item2.Asset.AssetStatus,
                                    AssetStatusId = item2.Asset.AssetStatusId,
                                    AssetTagId = item2.Asset.AssetTagId,
                                    DateAcquired = item2.Asset.DateAcquired,
                                    DepreciableAsset = item2.Asset.DepreciableAsset,
                                    DepreciableCost = item2.Asset.DepreciableCost,
                                    DepreciationMethod = item2.Asset.DepreciationMethod,
                                    DepreciationMethodId = item2.Asset.DepreciationMethodId,
                                    Item = item2.Asset.Item,
                                    ItemId = item2.Asset.ItemId,
                                    Photo = item2.Asset.Photo,
                                    Store = item2.Asset.Store,
                                    SalvageValue = item2.Asset.SalvageValue,
                                    StoreId = item2.Asset.StoreId,
                                    Vendor = item2.Asset.Vendor,
                                    VendorId = item2.Asset.VendorId
                                });
                            }
                        }
                    }
                }

            }
            return Ok(checkedoutassets.Distinct() );
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.Select(e => e).ToList();
            return Ok(new { departments });
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var Employees = _context.Employees.Select(e => e).ToList();
            return Ok(new { Employees });
        }
        [HttpGet]
        public IActionResult GetLocations()
        {
            var Locations = _context.Locations.Select(e => e).ToList();
            return Ok(new { Locations });
        }
        }
}
