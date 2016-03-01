using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Room
    {
        //here we put a property as Monster/Item instead of int, string etc..for creating an item Monster/Item in z Room
        public Monster MonsterInRoom { get; set; }
        
        public Item ItemInRoom{ get; set; }
    }
}
