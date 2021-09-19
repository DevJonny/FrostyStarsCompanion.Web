using System.Collections.Generic;
using FrostyStarsCompanion.Web.Model.Frostgrave;
using FrostyStarsCompanion.Web.Model.Stargrave;

namespace FrostyStarsCompanion.Web.ViewModels
{
    public class IndexViewModel
    {
        public List<Warband> Warbands { get; set; } = new();
        public List<Crew> Crews { get; set; } = new();
    }
}