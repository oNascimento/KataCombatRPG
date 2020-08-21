namespace CombatKataRPG.Commons.Models
{
    public class Thing : ICharacter
    {
        public Thing()
        {
            Name = "Thing";
            Level = 0;
            LifePoints = 2000;
        }
    }
}