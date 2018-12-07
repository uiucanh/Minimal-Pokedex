using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinimalPokedex.Models;
using System.Linq;
using System.Dynamic;
using MinimalPokedex.Models.ViewModels;
using System.Diagnostics;
using Type = MinimalPokedex.Models.Type;
using Microsoft.EntityFrameworkCore;

namespace MinimalPokedex.Controllers
{
    public class PokemonController : Controller
    {
        private IPokemonRepository repository;
        public int PageSize = 150;

        public PokemonController(IPokemonRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int listPage = 1)
        {
            return View(new PokemonListViewModel
            {
                Pokemons = repository.Pokemons
                .OrderBy(p => p.PokemonID)
                .Skip((listPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Pokemons.Count()
                }
            });
        }

        public ViewResult Pkm(int? id)
        {
            PokemonDetailViewModel ViewModel = new PokemonDetailViewModel();
            ViewModel.Pokemon = repository.Pokemons.Where(p => p.PokemonID == id).Single();

            var pokemonAbility = (from ability in repository.Abilities
                                 join pkmAbility in repository.PokemonAbilities on ability.AbilityID equals pkmAbility.AbilityID
                                  where pkmAbility.PokemonID == id
                                  select ability);
            ViewModel.Abilities = pokemonAbility;

            ViewModel.Type1 = repository.Pokemons.Where(p => p.PokemonID == id).Select(p => p.Type1).Single();
            var type1id = ViewModel.Type1.TypeID;
            int? type2id;
            ViewModel.Type2 = repository.Pokemons.Where(p => p.PokemonID == id).Select(p => p.Type2).Single();
            if (ViewModel.Type2 is null)
            {
                type2id = null;
            } else
            {
                type2id = ViewModel.Type2.TypeID;
            }

            var query1 = repository.Pokemons.Where(p => p.PokemonID == (id - 1));
            var query2 = repository.Pokemons.Where(p => p.PokemonID == (id + 1));
            ViewModel.PrevPokemon = query1.Any() ? query1.Single().Name : null;
            ViewModel.NextPokemon = query2.Any() ? query2.Single().Name : null;

            float[] TypesDamageMultiplierList = CalculateType.CalculateTypes(type1id, type2id);
            ViewModel.Weaknesses = CalculateType.FindWeaknesses(TypesDamageMultiplierList);
            ViewModel.Resists = CalculateType.FindResists(TypesDamageMultiplierList);
            ViewModel.Immunes = CalculateType.FindImmunes(TypesDamageMultiplierList);

            return View(ViewModel);
        }
    }
}