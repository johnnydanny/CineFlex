using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CinemasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("12d19e16-5f00-400f-8a55-dfcf74250992"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("772b73f9-da82-4203-94d5-4a56a17c607c"));

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ContactInformation = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "ContactInformation", "Location", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("65e790dd-9c19-45a6-92ad-89618506096e"), "Contact Info 1", "Location 1", "Cinema Name 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bff36968-e395-4549-b95a-71d1ead71569"), "Contact Info 2", "Location 2", "Cinema Name 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2258a003-e2ee-4878-8795-9e7071527a8e"), "Anime", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hajime no ippo" },
                    { new Guid("c3dd9f01-01e2-45bb-bef6-1b1294f96db5"), "Action", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Once upon a time in china" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2258a003-e2ee-4878-8795-9e7071527a8e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c3dd9f01-01e2-45bb-bef6-1b1294f96db5"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("12d19e16-5f00-400f-8a55-dfcf74250992"), "Anime", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hajime no ippo" },
                    { new Guid("772b73f9-da82-4203-94d5-4a56a17c607c"), "Action", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Once upon a time in china" }
                });
        }
    }
}
