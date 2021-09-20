using FrostyStarsCompanion.Web.Model.Frostgrave;

namespace FrostyStarsCompanion.Web.ViewModels
{
    public class WarbandViewModel
    {
        public Warband Warband { get; set; } = new();
        public string Title => Warband.Name;
        public Wizard Wizard => Warband.Wizard;
    }
}