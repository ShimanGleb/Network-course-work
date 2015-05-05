using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class AgilityIncrease:BuffSkill
    {
        public override void Buff(Hero character)
        {
            base.Buff(character);
            character.agility += character.buffSkill.power;
        }
        public AgilityIncrease()
        {
            buffType = "agility";
            name = "\"Hurry\"";
            description = "Glyph \"Hurry\" dramatically increases speed, provoding master with high speed and reaction. \r\nIncreases agility by 20 for 3 turns.";
        }
    }
}
