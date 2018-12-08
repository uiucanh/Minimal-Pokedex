using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalPokedex.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<PokemonAbilities> PokemonAbilities { get; set; }
        public DbSet<Type> Type1 { get; set; }
        public DbSet<Type> Type2 { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonAbilities>().HasKey(sc => new { sc.PokemonID, sc.AbilityID });
        }
    }
}
