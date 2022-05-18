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
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace AssetProject.Areas.Admin.Pages.AssetManagment
{
    [Authorize]
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
        [BindProperty]
        public int AssetId { set; get; }
        public AssetProfileModel(AssetContext context, IWebHostEnvironment hostEnvironment, IToastNotification toastNotification)
        {
            Context = context;
            _hostEnvironment = hostEnvironment;
            _toastNotification = toastNotification;
        }
        public IActionResult OnGet(int AssetId)
        {
            Asset = Context.Assets.Where(a => a.AssetId == AssetId).Include(a => a.Item).Include(a => a.DepreciationMethod).Include(a => a.AssetStatus).FirstOrDefault();
            if (Asset == null)
            {
                return Redirect("../../Error");

            }
            AssetPhoto = "/" + Asset.Photo;
            AssetId = Asset.AssetId;
            return Page();
        }

        public async Task<IActionResult> OnPostAddAssetPhotot(IFormFile file, AssetPhotos photos)
        {
            if (file != null)
            {
                string folder = "Images/AssetPhotos/";
                photos.PhotoUrl = await UploadImage(folder, file);
            }
            if (photos.AssetId != 0)
            {
                Context.AssetPhotos.Add(photos);
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 5,
                    AssetId = photos.AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($" Description : {photos.Remarks} ")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Photo Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = photos.AssetId });
            }
            _toastNotification.AddErrorToastMessage("Asset Photo Not ADDED ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = photos.AssetId });
        }
        public IActionResult OnGetDeletePhoto(int AssetId, int AssetPhotoId)
        {
            var Result = Context.AssetPhotos.Where(a => a.AssetId == AssetId && a.AssetPhotoId == AssetPhotoId).FirstOrDefault();

            Context.AssetPhotos.Remove(Result);
            AssetLog assetLog = new AssetLog()
            {
                ActionLogId = 9,
                AssetId = AssetId,
                ActionDate = DateTime.Now,
            };
            Context.AssetLogs.Add(assetLog);
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
            AssetLog assetLog = new AssetLog()
            {
                ActionLogId = 4,
                AssetId = instance.AssetId,
                ActionDate = DateTime.Now,
                Remark = string.Format($"Document Name : {instance.DocumentName} ")
            };
            Context.AssetLogs.Add(assetLog);
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
               
                string ContractTitle = "Contract Title : ";
                string ContractSDate = "Contract Start Date : ";
                string ContractEDate = "Contract End Date : ";
                Contract SelectedContract = Context.Contracts.Find(assetcontract.ContractId);
                string ContractStartDate = SelectedContract.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                string ContractEndDate = SelectedContract.EndDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 2,
                    AssetId    = assetcontract.AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"{ContractTitle}{SelectedContract.Title} , {ContractSDate}{ContractStartDate} and {ContractEDate}{ContractEndDate}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Link Contract Added Successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetcontract.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetcontract.AssetId });
        }
        public IActionResult OnpostAddAssetInsurance(AssetsInsurance assetsInsurance)
        {

            if (assetsInsurance.InsuranceId != 0 && assetsInsurance.AssetId != 0)
            {
                AssetsInsurance AssetIns = new AssetsInsurance { AssetId = assetsInsurance.AssetId, InsuranceId = assetsInsurance.InsuranceId };
                Context.AssetsInsurances.Add(AssetIns);
                
                string InsuranceTitle = "Insurance Title : ";
                string InsuranceCompany = "Insurance Company : ";
                Insurance SelectedInsurance = Context.Insurances.Find(assetsInsurance.InsuranceId);
                string InsuranceTit = SelectedInsurance.Title;
                string InsuranceComp = SelectedInsurance.InsuranceCompany;

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 3,
                    AssetId = assetsInsurance.AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"{InsuranceTitle}{InsuranceTit} and {InsuranceCompany}{InsuranceComp} ")
                };
                Context.AssetLogs.Add(assetLog);

                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Link Insurance Added Successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetsInsurance.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetsInsurance.AssetId });
        }

        public IActionResult OnPostAddAssetCheckOut(AssetMovement assetMovement)
        {

            if (ModelState.IsValid&&assetMovement.ActionTypeId!=null
                &&assetMovement.DepartmentId!=null&&assetMovement.LocationId!=null
                )
            {
                if (assetMovement.ActionTypeId == 1)
                {
                    if(assetMovement.EmpolyeeID==null)
                    {
                        _toastNotification.AddErrorToastMessage("Asset Movement Not Added ,Try again");
                        return Page();
                    }
                }
                var asset = Context.Assets.Find(AssetId);
                var LastAssetMovementDetails = Context.AssetMovementDetails.Where(a => a.AssetId == AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                if (LastAssetMovementDetails != null)
                {
                    var LastAssetMovement = Context.AssetMovements.Find(LastAssetMovementDetails.AssetMovementId);

                    if (LastAssetMovement != null)
                    {
                        assetMovement.StoreId = LastAssetMovement.StoreId;
                    }
                }
                else
                {
                    assetMovement.StoreId = asset.StoreId;

                }
                assetMovement.AssetMovementDirectionId = 1;
                asset.AssetStatusId = 2;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                assetMovement.AssetMovementDetails = new List<AssetMovementDetails>();
                assetMovement.AssetMovementDetails.Add(new AssetMovementDetails() { AssetId = AssetId, Remarks = "" });           
                Context.AssetMovements.Add(assetMovement);                        
                string ActionTitle = "Action Title : ";
                string TransDate = "Transaction Date : ";
                string DirectionTitle = "Direction Title : ";
                ActionType SelectedActionType = Context.ActionTypes.Find(assetMovement.ActionTypeId);
                AssetMovementDirection Direction = Context.AssetMovementDirections.Find(assetMovement.AssetMovementDirectionId);
                string TransactionDate = assetMovement.TransactionDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 17,
                    AssetId =AssetId ,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"{TransDate}{TransactionDate} and {ActionTitle}{SelectedActionType.ActionTypeTitle} and {DirectionTitle}{Direction.AssetMovementDirectionTitle}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Movement Added Successfully");
                return RedirectToPage("/ReportsManagement/CheckoutFormRPT", new { AssetMovement = assetMovement.AssetMovementId });
            }
            _toastNotification.AddErrorToastMessage("Asset Movement Not Added ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }

        public IActionResult OnPostAddAssetCheckIn(AssetMovement assetMovement)
        {

            if (ModelState.IsValid&&assetMovement.StoreId!=null)
            {
                var asset = Context.Assets.Find(AssetId);
                var LastAssetMovementDetails = Context.AssetMovementDetails.Where(a => a.AssetId == AssetId).OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault();
                if (LastAssetMovementDetails != null)
                {
                    var LastAssetMovement = Context.AssetMovements.Find(LastAssetMovementDetails.AssetMovementId);
                    assetMovement.ActionTypeId = LastAssetMovement.ActionTypeId;
                    assetMovement.DepartmentId = LastAssetMovement.DepartmentId;
                    assetMovement.LocationId = LastAssetMovement.LocationId;
                    assetMovement.EmpolyeeID = LastAssetMovement.EmpolyeeID;
                }
                assetMovement.AssetMovementDirectionId = 2;
                asset.AssetStatusId = 1;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                assetMovement.AssetMovementDetails = new List<AssetMovementDetails>();
                assetMovement.AssetMovementDetails.Add(new AssetMovementDetails() { AssetId = AssetId, Remarks = "" });
                Context.AssetMovements.Add(assetMovement);
                string DirectionTitle = "Direction Title : ";
                string TransDate = "Transaction Date : ";
                AssetMovementDirection Direction = Context.AssetMovementDirections.Find(assetMovement.AssetMovementDirectionId);
                string TransactionDate = assetMovement.TransactionDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 16,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"{TransDate}{TransactionDate} and {DirectionTitle}{Direction.AssetMovementDirectionTitle}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Movement Added Successfully");
                return RedirectToPage("/ReportsManagement/CheckInFormRPT", new { AssetMovement = assetMovement.AssetMovementId });
            }
            _toastNotification.AddErrorToastMessage("Asset Movement Not Added ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }

        public IActionResult OnPostAddAssetRepair(AssetRepair assetRepair)
        {
            if (ModelState.IsValid&&assetRepair.TechnicianId!=0)
            {

                //Update Asset Status
                var asset = Context.Assets.Find(AssetId);
                asset.AssetStatusId = 3;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                assetRepair.AssetRepairDetails = new List<AssetRepairDetails>();
                assetRepair.AssetRepairDetails.Add(new AssetRepairDetails { AssetId = AssetId, Remarks = "" });
                Context.AssetRepairs.Add(assetRepair);             
                Technician technician = Context.Technicians.Find(assetRepair.TechnicianId);
                string ScheduleDate = "Schedule Date : ";
                string CompletedDate = "Completed Date : ";
                string ScheduleD = assetRepair.ScheduleDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                string CompletedD = assetRepair.CompletedDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 13,
                    AssetId =AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Repair Asset Asigned to {technician.FullName} with {ScheduleDate}{ScheduleD} and {CompletedDate}{CompletedD}")
                };

                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Repair Added Successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
            }
            _toastNotification.AddErrorToastMessage("Asset Repair Not Added ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }
        public IActionResult OnpostAddAssetLost(AssetLost assetlost)
        {
            if (ModelState.IsValid && assetlost.DateLost.Date.Day > 1)
            {
                var asset = Context.Assets.Find(AssetId);
                assetlost.AssetLostDetails = new List<AssetLostDetails>();
                assetlost.AssetLostDetails.Add(new AssetLostDetails() { AssetId = AssetId, Remarks = "" });
                Context.AssetLosts.Add(assetlost);

                asset.AssetStatusId = 4;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                string LostDate = assetlost.DateLost.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 14,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Asset Lost Date {LostDate}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Broken Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new
                {
                    AssetId = AssetId
                });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }

        public IActionResult OnPostAddDisposeAsset(DisposeAsset disposeAsset)
        {
            if (ModelState.IsValid && disposeAsset.DateDisposed.Date.Day > 1)
            {
                var asset = Context.Assets.Find(AssetId);
                disposeAsset.AssetDisposeDetails = new List<AssetDisposeDetails>();
                disposeAsset.AssetDisposeDetails.Add(new AssetDisposeDetails() { AssetId = AssetId, Remarks = "" }
                );
                Context.DisposeAssets.Add(disposeAsset);
                asset.AssetStatusId = 5;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                string DisposeDate = "Dispose Date : ";
                string DisposeTo = "Disposed To  : ";
                string DisposeD = disposeAsset.DateDisposed.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                string DisposeFor = disposeAsset.DisposeTo;
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 12,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"{DisposeDate}{DisposeD} && {DisposeTo}{DisposeFor}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Dispose Asset Added successfully");

                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }

        public IActionResult OnpostAddAssetLeasing(AssetLeasing AssetLeasing)
        {
            if (ModelState.IsValid && AssetLeasing.StartDate.Date < AssetLeasing.EndDate)
            {

                var asset = Context.Assets.Find(AssetId);
                AssetLeasing.AssetLeasingDetails = new List<AssetLeasingDetails>();
                AssetLeasing.AssetLeasingDetails.Add(new AssetLeasingDetails() { AssetId = AssetId, Remarks = "" });
                Context.AssetLeasings.Add(AssetLeasing);

                asset.AssetStatusId = 6;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                string StartLeasingDate = AssetLeasing.StartDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                string EndLeasingDate = AssetLeasing.EndDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 15,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Leasing Asset Date is Between {StartLeasingDate} and {EndLeasingDate}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Leasing Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new
                {
                    AssetId = AssetId
                });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }


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

                string SaleD = Sellasset.SaleDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 10,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Sold Asset To {Sellasset.SoldTo} in Date {SaleD} With Amoun {Sellasset.SaleAmount}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Selling Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = AssetId });
        }

        public IActionResult OnpostAddAssetBroken(AssetBroken assetBroken)
        {

            if (ModelState.IsValid)
            {              
                var asset = Context.Assets.Find(AssetId);
                assetBroken.AssetBrokenDetails = new List<AssetBrokenDetails>();
                assetBroken.AssetBrokenDetails.Add(new AssetBrokenDetails() { AssetId = AssetId, Remarks = "" });
                Context.assetBrokens.Add(assetBroken);
               
                asset.AssetStatusId = 8;
                var UpdatedAsset = Context.Assets.Attach(asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                string BrockenDate = assetBroken.DateBroken.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 12,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Brocken Asset Date {BrockenDate}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Broken Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId =AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId =AssetId });
        }

        public IActionResult OnPostAddAssetMaintainance(AssetMaintainance assetMaintainance)
        {
            if (!assetMaintainance.AssetMaintainanceRepeating)
            {
                if (assetMaintainance.AssetMaintainanceFrequencyId != null ||
                    assetMaintainance.WeekDayId != null || assetMaintainance.WeeklyPeriod != null
                    || assetMaintainance.MonthlyDay != null || assetMaintainance.MonthlyPeriod != null
                    || assetMaintainance.YearlyDay != null || assetMaintainance.MonthId != null)
                {
                    _toastNotification.AddErrorToastMessage("Asset Maintainance Not Added ,Try again");
                    return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMaintainance.AssetId });
                }
            }
            if (ModelState.IsValid)
            {
                Context.AssetMaintainances.Add(assetMaintainance);
                Asset.AssetStatusId = 9;
                var UpdatedAsset = Context.Assets.Attach(Asset);
                UpdatedAsset.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                string DueDate = assetMaintainance.AssetMaintainanceDueDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                string CompletedDate = assetMaintainance.AssetMaintainanceDateCompleted.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

                AssetLog assetLog = new AssetLog()
                {
                    ActionLogId = 18,
                    AssetId = AssetId,
                    ActionDate = DateTime.Now,
                    Remark = string.Format($"Maintainance Asset with Title {assetMaintainance.AssetMaintainanceTitle} and DueDate {DueDate} and Completed Date {CompletedDate}")
                };
                Context.AssetLogs.Add(assetLog);
                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Asset Maintainance Added successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMaintainance.AssetId });
            }
            _toastNotification.AddErrorToastMessage("Asset Maintainance Not Added ,Try again");
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetMaintainance.AssetId });
        }

        public IActionResult OnpostDeattachAssetContract(AssetContract assetContract)
        {
            AssetContract _assetContract = Context.AssetContracts.Where(e => e.AssetContractID == assetContract.AssetContractID && e.AssetId == assetContract.AssetId).FirstOrDefault();
            try
            {
                Context.AssetContracts.Remove(_assetContract);
                _toastNotification.AddSuccessToastMessage("Asset Contract Dettached Succeffully");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Some Thing Went Error");
            }
            Contract contract = Context.Contracts.Find(assetContract.ContractId);
            
            AssetLog assetLog = new AssetLog()
            {
                ActionLogId = 6,
                AssetId = assetContract.AssetId,
                ActionDate = DateTime.Now,
                Remark = string.Format($"Dettached Asset Contract With Contract Name : {contract.Title} and Contract Number : {contract.ContractNo}")
            };
            Context.AssetLogs.Add(assetLog);

            Context.SaveChanges();
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetContract.AssetId });

        }
        public IActionResult OnpostDeattachAssetInsurance(AssetsInsurance assetInsurance)
        {
            AssetsInsurance _assetInsurance = Context.AssetsInsurances.Where(e => e.AssetsInsuranceId == assetInsurance.AssetsInsuranceId && e.AssetId == assetInsurance.AssetId).FirstOrDefault();
            try
            {
                Context.AssetsInsurances.Remove(_assetInsurance);
                _toastNotification.AddSuccessToastMessage("Asset Insurance Dettached Succeffully");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Some Thing Went Error");
            }
            Insurance insurance = Context.Insurances.Find(assetInsurance.InsuranceId);
           
            AssetLog assetLog = new AssetLog()
            {
                ActionLogId = 7,
                AssetId = assetInsurance.AssetId,
                ActionDate = DateTime.Now,
                Remark = string.Format($"Dettached Asset Insurance With Insurance Name : {insurance.Title} and Insurance Company : {insurance.InsuranceCompany}")
            };
            Context.AssetLogs.Add(assetLog);

            Context.SaveChanges();
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetInsurance.AssetId });

        }
        public IActionResult OnpostDeattachAssetDocument(AssetDocument assetDocument)
        {
            AssetDocument _assetDocument = Context.assetDocuments.Where(e => e.AssetDocumentId == assetDocument.AssetDocumentId && e.AssetId == assetDocument.AssetId).FirstOrDefault();
            string AssetDocName = _assetDocument.DocumentName;
            try
            {
                Context.assetDocuments.Remove(_assetDocument);
                _toastNotification.AddSuccessToastMessage("Asset Document Dettached Succeffully");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Some Thing Went Error");
            }
           
            AssetLog assetLog = new AssetLog()
            {
                ActionLogId = 8,
                AssetId = assetDocument.AssetId,
                ActionDate = DateTime.Now,
                Remark = string.Format($"Dettached Asset Document With Document Name : {AssetDocName} ")
            };
            Context.AssetLogs.Add(assetLog);
            Context.SaveChanges();
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetDocument.AssetId });

        }
        public IActionResult OnpostAddAssetWarranty(AssetWarranty assetWarranty)
        {

            if (assetWarranty.AssetId != 0)
            {
                AssetWarranty AssetWar = new AssetWarranty {AssetId=assetWarranty.AssetId, Length=assetWarranty.Length,Notes=assetWarranty.Notes,ExpirationDate=assetWarranty.ExpirationDate, };
                Context.AssetWarranties.Add(AssetWar); 
                //AssetLog assetLog = new AssetLog()
                //{
                //    ActionLogId = 20,
                //    AssetId = assetWarranty.AssetId,
                //    ActionDate = DateTime.Now,
                //    Remark = string.Format("Create Warranty")
                //};
                //Context.AssetLogs.Add(assetLog);

                Context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Link Warranty Added Successfully");
                return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetWarranty.AssetId });
            }

            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetWarranty.AssetId });
        }

        public IActionResult OnpostDeattachAssetWarranty(AssetWarranty assetwarranty)
        {
            AssetWarranty _assetwarranty = Context.AssetWarranties.Where(e => e.WarrantyId == assetwarranty.WarrantyId).FirstOrDefault();
            try
            {
                Context.AssetWarranties.Remove(_assetwarranty);
                _toastNotification.AddSuccessToastMessage("Asset Warranty Dettached Succeffully");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Some Thing Went Error");
            }
            //AssetWarranty insurance = Context.AssetWarranties.Find(assetwarranty.WarrantyId);
            //AssetLog assetLog = new AssetLog()
            //{
            //    ActionLogId = 7,
            //    AssetId = assetInsurance.AssetId,
            //    ActionDate = DateTime.Now,
            //    Remark = string.Format($"Dettached Asset Insurance With Insurance Name : {insurance.Title} and Insurance Company : {insurance.InsuranceCompany}")
            //};
            //Context.AssetLogs.Add(assetLog);

            Context.SaveChanges();
            return RedirectToPage("/AssetManagment/AssetProfile", new { AssetId = assetwarranty.AssetId });

        }
    }
}