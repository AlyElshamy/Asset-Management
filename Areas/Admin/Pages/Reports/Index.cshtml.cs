using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssetProject.Areas.Admin.Pages.Reports
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AssetContext _context;

        public IndexModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int DepartmentId { get; set; }

        public rptDepartments Report { get; set; }

        public void OnGet()
        {
           

        }

        public void OnPost()
        {
            Report = new rptDepartments();
            var ds = _context.Departments.ToList();
            Report.DataSource = ds;
            Report.Parameters[0].Value = DepartmentId;
            Report.RequestParameters = false;
            //Report.DataMember = "Departments";

        }

    }
}
