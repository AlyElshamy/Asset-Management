using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class ContractReportModel : PageModel
    {
        private readonly AssetContext _context;

        public ContractReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptContract Report { get; set; }

        public void OnGet()
        {
            List<ContractModel> ds = _context.AssetContracts.Select(i => new ContractModel { 
            AssetCost=i.Asset.AssetCost,
            AssetDescription=i.Asset.AssetDescription,
            AssetSerialNo=i.Asset.AssetSerialNo,
            AssetTagId=i.Asset.AssetTagId,
            ContractNo=i.Contract.ContractNo,
            ContractTL=i.Contract.Title,
            ContractEndDate=i.Contract.StartDate,
            ItemTL=i.Asset.Item.ItemTitle,
            ContractStartDate=i.Contract.StartDate,
            Cost=i.Contract.Cost,
            Photo=i.Asset.Photo
            }).ToList();
            Report = new rptContract();
            Report.DataSource = ds;
        }

        public void OnPost()
        {
            List<ContractModel> ds = _context.AssetContracts.Select(i => new ContractModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                ContractNo = i.Contract.ContractNo,
                ContractTL = i.Contract.Title,
                ContractEndDate = i.Contract.StartDate,
                ItemTL = i.Asset.Item.ItemTitle,
                ContractStartDate = i.Contract.StartDate,
                Cost = i.Contract.Cost,
                Photo = i.Asset.Photo,
                ContractId=i.ContractId
            }).ToList();
            if (filterModel.ContractId != null)
            {
                ds = ds.Where(i => i.ContractId == filterModel.ContractId).ToList();
            }
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            Report = new rptContract();
            Report.DataSource = ds;
        }
    }
}
