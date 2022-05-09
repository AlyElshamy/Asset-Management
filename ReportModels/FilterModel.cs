using AssetProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetProject.ReportModels
{
    public class FilterModel
    {
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }

        public string AssetTagId { set; get; }
        public double AssetCost { set; get; }
        public string AssetSerialNo { set; get; }
        public DateTime? AssetPurchaseDate { set; get; }
        public Item Item { set; get; }
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        public string PurchaseSerial { get; set; }
        public int? ItemId { set; get; }
        public DepreciationMethod DepreciationMethod { set; get; }
        public int? DepreciationMethodId { set; get; }
        public Vendor Vendor { set; get; }
        public int? VendorId  { set; get; }
    }
}
