using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Comandas.Api.Migrations
{
    /// <inheritdoc />
    public partial class versao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardapioItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    PossuiPreparo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardapioItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroMesa = table.Column<int>(type: "integer", nullable: false),
                    NomeCliente = table.Column<string>(type: "text", nullable: false),
                    SituacaoComanda = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroMesa = table.Column<int>(type: "integer", nullable: false),
                    SituacaoMesa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComandaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardapioItemId = table.Column<int>(type: "integer", nullable: false),
                    ComandaId = table.Column<int>(type: "integer", nullable: false),
                    ComandaId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComandaItem_CardapioItem_CardapioItemId",
                        column: x => x.CardapioItemId,
                        principalTable: "CardapioItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaItem_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaItem_Comanda_ComandaId1",
                        column: x => x.ComandaId1,
                        principalTable: "Comanda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidoCozinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComandaId = table.Column<int>(type: "integer", nullable: false),
                    SituacaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCozinha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoCozinha_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoCozinhaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoCozinhaId = table.Column<int>(type: "integer", nullable: false),
                    ComandaItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCozinhaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoCozinhaItem_ComandaItem_ComandaItemId",
                        column: x => x.ComandaItemId,
                        principalTable: "ComandaItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoCozinhaItem_PedidoCozinha_PedidoCozinhaId",
                        column: x => x.PedidoCozinhaId,
                        principalTable: "PedidoCozinha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItem_CardapioItemId",
                table: "ComandaItem",
                column: "CardapioItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItem_ComandaId",
                table: "ComandaItem",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItem_ComandaId1",
                table: "ComandaItem",
                column: "ComandaId1");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCozinha_ComandaId",
                table: "PedidoCozinha",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCozinhaItem_ComandaItemId",
                table: "PedidoCozinhaItem",
                column: "ComandaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCozinhaItem_PedidoCozinhaId",
                table: "PedidoCozinhaItem",
                column: "PedidoCozinhaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "PedidoCozinhaItem");

            migrationBuilder.DropTable(
                name: "ComandaItem");

            migrationBuilder.DropTable(
                name: "PedidoCozinha");

            migrationBuilder.DropTable(
                name: "CardapioItem");

            migrationBuilder.DropTable(
                name: "Comanda");
        }
    }
}
