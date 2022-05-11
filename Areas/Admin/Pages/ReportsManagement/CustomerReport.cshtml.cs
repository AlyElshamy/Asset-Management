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
    public class CustomerReportModel : PageModel
    {
        private readonly AssetContext _context;

        public CustomerReportModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptCustomer Report { get; set; }

        public void OnGet()
        {
            List<CustomerModel> ds = _context.Customers.Select(i => new CustomerModel
            {
                CompanyName=i.CompanyName,
                City=i.City,
                Country=i.Country,
                CustomerId=i.CustomerId,
                Address1=i.Address1,
                Address2=i.Address2,
                Email=i.Email,
                FullName=i.FullName,
                Notes=i.Notes,
                Phone=i.Phone,
                PostalCode=i.PostalCode,
                State=i.State
            }).ToList();
            Report = new rptCustomer();
            Report.DataSource = ds;
        }

        public void OnPost()
        {
            List<CustomerModel> ds = _context.Customers.Select(i => new CustomerModel
            {
                CompanyName = i.CompanyName,
                City = i.City,
                Country = i.Country,
                CustomerId = i.CustomerId,
                Address1 = i.Address1,
                Address2 = i.Address2,
                Email = i.Email,
                FullName = i.FullName,
                Notes = i.Notes,
                Phone = i.Phone,
                PostalCode = i.PostalCode,
                State = i.State
            }).ToList();
            if (filterModel.CustomerName != null)
            {
                ds = ds.Where(i => i.FullName.Contains(filterModel.CustomerName)).ToList();
            }
            if (filterModel.CompanyName != null)
            {
                ds = ds.Where(i => i.CompanyName.Contains(filterModel.CompanyName)).ToList();
            }
            Report = new rptCustomer();
            Report.DataSource = ds;
        }
    }
}
