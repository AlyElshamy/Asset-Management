using AssetProject.Data;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class Transactions_HistoryRPTModel : PageModel
    {

        public Transactions_HistoryRPTModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptTransactionsHistory Report { get; set; }
        public AssetContext _context { get; }
        public void OnGet()
        {
            Report = new rptTransactionsHistory();
        }

        public void OnPost()
        {
            List<TransactionHistoryRM> ds = _context.AssetLogs.Select(a => new TransactionHistoryRM
            {
                ActionDate=a.ActionDate,
                Remark=a.Remark,
                AssetLogId=a.AssetLogId,
                ActionLogTitle=a.ActionLog.ActionLogTitle,
                AssetId=a.AssetId,
                ActionLogId=a.ActionLogId,
                AssetCost=a.Asset.AssetCost,
                AssetDescription=a.Asset.AssetDescription,
                AssetSerialNo=a.Asset.AssetSerialNo,
                AssetTagId=a.Asset.AssetTagId
            }).ToList();

            if (filterModel.AssetTagId != null)
            {
                ds = ds.Where(i => i.AssetTagId == filterModel.AssetTagId).ToList();
            }
            if (filterModel.ActionLogId != null)
            {
                ds = ds.Where(i => i.ActionLogId == filterModel.ActionLogId).ToList();
            }
            if (filterModel.FromDate != null && filterModel.ToDate != null)
            {
                ds = ds.Where(i => i.ActionDate <= filterModel.ToDate && i.ActionDate >= filterModel.FromDate).ToList();
            }
           
            if (filterModel.AssetTagId == null && filterModel.FromDate == null && filterModel.ToDate == null && filterModel.ActionLogId == null)
            {
                ds = null;
            }
            Report = new rptTransactionsHistory();
            Report.DataSource = ds;

        }
    }
}
