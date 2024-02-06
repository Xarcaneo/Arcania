using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arcania.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCharacterValueInApplicationUserToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Character_CharacterId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Character_CharacterId",
                table: "AspNetUsers",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Character_CharacterId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Character_CharacterId",
                table: "AspNetUsers",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
