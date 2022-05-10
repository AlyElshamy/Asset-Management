using AssetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.ReportModels
{
    public class AssetCheckOutList
    {
        public int AssetMovementId { set; get; }
        public int AssetId { set; get; }
        public string AssetTL { set; get; }
        public DateTime TransactionDate { set; get; }
        public string EmployeeFullN { set; get; }
        public string LocationTl { set; get; }
        public string DepartmentTl { set; get; }
        public string StoreTl { set; get; }
        public string ActionTypeTl { set; get; }
        public string AssetMovementDirectionTl { set; get; }
        public string Remarks { set; get; }



        public string AssetDescription { set; get; }
        public string AssetTagId { set; get; }
        public double AssetCost { set; get; }
        public string AssetSerialNo { set; get; }

        public DateTime AssetPurchaseDate { set; get; }
        public string ItemTl { set; get; }



        public string AssetStatusTl { set; get; }



       
    }

}
