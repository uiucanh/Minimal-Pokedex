using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalPokedex.Infrastructure;
using MinimalPokedex.Models;
using MinimalPokedex.Models.ViewModels;

namespace MinimalPokedex.Controllers
{
    public class TeamController : Controller
    {
        private IPokemonRepository repository;
        private Team team;

        public TeamController(IPokemonRepository repo, Team teamService)
        {
            repository = repo;
            team = teamService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new TeamIndexViewModel
            {
                Team = team,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToTeam(int pokemonID, string returnUrl)
        {
            Pokemon pokemon = repository.Pokemons.Where(p => p.PokemonID == pokemonID).Single();
            if (team.AtMaximum())
            {
                return null;
            }
            if (pokemon != null)
            {
                int type1id = repository.Pokemons.Where(p => p.PokemonID == pokemonID).Select(p => p.Type1).Single().TypeID;
                int? type2id;
                var query = repository.Pokemons.Where(p => p.PokemonID == pokemonID).Select(p => p.Type2).SingleOrDefault();
                type2id = query == null ? null : (int?)query.TypeID;
                team.AddPokemon(pokemon, type1id, type2id);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromTeam(int pokemonID, int index, string returnUrl)
        {
            Pokemon pokemon = repository.Pokemons
            .FirstOrDefault(p => p.PokemonID == pokemonID);
            if (pokemon != null)
            {
                team.RemovePokemon(pokemon, index);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}