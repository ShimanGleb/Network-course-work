using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class Vampire:PassiveSkill
    {                       
        public Vampire()
        {
            power = 0.15;
            name = "I`M LOOSING BLOOD. GIMME YOURS!!!";
            description = "Killing is so pleasant. Look of bleeding enemy gives power to struggle. \r\nTransforms 10% dealt damage to health.";
        }
    }
}
