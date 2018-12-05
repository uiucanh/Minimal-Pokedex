using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models
{
    public interface IPokemonRepository
    {
        IQueryable<Pokemon> Pokemons { get; }
        IQueryable<Ability> Abilities { get; }
        IQueryable<PokemonAbilities> PokemonAbilities { get; }
        IQueryable<Type> Type1 { get; }
        IQueryable<Type> Type2 { get; }
        IQueryable<Type> WeaknessTypes { get; }
    }
}
