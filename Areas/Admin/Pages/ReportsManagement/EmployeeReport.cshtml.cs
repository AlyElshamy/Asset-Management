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
    public class EmployeeReportModel : PageModel
    {
        
        private readonly AssetContext _context;

        public EmployeeReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptEmployee Report { get; set; }
        static List<EmployeeModel> ShowAllList = new List<EmployeeModel>();
        public void OnGet()
        {
           ShowAllList = _context.Employees.Select(i => new EmployeeModel
            {
                FullName=i.FullName,
                EmployeeId=i.EmployeeId,
                Email=i.Email,
                Phone=i.Phone,
                Title=i.Title,
                Notes=i.Notes,
                Remark=i.Remark
            }).ToList();
            Report = new rptEmployee();
            //Report.DataSource = ds;
        }

        public void OnPost()
        {
           
                List<EmployeeModel> ds = _context.Employees.Select(i => new EmployeeModel
                {
                    FullName = i.FullName,
                    EmployeeId = i.EmployeeId,
                    Email = i.Email,
                    Phone = i.Phone,
                    Title = i.Title,
                    Notes = i.Notes,
                    Remark = i.Remark
                }).ToList();

                if (filterModel.ShowAll != false)
                {
                    ds = ShowAllList.ToList();
                }
                if (filterModel.EmployeeFullName != null)
                {
                    ds = ds.Where(i => i.FullName.Contains(filterModel.EmployeeFullName)).ToList();
                }
                if (filterModel.EmployeeIdStr != null)
                {
                    ds = ds.Where(i => i.EmployeeId.Contains(filterModel.EmployeeIdStr)).ToList();
                }
                if(filterModel.EmployeeFullName==null&& filterModel.EmployeeIdStr == null&& filterModel.ShowAll == false)
                {
                    ds = new List<EmployeeModel>();
                }
                Report = new rptEmployee();
                Report.DataSource = ds;
           
            
        }
    }
}

