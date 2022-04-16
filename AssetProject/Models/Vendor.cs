using System.Collections.Generic;

namespace AssetProject.Models
{
    public class Vendor
    {
       public int VendorId { set; get; }
       public string VendorTitle { set; get; }
       public string Phone { set; get; }
       public string Mobile { set; get; }
       public  string Email { set; get; }
       public string Website { set; get; }
       public  string ContactPersonName { set; get; }
       public  string ContactPersonEmail { set; get; }
       public string ContactPersonPhone { set; get; }
       public virtual ICollection<Contract> Cotracts { get; set; }

    }
}
