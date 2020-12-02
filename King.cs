using System;
using System.Collections.Generic;
using System.Text;

namespace Les_5._View_2
{
    class King : Figura
    {

        public King(byte Figure_Number, byte Cursor_Width, byte Cursor_Height, bool Blue_red) :
                base(Figure_Number,Cursor_Width, Cursor_Height, Blue_red)
        {
            type = 1;
        }



        public override void Move(byte Board_width, byte Board_height, List<Figura> Players_allies, Board board, List<Figura> Enemy_players)
        {
            bool availabe = Availabe_Move(Board_width, Board_height, Players_allies, board);
            if(availabe == true)
            {
                ConsoleKeyInfo key;
                while (true)
                {

                    key = Console.ReadKey(true);
                    if (Up == true && key.Key == ConsoleKey.W)
                    {

                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, Up, Down, Left, Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, cursor_Width, (byte)(cursor_Height - 1), blue_red, type);
                        cursor_Height--;
                        break;
                    }
                    else if (Down == true && key.Key == ConsoleKey.S)
                    {
                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, Up, Down, Left, Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, cursor_Width, (byte)(cursor_Height + 1), blue_red, type);
                        cursor_Height++;
                        break;
                    }
                    else if (Left == true && key.Key == ConsoleKey.A)
                    {
                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, Up, Down, Left, Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, (byte)(cursor_Width - 1), cursor_Height, blue_red, type);
                        cursor_Width--;
                        break;
                    }
                    else if (Right == true && key.Key == ConsoleKey.D)
                    {
                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, Up, Down, Left, Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, (byte)(cursor_Width + 1), cursor_Height, blue_red, type);
                        cursor_Width++;
                        break;
                    }
                }
                
            }
            Check_Enemy_On_Player_Position(Enemy_players);

        }
        public override bool Availabe_Move(byte Board_width, byte Board_height, List<Figura> Players_allies, Board board)
        {
            bool availabe = true;
            Up = true;
            Down = true;
            Left = true;
            Right = true;
            if (cursor_Height - 1 >= 0)
            {
                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width && player.cursor_Height == cursor_Height - 1)
                    {
                        Up = false;
                    }
                }
            }
            else
                Up = false;

            if (cursor_Height + 1 <= Board_height)
            {
                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width && player.cursor_Height == cursor_Height + 1)
                    {
                        Down = false;
                    }
                }
            }
            else
                Down = false;

            if (cursor_Width - 1 >= 0)
            {

                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width - 1 && player.cursor_Height == cursor_Height)
                    {
                       Left = false;
                    }
                }
            }
            else
               Left = false;

            if (cursor_Width + 1 < Board_width)
            {
                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width + 1 && player.cursor_Height == cursor_Height)
                    {
                        Right = false;
                    }
                }
            }
            else
               Right = false;


            if (Up == true || Down == true || Left == true || Right == true)
            {
                board.Paint_availabe_moves(cursor_Width, cursor_Height, Up, Down, Left, Right, type, false);
            }
            else
            {
                availabe = false;
            }

            return availabe;

        }

        


    }
}



