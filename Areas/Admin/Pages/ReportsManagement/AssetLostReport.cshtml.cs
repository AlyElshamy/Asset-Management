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
    public class AssetLostReportModel : PageModel
    {
        private readonly AssetContext _context;

        public AssetLostReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptAssetLost Report { get; set; }

        public void OnGet()
        {
           
            Report = new rptAssetLost();
        }
        public void OnPost()
        {
            List<AssetLostModel> ds = _context.AssetLostDetails.Select(i => new AssetLostModel
            {
                
                AssetCost = i.Asset.AssetCost,
                AssetDescription = i.Asset.AssetDescription,
                AssetSerialNo = i.Asset.AssetSerialNo,
                AssetTagId = i.Asset.AssetTagId,
                DateLost=i.AssetLost.DateLost,
                LostNotes=i.AssetLost.Notes
            }).ToList();

            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId.Contains(filterModel.AssetTagId)).ToList();
            }
            
            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.DateLost <= filterModel.ToDate && i.DateLost >= filterModel.FromDate).ToList();
            }
            if (filterModel.OnDay != null)
            {
                ds = ds.Where(i => i.DateLost == filterModel.OnDay).ToList();
            }
            if (filterModel.OnDay == null && filterModel.FromDate == null && filterModel.ToDate == null && filterModel.AssetTagId == null)
            {
                ds = null;
            }

            Report = new rptAssetLost();
            Report.DataSource = ds;
        }
    }
}
