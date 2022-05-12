using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class AssetRepairRPTModel : PageModel
    {
        private readonly AssetContext _context;

        public AssetRepairRPTModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptAssetRepair Report { get; set; }
        public void OnGet()
        {
            Report = new rptAssetRepair();
        }

        public void OnPost()
        {
            List<AssetRepairRM> ds = _context.AssetRepairDetails.Select(a => new AssetRepairRM
            {
                AssetId=a.AssetId,
                AssetTagId=a.Asset.AssetTagId,
                AssetSerialNo=a.Asset.AssetSerialNo,
                AssetCost=a.Asset.AssetCost,
                AssetDescription=a.Asset.AssetDescription,
                AssetRepairId=a.AssetRepairId,
                ScheduleDate=a.AssetRepair.ScheduleDate,
                CompletedDate=a.AssetRepair.CompletedDate,
                RepairCost=a.AssetRepair.RepairCost,
                Notes=a.AssetRepair.Notes,
                TechnicianId=a.AssetRepair.TechnicianId,
                TechnicianName=a.AssetRepair.Technician.FullName

            }).ToList();


            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.TechnicianId != null)
            {
                ds = ds.Where(i => i.TechnicianId == filterModel.TechnicianId).ToList();
            }
            if (filterModel.Cost != null)
            {
                ds = ds.Where(i => i.RepairCost == filterModel.Cost).ToList();
            }
            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.ScheduleDate <= filterModel.ToDate && i.ScheduleDate >= filterModel.FromDate).ToList();
            }
            if (filterModel.AssetTagId == null && filterModel.FromDate == null && filterModel.ToDate == null && filterModel.TechnicianId == null&&filterModel.Cost==null)
            {
                ds = null;
            }

            Report = new rptAssetRepair();
            Report.DataSource = ds;
        }
    }
}
