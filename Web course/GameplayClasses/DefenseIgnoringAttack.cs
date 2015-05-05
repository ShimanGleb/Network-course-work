using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class DefenseIgnoringAttack:AttackSkill
    {
        public override int HitEnemy(Hero enemy, Hero character)
        {            
            DamageDealer dealer = new DamageDealer();
            return dealer.attack(enemy.defence/2, enemy.agility, character.attack, character.agility, character.luck);
        }
        public DefenseIgnoringAttack()
        {
            name = "Fantasy seal";
            description = "A powerful spellcard sealing all evil power. No one can stand against it.\r\nIgnores half of enemy defense.";
        }
    }
}
