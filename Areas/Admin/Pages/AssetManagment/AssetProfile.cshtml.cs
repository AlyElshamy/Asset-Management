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
using System.Globalization;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{

    public class AssetProfileModel : PageModel
    {
        AssetContext Context;
        public Asset Asset { set; get; }
        public string AssetPhoto { set; get; }
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IToastNotification _toastNotification;
        public AssetMovement AssetMovementModel { set; get; }
        public AssetRepair AssetrepairModel { set; get; }
        public AssetMaintainance AssetMaintainance { set; get; }
        public AssetProfileModel(AssetContext context, IWebHostEnvironment hostEnvironment, IToastNotification toastNotification)
        {
            Context = context;
            _hostEnvironment = hostEnvironment;
            _toastNotification = toastNotification;
        }
        //public IActionResult OnGet(int AssetId)
        //{
        //    Asset = Context.Assets.Where(a => a.AssetId == AssetId).Include(a => a.Item).Include(a => a.DepreciationMethod).Include(a=>a.AssetStatus).FirstOrDefault();
        //    if (Asset == null)
        //    {
        //        return Redirect("../../Error");

        //    }
        //    AssetPhoto = "/" + Asset.Photo;
        //    return Page();
        //}

        //public async Task<IActionResult> OnPostAddAssetPhotot(IFormFile file, AssetPhotos photos)
        //{
        //    if (file != null)
        //    {
        //        string folder = "Images/AssetPhotos/";
        //        photos.PhotoUrl = await UploadImage(folder, file);
        //    }
        //    if (photos.AssetId!=0)
        //    {
        //        Context.AssetPhotos.Add(photos);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Link Asset Photo" };
        //        Asset asset = Context.Assets.Find(photos.AssetId);
        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($" Description : {photos.Remarks} ")
        //        };
        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Asset Photo Added successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = photos.AssetId });
        //    }
        //    _toastNotification.AddErrorToastMessage("Asset Photo Not ADDED ,Try again");
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = photos.AssetId });
        //}
        //public IActionResult OnGetDeletePhoto(int AssetId,int AssetPhotoId)
        //{
        //    var Result = Context.AssetPhotos.Where(a => a.AssetId == AssetId && a.AssetPhotoId == AssetPhotoId).FirstOrDefault();

        //    Context.AssetPhotos.Remove(Result);
        //    ActionLog actionLog = new ActionLog() { ActionLogTitle = "Detached Asset Photo" };
        //    Asset asset = Context.Assets.Find(AssetId);
        //    AssetLog assetLog = new AssetLog()
        //    {
        //        ActionLog = actionLog,
        //        Asset = asset,
        //        ActionDate = DateTime.Now,
        //    };
        //    Context.AssetLogs.Add(assetLog);
        //    Context.SaveChanges();
        //    if (Result.PhotoUrl != null)
        //    {
        //        var ImagePath = Path.Combine(_hostEnvironment.WebRootPath, Result.PhotoUrl);
        //        if (System.IO.File.Exists(ImagePath))
        //        {
        //            System.IO.File.Delete(ImagePath);
        //        }
        //    }

        //    return new JsonResult(Result);
        //}
        //public async Task<IActionResult> OnPostAddAssetDocument(AssetDocument instance, IFormFile file)
        //{

        //    if (file != null)
        //    {

        //        string folder = "Documents/AssetDocuments/";
        //        instance.DocumentType = await UploadImage(folder, file);
        //    }


        //    Context.assetDocuments.Add(instance);
        //    ActionLog actionLog = new ActionLog() { ActionLogTitle = "Creation Link Asset Document" };
        //    Asset asset = Context.Assets.Find(instance.AssetId);
        //    AssetLog assetLog = new AssetLog()
        //    {
        //        ActionLog = actionLog,
        //        Asset = asset,
        //        ActionDate = DateTime.Now,
        //        Remark = string.Format($"Document Name : {instance.DocumentName} ")
        //    };
        //    Context.AssetLogs.Add(assetLog);
        //    Context.SaveChanges();
        //    _toastNotification.AddSuccessToastMessage("Asset Document Added successfully");
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = instance.AssetId });

        //}
        //private async Task<string> UploadImage(string folderPath, IFormFile file)
        //{

        //    folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        //    string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folderPath);

        //    await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        //    return folderPath;
        //}

        //public IActionResult OnpostAddAssetContract(AssetContract assetcontract)
        //{

        //    if (assetcontract.ContractId != 0 && assetcontract.AssetId != 0)
        //    {
        //        var Assetcont = new AssetContract { AssetId = assetcontract.AssetId, ContractId = assetcontract.ContractId };
        //        Context.AssetContracts.Add(Assetcont);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Creation Link Contract" };
        //        Asset asset = Context.Assets.Find(assetcontract.AssetId);
        //        string ContractTitle = "Contract Title : ";
        //        string ContractSDate = "Contract Start Date : ";
        //        string ContractEDate = "Contract End Date : ";
        //        Contract SelectedContract = Context.Contracts.Find(assetcontract.ContractId);
        //        string ContractStartDate = SelectedContract.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        string ContractEndDate = SelectedContract.EndDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"{ContractTitle}{SelectedContract.Title} , {ContractSDate}{ContractStartDate} and {ContractEDate}{ContractEndDate}")
        //        };
        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Link Contract Added Successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetcontract.AssetId });
        //    }

        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetcontract.AssetId });
        //}
        //public IActionResult OnpostAddAssetInsurance(AssetsInsurance assetsInsurance)
        //{

        //    if (assetsInsurance.InsuranceId != 0 && assetsInsurance.AssetId != 0)
        //    {
        //        AssetsInsurance AssetIns = new AssetsInsurance { AssetId = assetsInsurance.AssetId, InsuranceId = assetsInsurance.InsuranceId };
        //        Context.AssetsInsurances.Add(AssetIns);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Creation Link Insurance" };
        //        Asset asset = Context.Assets.Find(assetsInsurance.AssetId);
        //        string InsuranceTitle = "Insurance Title : ";
        //        string InsuranceCompany = "Insurance Company : ";
        //        Insurance SelectedInsurance = Context.Insurances.Find(assetsInsurance.InsuranceId);
        //        string InsuranceTit = SelectedInsurance.Title;
        //        string InsuranceComp = SelectedInsurance.InsuranceCompany;

        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"{InsuranceTitle}{InsuranceTit} and {InsuranceCompany}{InsuranceComp} ")
        //        };
        //        Context.AssetLogs.Add(assetLog);

        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Link Insurance Added Successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetsInsurance.AssetId });
        //    }

        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetsInsurance.AssetId });
        //}

        public IActionResult OnPostAddAssetCheckOut(AssetMovement assetMovement)
        {

        ////    if (ModelState.IsValid)
        ////    {
        ////        var Asset = Context.Assets.Find(AssetId);
        ////        var LastAssetMovementDetails = Context.AssetMovementDetails.Where(a => a.AssetId == AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
        ////        if (LastAssetMovementDetails != null)
        ////        {
        ////            var LastAssetMovement = Context.AssetMovements.Find(LastAssetMovementDetails.AssetMovementId);

        ////            if (LastAssetMovement == null)
        ////            {
        ////                assetMovement.StoreId = Asset.StoreId;
        ////            }
        ////            else
        ////            {
        ////                assetMovement.StoreId = LastAssetMovement.StoreId;
        ////            }

        ////        }
        ////        assetMovement.AssetMovementDirectionId = 1;
        ////        Asset.AssetStatusId = 2;
        ////        var UpdatedAsset = Context.Assets.Attach(Asset);
        ////        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        ////        Context.AssetMovements.Add(assetMovement);
        ////        var assetMovementDetails = new AssetMovementDetails()
        ////        {
        ////            AssetId = AssetId,
        ////            AssetMovementId = assetMovement.AssetMovementId
        ////        };
        ////        Context.AssetMovementDetails.Add(assetMovementDetails);
        ////        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Asset Checkout" };
        ////        Asset asset = Context.Assets.Find(AssetId);
        ////        string ActionTitle = "Action Title : ";
        ////        string TransDate = "Transaction Date : ";
        ////        ActionType SelectedActionType = Context.ActionTypes.Find(assetMovement.ActionTypeId);
        ////        string TransactionDate = assetMovement.TransactionDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        ////        AssetLog assetLog = new AssetLog()
        ////        {
        ////            ActionLog = actionLog,
        ////            Asset = asset,
        ////            ActionDate = DateTime.Now,
        ////            Remark = string.Format($"{TransDate}{TransactionDate} and {ActionTitle}{SelectedActionType.ActionTypeTitle}")
        ////        };
        ////        Context.AssetLogs.Add(assetLog);
        ////        Context.SaveChanges();
        ////        _toastNotification.AddSuccessToastMessage("Asset Movement Added Successfully");
        ////        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId =AssetId });
        ////    }
        ////    _toastNotification.AddErrorToastMessage("Asset Movement Not Added ,Try again");
        ////    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        ////}

        ////public IActionResult OnPostAddAssetCheckIn(AssetMovement assetMovement,int AssetId)
        ////{

        ////    if (ModelState.IsValid)
        ////    {
        ////        var Asset = Context.Assets.Find(AssetId);
        ////        var LastAssetMovementDetails = Context.AssetMovementDetails.Where(a=>a.AssetId==AssetId).OrderByDescending(a=>a.AssetMovementDetailsId).FirstOrDefault();
        ////        if (LastAssetMovementDetails != null)
        ////        {
        ////            var LastAssetMovement = Context.AssetMovements.Find(LastAssetMovementDetails.AssetMovementId);                   
        ////            assetMovement.ActionTypeId = LastAssetMovement.ActionTypeId;
        ////            assetMovement.DepartmentId = LastAssetMovement.DepartmentId;
        ////            assetMovement.LocationId = LastAssetMovement.LocationId;
        ////            assetMovement.EmpolyeeID = LastAssetMovement.EmpolyeeID;
        ////        }
        ////        assetMovement.AssetMovementDirectionId = 2;
        ////        Asset.AssetStatusId = 1;
        ////        var UpdatedAsset = Context.Assets.Attach(Asset);
        ////        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        ////        Context.AssetMovements.Add(assetMovement);
        ////        var assetMovementDetails = new AssetMovementDetails()
        ////        {
        ////            AssetId = AssetId,
        ////            AssetMovementId = assetMovement.AssetMovementId
        ////        };
        ////        Context.AssetMovementDetails.Add(assetMovementDetails);
        ////        Context.SaveChanges();
        ////        _toastNotification.AddSuccessToastMessage("Asset Movement Added Successfully");
        ////        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId =AssetId });
        ////    }
        ////    _toastNotification.AddErrorToastMessage("Asset Movement Not Added ,Try again");
        ////    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId =AssetId });
        ////}

        //public IActionResult OnPostAddAssetRepair(AssetRepair assetRepair)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        //Update Asset Status

        //        Asset.AssetStatusId = 3;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        //        assetRepair.AssetRepairDetails.Add(new AssetRepairDetails  { AssetId=Asset.AssetId,Remarks="" });

        //        Context.AssetRepairs.Add(assetRepair);

        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Repair Asset " };
        //        Technician technician = Context.Technicians.Find(assetRepair.TechnicianId);
        //        string ScheduleDate = "Schedule Date : ";
        //        string CompletedDate = "Completed Date : ";
        //        string ScheduleD = assetRepair.ScheduleDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        string CompletedD = assetRepair.CompletedDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            AssetId = Asset.AssetId,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"Repair Asset Asigned to {technician.FullName} with {ScheduleDate}{ScheduleD} and {CompletedDate}{CompletedD}")
        //        };

        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Asset Repair Added Successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Asset.AssetId });
        //    }
        //    _toastNotification.AddErrorToastMessage("Asset Repair Not Added ,Try again");
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Asset.AssetId });
        //}

        //public IActionResult OnpostAddAssetLost(AssetLost assetlost)
        //{
        //    if (Asset.AssetId != 0)
        //    {
        //        Asset.AssetStatusId = 4;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        //        var AssetLost = new AssetLost { AssetId = assetlost.AssetId, DateLost = assetlost.DateLost, Notes = assetlost.Notes, };
        //        AssetLost.AssetLostDetails.Add(new AssetLostDetails() { AssetId = Asset.AssetId, Remarks = "" });

        //        Context.AssetLosts.Add(AssetLost);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Lost Asset " };
        //        Asset asset = Context.Assets.Find(Asset.AssetId);
        //        string LostDate = "Lost Date : ";
        //        string LostD = assetlost.DateLost.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"{LostDate}{LostD}")
        //        };
        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Asset Lost Added successfully");

        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Asset.AssetId });
        //    }

        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Asset.AssetId });
        //}
        //public IActionResult OnPostAddDisposeAsset(DisposeAsset disposeAsset)
        //{
        //    if (disposeAsset.AssetId != 0)
        //    {
        //        Asset.AssetStatusId = 5;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        var Disposeasset = new DisposeAsset { AssetId = disposeAsset.AssetId, DateDisposed = disposeAsset.DateDisposed, Notes = disposeAsset.Notes, DisposeTo = disposeAsset.DisposeTo };
        //        Disposeasset.AssetDisposeDetails.Add(new AssetDisposeDetails() { AssetId = Asset.AssetId, Remarks = "" });

        //        Context.DisposeAssets.Add(Disposeasset);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Dispose Asset " };
        //        Asset asset = Context.Assets.Find(disposeAsset.AssetId);
        //        string DisposeDate = "Dispose Date : ";
        //        string DisposeTo = "Disposed To  : ";
        //        string DisposeD = disposeAsset.DateDisposed.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        string DisposeFor = disposeAsset.DisposeTo;
        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"{DisposeDate}{DisposeD} && {DisposeTo}{DisposeFor}")
        //        };
        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Dispose Asset Added successfully");


        public IActionResult OnpostAddAssetsell(SellAsset Sellasset)
        {
            if (ModelState.IsValid && Sellasset.SaleDate.Date.Day > 1)
            {
                var asset = Context.Assets.Find(AssetId);
                Sellasset.AssetSellDetails = new List<AssetSellDetails>();
                Sellasset.AssetSellDetails.Add(new AssetSellDetails() { AssetId = AssetId, Remarks = "" }
                );
                Context.sellAssets.Add(Sellasset);
                asset.AssetStatusId = 7;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        //public IActionResult OnpostAddAssetLeasing(AssetLeasing AssetLeasing)
        //{
        //    AssetLeasing assetlea = new AssetLeasing { CustomerId = AssetLeasing.CustomerId, AssetId = AssetLeasing.AssetId, StartDate = AssetLeasing.StartDate, EndDate = AssetLeasing.EndDate, Notes = AssetLeasing.Notes };
        //    if (AssetLeasing.AssetId != 0)
        //    {
        //        Asset.AssetStatusId = 6;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        assetlea.AssetLeasingDetails.Add(new AssetLeasingDetails() { AssetId = Asset.AssetId, Remarks = "" });
        //        Context.AssetLeasings.Add(assetlea);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Asset Leasing" };
        //        Asset asset = Context.Assets.Find(AssetLeasing.AssetId);
        //        string StartD = AssetLeasing.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        string EndD = AssetLeasing.EndDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        Customer customer = Context.Customers.Find(AssetLeasing.CustomerId);
        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"Asset Leasing For {customer.FullName} from {StartD} To {EndD}")
        //        };
        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Asset Leasing Added successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetLeasing.AssetId });
        //    }

        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetLeasing.AssetId });
        //}
        //public IActionResult OnpostAddAssetsell(SellAsset Sellasset)
        //{
        //    SellAsset assetsell = new SellAsset { AssetId = Sellasset.AssetId, Notes = Sellasset.Notes, SaleAmount = Sellasset.SaleAmount, SaleDate = Sellasset.SaleDate, SoldTo = Sellasset.SoldTo };
        //    if (Sellasset.AssetId != 0)
        //    {
        //        Asset.AssetStatusId = 7;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        assetsell.AssetSellDetails.Add(new AssetSellDetails() { AssetId = Asset.AssetId, Remarks = "" });
        //        Context.sellAssets.Add(assetsell);
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Sell Asset" };
        //        Asset asset = Context.Assets.Find(Sellasset.AssetId);
        //        string SaleD = Sellasset.SaleDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }

        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = Sellasset.AssetId });
        //}
        public IActionResult OnpostAddAssetBroken(AssetBroken assetBroken)
        {

        //    if (assetBroken.AssetId != 0)
        //    {
        //        AssetBroken assetBroke = new AssetBroken { AssetId = assetBroken.AssetId, DateBroken = assetBroken.DateBroken, Notes = assetBroken.Notes };
        //        Context.assetBrokens.Add(assetBroke);
        //        var Asset = Context.Assets.Find(assetBroken.AssetId);
        //        Asset.AssetStatusId = 8;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        ActionLog actionLog = new ActionLog() { ActionLogTitle = "Broken Asset" };
        //        Asset asset = Context.Assets.Find(assetBroken.AssetId);
        //        string BrockenDate = assetBroken.DateBroken.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

        //        AssetLog assetLog = new AssetLog()
        //        {
        //            ActionLog = actionLog,
        //            Asset = asset,
        //            ActionDate = DateTime.Now,
        //            Remark = string.Format($"Brocken Asset Date {BrockenDate}")
        //        };
        //        Context.AssetLogs.Add(assetLog);
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Asset Broken Added successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetBroken.AssetId });
        //    }

        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetBroken.AssetId });
        //}

        //public IActionResult OnPostAddAssetMaintainance(AssetMaintainance assetMaintainance)
        //{
        //    if (!assetMaintainance.AssetMaintainanceRepeating)
        //    {
        //        if(assetMaintainance.AssetMaintainanceFrequencyId!=null || 
        //            assetMaintainance.WeekDayId!=null ||assetMaintainance.WeeklyPeriod !=null
        //            || assetMaintainance.MonthlyDay !=null || assetMaintainance.MonthlyPeriod !=null
        //            || assetMaintainance.YearlyDay !=null ||assetMaintainance.MonthId!=null)
        //        {
        //            _toastNotification.AddErrorToastMessage("Asset Maintainance Not Added ,Try again");
        //            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMaintainance.AssetId });
        //        }
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Context.AssetMaintainances.Add(assetMaintainance);
        //        var Asset = Context.Assets.Find(assetMaintainance.AssetId);
        //        Asset.AssetStatusId = 9;
        //        var UpdatedAsset = Context.Assets.Attach(Asset);
        //        UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        Context.SaveChanges();
        //        _toastNotification.AddSuccessToastMessage("Asset Maintainance Added successfully");
        //        return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMaintainance.AssetId });
        //    }
        //    _toastNotification.AddErrorToastMessage("Asset Maintainance Not Added ,Try again");
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMaintainance.AssetId });
        //}

        //public IActionResult OnpostDeattachAssetContract(AssetContract assetContract)
        //{
        //    AssetContract _assetContract = Context.AssetContracts.Where(e => e.AssetContractID == assetContract.AssetContractID && e.AssetId == assetContract.AssetId).FirstOrDefault();
        //    try
        //    {
        //        Context.AssetContracts.Remove(_assetContract);
        //        _toastNotification.AddSuccessToastMessage("Asset Contract Dettached Succeffully");
        //    }
        //    catch (Exception)
        //    {
        //        _toastNotification.AddErrorToastMessage("Some Thing Went Error");
        //    }
        //    Contract contract = Context.Contracts.Find(assetContract.ContractId);
        //    ActionLog actionLog = new ActionLog() { ActionLogTitle = "Dettached Asset Contract" };
        //    Asset asset = Context.Assets.Find(assetContract.AssetId);
        //    AssetLog assetLog = new AssetLog()
        //    {
        //        ActionLog = actionLog,
        //        Asset = asset,
        //        ActionDate = DateTime.Now,
        //        Remark = string.Format($"Dettached Asset Contract With Contract Name : {contract.Title} and Contract Number : {contract.ContractNo}")
        //    };
        //    Context.AssetLogs.Add(assetLog);

        //    Context.SaveChanges();
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetContract.AssetId });

        //}
        //public IActionResult OnpostDeattachAssetInsurance(AssetsInsurance assetInsurance)
        //{
        //    AssetsInsurance _assetInsurance = Context.AssetsInsurances.Where(e => e.AssetsInsuranceId == assetInsurance.AssetsInsuranceId && e.AssetId == assetInsurance.AssetId).FirstOrDefault();
        //    try
        //    {
        //        Context.AssetsInsurances.Remove(_assetInsurance);
        //        _toastNotification.AddSuccessToastMessage("Asset Insurance Dettached Succeffully");
        //    }
        //    catch (Exception)
        //    {
        //        _toastNotification.AddErrorToastMessage("Some Thing Went Error");
        //    }
        //    Insurance insurance = Context.Insurances.Find(assetInsurance.InsuranceId);
        //    ActionLog actionLog = new ActionLog() { ActionLogTitle = "Dettached Asset Insurance" };
        //    Asset asset = Context.Assets.Find(assetInsurance.AssetId);
        //    AssetLog assetLog = new AssetLog()
        //    {
        //        ActionLog = actionLog,
        //        Asset = asset,
        //        ActionDate = DateTime.Now,
        //        Remark = string.Format($"Dettached Asset Insurance With Insurance Name : {insurance.Title} and Insurance Company : {insurance.InsuranceCompany}")
        //    };
        //    Context.AssetLogs.Add(assetLog);

        //    Context.SaveChanges();
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetInsurance.AssetId });

        //}
        //public IActionResult OnpostDeattachAssetDocument(AssetDocument assetDocument)
        //{
        //    AssetDocument _assetDocument = Context.assetDocuments.Where(e => e.AssetDocumentId == assetDocument.AssetDocumentId && e.AssetId == assetDocument.AssetId).FirstOrDefault();
        //    string AssetDocName = _assetDocument.DocumentName;
        //    try
        //    {
        //        Context.assetDocuments.Remove(_assetDocument);
        //        _toastNotification.AddSuccessToastMessage("Asset Document Dettached Succeffully");
        //    }
        //    catch (Exception)
        //    {
        //        _toastNotification.AddErrorToastMessage("Some Thing Went Error");
        //    }
        //    ActionLog actionLog = new ActionLog() { ActionLogTitle = "Dettached Asset Document" };
        //    Asset asset = Context.Assets.Find(assetDocument.AssetId);
        //    AssetLog assetLog = new AssetLog()
        //    {
        //        ActionLog = actionLog,
        //        Asset = asset,
        //        ActionDate = DateTime.Now,
        //        Remark = string.Format($"Dettached Asset Document With Document Name : {AssetDocName} ")
        //    };
        //    Context.AssetLogs.Add(assetLog);
        //    Context.SaveChanges();
        //    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetDocument.AssetId });

        //}
    }
}