using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cultura.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Eventos musicais, de bandas locais a shows nacionais.", "Shows" },
                    { 2, "Peças teatrais, do drama à comédia, para todos os públicos.", "Teatro" },
                    { 3, "Festivais, workshops e experiências culinárias.", "Gastronomia" },
                    { 4, "Estreias, pré-estreias e mostras especiais de filmes.", "Cinema" },
                    { 5, "Palestras, workshops e hackathons sobre inovação.", "Tecnologia" },
                    { 6, "Eventos para fortalecer a comunidade, como feiras e ações sociais.", "Encontros comunitários" },
                    { 7, "Shows de stand-up comedy e noites de microfone aberto.", "Humor" },
                    { 8, "Mostras de arte, fotografia e exposições históricas.", "Exposições" },
                    { 9, "Lançamentos de livros, encontros de clubes de leitura e saraus.", "Literatura" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
