using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    class DamageDealer
    {
        public int attack(int enemyDefense, int enemyAgility, int characterAttack, int characterAgility, int characterLuck)
        {
            int damage = characterAttack;
            Random rand = new Random();
            if (rand.Next(0, 100) <= characterLuck) damage *= 2;
            damage *=  (enemyDefense / 100);
            return damage;
        }
    }
}
