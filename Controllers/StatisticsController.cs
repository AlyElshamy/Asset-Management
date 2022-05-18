using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AssetProject.Data;
using AssetProject.Models;
using AssetProject.ViewModel;

namespace AssetProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StatisticsController : Controller
    {
        private AssetContext _context;

        public StatisticsController(AssetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object GetAssetCountsPerCategory(DataSourceLoadOptions loadOptions)
        {

            var listEn = _context.Categories.GroupBy(c => c.CategoryId).Select(g => new
            {
                Name = _context.Categories.FirstOrDefault(r => r.CategoryId == g.Key).CategoryTIAR,
                Count = _context.Assets.Where(r => r.Item.CategoryId == g.Key).Count()

            }).OrderByDescending(r => r.Count);

         

            return listEn;
        }
        [HttpGet]
        public object GetAssetCostByCategory(DataSourceLoadOptions loadOptions)
        {
            var listEn = _context.Categories.GroupBy(c => c.CategoryId).Select(g => new
            {
                Name = _context.Categories.FirstOrDefault(r => r.CategoryId == g.Key).CategoryTIAR,
                Cost = _context.Assets.Where(r => r.Item.CategoryId == g.Key).Sum(s=>s.AssetCost)

            }).OrderByDescending(r => r.Cost);



            return listEn;
        }
        [HttpGet]
        public object GetAssetCostByDepartment(DataSourceLoadOptions loadOptions)
        {

                        var listEn = _context.Departments.GroupBy(c => c.DepartmentId).Select(g => new
            {
                Name = _context.Departments.FirstOrDefault(r => r.DepartmentId == g.Key).DepartmentTitle,
                Cost = _context.Assets.Include(a => a.AssetMovementDetails).ThenInclude(g=>g.AssetMovement)
                    .Where(a => a.AssetStatusId == 2 && a.AssetMovementDetails
                    .OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()
                    .AssetMovement.DepartmentId == g.Key).Sum(a => a.AssetCost)

          }).OrderByDescending(r => r.Cost);
            return listEn;

            
        }
        public object GetAssetCountByDepartment(DataSourceLoadOptions loadOptions)
        {

            var listEn = _context.Departments.GroupBy(c => c.DepartmentId).Select(g => new
            {
                Name = _context.Departments.FirstOrDefault(r => r.DepartmentId == g.Key).DepartmentTitle,
                Count = _context.Assets.Include(a => a.AssetMovementDetails).ThenInclude(g => g.AssetMovement)
        .Where(a => a.AssetStatusId == 2 && a.AssetMovementDetails
        .OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()
        .AssetMovement.DepartmentId == g.Key).Count()

            }).OrderByDescending(r => r.Count);
            return listEn;


        }
        [HttpGet]
        public object GetAssetCostByStatus(DataSourceLoadOptions loadOptions)
        {

            var listEn = _context.AssetStatuses.GroupBy(c => c.AssetStatusId).Select(g => new
            {
                Name = _context.AssetStatuses.FirstOrDefault(r => r.AssetStatusId == g.Key).AssetStatusTitle,
                Cost = _context.Assets.Where(r => r.AssetStatusId== g.Key).Sum(s => s.AssetCost)

            }).OrderByDescending(r => r.Cost);



            return listEn;
        }
        [HttpGet]
        public object GetAssetCountByStatus(DataSourceLoadOptions loadOptions)
        {

            var listEn = _context.AssetStatuses.GroupBy(c => c.AssetStatusId).Select(g => new
            {
                Name = _context.AssetStatuses.FirstOrDefault(r => r.AssetStatusId == g.Key).AssetStatusTitle,
                Count = _context.Assets.Where(r => r.AssetStatusId == g.Key).Count()
            }).OrderByDescending(r => r.Count);



            return listEn;
        }
      
        public object GetAssetCostByLocation(DataSourceLoadOptions loadOptions)
        {

            var listEn = _context.Locations.GroupBy(c => c.LocationId).Select(g => new
            {
                Name = _context.Locations.FirstOrDefault(r => r.LocationId == g.Key).LocationTitle,
                Cost = _context.Assets.Include(a => a.AssetMovementDetails).ThenInclude(g => g.AssetMovement)
        .Where(a => a.AssetStatusId == 2 
         && a.AssetMovementDetails
        .OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()
        .AssetMovement.LocationId == g.Key).Sum(a => a.AssetCost)

            }).OrderByDescending(r => r.Cost);
            return listEn;


        }
        public object GetAssetCountByLocation(DataSourceLoadOptions loadOptions)
        {

            var listEn = _context.Locations.GroupBy(c => c.LocationId).Select(g => new
            {
                Name = _context.Locations.FirstOrDefault(r => r.LocationId == g.Key).LocationTitle,
                Count = _context.Assets.Include(a => a.AssetMovementDetails).ThenInclude(g => g.AssetMovement)
        .Where(a => a.AssetStatusId == 2
         && a.AssetMovementDetails
        .OrderByDescending(a => a.AssetMovementDetailsId).FirstOrDefault()
        .AssetMovement.LocationId == g.Key).Count()

            }).OrderByDescending(r => r.Count);
            return listEn;


        }



    }
}