using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CGST = table.Column<double>(type: "float", nullable: false),
                    SGST = table.Column<double>(type: "float", nullable: true),
                    IGST = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Department = table.Column<int>(type: "int", nullable: true),
                    HSN = table.Column<int>(type: "int", nullable: false),
                    BuyingUnit = table.Column<int>(type: "int", nullable: true),
                    BuyingUnitPrice = table.Column<double>(type: "float", nullable: true),
                    SellingUnit = table.Column<int>(type: "int", nullable: true),
                    SellingUnitPrice = table.Column<double>(type: "float", nullable: true),
                    TaxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_TaxId",
                table: "Items",
                column: "TaxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
