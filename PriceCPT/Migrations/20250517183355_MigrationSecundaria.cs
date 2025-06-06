using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceCPT.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSecundaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlteracaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "produto",
                newName: "preco");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "produto",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "produto",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "produto",
                newName: "estoque");

            migrationBuilder.AlterColumn<int>(
                name: "estoque",
                table: "produto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "id_produto",
                table: "produto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_cadastro",
                table: "produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "imagem_url",
                table: "produto",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "mlb",
                table: "produto",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "id_produto");

            migrationBuilder.CreateTable(
                name: "alteracao_preco",
                columns: table => new
                {
                    id_preco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    preco_novo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    preco_antigo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alteracao_preco", x => x.id_preco);
                    table.ForeignKey(
                        name: "FK_alteracao_preco_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alteracao_preco_id_produto",
                table: "alteracao_preco",
                column: "id_produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alteracao_preco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "id_produto",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "data_cadastro",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "imagem_url",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "mlb",
                table: "produto");

            migrationBuilder.RenameColumn(
                name: "preco",
                table: "produto",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "produto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "produto",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "estoque",
                table: "produto",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "produto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlteracaoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    preco_antigo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    preco_novo = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlteracaoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlteracaoProduto_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoProduto_id_produto",
                table: "AlteracaoProduto",
                column: "id_produto");
        }
    }
}
