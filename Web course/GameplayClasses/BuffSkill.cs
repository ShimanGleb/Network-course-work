using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class BuffSkill:Skill
    {        
        public int timer = 3;
        public virtual void Buff(Hero enemy, Hero character)
        {
            character.buffTimer = timer;
        }
    }
}
