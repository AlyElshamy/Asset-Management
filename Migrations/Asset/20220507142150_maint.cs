using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class maint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetStatusId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetMovementDirectionId",
                table: "AssetMovements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "AssetMovements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    ActionLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionLogTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.ActionLogId);
                });

            migrationBuilder.CreateTable(
                name: "AssetMaintainanceFrequencies",
                columns: table => new
                {
                    AssetMaintainanceFrequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMaintainanceFrequencyTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintainanceFrequencies", x => x.AssetMaintainanceFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "AssetMovementDirections",
                columns: table => new
                {
                    AssetMovementDirectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMovementDirectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMovementDirections", x => x.AssetMovementDirectionId);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatuses",
                columns: table => new
                {
                    AssetStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetStatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatuses", x => x.AssetStatusId);
                });

            migrationBuilder.CreateTable(
                name: "MaintainanceStatuses",
                columns: table => new
                {
                    MaintainanceStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainanceStatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintainanceStatuses", x => x.MaintainanceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    MonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    WeekDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.WeekDayId);
                });

            migrationBuilder.CreateTable(
                name: "AssetLogs",
                columns: table => new
                {
                    AssetLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    ActionLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLogs", x => x.AssetLogId);
                    table.ForeignKey(
                        name: "FK_AssetLogs_ActionLogs_ActionLogId",
                        column: x => x.ActionLogId,
                        principalTable: "ActionLogs",
                        principalColumn: "ActionLogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLogs_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetMaintainances",
                columns: table => new
                {
                    AssetMaintainanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMaintainanceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetMaintainanceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetMaintainanceDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintainanceStatusId = table.Column<int>(type: "int", nullable: false),
                    AssetMaintainanceDateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetMaintainanceRepairesCost = table.Column<double>(type: "float", nullable: false),
                    AssetMaintainanceRepeating = table.Column<bool>(type: "bit", nullable: false),
                    AssetMaintainanceFrequencyId = table.Column<int>(type: "int", nullable: true),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    WeeklyPeriod = table.Column<int>(type: "int", nullable: true),
                    WeekDayId = table.Column<int>(type: "int", nullable: true),
                    MonthlyPeriod = table.Column<int>(type: "int", nullable: true),
                    MonthlyDay = table.Column<int>(type: "int", nullable: true),
                    MonthId = table.Column<int>(type: "int", nullable: true),
                    YearlyDay = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintainances", x => x.AssetMaintainanceId);
                    table.ForeignKey(
                        name: "FK_AssetMaintainances_AssetMaintainanceFrequencies_AssetMaintainanceFrequencyId",
                        column: x => x.AssetMaintainanceFrequencyId,
                        principalTable: "AssetMaintainanceFrequencies",
                        principalColumn: "AssetMaintainanceFrequencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintainances_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMaintainances_MaintainanceStatuses_MaintainanceStatusId",
                        column: x => x.MaintainanceStatusId,
                        principalTable: "MaintainanceStatuses",
                        principalColumn: "MaintainanceStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMaintainances_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintainances_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMaintainances_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetStatusId",
                table: "Assets",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_StoreId",
                table: "Assets",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_VendorId",
                table: "Assets",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_AssetMovementDirectionId",
                table: "AssetMovements",
                column: "AssetMovementDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_StoreId",
                table: "AssetMovements",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLogs_ActionLogId",
                table: "AssetLogs",
                column: "ActionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLogs_AssetId",
                table: "AssetLogs",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintainances_AssetId",
                table: "AssetMaintainances",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintainances_AssetMaintainanceFrequencyId",
                table: "AssetMaintainances",
                column: "AssetMaintainanceFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintainances_MaintainanceStatusId",
                table: "AssetMaintainances",
                column: "MaintainanceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintainances_MonthId",
                table: "AssetMaintainances",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintainances_TechnicianId",
                table: "AssetMaintainances",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintainances_WeekDayId",
                table: "AssetMaintainances",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovements_AssetMovementDirections_AssetMovementDirectionId",
                table: "AssetMovements",
                column: "AssetMovementDirectionId",
                principalTable: "AssetMovementDirections",
                principalColumn: "AssetMovementDirectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMovements_Stores_StoreId",
                table: "AssetMovements",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetStatuses_AssetStatusId",
                table: "Assets",
                column: "AssetStatusId",
                principalTable: "AssetStatuses",
                principalColumn: "AssetStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Stores_StoreId",
                table: "Assets",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Vendors_VendorId",
                table: "Assets",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetMovements_AssetMovementDirections_AssetMovementDirectionId",
                table: "AssetMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMovements_Stores_StoreId",
                table: "AssetMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetStatuses_AssetStatusId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Stores_StoreId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Vendors_VendorId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "AssetLogs");

            migrationBuilder.DropTable(
                name: "AssetMaintainances");

            migrationBuilder.DropTable(
                name: "AssetMovementDirections");

            migrationBuilder.DropTable(
                name: "AssetStatuses");

            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "AssetMaintainanceFrequencies");

            migrationBuilder.DropTable(
                name: "MaintainanceStatuses");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropIndex(
                name: "IX_Assets_AssetStatusId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_StoreId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_VendorId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_AssetMovements_AssetMovementDirectionId",
                table: "AssetMovements");

            migrationBuilder.DropIndex(
                name: "IX_AssetMovements_StoreId",
                table: "AssetMovements");

            migrationBuilder.DropColumn(
                name: "AssetStatusId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AssetMovementDirectionId",
                table: "AssetMovements");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AssetMovements");
        }
    }
}
