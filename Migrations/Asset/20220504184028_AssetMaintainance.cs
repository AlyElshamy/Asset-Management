using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class AssetMaintainance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    WeekDayTitle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.WeekDayId);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetMaintainances");

            migrationBuilder.DropTable(
                name: "AssetMaintainanceFrequencies");

            migrationBuilder.DropTable(
                name: "MaintainanceStatuses");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "WeekDays");
        }
    }
}
