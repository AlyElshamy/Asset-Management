using Microsoft.AspNetCore.Http;
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

        [Column(TypeName = "date")]
        public DateTime AssetPurchaseDate { set; get; }
        public Item Item { set; get; }
        public int ItemId { set; get; }
        public string Photo { set; get; }

        public bool DepreciableAsset { set; get; }
        public double? DepreciableCost { set; get; }
        public double? SalvageValue { set; get; }
        public int? AssetLife { set; get; }

        [Column(TypeName = "date")]
        public DateTime? DateAcquired { set; get; }
        public DepreciationMethod DepreciationMethod { set; get; }
        public int? DepreciationMethodId { set; get; }
        public AssetStatus AssetStatus { set; get; }
        public int? AssetStatusId { set; get; }

        public int? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }


        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        public ICollection<AssetPhotos> AssetPhotos { set; get; }
        public ICollection<AssetContract> AssetContracts { get; set; }
        public ICollection<AssetsInsurance> AssetsInsurances { get; set; }
        public ICollection<AssetDocument> documents { get; set; }

    }
}
