using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class more : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("12d19e16-5f00-400f-8a55-dfcf74250992"), "Anime", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hajime no ippo" },
                    { new Guid("772b73f9-da82-4203-94d5-4a56a17c607c"), "Action", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Once upon a time in china" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("12d19e16-5f00-400f-8a55-dfcf74250992"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("772b73f9-da82-4203-94d5-4a56a17c607c"));
        }
    }
}
