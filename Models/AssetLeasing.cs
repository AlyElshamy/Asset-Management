using System;
using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class AssetLeasing
    {
        [Key]
        public int AssetLeasingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }



    }
}
