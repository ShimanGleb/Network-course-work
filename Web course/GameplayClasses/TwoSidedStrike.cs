using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class TwoSidedStrike:AttackSkill
    {
        public override int HitEnemy(Hero enemy, Hero character)
        {            
            DamageDealer dealer = new DamageDealer();
            character.health -= character.attack;
            return dealer.attack(enemy.defence,enemy.agility,character.attack*3,character.agility,character.luck);             
        }
        public TwoSidedStrike()
        {
            name = "STOP SCREAMING!!!";
            description = "Krieg tells about this skill:\"I ATE YOUR CHILDREN!!!\". Meaning is unknown. \r\nHits enemy with 3 times power, but takes damage equal basic attack.";
        }
    }
}
