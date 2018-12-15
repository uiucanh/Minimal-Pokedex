using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models
{
    public class Team
    {
        private List<TeamLineUp> teamCollection = new List<TeamLineUp>();

        public virtual void AddPokemon(Pokemon pokemon, int type1id, int? type2id)
        {
            if (AtMaximum())
            {
                // If there are 6 pokemons already
                return;
            }
            float[] TypesDamageMultiplierList = CalculateType.CalculateTypes(type1id, type2id);
            List<Type> WeaknessTypes = CalculateType.FindWeaknesses(TypesDamageMultiplierList);
            teamCollection.Add(new TeamLineUp { Pokemon = pokemon, Weaknesses=WeaknessTypes });
        }

        public virtual void RemovePokemon(Pokemon pokemon, int index)
        {
            teamCollection.RemoveAt(index);
        }

        public virtual bool AtMaximum() => teamCollection.Count() >= 6;

        public virtual void Clear() => teamCollection.Clear();
        public virtual IEnumerable<TeamLineUp> Pokemons => teamCollection;
    }

    public class TeamLineUp
    {
        public int TeamID { get; set; }
        public Pokemon Pokemon { get; set; }
        public IEnumerable<Type> Weaknesses { get; set; }
    }
}
