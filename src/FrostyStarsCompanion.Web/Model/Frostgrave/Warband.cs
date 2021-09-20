using System;

namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class Warband : Band<SoldierType>
    {
        public Wizard Wizard { get; set; } = new();
        public Apprentice Apprentice { get; set; } = new();
        public Soldier[] Soldiers { get; set; } = Array.Empty<Soldier>();
    }
}