using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UGCase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "musteris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "musterisFatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    musteriId = table.Column<int>(type: "int", nullable: false),
                    faturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    faturaTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    odemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musterisFatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musterisFatura_musteris_musteriId",
                        column: x => x.musteriId,
                        principalTable: "musteris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_musterisFatura_musteriId",
                table: "musterisFatura",
                column: "musteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "musterisFatura");

            migrationBuilder.DropTable(
                name: "musteris");
        }
    }
}
