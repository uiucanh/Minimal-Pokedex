using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalPokedex.Migrations
{
    public partial class Ability2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PokemonAbilities");

            migrationBuilder.AddColumn<string>(
                name: "AbilityDescription",
                table: "Abilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbilityDescription",
                table: "Abilities");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PokemonAbilities",
                nullable: true);
        }
    }
}
