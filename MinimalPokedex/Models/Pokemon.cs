using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models
{
    public class Pokemon
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int PokemonID { get; set; }

        public string Name { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }
        public int Generation { get; set; }

        public int ExperienceGrowth { get; set; }
        public int EggSteps { get; set; }

        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public bool IsLegendary { get; set; }

        public IList<PokemonAbilities> PokemonAbilities { get; set; }
    }

    public class Type
    {
        public Type(int typeID, string typeName)
        {
            this.TypeID = typeID;
            this.TypeName = typeName;
        }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
    }

    public class PokemonAbilities
    {
        public int PokemonID { get; set; }
        public Pokemon Pokemon { get; set; }

        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        public int AbilityID { get; set; }
        public string AbilityName { get; set; }

        public IList<PokemonAbilities> PokemonAbilities { get; set; }
    }
}
