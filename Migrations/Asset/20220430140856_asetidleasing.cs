using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class asetidleasing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
