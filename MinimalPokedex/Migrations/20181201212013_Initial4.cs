using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalPokedex.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonAbilityID",
                table: "PokemonAbilities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonAbilityID",
                table: "PokemonAbilities");
        }
    }
}
