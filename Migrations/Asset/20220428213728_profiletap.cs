using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class profiletap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetContracts_Contracts_ContractId",
                table: "AssetContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsInsurances_Insurances_InsuranceId",
                table: "AssetsInsurances");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceId",
                table: "AssetsInsurances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "AssetContracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "assetDocuments",
                columns: table => new
                {
                    AssetDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assetDocuments", x => x.AssetDocumentId);
                    table.ForeignKey(
                        name: "FK_assetDocuments_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetPhotos",
                columns: table => new
                {
                    AssetPhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPhotos", x => x.AssetPhotoId);
                    table.ForeignKey(
                        name: "FK_AssetPhotos_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetMovements",
                columns: table => new
                {
                    AssetMovementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpolyeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMovements", x => x.AssetMovementId);
                    table.ForeignKey(
                        name: "FK_AssetMovements_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMovements_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMovements_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMovements_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMovements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assetDocuments_AssetId",
                table: "assetDocuments",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_ActionTypeId",
                table: "AssetMovements",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_AssetId",
                table: "AssetMovements",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_DepartmentId",
                table: "AssetMovements",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_EmployeeID",
                table: "AssetMovements",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_LocationId",
                table: "AssetMovements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPhotos_AssetId",
                table: "AssetPhotos",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetContracts_Contracts_ContractId",
                table: "AssetContracts",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsInsurances_Insurances_InsuranceId",
                table: "AssetsInsurances",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetContracts_Contracts_ContractId",
                table: "AssetContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsInsurances_Insurances_InsuranceId",
                table: "AssetsInsurances");

            migrationBuilder.DropTable(
                name: "assetDocuments");

            migrationBuilder.DropTable(
                name: "AssetMovements");

            migrationBuilder.DropTable(
                name: "AssetPhotos");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceId",
                table: "AssetsInsurances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "AssetContracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetContracts_Contracts_ContractId",
                table: "AssetContracts",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsInsurances_Insurances_InsuranceId",
                table: "AssetsInsurances",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
