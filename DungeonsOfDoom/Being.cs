using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
   abstract class Being //can't be insatinated/we can't creat new
    {
        public Being (int health, int attackstrength)
        {
            Health = health;
            AttackStrength = attackstrength;
        }
        public int Health { get; set; }
        public int AttackStrength { get; set; }

        public virtual void Fight(Being opponent)//instead of moster/player we use Being...poly rule #1
        {
            opponent.Health -= 10;


        }
    }
}
