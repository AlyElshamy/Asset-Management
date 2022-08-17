using AssetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetProject.ViewModel
{
    public class TwowaysTansfer
    {
        public int? LeftActionTypeId { get; set; }
        public int? RightActionTypeId { get; set; }
        public int? LeftDepartmentId { get; set; }
        public int? RightDepartmentId { get; set; }
        public int? LeftEmployeeId { get; set; }
        public int? RightEmployeeId { get; set; }
        public int? LeftLocationId { get; set; }
        public int? RightLocationId { get; set; }
        public int? LeftStoreId { get; set; }
        public int? RightStoreId { get; set; }
        public List<Asset> SelectedLeftAssets { get; set; }
        public List<Asset> SelectedRightAssets { get; set; }
        public List<Asset> RightDataSource { get; set; }


        public List<Asset> LeftDataSource { get; set; }
        public List<Asset> RightEmployeeDataSource { get; set; }
        public List<Asset> LeftEmployeeDataSource { get; set; }
        public List<Asset> LeftDepartmentDataSource { get; set; }
        public List<Asset> RightDepartmentDataSource { get; set; }


    }
}
