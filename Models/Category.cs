using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryTIAR { get; set; }
    }
}
