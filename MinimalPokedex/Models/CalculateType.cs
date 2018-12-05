using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models
{
    public class CalculateType
    {
        public static string[] TypeList = { "Bug","Dark","Dragon","Electric","Fairy","Fighting","Fire",
                "Flying","Ghost","Grass","Ground","Ice","Normal","Poison",
                "Psychic","Rock","Steel","Water"};

        public const int NumberOfTypes = 18;

        public static float[][] TypeEffectiveness =
        {
            new float[]{1, 1, 1, 1, 1, 0.5f, 2, 2, 1, 0.5f, 0.5f, 1, 1, 1, 1, 2, 1, 1},
            new float[]{2, 0.5f, 1, 1, 2, 2, 1, 1, 0.5f, 1, 1, 1, 1, 1, 0, 1, 1, 1},
            new float[]{1, 1, 2, 0.5f, 2, 1, 0.5f, 1, 1, 0.5f, 1, 2, 1, 1, 1, 1, 1, 0.5f},
            new float[]{1, 1, 1, 0.5f, 1, 1, 1, 0.5f, 1, 1, 2, 1, 1, 1, 1, 1, 0.5f, 1},
            new float[]{0.5f, 0.5f, 0, 1, 1, 0.5f, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1},
            new float[]{0.5f, 0.5f, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 0.5f, 1, 1},
            new float[]{0.5f, 1, 1, 1, 0.5f, 1, 0.5f, 1, 1, 0.5f, 2, 0.5f, 1, 1, 1, 2, 0.5f, 2},
            new float[]{0.5f, 1, 1, 2, 1, 0.5f, 1, 1, 1, 0.5f, 0, 2, 1, 1, 1, 2, 1, 1},
            new float[]{0.5f, 2, 1, 1, 1, 0, 1, 1, 2, 1, 1, 1, 0, 0.5f, 1, 1, 1, 1},
            new float[]{2, 1, 1, 0.5f, 1, 1, 2, 2, 1, 0.5f, 0.5f, 2, 1, 2, 1, 1, 1, 0.5f},
            new float[]{1, 1, 1, 0, 1, 1, 1, 1, 1, 2, 1, 2, 1, 0.5f, 1, 0.5f, 1, 2},
            new float[]{1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 0.5f, 1, 1, 1, 2, 2, 1},
            new float[]{1, 1, 1, 1, 1, 2, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            new float[]{0.5f, 1, 1, 1, 0.5f, 0.5f, 1, 1, 1, 0.5f, 2, 1, 1, 0.5f, 2, 1, 1, 1},
            new float[]{2, 2, 1, 1, 1, 0.5f, 1, 1, 2, 1, 1, 1, 1, 1, 0.5f, 1, 1, 1},
            new float[]{1, 1, 1, 1, 1, 2, 0.5f, 0.5f, 1, 2, 2, 1, 0.5f, 0.5f, 1, 1, 2, 2},
            new float[]{0.5f, 1, 0.5f, 1, 0.5f, 2, 2, 0.5f, 1, 0.5f, 2, 0.5f, 0.5f, 0, 0.5f, 0.5f, 0.5f, 1},
            new float[]{1, 1, 1, 2, 1, 1, 0.5f, 1, 1, 2, 1, 0.5f, 1, 1, 1, 1, 0.5f, 0.5f}
        };

        public static float[] CalculateTypes(int type1, int? type2)
        {
            float[] TypesDamageMultiplierList;
            if (type2 is null)
            {
                TypesDamageMultiplierList = CalculateEffectiveness(type1);
            }
            else
            {
                TypesDamageMultiplierList = CalculateEffectiveness(type1, type2.Value);
            }
            return TypesDamageMultiplierList;
        }

        public static float[] CalculateEffectiveness(int type1)
        {
            return TypeEffectiveness[type1 - 1];
        }

        public static float[] CalculateEffectiveness(int type1, int type2)
        {
            float[] Type1Effectiveness = TypeEffectiveness[type1 - 1];
            float[] Type2Effectiveness = TypeEffectiveness[type2 - 1];
            float[] Result = new float[NumberOfTypes]; 
            for (int i = 0; i < NumberOfTypes; i++)
            {
                Result[i] = Type1Effectiveness[i] * Type2Effectiveness[i];
            }
            return Result;
        }

        public static List<Type> FindWeaknesses(float[] typesDamageMultiplierList)
        {
            List<int> Weaknesses = typesDamageMultiplierList.Select((v, i) => new { v, i })
                    .Where(x => x.v >= 2)
                    .Select(x => x.i).ToList<int>();
            List<Type> WeaknessList = new List<Type>();
            foreach (int p in Weaknesses)
            {
                WeaknessList.Add(new Type(p + 1, CalculateType.TypeList[p]));
            }
            return WeaknessList;
        }

        public static List<Type> FindResists(float[] typesDamageMultiplierList)
        {
            List<int> Resists = typesDamageMultiplierList.Select((v, i) => new { v, i })
                    .Where(x => x.v < 1 && x.v > 0)
                    .Select(x => x.i).ToList<int>();
            List<Type> ResistList = new List<Type>();
            foreach (int p in Resists)
            {
                ResistList.Add(new Type(p + 1, CalculateType.TypeList[p]));
            }
            return ResistList;
        }

        public static List<Type> FindImmunes(float[] typesDamageMultiplierList)
        {
            List<int> Immunes = typesDamageMultiplierList.Select((v, i) => new { v, i })
                    .Where(x => x.v == 0)
                    .Select(x => x.i).ToList<int>();
            List<Type> ImmunesList = new List<Type>();
            foreach (int p in Immunes)
            {
                ImmunesList.Add(new Type(p + 1, CalculateType.TypeList[p]));
            }
            return ImmunesList;
        }
    }
}
