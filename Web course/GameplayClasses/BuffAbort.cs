using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class BuffAbort:PassiveSkill
    {
        public BuffAbort()
        {
            name = "Power of shrine maiden.";
            description = "Reimu, as shrine maiden, knows how to seal evil spirits, and enemy buffs.\r\nHas a chance 10% to remove enemy buff.";
        }
    }
}
