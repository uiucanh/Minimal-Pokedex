using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models.ViewModels
{
    public class PokemonDetailViewModel
    {
        public Pokemon Pokemon { get; set; }
        public IQueryable<Ability> Abilities { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }
        public string PrevPokemon { get; set; }
        public string NextPokemon { get; set; }
        public IEnumerable<Type> Weaknesses { get; set; }
        public IEnumerable<Type> Resists { get; set; }
        public IEnumerable<Type> Immunes { get; set; }
    }
}
