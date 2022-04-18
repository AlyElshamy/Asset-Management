using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class Brand
    {
        public int BrandId { set; get; }
        [Required]
        public string BrandTitle { set; get; }
        public virtual ICollection<Type> Types { get; set; }
    }
}
