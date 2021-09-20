using System;
using System.Collections.Generic;
using System.Linq;

namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public record SoldierProfile
    {
        public Guid Id { get; init; }
        public SoldierType SoldierType { get; init; }
        public Stats Stats { get; init; }
        public int Cost { get; init; }
        public Weapon[] Weapons { get; init; }

        public IEnumerable<WeaponProfile> WeaponProfiles =>
            Weapons.Select(w => FrostgraveData.Weapons.First(wd => wd.Type == w));
    }
}