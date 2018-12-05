using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models.ViewModels
{
    public class PokemonListViewModel
    {
        public IEnumerable<Pokemon> Pokemons { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
