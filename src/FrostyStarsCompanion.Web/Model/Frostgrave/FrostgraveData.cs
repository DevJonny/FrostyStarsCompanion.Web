using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class FrostgraveData
    {
        [JsonIgnore]
        public static readonly IReadOnlyCollection<WeaponProfile> Weapons = new List<WeaponProfile>
        {
            new(Weapon.None, nameof(Weapon.None), 0, 0, string.Empty),
            new(Weapon.Staff, nameof(Weapon.Staff), -1, 0, "-1 damage modifier to opponent in hand-to-hand combat" ),
            new(Weapon.Bow, nameof(Weapon.Bow), 0, 0, ""),
            new(Weapon.TwoHandedWeapon, "Two-Handed Weapon", 0, 0, ""),
            new(Weapon.Dagger, nameof(Weapon.Dagger), 0, 0, ""),
            new(Weapon.HandWeapon, "Hand Weapon", 0, 0, "")
        };

        [JsonIgnore] 
        public static readonly IReadOnlyCollection<SoldierProfile> Soldiers = new List<SoldierProfile>
        {
            new() { Id = Guid.Empty, SoldierType = SoldierType.Archer, Stats = new Stats(6, 3, 2, 11, 0, 10), Cost = 50, Weapons = new[] {Weapon.Bow, Weapon.Dagger}},
            new() { Id = Guid.Empty, SoldierType = SoldierType.Infantryman, Stats = new Stats(6, 3, 0, 11, 0, 10), Cost = 50, Weapons = new[] {Weapon.TwoHandedWeapon}},
            new() { Id = Guid.Empty, SoldierType = SoldierType.MenAtArms, Stats = new Stats(6, 3, 0, 12, 1, 12), Cost = 80, Weapons = new[] {Weapon.HandWeapon}},
            new() { Id = Guid.Empty, SoldierType = SoldierType.Thief, Stats = new Stats(7, 1, 0, 10, 0, 10), Cost = 20, Weapons = new[] {Weapon.Dagger}},
            new() { Id = Guid.Empty, SoldierType = SoldierType.Thug, Stats = new Stats(6, 2, 0, 10, -1, 10), Cost = 20, Weapons = new[] {Weapon.HandWeapon}}
        };

        public List<Warband> Warbands { get; init; }
    }

    public record WeaponProfile (Weapon Type, string Name, int DamageModifier, int MaximumRange, string Notes);
}