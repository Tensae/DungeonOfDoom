using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        // here we creat our map size
        const int mapWidth = 20;
        const int mapHeight = 10;
        Room[,] rooms = new Room[mapWidth, mapHeight]; //creat 2 dim array room
        Player player = new Player();
       // Giant giant = new Giant(); we can creat objects of itemson the same way
       
        int monsterCount =0;


        public void Start()
        {
            //when it starts it will creat a map, display player info, display map
            CreatMap();


            //we will run many times till the game is over so we have to use do while loop method. if it is "for" it is fixed with how many times it should run. 
            do
            {
                Console.Clear(); //it will hide the steps but display the result
                DisplayPlayerInfo();
                DisplayMap();
                if(monsterCount==0)
                {
                    Console.WriteLine("You won!!");

                }

                AskForCommand();



            } while (player.Health > 0);
            Console.WriteLine("Game is over");//as the player is alive 

            
        }

        private void CreatMap()
        {
           Random rand = new Random();
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Room room = new Room();
                    rooms[x, y] = room;
                   // int randomValue = rand.Next(100);
                   // if (randomValue < 10)

                        // here locations in z map
                        if (x == 1 && y == 1)
                            room.MonsterInRoom = new Giant();
                    monsterCount++;
                
                //    else if (randomValue < 5)

                        if (x == 6 && y == 4)
                            room.MonsterInRoom = new Ogre();
                    monsterCount++;

                    if (x == 3 && y == 3)

                        room.ItemInRoom = new Potion("Dark potion");
                    if (x == 9 && y == 3)

                        room.ItemInRoom = new Scroll();

                
                }
                
            }
        }

       
        private void DisplayPlayerInfo()
        {
            Console.WriteLine("Health:" + player.Health);
            Console.WriteLine("Attack:" + player.AttackStrength);
            Console.WriteLine("backpack:");
            foreach (Item item in player.BackPack)
            {
                Console.WriteLine(item.Name);
            }



        }

       
       
        public void AskForCommand()
        {
            Console.WriteLine("Enter movement");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            int x = player.X;
            int y = player.Y;

            switch (keyInfo.Key)
            {

                case ConsoleKey.LeftArrow: x--; break;
                case ConsoleKey.RightArrow: x++; break;
                case ConsoleKey.UpArrow: y--; break;
                case ConsoleKey.DownArrow:
                    y++; break;

            }
            //to limit the move fm outside of the map

            if (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight)
            {
                player.X = x;
                player.Y = y;

                Room thisRoom = rooms[x, y];
                if (thisRoom.ItemInRoom != null)
                {
                    player.BackPack.Add(thisRoom.ItemInRoom);
                    thisRoom.ItemInRoom.GetPickedUP(player);
                    thisRoom.ItemInRoom = null; //to make it empty aft the palyer get it
                   
                    

                }
                if (thisRoom.MonsterInRoom != null)
                {
                    player.Fight(thisRoom.MonsterInRoom);
                    thisRoom.MonsterInRoom.Fight(player);
                   

                    if(thisRoom.MonsterInRoom.Health <=0)
                    {
                        
                        thisRoom.MonsterInRoom = null;
                    }

                }

            }
           
        }
       
        private void DisplayMap()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {       
                    Room room = rooms[x, y];

                    if (player.X == x && player.Y == y)
                        Console.Write("P");
                    else if (room.MonsterInRoom != null)
                        Console.Write(room.MonsterInRoom.Name[0]);

                    else if (room.ItemInRoom != null)
                        Console.Write(room.ItemInRoom.Name[0]);
                    else
                        Console.Write(".");
                    
                }
                Console.WriteLine();
            }
        }

    }
   
}
/* creat a sound class with enum :- public enum Mysound{
Eating, 
Attaching, etc..
creat a method with "MySound" parameter
public static void Play(MySound sound) with case statement
{
case MySound.Eating:
path = @"c:...address for sound";
..
isLooping= false;
break;.....

    in Game class, if there is monster.. if palyer attack
    Sound.Play(Sound.*/