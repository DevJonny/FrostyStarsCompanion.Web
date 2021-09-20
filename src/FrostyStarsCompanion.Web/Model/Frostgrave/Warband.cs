namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class Warband : Band<Soldier>
    {
        public Wizard Wizard { get; set; } = new();
        public Apprentice Apprentice { get; set; } = new();
    }
}