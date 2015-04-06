using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class Vampire:PassiveSkill
    {               
        public override void Affect(Hero enemy, Hero character)
        {
            
        }
        public Vampire()
        {
            name = "I`M LOOSING BLOOD. GIMME YOURS!!!";
            description = "Killing is so pleasant. Look of bleeding enemy gives power to struggle. \r\nTransforms 10% dealt damage to health.";
        }
    }
}
