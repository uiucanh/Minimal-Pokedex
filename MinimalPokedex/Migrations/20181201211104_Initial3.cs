using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalPokedex.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Abilities_AbilitiesID",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_AbilitiesID",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "AbilitiesID",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "AbilitiesName",
                table: "Abilities",
                newName: "AbilityName");

            migrationBuilder.RenameColumn(
                name: "AbilitiesID",
                table: "Abilities",
                newName: "AbilityID");

            migrationBuilder.CreateTable(
                name: "PokemonAbilities",
                columns: table => new
                {
                    PokemonID = table.Column<int>(nullable: false),
                    AbilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonAbilities", x => new { x.PokemonID, x.AbilityID });
                    table.ForeignKey(
                        name: "FK_PokemonAbilities_Abilities_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilities",
                        principalColumn: "AbilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonAbilities_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonAbilities_AbilityID",
                table: "PokemonAbilities",
                column: "AbilityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonAbilities");

            migrationBuilder.RenameColumn(
                name: "AbilityName",
                table: "Abilities",
                newName: "AbilitiesName");

            migrationBuilder.RenameColumn(
                name: "AbilityID",
                table: "Abilities",
                newName: "AbilitiesID");

            migrationBuilder.AddColumn<int>(
                name: "AbilitiesID",
                table: "Pokemons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_AbilitiesID",
                table: "Pokemons",
                column: "AbilitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Abilities_AbilitiesID",
                table: "Pokemons",
                column: "AbilitiesID",
                principalTable: "Abilities",
                principalColumn: "AbilitiesID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
