namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public class Warband : Band<Soldier>
    {
        public Wizard Wizard { get; set; }
        public Apprentice Apprentice { get; set; }
    }
}