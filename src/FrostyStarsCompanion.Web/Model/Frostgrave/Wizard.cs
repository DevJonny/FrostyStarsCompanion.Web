using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class Wizard
    {
        public Class Class { get; set; } = Class.Necromancer;
        public Weapon Weapon { get; set; } = Weapon.None;
        public Weapon OptionalWeapon { get; set; } = Weapon.None;
        public Stats Stats { get; set; } = new Stats(0, 0, 0, 0, 0, 0);
        public Spell[] Spells { get; set; } = Array.Empty<Spell>();

        [JsonIgnore] 
        public WeaponProfile WeaponProfile => FrostgraveData.Weapons.First(w => w.Type == Weapon);
    }
}