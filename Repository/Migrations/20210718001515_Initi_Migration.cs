using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class Initi_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    active = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    uf = table.Column<string>(type: "char(2)", nullable: false),
                    codigo_ibge = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "char(250)", nullable: false),
                    caminhoarquivo = table.Column<string>(type: "char(250)", nullable: false),
                    principal = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "char(150)", nullable: false),
                    descricao = table.Column<string>(type: "char(250)", nullable: false),
                    preco = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    codigo = table.Column<string>(type: "char(50)", nullable: false),
                    ean = table.Column<string>(type: "char(30)", nullable: false),
                    id_categoria = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_CategoriaProduto_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "CategoriaProduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<byte>(type: "smallint", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(350)", nullable: false),
                    bairro = table.Column<string>(type: "char(250)", nullable: false),
                    numero = table.Column<string>(type: "char(50)", nullable: false),
                    complemento = table.Column<string>(type: "char(250)", nullable: true),
                    cep = table.Column<string>(type: "char(20)", nullable: true),
                    id_cidade = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Cidades_id_cidade",
                        column: x => x.id_cidade,
                        principalTable: "Cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "char(250)", nullable: false),
                    preco = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    id_imagem = table.Column<int>(type: "integer", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Combos_Imagens_id_imagem",
                        column: x => x.id_imagem,
                        principalTable: "Imagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensProdutos",
                columns: table => new
                {
                    id_imagem = table.Column<int>(type: "integer", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensProdutos", x => new { x.id_imagem, x.id_produto });
                    table.ForeignKey(
                        name: "FK_ImagensProdutos_Imagens_id_imagem",
                        column: x => x.id_imagem,
                        principalTable: "Imagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagensProdutos_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromocaoProduto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "char(150)", nullable: false),
                    preco = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    id_imagem = table.Column<int>(type: "integer", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocaoProduto", x => x.id);
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Imagens_id_imagem",
                        column: x => x.id_imagem,
                        principalTable: "Imagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "char(150)", nullable: false),
                    cpfcnpj = table.Column<string>(type: "char(20)", nullable: false),
                    id_endereco = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<string>(type: "char(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosCombo",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    id_combo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosCombo", x => new { x.id_produto, x.id_combo });
                    table.ForeignKey(
                        name: "FK_ProdutosCombo_Combos_id_combo",
                        column: x => x.id_combo,
                        principalTable: "Combos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosCombo_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "char(250)", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    dt_entrega = table.Column<TimeSpan>(type: "interval", nullable: false),
                    id_cliente = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosPedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    preco = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    id_pedido = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosPedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Pedidos_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_id_endereco",
                table: "Clientes",
                column: "id_endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Combos_id_imagem",
                table: "Combos",
                column: "id_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_id_cidade",
                table: "Enderecos",
                column: "id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProdutos_id_produto",
                table: "ImagensProdutos",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_id_cliente",
                table: "Pedidos",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_id_categoria",
                table: "Produtos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosCombo_id_combo",
                table: "ProdutosCombo",
                column: "id_combo");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosPedidos_id_pedido",
                table: "ProdutosPedidos",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosPedidos_id_produto",
                table: "ProdutosPedidos",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_id_imagem",
                table: "PromocaoProduto",
                column: "id_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_id_produto",
                table: "PromocaoProduto",
                column: "id_produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProdutos");

            migrationBuilder.DropTable(
                name: "ProdutosCombo");

            migrationBuilder.DropTable(
                name: "ProdutosPedidos");

            migrationBuilder.DropTable(
                name: "PromocaoProduto");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
