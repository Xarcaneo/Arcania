using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arcania.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterValueToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CharacterId",
                table: "AspNetUsers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Character_CharacterId",
                table: "AspNetUsers",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Character_CharacterId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CharacterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "AspNetUsers");
        }
    }
}
