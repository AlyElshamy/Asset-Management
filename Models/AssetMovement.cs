using System;
using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class AssetMovement
    {
        [Key]
        public int AssetMovementId { set; get; }
        public int AssetId { set; get; }
        public Asset Asset { set; get; }
        public DateTime TransactionDate { set; get; }
        public int EmpolyeeId { set; get; }
        public Employee Employee { set; get; }
        public int LocationId{ set; get; }
        public Location Location { set; get; }
        public int DepartmentId { set; get; }
        public Department Department { set; get; }
        public int ActionTypeId { set; get; }
        public ActionType ActionType { set; get; }
        public string Remarks { set; get; }

    }
}
