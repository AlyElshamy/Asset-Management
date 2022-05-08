using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class DataSeesing1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActionTypes",
                columns: new[] { "ActionTypeId", "ActionTypeTitle" },
                values: new object[,]
                {
                    { 1, "To Employee" },
                    { 2, "To Department" }
                });

            migrationBuilder.InsertData(
                table: "DepreciationMethods",
                columns: new[] { "DepreciationMethodId", "DepreciationMethodTitle" },
                values: new object[,]
                {
                    { 1, "Straight Line" },
                    { 2, "Declining Balance" },
                    { 3, "Double Declining Balance" },
                    { 4, "150% Declining Balance" },
                    { 5, "Sum of the Years' Digits" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionTypes",
                keyColumn: "ActionTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActionTypes",
                keyColumn: "ActionTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DepreciationMethods",
                keyColumn: "DepreciationMethodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DepreciationMethods",
                keyColumn: "DepreciationMethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DepreciationMethods",
                keyColumn: "DepreciationMethodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DepreciationMethods",
                keyColumn: "DepreciationMethodId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DepreciationMethods",
                keyColumn: "DepreciationMethodId",
                keyValue: 5);
        }
    }
}
