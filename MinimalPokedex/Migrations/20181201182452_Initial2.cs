using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalPokedex.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type1",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Type2",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "AbilitiesID",
                table: "Pokemons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EggSteps",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceGrowth",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HP",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLegendary",
                table: "Pokemons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SpAttack",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpDefense",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type1TypeID",
                table: "Pokemons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type2TypeID",
                table: "Pokemons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilitiesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbilitiesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilitiesID);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_AbilitiesID",
                table: "Pokemons",
                column: "AbilitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Type1TypeID",
                table: "Pokemons",
                column: "Type1TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Type2TypeID",
                table: "Pokemons",
                column: "Type2TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Abilities_AbilitiesID",
                table: "Pokemons",
                column: "AbilitiesID",
                principalTable: "Abilities",
                principalColumn: "AbilitiesID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_Type1TypeID",
                table: "Pokemons",
                column: "Type1TypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_Type2TypeID",
                table: "Pokemons",
                column: "Type2TypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Abilities_AbilitiesID",
                table: "Pokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_Type1TypeID",
                table: "Pokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_Type2TypeID",
                table: "Pokemons");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_AbilitiesID",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_Type1TypeID",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_Type2TypeID",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "AbilitiesID",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "EggSteps",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "ExperienceGrowth",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "HP",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "IsLegendary",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "SpAttack",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "SpDefense",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Type1TypeID",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Type2TypeID",
                table: "Pokemons");

            migrationBuilder.AddColumn<string>(
                name: "Type1",
                table: "Pokemons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type2",
                table: "Pokemons",
                nullable: true);
        }
    }
}
