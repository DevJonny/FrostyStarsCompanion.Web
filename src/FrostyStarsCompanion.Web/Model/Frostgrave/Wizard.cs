using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class Wizard
    {
        public School Class { get; set; } = School.Chronomancer;
        public Weapon Weapon { get; set; } = Weapon.None;
        public Weapon OptionalWeapon { get; set; } = Weapon.None;
        public Stats Stats { get; set; } = new(0, 0, 0, 0, 0, 0);
        public WizardSpells SelectedSpells { get; set; } = new(Array.Empty<Spells>(), Array.Empty<Spells>(), Array.Empty<Spells>(), Array.Empty<Spells>());

        [JsonIgnore] public WeaponProfile WeaponProfile => FrostgraveData.Weapons.First(w => w.Type == Weapon);
        [JsonIgnore] public virtual int CastingModifier => 0;
        
        public List<Spell> Spells()
        {
            if (_spells is not null)
                return _spells;

            _spells = new List<Spell>(HydrateSpells(SelectedSpells.Base, CastingModifier));
            
            _spells.AddRange(HydrateSpells(SelectedSpells.Aligned, 2 + CastingModifier));
            _spells.AddRange(HydrateSpells(SelectedSpells.Neutral, 4 + CastingModifier));
            _spells.AddRange(HydrateSpells(SelectedSpells.Opposed, 6 + CastingModifier));

            return _spells;
        }

        private List<Spell> _spells;

        static IEnumerable<Spell> HydrateSpells(IEnumerable<Spells> spells, int castingValueIncrease = 0)
        {
            var hydratedSpells = spells.Select(s => FrostgraveData.Spells.First(sp => sp.Type == s));
            
            return castingValueIncrease is 0 
                ? hydratedSpells 
                : hydratedSpells.Select(hs => hs with {CastingValue = hs.CastingValue + castingValueIncrease});
        }
    }

    public record WizardSpells(IEnumerable<Spells> Base, IEnumerable<Spells> Aligned, IEnumerable<Spells> Neutral, IEnumerable<Spells> Opposed);
}