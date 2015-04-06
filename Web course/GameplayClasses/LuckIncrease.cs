using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class LuckIncrease:BuffSkill
    {
        public override void Buff(Hero enemy, Hero character)
        {
            base.Buff(enemy, character);
            character.luck += 20;
        }
        public LuckIncrease()
        {
            name = "Great intuition";
            description = "Reimu has a great intuition. When she relies on it, she always finds a right way to solve problem.\r\nIncreases luck by 20 for 3 turns.";
        }
    }
}
