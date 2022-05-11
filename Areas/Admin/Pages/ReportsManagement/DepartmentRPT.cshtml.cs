using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ReportModels;
using AssetProject.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AssetProject.Areas.Admin.Pages.ReportsManagement
{
    public class DepartmentRPTModel : PageModel
    {
        private readonly AssetContext _context;

        public DepartmentRPTModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public rptDepartmentReport Report { get; set; }
        public void OnGet()
        {
            List<Department> ds = _context.Departments.ToList();
            Report = new rptDepartmentReport();
            Report.DataSource = ds;
        }
       
        public void OnPost()
        {
            List<Department> ds = _context.Departments.ToList();
            if (filterModel.DepartmentTitle != null)
            {
                ds = ds.Where(d => d.DepartmentTitle.Contains(filterModel.DepartmentTitle)).ToList();
            }
            Report = new rptDepartmentReport();
            Report.DataSource = ds;
        }
    }
}
