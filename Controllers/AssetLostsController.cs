﻿using DevExtreme.AspNet.Data;
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

namespace AssetProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetLostsController : Controller
    {
        private AssetContext _context;

        public AssetLostsController(AssetContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var assetlosts = _context.AssetLosts.Select(i => new {
                i.AssetLostId,
                i.AssetId,
                i.DateLost,
                i.Notes,
                i.Asset
            });

            // If underlying data is a large SQL table, specify PrimaryKey and PaginateViaPrimaryKey.
            // This can make SQL execution plans more efficient.
            // For more detailed information, please refer to this discussion: https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "AssetLostId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(assetlosts, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new AssetLost();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.AssetLosts.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.AssetLostId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.AssetLosts.FirstOrDefaultAsync(item => item.AssetLostId == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.AssetLosts.FirstOrDefaultAsync(item => item.AssetLostId == key);

            _context.AssetLosts.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AssetsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Assets
                         orderby i.AssetDescription
                         select new {
                             Value = i.AssetId,
                             Text = i.AssetDescription
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(AssetLost model, IDictionary values) {
            string ASSET_LOST_ID = nameof(AssetLost.AssetLostId);
            string ASSET_ID = nameof(AssetLost.AssetId);
            string DATE_LOST = nameof(AssetLost.DateLost);
            string NOTES = nameof(AssetLost.Notes);

            if(values.Contains(ASSET_LOST_ID)) {
                model.AssetLostId = Convert.ToInt32(values[ASSET_LOST_ID]);
            }

            if(values.Contains(ASSET_ID)) {
                model.AssetId = Convert.ToInt32(values[ASSET_ID]);
            }

            if(values.Contains(DATE_LOST)) {
                model.DateLost = Convert.ToDateTime(values[DATE_LOST]);
            }

            if(values.Contains(NOTES)) {
                model.Notes = Convert.ToString(values[NOTES]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}