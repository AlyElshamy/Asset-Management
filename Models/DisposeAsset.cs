using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.Models
{
    public class DisposeAsset
    {
        public int DisposeAssetId { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { set; get; }
        [Column(TypeName = "date")]
        public DateTime DateDisposed { get; set; }
        public string DisposeTo { get; set; }
        public string Notes { get; set; }

    }
}
