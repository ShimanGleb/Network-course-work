using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class DefenseUp:BuffSkill
    {
        public override void Buff(Hero character)
        {
            base.Buff(character);
            character.defence += 20;
        }
        public DefenseUp()
        {
            buffType = "defence";
            name = "NOW YOU SHOULD BE SCARED!!!";
            description = "Krieg got used to pain, and learnt to ignore it. \r\nIncreases defense by 20 for 3 turns.";
        }
    }
}
