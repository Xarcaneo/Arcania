using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arcania.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToCharacterRaceRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Races_RaceId",
                table: "Character",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }
    }
}
