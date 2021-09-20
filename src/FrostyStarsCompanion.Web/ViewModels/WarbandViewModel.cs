using System;
using System.Collections.Generic;
using System.Linq;
using FrostyStarsCompanion.Web.Model.Frostgrave;

namespace FrostyStarsCompanion.Web.ViewModels
{
    public class WarbandViewModel
    {
        public Warband Warband { get; set; } = new();
        public string Title => Warband.Name;
        public Wizard Wizard => Warband.Wizard;
        public Apprentice Apprentice => Warband.Apprentice;

        public IEnumerable<SoldierProfile> Soldiers =>
            Warband.Soldiers.Select(s =>
                FrostgraveData.Soldiers.First(sd => sd.SoldierType == s.Type) with {Id = s.Id}
            );
    }
}