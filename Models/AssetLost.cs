using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Models
{
    public class AssetLost
    {
        public int AssetLostId { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { set; get; }
        [Column(TypeName = "date")]
        public DateTime DateLost { get; set; }
        public string Notes { get; set; }
    }
}
