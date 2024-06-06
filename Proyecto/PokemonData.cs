using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class PokemonData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SpriteData Sprites { get; set; }
        public List<TypeData> Types { get; set; }
        public List<StatData> Stats { get; set; }
        public List<MoveData> Moves { get; set; }
        public List<AbilityData> Abilities { get; set; }
        public List<HeldItemData> Held_Items { get; set; }
    }

    internal class StatData
    {
        public StatDetail Stat { get; set; }
        public int Base_Stat { get; set; }
    }

    internal class StatDetail
    {
        public string Name { get; set; }
    }
    internal class MoveData
    {
        public MoveDetail Move { get; set; }
    }

    internal class MoveInfo
    {
        public string Name { get; set; }
        public IEnumerable<FlavorTextEntry> Flavor_Text_Entries { get; internal set; }
    }

    internal class FlavorTextEntry
    {
        public string Flavor_Text { get; set; }
        public Language Language { get; set; }
    }
    internal class Language
    {
        public string Name { get; set; }
    }

    internal class MoveDetail
    {
        public string Name { get; set; }
    }

    internal class MoveType
    {
        public string Name { get; set; }
    }

    internal class AbilityData
    {
        public AbilityDetail Ability { get; set; }
    }

    internal class AbilityDetail
    {
        public string Name { get; set; }
    }

    internal class HeldItemData
    {
        public HeldItemDetail Item { get; set; }
    }

    internal class HeldItemDetail
    {
        public string Name { get; set; }
    }
    internal class ItemInfo
    {
        public string Name { get; set; }
        public List<ItemEffectEntry> Effect_Entries { get; set; }
    }

    internal class ItemEffectEntry
    {
        public string Effect { get; set; }
        public string ShortEffect { get; set; }
    }
    internal class PokemonSpeciesData
    {
        public List<FlavorTextEntry> Flavor_Text_Entries { get; set; }
    }

    public class TypeInfo
    {
        public string Name { get; set; }
    }
}