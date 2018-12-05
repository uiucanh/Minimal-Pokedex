using System.Collections.Generic;
using System.Linq;
namespace MinimalPokedex.Models
{
    public class EFPokemonRepository : IPokemonRepository
    {
        private ApplicationDbContext context; 
        public EFPokemonRepository(ApplicationDbContext ctx)

        {
            context = ctx;
        }

        public IQueryable<Pokemon> Pokemons => context.Pokemons;
        public IQueryable<Ability> Abilities => context.Abilities;
        public IQueryable<PokemonAbilities> PokemonAbilities => context.PokemonAbilities;
        public IQueryable<Type> Type1 => context.Type1;
        public IQueryable<Type> Type2 => context.Type2;
        public IQueryable<Type> WeaknessTypes => context.WeaknessTypes;
    }
}