using Microsoft.AspNetCore.Http;
using System;
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
        public DateTime AssetPurchaseDate { set; get; }
        public Item Item { set; get; }
        public int ItemId { set; get; }
        public string Photo { set; get; }
        [NotMapped]
        public IFormFile AssetPhoto { set; get; }
        public bool DepreciableAsset { set; get; }
        public double? DepreciableCost { set; get; }
        public double? SalvageValue { set; get; }
        public int? AssetLife { set; get; }
        public DateTime? DateAcquired { set; get; }
        public DepreciationMethod DepreciationMethod { set; get; }
        public int? DepreciationMethodId { set; get; }
    }
}
