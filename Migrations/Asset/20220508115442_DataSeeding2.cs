using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class DataSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActionLogs",
                columns: new[] { "ActionLogId", "ActionLogTitle" },
                values: new object[,]
                {
                    { 1, "Asset Purchase" },
                    { 18, "Asset Maintainance" },
                    { 17, "CheckOut" },
                    { 16, "CheckIn" },
                    { 15, "Asset Leasing" },
                    { 13, "Repair Asset" },
                    { 12, "Broken Asset" },
                    { 11, "Dispose Asset " },
                    { 10, "Sell Asset" },
                    { 14, "Repair Asset" },
                    { 8, "Dettached Asset Document" },
                    { 7, "Dettached Asset Insurance" },
                    { 6, "Dettached Asset Contract" },
                    { 5, "Add New Asset Photo" },
                    { 4, "Creation Link Document" },
                    { 3, "Creation Link Insurance" },
                    { 2, "Creation Link Contract" },
                    { 9, "Delete Asset Photo" }
                });

            migrationBuilder.InsertData(
                table: "AssetMaintainanceFrequencies",
                columns: new[] { "AssetMaintainanceFrequencyId", "AssetMaintainanceFrequencyTitle" },
                values: new object[,]
                {
                    { 4, "Yearly" },
                    { 3, "Monthly" },
                    { 1, "Daily" },
                    { 2, "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "AssetMovementDirections",
                columns: new[] { "AssetMovementDirectionId", "AssetMovementDirectionTitle" },
                values: new object[,]
                {
                    { 1, "CheckOut" },
                    { 2, "CheckIn" }
                });

            migrationBuilder.InsertData(
                table: "AssetStatuses",
                columns: new[] { "AssetStatusId", "AssetStatusTitle" },
                values: new object[,]
                {
                    { 7, "Sold" },
                    { 9, "InMaimtainance" },
                    { 8, "Broken" },
                    { 6, "Leased" },
                    { 2, "CheckedOut" },
                    { 4, "Lost" },
                    { 3, "InRepair" },
                    { 1, "CheckedIn(Avaliable)" },
                    { 5, "Disposed" }
                });

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "MonthId", "MonthTitle" },
                values: new object[,]
                {
                    { 12, "December" },
                    { 11, "November" },
                    { 10, "October" },
                    { 9, "September" },
                    { 7, "July" },
                    { 8, "August" },
                    { 5, "May" },
                    { 4, "April" },
                    { 3, "March" }
                });

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "MonthId", "MonthTitle" },
                values: new object[,]
                {
                    { 2, "February" },
                    { 1, "January" },
                    { 6, "June" }
                });

            migrationBuilder.InsertData(
                table: "WeekDays",
                columns: new[] { "WeekDayId", "WeekDayTitle" },
                values: new object[,]
                {
                    { 6, "Thursday" },
                    { 1, "Saturday" },
                    { 2, "Sunday" },
                    { 3, "Monday" },
                    { 4, "Tuesday" },
                    { 5, "Wednesday" },
                    { 7, "Friday" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActionLogs",
                keyColumn: "ActionLogId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AssetMaintainanceFrequencies",
                keyColumn: "AssetMaintainanceFrequencyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssetMaintainanceFrequencies",
                keyColumn: "AssetMaintainanceFrequencyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetMaintainanceFrequencies",
                keyColumn: "AssetMaintainanceFrequencyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssetMaintainanceFrequencies",
                keyColumn: "AssetMaintainanceFrequencyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AssetMovementDirections",
                keyColumn: "AssetMovementDirectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssetMovementDirections",
                keyColumn: "AssetMovementDirectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AssetStatuses",
                keyColumn: "AssetStatusId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Months",
                keyColumn: "MonthId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WeekDays",
                keyColumn: "WeekDayId",
                keyValue: 7);
        }
    }
}
