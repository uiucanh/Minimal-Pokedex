using MinimalPokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Type = MinimalPokedex.Models.Type;

namespace MinimalPokedex.Tests
{
    public class TeamTests
    {
        [Fact]
        public void Can_Add_New_Pokemon_To_Team()
        {
            // Arrange - create some test products
            Pokemon p1 = new Pokemon
            {
                PokemonID = 1,
                Name = "TestPokemon1",
                Type1 = new Type(1, "TypeTest1"),
                Type2 = null,
                ExperienceGrowth = 10000,
                EggSteps = 1000,
                Attack = 100,
                Defense = 100,
                SpAttack = 100,
                SpDefense = 100,
                Speed = 100,
                IsLegendary = false,
                Generation = 1,
                HP = 100
            };
            Pokemon p2 = new Pokemon
            {
                PokemonID = 2,
                Name = "TestPokemon2",
                Type1 = new Type(2, "TypeTest2"),
                Type2 = null,
                ExperienceGrowth = 20000,
                EggSteps = 2000,
                Attack = 200,
                Defense = 200,
                SpAttack = 200,
                SpDefense = 200,
                Speed = 200,
                IsLegendary = false,
                Generation = 2,
                HP = 200
            };

            // Arrange - create a new cart
            Team target = new Team();

            // Act
            target.AddPokemon(p1);
            target.AddPokemon(p2);

            TeamLineUp[] results = target.Pokemons.ToArray();

            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Pokemon);
            Assert.Equal(p2, results[1].Pokemon);
        }

        [Fact]
        public void Can_Remove_Pokemon_From_Team()
        {
            // Arrange - create some test products
            Pokemon p1 = new Pokemon
            {
                PokemonID = 1,
                Name = "TestPokemon1",
                Type1 = new Type(1, "TypeTest1"),
                Type2 = null,
                ExperienceGrowth = 10000,
                EggSteps = 1000,
                Attack = 100,
                Defense = 100,
                SpAttack = 100,
                SpDefense = 100,
                Speed = 100,
                IsLegendary = false,
                Generation = 1,
                HP = 100
            };
            Pokemon p2 = new Pokemon
            {
                PokemonID = 2,
                Name = "TestPokemon2",
                Type1 = new Type(2, "TypeTest2"),
                Type2 = null,
                ExperienceGrowth = 20000,
                EggSteps = 2000,
                Attack = 200,
                Defense = 200,
                SpAttack = 200,
                SpDefense = 200,
                Speed = 200,
                IsLegendary = false,
                Generation = 2,
                HP = 200
            };

            // Arrange - create a new cart
            Team target = new Team();

            // Arrange - add some products to the cart
            target.AddPokemon(p1);
            target.AddPokemon(p2);

            // Act
            target.RemovePokemon(p2);

            // Assert
            Assert.Empty(target.Pokemons.Where(c => c.Pokemon == p2));
            Assert.Single(target.Pokemons);
        }

        [Fact]
        public void Can_Clear_Team()
        {
            // Arrange - create some test products
            Pokemon p1 = new Pokemon
            {
                PokemonID = 1,
                Name = "TestPokemon1",
                Type1 = new Type(1, "TypeTest1"),
                Type2 = null,
                ExperienceGrowth = 10000,
                EggSteps = 1000,
                Attack = 100,
                Defense = 100,
                SpAttack = 100,
                SpDefense = 100,
                Speed = 100,
                IsLegendary = false,
                Generation = 1,
                HP = 100
            };
            Pokemon p2 = new Pokemon
            {
                PokemonID = 2,
                Name = "TestPokemon2",
                Type1 = new Type(2, "TypeTest2"),
                Type2 = null,
                ExperienceGrowth = 20000,
                EggSteps = 2000,
                Attack = 200,
                Defense = 200,
                SpAttack = 200,
                SpDefense = 200,
                Speed = 200,
                IsLegendary = false,
                Generation = 2,
                HP = 200
            };

            // Arrange - create a new cart
            Team target = new Team();

            // Arrange - add some products to the cart
            target.AddPokemon(p1);
            target.AddPokemon(p2);

            // Act - reset the cart
            target.Clear();
            // Assert
            Assert.Empty(target.Pokemons);
        }
    }
}
