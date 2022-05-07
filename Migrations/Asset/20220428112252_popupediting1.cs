using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetProject.Migrations.Asset
{
    public partial class popupediting1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetContracts",
                columns: table => new
                {
                    AssetContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetContracts", x => x.AssetContractID);
                    table.ForeignKey(
                        name: "FK_AssetContracts_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetContracts_AssetId",
                table: "AssetContracts",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetContracts_ContractId",
                table: "AssetContracts",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetContracts");
        }
    }
}
