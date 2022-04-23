using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryTIAR { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}