using System;
using System.Collections.Generic;

namespace FrostyStarsCompanion.Web.Model.Stargrave
{
    public class Captain
    {
        public Background Background { get; set; } = Background.Biomorph;
        public Weapon[] Weapons { get; set; } = Array.Empty<Weapon>();
        public Armour Armour { get; set; } = Armour.LightArmour;
        public Stats Stats { get; set; } = new(0,0,0,0,0,0);
        public CaptainPowers SelectedPowers { get; set; } = new (Array.Empty<Powers>(), Array.Empty<Powers>(), Array.Empty<Powers>(), Array.Empty<Powers>());
    }

    public record CaptainPowers
    (
        IEnumerable<Powers> Core,
        IEnumerable<Powers> NonCore,
        IEnumerable<Powers> Empowered,
        IEnumerable<Powers> NonCoreEmpowered
    );
}