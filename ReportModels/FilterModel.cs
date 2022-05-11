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
        public string PurchaseSerial { get; set; }
        public int? ItemId { set; get; }
        public DepreciationMethod DepreciationMethod { set; get; }
        public int? DepreciationMethodId { set; get; }
        public Vendor Vendor { set; get; }
        public int? VendorId  { set; get; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public Location Location { get; set; }
        public int? LocationId { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public int? employeeId { get; set; }
        public Employee employee { get; set; }
        public int? ContractId { get; set; }
        //public Contract Contract { get; set; }
        public int? InsuranceId { get; set; }
        public int? CustomerId { get; set; }
        public string DepartmentTitle { set; get; }
        public int StatusId { get; set; }


    }
}
