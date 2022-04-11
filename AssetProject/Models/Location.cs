using System.Collections.Generic;

namespace AssetProject.Models
{
    public partial class Location
    {
        public Location()
        {
            InverseLocationParent = new HashSet<Location>();
        }

        public int LocationId { get; set; }
        public int? LocationParentId { get; set; }
        public string LocationTitle { get; set; }
        public int? CountryId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public virtual Location LocationParent { get; set; }
        public virtual ICollection<Location> InverseLocationParent { get; set; }

    }
}
