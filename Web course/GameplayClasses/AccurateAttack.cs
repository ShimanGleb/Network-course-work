﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class AccurateAttack:AttackSkill
    {
        public override int HitEnemy(Hero enemy, Hero character)
        {            
            DamageDealer dealer = new DamageDealer();
            return dealer.attack(enemy.defence, enemy.agility, Convert.ToInt32(character.attack*0.9), character.agility+20, character.luck);       
        }
        public AccurateAttack()
        {
            name = "\"Hawk\"";
            description = "Glyph \"Hawk\" creates a stick golem, which, being colored, will fly to pointed direction.\r\nHas high hit chance, but a bit weaker than normal attack.";
        }
    }
}
