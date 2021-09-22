namespace FrostyStarsCompanion.Web.Model.Frostgrave
{
    public record Spell(Spells Type, string Name, School School, Category Category, int CastingValue, string Description);
}