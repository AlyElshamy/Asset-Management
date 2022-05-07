using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class Custo2304 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "AssetLeasings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AssetLeasings_AssetId",
                table: "AssetLeasings",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLeasings_Assets_AssetId",
                table: "AssetLeasings",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetLeasings_Assets_AssetId",
                table: "AssetLeasings");

            migrationBuilder.DropIndex(
                name: "IX_AssetLeasings_AssetId",
                table: "AssetLeasings");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "AssetLeasings");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
