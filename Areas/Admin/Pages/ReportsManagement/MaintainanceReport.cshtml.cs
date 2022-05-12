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
    public class MaintainanceReportModel : PageModel
    {
        private readonly AssetContext _context;

        public MaintainanceReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptMaintainance Report { get; set; }
        public void OnGet()
        {
            //List<MaintainanceModel> ds = _context.AssetMaintainances.Select(i => new MaintainanceModel
            //{
            //    AssetCost = i.Asset.AssetCost,
            //    AssetDescription = i.Asset.AssetDescription,
            //    AssetSerialNo = i.Asset.AssetSerialNo,
            //    AssetTagId = i.Asset.AssetTagId,
            //    AssetMaintainanceDateCompleted = i.AssetMaintainanceDateCompleted,
            //    AssetMaintainanceDueDate = i.AssetMaintainanceDueDate,
            //    AssetMaintainanceFrequencyTl = i.AssetMaintainanceFrequency.AssetMaintainanceFrequencyTitle,
            //    AssetMaintainanceRepairesCost = i.AssetMaintainanceRepairesCost,
            //    AssetMaintainanceTitle = i.AssetMaintainanceTitle,
            //    MaintainanceStatusTL = i.AssetMaintainanceTitle,
            //    TechnicianName = i.Technician.FullName,
            //    MonthTl = i.Month.MonthTitle,
            //    WeekDayTl = i.WeekDay.WeekDayTitle,
            //    TechnicianId = i.TechnicianId
            // }).ToList();
            Report = new rptMaintainance();
            //Report.DataSource = ds;
        }
        public void OnPost()
        {
            List<MaintainanceModel> ds = _context.AssetMaintainances.Select(i => new MaintainanceModel
            {
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                AssetMaintainanceDateCompleted = i.AssetMaintainanceDateCompleted,
                AssetMaintainanceDueDate = i.AssetMaintainanceDueDate,
                AssetMaintainanceFrequencyTl = i.AssetMaintainanceFrequency.AssetMaintainanceFrequencyTitle,
                AssetMaintainanceRepairesCost = i.AssetMaintainanceRepairesCost,
                AssetMaintainanceTitle = i.AssetMaintainanceTitle,
                MaintainanceStatusTL = i.AssetMaintainanceTitle,
                TechnicianName = i.Technician.FullName,
                MonthTl = i.Month.MonthTitle,
                WeekDayTl = i.WeekDay.WeekDayTitle,
                TechnicianId = i.TechnicianId
            }).ToList();
            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.TechnicianId != null)
            {
                ds = ds.Where(i => i.TechnicianId == filterModel.TechnicianId).ToList();
            }
            Report = new rptMaintainance();
            Report.DataSource = ds;
        }
    }
}
