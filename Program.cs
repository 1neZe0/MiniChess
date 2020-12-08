using System;

namespace Les_5._View_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set width of board");
            Console.Write("Width: ");
            byte width = byte.Parse(Console.ReadLine());

            Console.WriteLine("Set height of board");
            Console.Write("Height: ");
            byte height = byte.Parse(Console.ReadLine());

            Gamemode game = new Gamemode(width, height);
            game.init();
            game.Game_Start();
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}

/**
 * no console in king
 * 
 * more responsible classes: gamemode class, board class
 * 
 * { main
 *     gamemode = new Gamemode()
 *     
 *     gamemode.init() -> {
 *          board = new Board(10,10)
 *          
 *          king = new King()
 *          
 *          board.set([0,2], king) -> public void set(coord, Figure)
 *     }
 *     
 *     gamemode.run() -> while(not finished)
 * }
 * 
 * board - responsiable for render - all Console there
 * 
**/