using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftBuy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemThumb",
                table: "imagens");

            migrationBuilder.DropColumn(
                name: "Principal",
                table: "imagens");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ImagemThumb",
                table: "imagens",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Principal",
                table: "imagens",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
