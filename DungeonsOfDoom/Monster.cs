using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster: Being
    {
        public Monster(string name, int health, int attackStrength): base(health, attackStrength)
        {
            Name = name;
            
        }

        public string Name { get; set; }
        
    }

    class Ogre : Monster
    {
        public Ogre() : base("Ogg", 40, 20)
        {

        }
    }
        class Giant : Monster
        {
            public Giant() : base("Gii", 30, 20)
            {

            }
        public override void Fight(Being opponent)//we make override to make a different fight value for Giant 
        {
            opponent.Health -= 20; //copy the superclass method and modify it
        }
    }

    }
