using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class BuffSkill:Skill
    {
        public int power = 20;
        public int timer = 3;
        public string buffType = "";
        public virtual void Buff(Hero character)
        {
            character.buffs.Add(buffType+"+"+power,timer);
        }
    }
}