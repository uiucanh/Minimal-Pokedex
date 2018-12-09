using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinimalPokedex.Models;
using MinimalPokedex.Models.ViewModels;

namespace MinimalPokedex.Controllers
{
    public class SearchController : Controller
    {
        private IPokemonRepository repository;
        public int PageSize = 150;

        public SearchController(IPokemonRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string searchString, int listPage=1)
        {
            var query = repository.Pokemons.Where(p => p.Name.Contains(searchString));
            var count = query.Count();
            return View(new PokemonListViewModel
            {
                Pokemons = query
                .OrderBy(p => p.PokemonID)
                .Skip((listPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = count,
                    SearchString = searchString
                }
            });
        }

        public ViewResult ListType()
        {
            return View(new TypeListViewModel
            {
                Types = repository.Types
            });
        }

        public ViewResult ListGeneration()
        {
            var NumGen = repository.Pokemons.Select(g => g.Generation).Distinct().Count();
            ViewBag.NumGen = NumGen;
            List<Tuple<int,int>> NumPokeInGen = new List<Tuple<int,int>>();
            var x = 1;
            var total = 0;
            for(int i = 1; i <= NumGen; i++)
            {
                var queryResult = repository.Pokemons.Where(g => g.Generation == i).Count();
                total += queryResult;
                NumPokeInGen.Add(new Tuple<int, int>(x, queryResult + x - 1));   
                x = total + 1;
            }
            ViewBag.NumPokeInGen = NumPokeInGen;
            return View();
        }

        public ViewResult FilterType(string typeName, int listPage=1)
        {
            var query = repository.Pokemons.Where(p => p.Type1.TypeName == typeName || p.Type2.TypeName ==typeName);
            var count = query.Count();
            return View(new PokemonListViewModel
            {
                Pokemons = query
                .OrderBy(p => p.PokemonID)
                .Skip((listPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = count
                }
            });
        }

        public ViewResult FilterGen(int genNum, int listPage = 1)
        {
            var query = repository.Pokemons.Where(p => p.Generation == genNum);
            var count = query.Count();
            PageSize = 51;
            return View(new PokemonListViewModel
            {
                Pokemons = query
                .OrderBy(p => p.PokemonID)
                .Skip((listPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = listPage,
                    ItemsPerPage = PageSize,
                    TotalItems = count,
                    GenNum = genNum
                }
            });
        }
    }
}