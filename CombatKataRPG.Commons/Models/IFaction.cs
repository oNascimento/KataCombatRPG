using System.Collections.Generic;

namespace CombatKataRPG.Commons.Models
{
    public abstract class IFaction
    {
        public string Name { get; set; }
        public List<ICharacter> Characters { get; set; }

        public void HealAlly(Character character, long healAmount){
            if(Characters.Contains(character))
                character.HealAmount(healAmount);
        }
    }
}