using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class ShrineMaiden:Hero
    {
        public ShrineMaiden()
        {
            type = "Shrine maiden";
            DefenseIgnoringAttack attackTemp = new DefenseIgnoringAttack();
            attackSkill = attackTemp;
            LuckIncrease buffTemp = new LuckIncrease();
            buffSkill = buffTemp;
            BuffAbort passiveTemp = new BuffAbort();
            passiveSkill = passiveTemp;
        }
    }
}
