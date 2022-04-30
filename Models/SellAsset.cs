using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Models
{
    public class SellAsset
    {
        [Key]
        public int SellAssetId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public string SoldTo { get; set; }
        [Required]
        public double SaleAmount { get; set; }
        public string Notes { get; set; }
        [Required]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
    }
}
