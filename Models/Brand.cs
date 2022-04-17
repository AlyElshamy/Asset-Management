using System.Collections.Generic;

namespace AssetProject.Models
{
    public class Brand
    {
        public int BrandId { set; get; }
        public string BrandTitle { set; get; }
        public virtual ICollection<Type> Types { get; set; }
    }
}
