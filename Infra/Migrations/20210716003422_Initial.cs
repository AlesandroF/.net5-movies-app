using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Ativo", "DataCriacao", "Nome" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ação" },
                    { 2, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aventura" },
                    { 3, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comédia" },
                    { 4, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { 5, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroeste" },
                    { 6, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Musical" },
                    { 7, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspense" },
                    { 8, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror" },
                    { 9, 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenreId",
                table: "Movie",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
