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
    public class LeasingReportModel : PageModel
    {
        private readonly AssetContext _context;

        public LeasingReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptLeasing Report { get; set; }

        public void OnGet()
        {
            List<LeasingModel> ds = _context.AssetLeasingDetails.Select(i => new LeasingModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                CustomerTL=i.AssetLeasing.Customer.FullName,
                LeasingEndDate=i.AssetLeasing.EndDate,
                LeasingStartDate=i.AssetLeasing.StartDate,
                AssetLeasingId=i.AssetLeasing.AssetLeasingId,
                CustomerId = i.AssetLeasing.Customer.CustomerId

            }).ToList();
            Report = new rptLeasing();
            Report.DataSource = ds;
        }
        public void OnPost()
        {
            List<LeasingModel> ds = _context.AssetLeasingDetails.Select(i => new LeasingModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                CustomerTL = i.AssetLeasing.Customer.FullName,
                LeasingEndDate = i.AssetLeasing.EndDate,
                LeasingStartDate = i.AssetLeasing.StartDate,
                AssetLeasingId=i.AssetLeasing.AssetLeasingId,
                CustomerId=i.AssetLeasing.Customer.CustomerId

            }).ToList();
            
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.CustomerId!=null)
            {
                ds = ds.Where(i => i.CustomerId == filterModel.CustomerId).ToList();
            }
            Report = new rptLeasing();
            Report.DataSource = ds;
        }
    }
    }

