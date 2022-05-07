using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class assetreportModel : PageModel
    {
        public assetreportModel(AssetContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int AssetId { get; set; }
        public sampleblankreport Report { get; set; }
        public AssetContext _context { get; }

        public void OnGet()
        {
            Report = new sampleblankreport();
            var ds = _context.Assets.ToList();
            Report.DataSource = ds;

        }
    }
}
