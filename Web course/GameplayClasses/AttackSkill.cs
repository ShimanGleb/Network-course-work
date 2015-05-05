using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class AttackSkill:Skill
    {        
        public virtual int HitEnemy(Hero enemy, Hero character)
        {
            Random rand = new Random();
            if (rand.Next(0, 100) > ((100-enemy.agility)+character.agility)) return -1;
            return 0;
        }
    }
}
