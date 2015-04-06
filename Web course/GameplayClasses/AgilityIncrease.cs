using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class AgilityIncrease:BuffSkill
    {
        public override void Buff(Hero enemy, Hero character)
        {
            base.Buff(enemy,character);
            character.agility += 20;
        }
        public AgilityIncrease()
        {
            name = "\"Hurry\"";
            description = "Gylph \"Hurry\" dramatically increases speed, provoding master with high speed and reaction. \r\nIncreases agility by 20 for 3 turns.";
        }
    }
}
