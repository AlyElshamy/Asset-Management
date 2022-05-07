using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class AssetStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetStatusId",
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
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetStatusId",
                table: "Assets",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_AssetMovementDirectionId",
                table: "AssetMovements",
                column: "AssetMovementDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMovements_StoreId",
                table: "AssetMovements",
                column: "StoreId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetStatuses_AssetStatusId",
                table: "Assets",
                column: "AssetStatusId",
                principalTable: "AssetStatuses",
                principalColumn: "AssetStatusId",
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

            migrationBuilder.DropTable(
                name: "AssetMovementDirections");

            migrationBuilder.DropTable(
                name: "AssetStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Assets_AssetStatusId",
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
                name: "AssetMovementDirectionId",
                table: "AssetMovements");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AssetMovements");
        }
    }
}
