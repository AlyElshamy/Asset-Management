using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetProject.Models
{
    public class Asset
    {
        public int AssetId { set; get; }
        [Required]
        public string AssetDescription { set; get; }
        [Required]
        public string AssetTagId { set; get; }
        public double AssetCost { set; get; }
        [Required]
        public string AssetSerialNo { set; get; }

        //[Column(TypeName = "date")]
        public DateTime AssetPurchaseDate { set; get; }
        public Item Item { set; get; }
        public int ItemId { set; get; }
        public string Photo { set; get; }
        [Required]
        public string PurchaseNo { get; set; }
        public bool DepreciableAsset { set; get; }
        public double? DepreciableCost { set; get; }
        public double? SalvageValue { set; get; }
        public int? AssetLife { set; get; }

        //[Column(TypeName = "date")]
        public DateTime? DateAcquired { set; get; }
        public DepreciationMethod DepreciationMethod { set; get; }
        public int? DepreciationMethodId { set; get; }
        public AssetStatus AssetStatus { set; get; }
        public int? AssetStatusId { set; get; }

        public int? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int? TenantId { get; set; }

        public virtual Tenant tenant { get; set; }
        public ICollection<AssetPhotos> AssetPhotos { set; get; }
        public ICollection<AssetContract> AssetContracts { get; set; }
        public ICollection<AssetsInsurance> AssetsInsurances { get; set; }
        public ICollection<AssetDocument> documents { get; set; }
        public ICollection<AssetMovementDetails> AssetMovementDetails{ get; set; }
        public ICollection<AssetLeasingDetails> AssetLeasingDetails{ get; set; }
        public ICollection<AssetLostDetails> AssetLostDetails{ get; set; }
        public ICollection<AssetDisposeDetails> AssetDisposeDetails{ get; set; }
        public ICollection<AssetRepairDetails> AssetRepairDetails{ get; set; }
        public ICollection<AssetSellDetails> AssetSellDetails{ get; set; }
        public ICollection<AssetBrokenDetails> AssetBrokenDetails{ get; set; }
        public ICollection<AssetWarranty> Warranty { get; set; }
        

    }
}
