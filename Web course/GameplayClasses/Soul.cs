using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class Soul:Hero
    {
        public Soul()
        {
            name = "Spirit";
            type = "Soul";
            luck = 40;
            AccurateAttack attackTemp = new AccurateAttack();
            attackSkill = attackTemp;
            AgilityIncrease buffTemp = new AgilityIncrease();
            buffSkill = buffTemp;
            DamageBlock passiveTemp = new DamageBlock();
            passiveSkill = passiveTemp;
        }
    }
}
