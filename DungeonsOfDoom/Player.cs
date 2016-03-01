using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Being
    {
      

        public Player() : base(100, 30)
        {
            BackPack = new List<Item>();
            
        }

        public int X { get; set; }
        public int Y { get; set; }

        public List<Item> BackPack {get; set; }
           
        
    }

    

}
       
    
