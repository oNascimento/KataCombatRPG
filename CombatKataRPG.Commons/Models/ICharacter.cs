namespace CombatKataRPG.Commons.Models
{
    public abstract class ICharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Position { get; set; }
        private long lifePoints;
        public long LifePoints
        {
            get { return lifePoints; }
            set
            {
                if (value >= 0)
                {
                    isAlive = true;
                    lifePoints = value;
                }
                else if (value >= 1000)
                {
                    isAlive = true;
                    lifePoints = 1000;
                }
                else
                {
                    isAlive = false;
                    lifePoints = 0;
                }
            }
        }
        private bool isAlive = true;
        public bool IsAlive
        {
            get { return isAlive; }
        }
    }
}