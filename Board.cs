using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Les_5._View_2
{
    class Board
    {
        byte width;
        byte height;

        byte red_players_count;
        byte red_kings;
        byte red_queens;
        byte blue_players_count;
        byte blue_kings;
        byte blue_queens;

        public Board(byte Width, byte Height)
        {
            red_kings = 0;
            red_queens = 0;
            blue_kings = 0;
            blue_queens = 0;
            red_players_count = 0;
            blue_players_count = 0;
            width = Width;
            height = Height;
            Console.SetWindowSize(Width + 15, Height + 10);
            Controller_Paint();
            
        }


        #region Default board paint


        public void Board_Paint()
        {
            for (byte i = 0; i < width; i++)
            {
                for (byte j = 0; j < height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine('.');
                }
            }
        }
        private void Controller_Paint()
        {
            #region Kings
            Console.SetCursorPosition(1, height + 2);
            Console.Write(" Kings" +
                        "\n control");

            Console.SetCursorPosition(4, height + 5);
            Console.Write((char)24);
            Console.SetCursorPosition(4, height + 4);
            Console.Write('W');

            Console.SetCursorPosition(4, height + 7);
            Console.Write((char)25);
            Console.SetCursorPosition(4, height + 8);
            Console.Write('S');

            Console.SetCursorPosition(2, height + 6);
            Console.Write((char)17);
            Console.SetCursorPosition(1, height + 6);
            Console.Write('A');

            Console.SetCursorPosition(6, height + 6);
            Console.Write((char)16);
            Console.SetCursorPosition(7, height + 6);
            Console.Write('D');
            #endregion

            #region Queens
            Console.SetCursorPosition(11, height + 2);
            Console.Write("  Queen");
            Console.SetCursorPosition(12, height + 3);
            Console.Write("control");


            Console.SetCursorPosition(14, height + 5);
            Console.Write((char)24);
            Console.SetCursorPosition(13, height + 5);
            Console.Write((char)17);
            Console.SetCursorPosition(13, height + 4);
            Console.Write("Q");

            Console.SetCursorPosition(16, height + 5);
            Console.Write((char)24);
            Console.SetCursorPosition(17, height + 5);
            Console.Write((char)16);
            Console.SetCursorPosition(17, height + 4);
            Console.Write("W");

            Console.SetCursorPosition(14, height + 6);
            Console.Write((char)25);
            Console.SetCursorPosition(13, height + 6);
            Console.Write((char)17);
            Console.SetCursorPosition(13, height + 7);
            Console.Write("A");

            Console.SetCursorPosition(16, height + 6);
            Console.Write((char)25);
            Console.SetCursorPosition(17, height + 6);
            Console.Write((char)16);
            Console.SetCursorPosition(17, height + 7);
            Console.Write("S");
            #endregion

            #region Player Choose

            Console.SetCursorPosition(24, height + 4);
            Console.Write("Player");
            Console.SetCursorPosition(24, height + 5);
            Console.Write("choose");

            Console.SetCursorPosition(22, height + 6);
            Console.Write((char)17);
            Console.SetCursorPosition(21, height + 6);
            Console.Write("A");

            Console.SetCursorPosition(31, height + 6);
            Console.Write((char)16);
            Console.SetCursorPosition(32, height + 6);
            Console.Write("D");

            Console.SetCursorPosition(24, height + 6);
            Console.Write("Enter!");

            #endregion
        }


        #endregion



        #region Game and count players check


        public bool Game_Players_Check(List<Figura> Red_Players, List<Figura> Blue_Players)
        {
            red_players_count = 0;
            red_kings = 0;
            red_queens = 0;

            blue_players_count = 0;
            blue_kings = 0;
            blue_queens = 0;
            foreach (Figura player in Red_Players)
            {
                if (player.life == true)
                {
                    red_players_count++;
                    if(player.GetType() == typeof(King))
                        red_kings++;
                    else if(player.GetType() == typeof(Queen))
                        red_queens++;
                }
            }

            foreach (Figura player in Blue_Players)
            {
                if (player.life == true)
                {
                    blue_players_count++;
                    if (player.GetType() == typeof(King))
                        blue_kings++;
                    else if (player.GetType() == typeof(Queen))
                        blue_queens++;
                }
            }

            Players_Information_Print();
            return Check_Player_Count();
        }

        private bool Check_Player_Count()
        {
            bool Game_end = false;
            if (red_players_count == 0 && blue_players_count > 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Congratulations, blue win!");
                Game_end = true;
            }
            else if (red_players_count > 0 && blue_players_count == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Congratulations, red win!");
                Game_end = true;
            }
            return Game_end;
        }

        private void Players_Information_Print()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(width + 1, height - (height / 3)); Console.WriteLine($"Red count:{red_players_count}");
            Console.SetCursorPosition(width + 1, height - (height / 3) + 1); Console.Write($"K:{red_kings} Q:{red_queens}");


            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(width + 1, height - (height / 3 * 2)); Console.WriteLine($"Blue count:{blue_players_count}");
            Console.SetCursorPosition(width + 1, height - (height / 3 * 2) + 1); Console.Write($"K:{blue_kings} Q:{blue_queens}");


        }


        #endregion
        


        #region Player painting


        public void Player_paint(byte Width, byte Height, bool Blue_Red, byte type)
        {
            if (Blue_Red == false)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(Width, Height);
                switch (type)
                {
                    case 1: Console.WriteLine('K'); break;
                    case 2: Console.WriteLine('Q'); break;
                }
            }
            else if (Blue_Red == true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Width, Height);
                switch (type)
                {
                    case 1: Console.WriteLine('K'); break;
                    case 2: Console.WriteLine('Q'); break;
                }
            }
        }

        public void Paint_availabe_moves(byte Player_Width_Position, byte Player_Height_Position,
                                         bool Up__or__Up_Right, bool Down__or__Up_Left, bool Left__or__Down_left, bool Right__or__Down_Right,
                                         byte Type, bool Check_or_Go)
        {
            if(Type == 1)
            {
                Console.SetCursorPosition(4, height + 6);
            }
            else if(Type == 2)
            {
                Console.SetCursorPosition(15, height + 5);
            }
            Thread.Sleep(500);
            Move_Painter(Type, Player_Width_Position, Player_Height_Position, Check_or_Go);
            if (Type == 1)
            {
                if (Up__or__Up_Right == true)
                    Move_Painter(3, Player_Width_Position, (byte)(Player_Height_Position - 1), Check_or_Go );

                if (Down__or__Up_Left == true)
                    Move_Painter(3, Player_Width_Position, (byte)(Player_Height_Position + 1), Check_or_Go);

                if (Left__or__Down_left == true)
                    Move_Painter(3, (byte)(Player_Width_Position - 1), Player_Height_Position, Check_or_Go);

                if (Right__or__Down_Right == true)
                    Move_Painter(3, (byte)(Player_Width_Position + 1), Player_Height_Position, Check_or_Go);
            }
            else if (Type == 2)
            {
                if (Up__or__Up_Right == true)
                    Move_Painter(3, (byte)(Player_Width_Position - 1), (byte)(Player_Height_Position - 1), Check_or_Go);

                if (Down__or__Up_Left == true)
                    Move_Painter(3, (byte)(Player_Width_Position + 1), (byte)(Player_Height_Position - 1), Check_or_Go);

                if (Left__or__Down_left == true)
                    Move_Painter(3, (byte)(Player_Width_Position - 1), (byte)(Player_Height_Position + 1), Check_or_Go);

                if (Right__or__Down_Right == true)
                    Move_Painter(3, (byte)(Player_Width_Position + 1), (byte)(Player_Height_Position + 1), Check_or_Go);
            }
           
        }
        public void PaintOver_availabe_moves(byte Player_Width_Position, byte Player_Height_Position,
                                        bool Up__or__Up_Right, bool Down__or__Up_Left, bool Left__or__Down_left, bool Right__or__Down_Right,
                                        byte Type, bool Check_or_Go, List<Figura> Enemys)
        {
            Move_Painter(Type, Player_Width_Position, Player_Height_Position, Check_or_Go);
            if (Type == 1)
            {

                if (Up__or__Up_Right == true)
                {
                    Move_Painter(3, Player_Width_Position, (byte)(Player_Height_Position - 1), Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                       Enemy.cursor_Width == Player_Width_Position && Enemy.cursor_Height == Player_Height_Position - 1)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }

                if (Down__or__Up_Left == true)
                {
                    Move_Painter(3, Player_Width_Position, (byte)(Player_Height_Position + 1), Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position && Enemy.cursor_Height == Player_Height_Position + 1)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }

                if (Left__or__Down_left == true)
                {
                    Move_Painter(3, (byte)(Player_Width_Position - 1), Player_Height_Position, Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position - 1 && Enemy.cursor_Height == Player_Height_Position)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }

                if (Right__or__Down_Right == true)
                {
                    Move_Painter(3, (byte)(Player_Width_Position + 1), Player_Height_Position, Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position + 1 && Enemy.cursor_Height == Player_Height_Position)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }
            }
            else if(Type == 2)
            {
                if (Up__or__Up_Right == true)
                {
                    Move_Painter(3, (byte)(Player_Width_Position - 1), (byte)(Player_Height_Position - 1), Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position - 1 && Enemy.cursor_Height == Player_Height_Position - 1)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }

                if (Down__or__Up_Left == true)
                {
                    Move_Painter(3, (byte)(Player_Width_Position + 1), (byte)(Player_Height_Position - 1), Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position + 1 && Enemy.cursor_Height == Player_Height_Position - 1)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }

                if (Left__or__Down_left == true)
                {
                    Move_Painter(3, (byte)(Player_Width_Position - 1), (byte)(Player_Height_Position + 1), Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position - 1 && Enemy.cursor_Height == Player_Height_Position + 1)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }

                if (Right__or__Down_Right == true)
                {
                    Move_Painter(3, (byte)(Player_Width_Position + 1), (byte)(Player_Height_Position + 1), Check_or_Go);

                    foreach (Figura Enemy in Enemys)
                    {
                        if (Enemy.life == true &&
                        Enemy.cursor_Width == Player_Width_Position + 1 && Enemy.cursor_Height == Player_Height_Position + 1)
                            Player_paint(Enemy.cursor_Width, Enemy.cursor_Height, Enemy.blue_red, Enemy.type);
                    }
                }
            }

        }
        public void Move_Painter(byte type, byte Width, byte Height, bool Paint_PaintOver)
        {
            Console.SetCursorPosition(Width, Height);
            if(Paint_PaintOver == false)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if(Paint_PaintOver == true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            switch (type)
            { 
                case 1: Console.WriteLine('K'); break;
                case 2: Console.WriteLine('Q'); break;
                case 3: Console.WriteLine('.'); break;
            }
        }

        public void Player_Move_Paint(byte Later_Width, byte Later_Height, byte New_Width, byte New_Height, bool Blue_Red, byte Type)
        {
            Console.SetCursorPosition(Later_Width, Later_Height);
            Console.WriteLine('.');
            Player_paint(New_Width, New_Height, Blue_Red, Type);
        }


        #endregion
    }
}
