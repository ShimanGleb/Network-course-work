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
        public int health = 100;
        public int attack = 10;
        public int defense = 10;
        public int agility = 10;        
        public int luck = 20;
        public int buffTimer = 0;
        public string buffType;
        public int debuffTimer = 0;
        public string debuffType;
        public AttackSkill attackSkill = new AttackSkill();
        public BuffSkill buffSkill = new BuffSkill();
        public PassiveSkill passiveSkill = new PassiveSkill();
    }
}
