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
            name = "Reimu Hakurei";
            type = "Shrine maiden";
            agility = 40;
            DefenseIgnoringAttack attackTemp = new DefenseIgnoringAttack();
            attackSkill = attackTemp;
            LuckIncrease buffTemp = new LuckIncrease();
            buffSkill = buffTemp;
            BuffAbort passiveTemp = new BuffAbort();
            passiveSkill = passiveTemp;
        }
    }
}
