using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class DamageBlock:PassiveSkill
    {
        public DamageBlock()
        {
            power = 5;
            name = "\"Shell\"";
            description = "Glyph \"Shell\" creates protective shield which blocks any incomming damage. \r\nNulls incoming damage.";
        }
    }
}
