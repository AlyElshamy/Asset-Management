using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    [Authorize]
    public class assetreportModel : PageModel
    {
        public assetreportModel(AssetContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManger = userManager;
        }
        [BindProperty]
        public int AssetId { get; set; }
        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptAssetReports Report { get; set; }
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }
        public AssetContext _context { get; }

        public async Task<IActionResult> OnGet()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptAssetReports(tenant);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            List<AssetReportsModel> ds = _context.Assets.Select(i => new AssetReportsModel
            {
                AssetCost = i.AssetCost,
                AssetDescription = i.AssetDescription,
                AssetLife = i.AssetLife,
                AssetPurchaseDate = i.AssetPurchaseDate,
                AssetSerialNo = i.AssetSerialNo,
                AssetStatusTL = i.AssetStatus.AssetStatusTitle,
                AssetTagId = i.AssetTagId,
                CategoryTL = i.Item.Category.CategoryTIAR,
                DateAcquired = i.DateAcquired,
                DepreciableCost = i.DepreciableCost,
                DepreciationMethodTL = i.DepreciationMethod.DepreciationMethodTitle,
                ItemTL = i.Item.ItemTitle,
                Photo = i.Photo,
                StoreTL = i.Store.StoreTitle,
                VendorTL = i.Vendor.VendorTitle,
                SalvageValue = i.SalvageValue,
                LocationTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()==null?null: _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationTitle,
                DepartmentTL = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? null : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentTitle,
                LocationId= _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault() == null ? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Location.LocationId,
                DepartmentId = _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()== null? 0 : _context.AssetMovementDetails.Where(a => a.AssetId == i.AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault().AssetMovement.Department.DepartmentId,
                CategoryId=i.Item.CategoryId,
                WarrantyId=i.Warranty.WarrantyId,
                WarrantyLenght=i.Warranty.Length
                
            }).ToList();
            

            if (filterModel.AssetTagId!=null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.LocationId!=null)
            {
                ds = ds.Where(i => i.LocationId == filterModel.LocationId).ToList();
            }
            if (filterModel.DepartmentId!=null)
            {
                ds = ds.Where(i => i.DepartmentId == filterModel.DepartmentId).ToList();
            }
            if (filterModel.CategoryId!=null)
            {
                ds = ds.Where(i => i.CategoryId == filterModel.CategoryId).ToList();
            }
             if (filterModel.warrantyId!=null)
            {
                ds = ds.Where(i => i.WarrantyId == filterModel.warrantyId).ToList();
            }

            if (filterModel.warrantyId == null&&filterModel.AssetTagId == null && filterModel.LocationId == null && filterModel.DepartmentId == null && filterModel.CategoryId == null)
            {
                ds =new List<AssetReportsModel>();
            }

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManger.FindByIdAsync(userid);
            tenant = _context.Tenants.Find(user.TenantId);
            tenant.Email = user.Email;
            tenant.Phone = user.PhoneNumber;
            Report = new rptAssetReports(tenant);
            return Page();
            Report.DataSource = ds;

        }
    }
}
