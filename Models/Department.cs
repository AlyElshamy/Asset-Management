using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentTitle { get; set; }
    }
}
