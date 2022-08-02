using AssetProject.Data;
using AssetProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;


namespace AssetProject.Areas.Admin.Pages.PatchProcess
{
    public class PatchTansferModel : PageModel
    {
        [BindProperty]
        public AssetMovement assetmovement { set; get; }
        AssetContext _context;
        public static List<Asset> SelectedAssets = new List<Asset>();
        public List<Asset> EmpoyeeAssets = new List<Asset>();
        public List<Asset> DepartmentAssets = new List<Asset>();

        private readonly IToastNotification _toastNotification;
        UserManager<ApplicationUser> UserManger;
        public Tenant tenant { set; get; }
        public PatchTansferModel(AssetContext context, IToastNotification toastNotification, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _toastNotification = toastNotification;
            assetmovement = new AssetMovement();
            UserManger = userManager;
        }

        public void OnGet()
        {

        }
        public IActionResult OnGetAssetsForDepartment(string values)
        {
            var DepartmentId = JsonConvert.DeserializeObject<int>(values);
            var movementsForDepartment = _context.AssetMovements.Where(a => a.DepartmentId == DepartmentId && a.AssetMovementDirectionId == 1 && a.EmpolyeeID == null).Include(a => a.AssetMovementDetails).ThenInclude(a => a.Asset);
            foreach (var item in movementsForDepartment)
            {
                foreach (var item2 in item.AssetMovementDetails)
                {
                    if (item2.Asset.AssetStatusId == 2)
                    {
                        var lastassetmovement = _context.AssetMovementDetails.Where(a => a.AssetId == item2.AssetId && a.AssetMovement.AssetMovementDirectionId == 1).Include(a => a.AssetMovement).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                        if (lastassetmovement.AssetMovement.EmpolyeeID == null && lastassetmovement.AssetMovement.DepartmentId == DepartmentId)
                        {
                            item2.Asset.AssetMovementDetails = null;
                            DepartmentAssets.Add(item2.Asset);
                        }

                    }
                }
            }

            return new JsonResult(DepartmentAssets.Distinct());
        }


        public IActionResult OnGetAssetsForEmpolyee(string values)
        {
            var EmpoyeeId = JsonConvert.DeserializeObject<int>(values);
            var movementsForEmpolyee = _context.AssetMovements.Where(a => a.EmpolyeeID == EmpoyeeId && a.AssetMovementDirectionId == 1).Include(a => a.AssetMovementDetails).ThenInclude(a => a.Asset);
            foreach (var item in movementsForEmpolyee)
            {
                foreach (var item2 in item.AssetMovementDetails)
                {
                    if (item2.Asset.AssetStatusId == 2)
                    {
                        var lastassetmovement = _context.AssetMovementDetails.Where(a => a.AssetId == item2.AssetId && a.AssetMovement.AssetMovementDirectionId == 1).Include(a => a.AssetMovement).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                        if (lastassetmovement.AssetMovement.EmpolyeeID == EmpoyeeId)
                        {
                            item2.Asset.AssetMovementDetails = null;
                            EmpoyeeAssets.Add(item2.Asset);
                        }
                    }
                }
            }

            return new JsonResult(EmpoyeeAssets.Distinct());
        }

    }
}
