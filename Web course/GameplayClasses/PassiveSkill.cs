using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class PassiveSkill:Skill
    {
        public int power = 10;  
        public virtual void Affect(Hero enemy, Hero character)
        {
            
        }
    }
}
