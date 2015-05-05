using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class BuffAbort:PassiveSkill
    {
        public BuffAbort()
        {
            power = 20;
            name = "Power of shrine maiden";
            description = "Reimu, as shrine maiden, knows how to seal evil spirits, and enemy buffs.\r\nHas a chance " + power + " to remove enemy buff.";
        }
    }
}
