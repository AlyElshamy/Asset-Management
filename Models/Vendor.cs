using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class Vendor
    {
       public int VendorId { set; get; }
        [Required]
       public string VendorTitle { set; get; }
        [Required]
        public string Phone { set; get; }
        [Required]
        public string Mobile { set; get; }
        [Required]
        [EmailAddress]
        public  string Email { set; get; }
        [Required]
        [Url]
        public string Website { set; get; }
        [Required]
        public  string ContactPersonName { set; get; }
        [Required]
        public  string ContactPersonEmail { set; get; }
        [Required]
        public string ContactPersonPhone { set; get; }
       public virtual ICollection<Contract> Cotracts { get; set; }

    }
}
