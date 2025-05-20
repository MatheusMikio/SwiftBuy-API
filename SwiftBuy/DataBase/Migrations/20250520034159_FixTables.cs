using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftBuy.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imagens_produtos_ProdutoModelId",
                table: "imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoModelProdutoModel_pedidos_pedidoModelsId",
                table: "PedidoModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoModelProdutoModel_produtos_produtosId",
                table: "PedidoModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_promocoes_PromocaoProdutoModelid",
                table: "produtos");

            migrationBuilder.DropIndex(
                name: "IX_imagens_ProdutoModelId",
                table: "imagens");

            migrationBuilder.DropColumn(
                name: "DescricaoDetalhada",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoModelId",
                table: "imagens");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "usuarios",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "porcentagem",
                table: "promocoes",
                newName: "Porcentagem");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "promocoes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "dataInicio",
                table: "promocoes",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "dataFim",
                table: "promocoes",
                newName: "DataFim");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "promocoes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PromocaoProdutoModelid",
                table: "produtos",
                newName: "PromocaoProdutoModelId");

            migrationBuilder.RenameIndex(
                name: "IX_produtos_PromocaoProdutoModelid",
                table: "produtos",
                newName: "IX_produtos_PromocaoProdutoModelId");

            migrationBuilder.RenameColumn(
                name: "produtosId",
                table: "PedidoModelProdutoModel",
                newName: "ProdutosId");

            migrationBuilder.RenameColumn(
                name: "pedidoModelsId",
                table: "PedidoModelProdutoModel",
                newName: "PedidoModelsId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoModelProdutoModel_produtosId",
                table: "PedidoModelProdutoModel",
                newName: "IX_PedidoModelProdutoModel_ProdutosId");

            migrationBuilder.RenameColumn(
                name: "principal",
                table: "imagens",
                newName: "Principal");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagem",
                table: "imagens",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemThumb",
                table: "imagens",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_imagens_ProdutoId",
                table: "imagens",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_imagens_produtos_ProdutoId",
                table: "imagens",
                column: "ProdutoId",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoModelProdutoModel_pedidos_PedidoModelsId",
                table: "PedidoModelProdutoModel",
                column: "PedidoModelsId",
                principalTable: "pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoModelProdutoModel_produtos_ProdutosId",
                table: "PedidoModelProdutoModel",
                column: "ProdutosId",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_promocoes_PromocaoProdutoModelId",
                table: "produtos",
                column: "PromocaoProdutoModelId",
                principalTable: "promocoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imagens_produtos_ProdutoId",
                table: "imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoModelProdutoModel_pedidos_PedidoModelsId",
                table: "PedidoModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoModelProdutoModel_produtos_ProdutosId",
                table: "PedidoModelProdutoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_promocoes_PromocaoProdutoModelId",
                table: "produtos");

            migrationBuilder.DropIndex(
                name: "IX_imagens_ProdutoId",
                table: "imagens");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "usuarios",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Porcentagem",
                table: "promocoes",
                newName: "porcentagem");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "promocoes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "promocoes",
                newName: "dataInicio");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "promocoes",
                newName: "dataFim");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "promocoes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PromocaoProdutoModelId",
                table: "produtos",
                newName: "PromocaoProdutoModelid");

            migrationBuilder.RenameIndex(
                name: "IX_produtos_PromocaoProdutoModelId",
                table: "produtos",
                newName: "IX_produtos_PromocaoProdutoModelid");

            migrationBuilder.RenameColumn(
                name: "ProdutosId",
                table: "PedidoModelProdutoModel",
                newName: "produtosId");

            migrationBuilder.RenameColumn(
                name: "PedidoModelsId",
                table: "PedidoModelProdutoModel",
                newName: "pedidoModelsId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoModelProdutoModel_ProdutosId",
                table: "PedidoModelProdutoModel",
                newName: "IX_PedidoModelProdutoModel_produtosId");

            migrationBuilder.RenameColumn(
                name: "Principal",
                table: "imagens",
                newName: "principal");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoDetalhada",
                table: "produtos",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "imagens",
                keyColumn: "UrlImagem",
                keyValue: null,
                column: "UrlImagem",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagem",
                table: "imagens",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.UpdateData(
                table: "imagens",
                keyColumn: "ImagemThumb",
                keyValue: null,
                column: "ImagemThumb",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemThumb",
                table: "imagens",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoModelId",
                table: "imagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_imagens_ProdutoModelId",
                table: "imagens",
                column: "ProdutoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_imagens_produtos_ProdutoModelId",
                table: "imagens",
                column: "ProdutoModelId",
                principalTable: "produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoModelProdutoModel_pedidos_pedidoModelsId",
                table: "PedidoModelProdutoModel",
                column: "pedidoModelsId",
                principalTable: "pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoModelProdutoModel_produtos_produtosId",
                table: "PedidoModelProdutoModel",
                column: "produtosId",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_promocoes_PromocaoProdutoModelid",
                table: "produtos",
                column: "PromocaoProdutoModelid",
                principalTable: "promocoes",
                principalColumn: "id");
        }
    }
}
