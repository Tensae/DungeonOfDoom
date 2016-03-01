using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item
    {

        
        //creating constractor 
        public Item(string name)
        {
            Name = name;
            


        }
        public string Name { get; set; }
        public abstract void GetPickedUP(Player player); //no { bec it is abstruct
        //Player is a type

    }

    class Potion : Item
    {
        public override void GetPickedUP(Player player)
        {
            player.Health += 2;
            player.AttackStrength+=1 ;
        }
        public Potion(string name) : base(name)
        {
        }
    }

    class Scroll : Item
    {
        public override void GetPickedUP(Player player)
        {
            
            player.AttackStrength += 10;
            
        }
        public Scroll() : base("Wish scroll") //all scrool will have a name "wish scroll"
        {

        }
    }

}

