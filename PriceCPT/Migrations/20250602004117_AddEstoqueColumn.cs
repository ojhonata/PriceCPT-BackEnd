using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceCPT.Migrations
{
    /// <inheritdoc />
    public partial class AddEstoqueColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estoque",
                table: "alteracao_preco",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estoque",
                table: "alteracao_preco");
        }
    }
}
