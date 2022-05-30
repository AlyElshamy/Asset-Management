using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class Item3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetBrokenDetails_assetBrokens_AssetBrokenId",
                table: "AssetBrokenDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetBrokenDetails_Assets_AssetId",
                table: "AssetBrokenDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetContracts_Assets_AssetId",
                table: "AssetContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDisposeDetails_Assets_AssetId",
                table: "AssetDisposeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDisposeDetails_DisposeAssets_DisposeAssetId",
                table: "AssetDisposeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_assetDocuments_Assets_AssetId",
                table: "assetDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLeasingDetails_AssetLeasings_AssetLeasingId",
                table: "AssetLeasingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLeasingDetails_Assets_AssetId",
                table: "AssetLeasingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLogs_ActionLogs_ActionLogId",
                table: "AssetLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLogs_Assets_AssetId",
                table: "AssetLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLostDetails_AssetLosts_AssetLostId",
                table: "AssetLostDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLostDetails_Assets_AssetId",
                table: "AssetLostDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMaintainances_Assets_AssetId",
                table: "AssetMaintainances");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMovementDetails_AssetMovements_AssetMovementId",
                table: "AssetMovementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMovementDetails_Assets_AssetId",
                table: "AssetMovementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetPhotos_Assets_AssetId",
                table: "AssetPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRepairDetails_AssetRepairs_AssetRepairId",
                table: "AssetRepairDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRepairDetails_Assets_AssetId",
                table: "AssetRepairDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRepairs_Technicians_TechnicianId",
                table: "AssetRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Items_ItemId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetSellDetails_Assets_AssetId",
                table: "AssetSellDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetSellDetails_sellAssets_SellAssetId",
                table: "AssetSellDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsInsurances_Assets_AssetId",
                table: "AssetsInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetWarranties_Assets_AssetId",
                table: "AssetWarranties");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseAssets_Items_ItemId",
                table: "PurchaseAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseAssets_Purchases_PurchaseId",
                table: "PurchaseAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetBrokenDetails_assetBrokens_AssetBrokenId",
                table: "AssetBrokenDetails",
                column: "AssetBrokenId",
                principalTable: "assetBrokens",
                principalColumn: "AssetBrokenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetBrokenDetails_Assets_AssetId",
                table: "AssetBrokenDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetContracts_Assets_AssetId",
                table: "AssetContracts",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDisposeDetails_Assets_AssetId",
                table: "AssetDisposeDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDisposeDetails_DisposeAssets_DisposeAssetId",
                table: "AssetDisposeDetails",
                column: "DisposeAssetId",
                principalTable: "DisposeAssets",
                principalColumn: "DisposeAssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assetDocuments_Assets_AssetId",
                table: "assetDocuments",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLeasingDetails_AssetLeasings_AssetLeasingId",
                table: "AssetLeasingDetails",
                column: "AssetLeasingId",
                principalTable: "AssetLeasings",
                principalColumn: "AssetLeasingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLeasingDetails_Assets_AssetId",
                table: "AssetLeasingDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLogs_ActionLogs_ActionLogId",
                table: "AssetLogs",
                column: "ActionLogId",
                principalTable: "ActionLogs",
                principalColumn: "ActionLogId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLogs_Assets_AssetId",
                table: "AssetLogs",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLostDetails_AssetLosts_AssetLostId",
                table: "AssetLostDetails",
                column: "AssetLostId",
                principalTable: "AssetLosts",
                principalColumn: "AssetLostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLostDetails_Assets_AssetId",
                table: "AssetLostDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMaintainances_Assets_AssetId",
                table: "AssetMaintainances",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovementDetails_AssetMovements_AssetMovementId",
                table: "AssetMovementDetails",
                column: "AssetMovementId",
                principalTable: "AssetMovements",
                principalColumn: "AssetMovementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovementDetails_Assets_AssetId",
                table: "AssetMovementDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPhotos_Assets_AssetId",
                table: "AssetPhotos",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRepairDetails_AssetRepairs_AssetRepairId",
                table: "AssetRepairDetails",
                column: "AssetRepairId",
                principalTable: "AssetRepairs",
                principalColumn: "AssetRepairId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRepairDetails_Assets_AssetId",
                table: "AssetRepairDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRepairs_Technicians_TechnicianId",
                table: "AssetRepairs",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "TechnicianId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Items_ItemId",
                table: "Assets",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetSellDetails_Assets_AssetId",
                table: "AssetSellDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetSellDetails_sellAssets_SellAssetId",
                table: "AssetSellDetails",
                column: "SellAssetId",
                principalTable: "sellAssets",
                principalColumn: "SellAssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsInsurances_Assets_AssetId",
                table: "AssetsInsurances",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetWarranties_Assets_AssetId",
                table: "AssetWarranties",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseAssets_Items_ItemId",
                table: "PurchaseAssets",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseAssets_Purchases_PurchaseId",
                table: "PurchaseAssets",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetBrokenDetails_assetBrokens_AssetBrokenId",
                table: "AssetBrokenDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetBrokenDetails_Assets_AssetId",
                table: "AssetBrokenDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetContracts_Assets_AssetId",
                table: "AssetContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDisposeDetails_Assets_AssetId",
                table: "AssetDisposeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetDisposeDetails_DisposeAssets_DisposeAssetId",
                table: "AssetDisposeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_assetDocuments_Assets_AssetId",
                table: "assetDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLeasingDetails_AssetLeasings_AssetLeasingId",
                table: "AssetLeasingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLeasingDetails_Assets_AssetId",
                table: "AssetLeasingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLogs_ActionLogs_ActionLogId",
                table: "AssetLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLogs_Assets_AssetId",
                table: "AssetLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLostDetails_AssetLosts_AssetLostId",
                table: "AssetLostDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLostDetails_Assets_AssetId",
                table: "AssetLostDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMaintainances_Assets_AssetId",
                table: "AssetMaintainances");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMovementDetails_AssetMovements_AssetMovementId",
                table: "AssetMovementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMovementDetails_Assets_AssetId",
                table: "AssetMovementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetPhotos_Assets_AssetId",
                table: "AssetPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRepairDetails_AssetRepairs_AssetRepairId",
                table: "AssetRepairDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRepairDetails_Assets_AssetId",
                table: "AssetRepairDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetRepairs_Technicians_TechnicianId",
                table: "AssetRepairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Items_ItemId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetSellDetails_Assets_AssetId",
                table: "AssetSellDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetSellDetails_sellAssets_SellAssetId",
                table: "AssetSellDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsInsurances_Assets_AssetId",
                table: "AssetsInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetWarranties_Assets_AssetId",
                table: "AssetWarranties");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseAssets_Items_ItemId",
                table: "PurchaseAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseAssets_Purchases_PurchaseId",
                table: "PurchaseAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetBrokenDetails_assetBrokens_AssetBrokenId",
                table: "AssetBrokenDetails",
                column: "AssetBrokenId",
                principalTable: "assetBrokens",
                principalColumn: "AssetBrokenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetBrokenDetails_Assets_AssetId",
                table: "AssetBrokenDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetContracts_Assets_AssetId",
                table: "AssetContracts",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDisposeDetails_Assets_AssetId",
                table: "AssetDisposeDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDisposeDetails_DisposeAssets_DisposeAssetId",
                table: "AssetDisposeDetails",
                column: "DisposeAssetId",
                principalTable: "DisposeAssets",
                principalColumn: "DisposeAssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assetDocuments_Assets_AssetId",
                table: "assetDocuments",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLeasingDetails_AssetLeasings_AssetLeasingId",
                table: "AssetLeasingDetails",
                column: "AssetLeasingId",
                principalTable: "AssetLeasings",
                principalColumn: "AssetLeasingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLeasingDetails_Assets_AssetId",
                table: "AssetLeasingDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLogs_ActionLogs_ActionLogId",
                table: "AssetLogs",
                column: "ActionLogId",
                principalTable: "ActionLogs",
                principalColumn: "ActionLogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLogs_Assets_AssetId",
                table: "AssetLogs",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLostDetails_AssetLosts_AssetLostId",
                table: "AssetLostDetails",
                column: "AssetLostId",
                principalTable: "AssetLosts",
                principalColumn: "AssetLostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLostDetails_Assets_AssetId",
                table: "AssetLostDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMaintainances_Assets_AssetId",
                table: "AssetMaintainances",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovementDetails_AssetMovements_AssetMovementId",
                table: "AssetMovementDetails",
                column: "AssetMovementId",
                principalTable: "AssetMovements",
                principalColumn: "AssetMovementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovementDetails_Assets_AssetId",
                table: "AssetMovementDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPhotos_Assets_AssetId",
                table: "AssetPhotos",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRepairDetails_AssetRepairs_AssetRepairId",
                table: "AssetRepairDetails",
                column: "AssetRepairId",
                principalTable: "AssetRepairs",
                principalColumn: "AssetRepairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRepairDetails_Assets_AssetId",
                table: "AssetRepairDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetRepairs_Technicians_TechnicianId",
                table: "AssetRepairs",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "TechnicianId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Items_ItemId",
                table: "Assets",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetSellDetails_Assets_AssetId",
                table: "AssetSellDetails",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetSellDetails_sellAssets_SellAssetId",
                table: "AssetSellDetails",
                column: "SellAssetId",
                principalTable: "sellAssets",
                principalColumn: "SellAssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsInsurances_Assets_AssetId",
                table: "AssetsInsurances",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetWarranties_Assets_AssetId",
                table: "AssetWarranties",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseAssets_Items_ItemId",
                table: "PurchaseAssets",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseAssets_Purchases_PurchaseId",
                table: "PurchaseAssets",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
