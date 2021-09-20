using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class FrostgraveData
    {
        [JsonIgnoreAttribute]
        public static readonly IReadOnlyCollection<WeaponProfile> Weapons = new List<WeaponProfile>()
        {
            new(Weapon.None, 0, 0, string.Empty),
            new(Weapon.Staff, -1, 0, "-1 damage modifier to opponent in hand-to-hand combat" )
        };

        public List<Warband> Warbands { get; init; }
    }

    public record WeaponProfile (Weapon Type, int DamageModifier, int MaximumRange, string Notes);
}