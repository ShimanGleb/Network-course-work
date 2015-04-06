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
            base.HitEnemy(enemy, character);
            character.health -= character.attack;
            DamageDealer dealer = new DamageDealer();
            return dealer.attack(enemy.defense,enemy.agility,character.attack*3,character.agility,character.luck);             
        }
        public TwoSidedStrike()
        {
            name = "STOP SCREAMING!!!";
            description = "Krieg tells about this skill:\"I ATE YOUR CHILDREN!!!\". Meaning is unknown. \r\nHits enemy with 3 times power, but takes damage equal basic attack.";
        }
    }
}
