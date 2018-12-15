using System.Collections.Generic;
using System.Linq;
using Moq;
using MinimalPokedex.Controllers;
using MinimalPokedex.Models;
using Xunit;
using MinimalPokedex.Models.ViewModels;

namespace MinimalPokedex.Tests
{
    public class PokemonControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IPokemonRepository> mock = new Mock<IPokemonRepository>();

            mock.Setup(m => m.Pokemons).Returns((new Pokemon[] {
                new Pokemon {PokemonID = 1, Name="TestPokemon1", Type1= new Type(1, "TypeTest1"), Type2=null,
                                ExperienceGrowth=10000, EggSteps=1000, Attack=100, Defense=100,SpAttack=100, SpDefense=100, Speed=100,
                                IsLegendary=false, Generation=1, HP=100},
                new Pokemon {PokemonID = 2, Name="TestPokemon2", Type1= new Type(2, "TypeTest2"), Type2=null,
                                ExperienceGrowth=20000, EggSteps=2000, Attack=200, Defense=200,SpAttack=200, SpDefense=200, Speed=200,
                                IsLegendary=false, Generation=2, HP=200},
                new Pokemon {PokemonID = 3, Name="TestPokemon3", Type1= new Type(3, "TypeTest3"), Type2=null,
                                ExperienceGrowth=30000, EggSteps=3000, Attack=300, Defense=300,SpAttack=300, SpDefense=300, Speed=300,
                                IsLegendary=false, Generation=3, HP=300},
                new Pokemon {PokemonID = 4, Name="TestPokemon4", Type1= new Type(4, "TypeTest4"), Type2=null,
                                ExperienceGrowth=40000, EggSteps=4000, Attack=400, Defense=400,SpAttack=400, SpDefense=400, Speed=400,
                                IsLegendary=false, Generation=4, HP=400},
                new Pokemon {PokemonID = 5, Name="TestPokemon5", Type1= new Type(5, "TypeTest5"), Type2=null,
                                ExperienceGrowth=50000, EggSteps=5000, Attack=500, Defense=500,SpAttack=500, SpDefense=500, Speed=500,
                                IsLegendary=true, Generation=5, HP=500}
                }).AsQueryable<Pokemon>());

            PokemonController controller = new PokemonController(mock.Object)
            {
                PageSize = 3
            };

            // Act
            PokemonListViewModel result = controller.List(2).ViewData.Model as PokemonListViewModel;

            // Assert
            Pokemon[] pokemonArray = result.Pokemons.ToArray();
            Assert.True(pokemonArray.Length == 2);
            Assert.Equal("TestPokemon4", pokemonArray[0].Name);
            Assert.Equal("TestPokemon5", pokemonArray[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IPokemonRepository> mock = new Mock<IPokemonRepository>();

            mock.Setup(m => m.Pokemons).Returns((new Pokemon[] {
                new Pokemon {PokemonID = 1, Name="TestPokemon1", Type1= new Type(1, "TypeTest1"), Type2=null,
                                ExperienceGrowth=10000, EggSteps=1000, Attack=100, Defense=100,SpAttack=100, SpDefense=100, Speed=100,
                                IsLegendary=false, Generation=1, HP=100},
                new Pokemon {PokemonID = 2, Name="TestPokemon2", Type1= new Type(2, "TypeTest2"), Type2=null,
                                ExperienceGrowth=20000, EggSteps=2000, Attack=200, Defense=200,SpAttack=200, SpDefense=200, Speed=200,
                                IsLegendary=false, Generation=2, HP=200},
                new Pokemon {PokemonID = 3, Name="TestPokemon3", Type1= new Type(3, "TypeTest3"), Type2=null,
                                ExperienceGrowth=30000, EggSteps=3000, Attack=300, Defense=300,SpAttack=300, SpDefense=300, Speed=300,
                                IsLegendary=false, Generation=3, HP=300},
                new Pokemon {PokemonID = 4, Name="TestPokemon4", Type1= new Type(4, "TypeTest4"), Type2=null,
                                ExperienceGrowth=40000, EggSteps=4000, Attack=400, Defense=400,SpAttack=400, SpDefense=400, Speed=400,
                                IsLegendary=false, Generation=4, HP=400},
                new Pokemon {PokemonID = 5, Name="TestPokemon5", Type1= new Type(5, "TypeTest5"), Type2=null,
                                ExperienceGrowth=50000, EggSteps=5000, Attack=500, Defense=500,SpAttack=500, SpDefense=500, Speed=500,
                                IsLegendary=true, Generation=5, HP=500}
                }).AsQueryable<Pokemon>());

            // Arrange
            PokemonController controller =
            new PokemonController(mock.Object) { PageSize = 3 };

            // Act
            PokemonListViewModel result =
            controller.List(2).ViewData.Model as PokemonListViewModel;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;

            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Display_Pokemon()
        {
            // Arrange
            Mock<IPokemonRepository> mock = new Mock<IPokemonRepository>();

            mock.Setup(m => m.Pokemons).Returns((new Pokemon[] {
                new Pokemon {PokemonID = 1, Name="TestPokemon1", Type1= new Type(1, "TypeTest1"), Type2=null,
                                ExperienceGrowth=10000, EggSteps=1000, Attack=100, Defense=100,SpAttack=100, SpDefense=100, Speed=100,
                                IsLegendary=false, Generation=1, HP=100},
                new Pokemon {PokemonID = 2, Name="TestPokemon2", Type1= new Type(2, "TypeTest2"), Type2=null,
                                ExperienceGrowth=20000, EggSteps=2000, Attack=200, Defense=200,SpAttack=200, SpDefense=200, Speed=200,
                                IsLegendary=false, Generation=2, HP=200}
                }).AsQueryable<Pokemon>());

            // Arrange
            PokemonController controller =
            new PokemonController(mock.Object) { };

            // Act
            PokemonDetailViewModel result = controller.Pkm(2).ViewData.Model as PokemonDetailViewModel;

            // Assert
            Assert.Equal(2, result.Pokemon.PokemonID);
            Assert.Equal("TestPokemon2", result.Pokemon.Name);
        }
    }
}
