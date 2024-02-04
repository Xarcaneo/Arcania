using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arcania.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The versatile and adaptable human race.", "Human" },
                    { 2, "The stout and hearty dwarf race.", "Dwarf" },
                    { 3, "The graceful and agile elf race.", "Elf" },
                    { 4, "The clever and inventive gnome race.", "Gnome" },
                    { 5, "The powerful and intimidating ogre race.", "Ogre" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
