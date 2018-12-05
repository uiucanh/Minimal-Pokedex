using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalPokedex.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    PokemonID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type1 = table.Column<string>(nullable: true),
                    Type2 = table.Column<string>(nullable: true),
                    Generation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.PokemonID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
