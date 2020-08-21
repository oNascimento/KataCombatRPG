using System.Collections.Generic;
using System.Linq;

namespace CombatKataRPG.Commons.Models
{
    public class Character : ICharacter
    {
        public Character(string name)
        {
            Name = name;
            Level = 1;
            LifePoints = 1000;
            MaxRange = CharacterClass.MELEE;
        }

        public CharacterClass MaxRange { get; set; }
        public List<ICharacter> Allies { get; set; }
        public void DealDamage(IEnumerable<ICharacter> characters, long damage)
        {
            characters = characters.Where(c => !this.Allies.Contains(c));
            foreach (var character in characters)
            {
                var currentDamage = damage;
                if(Level >= character.Level + 5) currentDamage *= 2;
                if(Level <= character.Level + 5) currentDamage /= 2;

                if(this != character && (this.Position - character.Position) <= (int) this.MaxRange)
                    character.LifePoints -= currentDamage;
            }
        }

        public void JoinFaction(IFaction faction, ICharacter character)
        {
            faction.Characters.Add(character);
            Allies.AddRange(faction.Characters);
        }
        public void LeaveFaction(IFaction faction, Character character)
        {
            faction.Characters.Remove(character);
            faction.Characters.ForEach(c => character.Allies.Remove(c));
        }
        
        public void HealAmount(long healing)
        {
            if (this.IsAlive)
                this.LifePoints += healing;
        }
    }
}