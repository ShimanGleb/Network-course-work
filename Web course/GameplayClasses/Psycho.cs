using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class Psycho:Hero
    {        
        public Psycho()
        {
            name = "Krieg";
            type = "Psycho";
            attack = 20;
            TwoSidedStrike attackTemp = new TwoSidedStrike();
            attackSkill = attackTemp;
            DefenseUp buffTemp = new DefenseUp();
            buffSkill = buffTemp;
            Vampire passiveTemp = new Vampire();
            passiveSkill = passiveTemp;
        }        
    }
}
