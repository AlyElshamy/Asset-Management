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
    public class DisposeAssetReportModel : PageModel
    {
        
            private readonly AssetContext _context;

            public DisposeAssetReportModel(AssetContext context)
            {
                _context = context;
            }

            [BindProperty]
            public FilterModel filterModel { get; set; }
            public int AssetId { get; set; }
            public rptDisposeAsset Report { get; set; }

            public void OnGet()
            {
                Report = new rptDisposeAsset();
            }

            public void OnPost()
            {
                List<DisposeModel> ds = _context.AssetDisposeDetails.Select(i => new DisposeModel
                {
                    AssetCost = i.Asset.AssetCost,
                    AssetDescription = i.Asset.AssetDescription,
                    AssetSerialNo = i.Asset.AssetSerialNo,
                    AssetTagId = i.Asset.AssetTagId,
                    DateDisposed = i.DisposeAsset.DateDisposed,
                    DisposeNotes = i.DisposeAsset.Notes,
                    DisposeTo = i.DisposeAsset.DisposeTo
                }).ToList();

                if (filterModel.AssetTagId != null)
                {
                    ds = ds.Where(i => i.AssetTagId.Contains(filterModel.AssetTagId)).ToList();
                }
                if (filterModel.DisposeTo != null)
                {
                    ds = ds.Where(i => i.DisposeTo.Contains(filterModel.DisposeTo)).ToList();
                }
                if (filterModel.FromDate != null && filterModel.ToDate != null)
                {
                    ds = ds.Where(i => i.DateDisposed <= filterModel.ToDate && i.DateDisposed >= filterModel.FromDate).ToList();
                }
                if (filterModel.OnDay != null)
                {
                    ds = ds.Where(i => i.DateDisposed == filterModel.OnDay).ToList();
                }
                if (filterModel.OnDay == null&& filterModel.FromDate == null && filterModel.ToDate == null&& filterModel.DisposeTo == null&& filterModel.AssetTagId == null)
                {
                    ds = null;
                }

                Report = new rptDisposeAsset();
                Report.DataSource = ds;
            }
        }
    }

