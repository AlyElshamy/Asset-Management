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
    public class PrintCategoryModel : PageModel
    {
        private readonly AssetContext _context;

        public PrintCategoryModel(AssetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public int AssetId { get; set; }
        public rptCategory Report { get; set; }

        public void OnGet()
        {
            //List<Category> ds = _context.SubCategories.Select(i => new Category
            //{
            //   CategoryTIAR=i.Category.CategoryTIAR,
            //   SubCategoryDescription=i.SubCategoryDescription,
            //   SubCategoryTitle= i.SubCategoryTitle

            //}).ToList();
            Report = new rptCategory();
            //Report.DataSource = ds;
        }
        public void OnPost()
        {
            List<Category> ds = _context.SubCategories.Select(i => new Category
            {
                CategoryTIAR = i.Category.CategoryTIAR,
                SubCategoryDescription = i.SubCategoryDescription,
                SubCategoryTitle = i.SubCategoryTitle,
                CategoryId = i.Category.CategoryId


            }).ToList();

            if (filterModel.CategoryId != null)
            {
                ds = ds.Where(i => i.CategoryId == filterModel.CategoryId).ToList();
            }
            Report = new rptCategory();
            Report.DataSource = ds;
        }
    }
}
