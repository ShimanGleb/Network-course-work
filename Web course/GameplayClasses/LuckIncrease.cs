using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class LuckIncrease:BuffSkill
    {
        public override void Buff(Hero character)
        {
            base.Buff(character);
            character.luck += 20;
        }
        public LuckIncrease()
        {
            buffType = "luck";
            name = "Great intuition";
            description = "Reimu has a great intuition. When she relies on it, she always finds a right way to solve problem.\r\nIncreases luck by 20 for 3 turns.";
        }
    }
}
