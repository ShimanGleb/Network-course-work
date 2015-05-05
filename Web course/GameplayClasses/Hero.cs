using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class Hero
    {
        public string playerName;
        public string name;
        public string type;
        public int health = 1;
        public int attack = 10;
        public int defence = 10;
        public int agility = 10;        
        public int luck = 20;
        public SortedList<string, int> buffs = new SortedList<string, int>();        
        public AttackSkill attackSkill = new AttackSkill();
        public BuffSkill buffSkill = new BuffSkill();
        public PassiveSkill passiveSkill = new PassiveSkill();        
    }
}
