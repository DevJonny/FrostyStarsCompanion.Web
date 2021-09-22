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

        [JsonIgnore] public static readonly IReadOnlyCollection<Spell> Spells = new List<Spell>
        {
            new(Frostgrave.Spells.BoneDart, "Bone Dart", School.Necromancer, Category.LineOfSight, 10, "This spell fires a small, sharp shard of bone. The spellcaster makes a +5 shooting attack against any figure within line of sight and 12\". This does not count as a magic attack."),
            new(Frostgrave.Spells.Curse, "Curse", School.Witch, Category.LineOfSight, 8, "The target suffers -2 to all die rolls. At the end of the each turn, the target may make a Will Roll with the Target Number equal to the Casting Roll (at -2, of course). If successful, this spell is cancelled. Curse cannot be cast on a figure already suffering the effects of a Curse spell."),
            new(Frostgrave.Spells.Decay, "Decay", School.Chronomancer, Category.LineOfSight, 12, "The spellcaster selects and attacks a target's weapon, causing it to decay and fall apart, rendering it useless for the rest of the game. This spell has no effect on magic weapons (even those temporarily enchanted). This spell has no effect on creatures (unless they are specifically identified as being equipped with a weapon from the General Arms and Armour List)."),
            new(Frostgrave.Spells.FleetFeet, "Fleet Feet", School.Chronomancer, Category.LineOfSight, 10, "The target receives +2 Move for the rest of the game. Multiple castings of Fleet Feet on the same target have no effect."),
            new(Frostgrave.Spells.Leap, "Leap", School.Summoner, Category.LineOfSight, 8, "This spell may only be cast on a member of the spellcaster's warband. Immediately move the target figure up to 10\" in any direction, including vertically. This move must either be in a straight line or an arc. It cannot curve around corners. If this move leaves the figure above the ground, it immediately falls, take damage as normal. If the target is carrying treasure, this move is reduced to 5\". This move may not take a figure off the table or into combat. The target of the Leap spell may take no other actions this turn, though is may have taken actions previously."),
            new(Frostgrave.Spells.Possess, "Possess", School.Summoner, Category.LineOfSight, 12, "This spell may only be cast on a permanent or temporary member of the spellcaster's own warband, except the wizard, apprentice, or demons. The target is possessed by a demon and gains +2 Fight, +1 Armour, and -2 Will and counts as a demon (i.e. it will be affected by Banish, Control Demon, Circle of Protection, etc.). This figure may not be part of a group activation. If removed from the game for any reason (such as being hit by a Banish spell), check for the character's survival as normal. A spellcaster may only have one Possess spell active at a time."),
            new(Frostgrave.Spells.RaiseZombie, "Raise Zombie", School.Necromancer, Category.OutOfGameBefore, 10, "The spellcaster adds one Zombie to their warband as a temporary member. If the spell is cast before the game, the zombie can be deployed normally. If it is cast during a game, the zombie appears in base contact with the spellcaster. A warband may only have one raised Zombie at any one time. If the Zombie is killed or exits the table, Raise Zombie can be cast again to create another."),
            new(Frostgrave.Spells.StealHealth, "Steal Health", School.Necromancer, Category.LineOfSight, 10, "The target must make an immediate Will Roll with a Target Number equal to the Casting Roll. If failed, the target immediately loses 3 Health, even if the target had less Health than that remaining. This may not take the spellcaster above their starting Health. This spell has no effect on undead or constructs. A spellcaster may target a member of their own warband - if they do, however, the target immediately (and permanently) leaves the warband and is treated as an uncontrolled creature for the rest of the game.")
        };

        public List<Warband> Warbands { get; init; }
    }

    public record WeaponProfile (Weapon Type, string Name, int DamageModifier, int MaximumRange, string Notes);
}