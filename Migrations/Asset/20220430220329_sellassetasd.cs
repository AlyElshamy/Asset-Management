using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class sellassetasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetMovements");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "assetBrokens",
                columns: table => new
                {
                    AssetBrokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateBroken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assetBrokens", x => x.AssetBrokenId);
                    table.ForeignKey(
                        name: "FK_assetBrokens_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetLosts",
                columns: table => new
                {
                    AssetLostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    DateLost = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLosts", x => x.AssetLostId);
                    table.ForeignKey(
                        name: "FK_AssetLosts_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisposeAssets",
                columns: table => new
                {
                    DisposeAssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    DateDisposed = table.Column<DateTime>(type: "date", nullable: false),
                    DisposeTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisposeAssets", x => x.DisposeAssetId);
                    table.ForeignKey(
                        name: "FK_DisposeAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "AssetRepairs",
                columns: table => new
                {
                    AssetRepairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairCost = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRepairs", x => x.AssetRepairId);
                    table.ForeignKey(
                        name: "FK_AssetRepairs_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetRepairs_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assetBrokens_AssetId",
                table: "assetBrokens",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLosts_AssetId",
                table: "AssetLosts",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRepairs_AssetId",
                table: "AssetRepairs",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRepairs_TechnicianId",
                table: "AssetRepairs",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_DisposeAssets_AssetId",
                table: "DisposeAssets",
                column: "AssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assetBrokens");

            migrationBuilder.DropTable(
                name: "AssetLosts");

            migrationBuilder.DropTable(
                name: "AssetRepairs");

            migrationBuilder.DropTable(
                name: "DisposeAssets");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AssetMovements",
                columns: table => new
                {
                    AssetMovementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    EmpolyeeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
        }
    }
}
