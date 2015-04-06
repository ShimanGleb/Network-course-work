using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class DefenseUp:BuffSkill
    {
        public override void Buff(Hero enemy, Hero character)
        {
            base.Buff(enemy, character);
            character.defense += 20;
        }
        public DefenseUp()
        {
            name = "NOW YOU SHOULD BE SCARED!!!";
            description = "Krieg got used to pain, and learnt to ignore it. \r\nIncreases defense by 20 for 3 turns.";
        }
    }
}
