using System;
using System.Collections.Generic;
using System.Text;

namespace Les_5._View_2
{
    class Queen : Figura
    {

        public Queen(byte Figure_Number, byte Cursor_Width, byte Cursor_Height, bool Blue_red) :
                base(Figure_Number, Cursor_Width, Cursor_Height, Blue_red)
        {
            type = 2;
        }



        public override void Move(byte Board_width, byte Board_height, List<Figura> Players_allies, Board board, List<Figura> Enemy_players)
        {
            bool availabe = Availabe_Move(Board_width, Board_height, Players_allies, board);
            if (availabe == true)
            {
                ConsoleKeyInfo key;
                while (true)
                {

                    key = Console.ReadKey(true);
                    if (up_Left == true && key.Key == ConsoleKey.Q)
                    {

                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, up_Left, up_Right, down_Left, down_Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, (byte)(cursor_Width - 1), (byte)(cursor_Height - 1), blue_red, type);
                        cursor_Width--;
                        cursor_Height--;
                        break;
                    }
                    else if (up_Right == true && key.Key == ConsoleKey.W)
                    {
                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, up_Left, up_Right, down_Left, down_Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, (byte)(cursor_Width + 1), (byte)(cursor_Height - 1), blue_red, type);
                        cursor_Width++;
                        cursor_Height--;
                        break;
                    }
                    else if (down_Left == true && key.Key == ConsoleKey.A)
                    {
                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, up_Left, up_Right, down_Left, down_Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, (byte)(cursor_Width - 1), (byte)(cursor_Height + 1), blue_red, type);
                        cursor_Width--;
                        cursor_Height++;
                        break;
                    }
                    else if (down_Right == true && key.Key == ConsoleKey.S)
                    {
                        board.PaintOver_availabe_moves(cursor_Width, cursor_Height, up_Left, up_Right, down_Left, down_Right, type, true, Enemy_players);
                        board.Player_Move_Paint(cursor_Width, cursor_Height, (byte)(cursor_Width + 1), (byte)(cursor_Height + 1), blue_red, type);
                        cursor_Width++;
                        cursor_Height++;
                        break;
                    }
                }

                Check_Enemy_On_Player_Position(Enemy_players);
            }

        }
        public override bool Availabe_Move(byte Board_width, byte Board_height, List<Figura> Players_allies, Board board)
        {
            bool availabe = true;
            up_Left = true;
            up_Right = true;
            down_Left = true;
            down_Right = true;
            if (cursor_Width - 1 >= 0 && cursor_Height - 1 >= 0)
            {
                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width - 1 && player.cursor_Height == cursor_Height - 1)
                    {
                        up_Left = false;
                    }
                }
            }
            else
                up_Left = false;

            if (cursor_Width + 1 <= Board_width && cursor_Height - 1 >= 0)
            {
                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width + 1 && player.cursor_Height == cursor_Height - 1)
                    {
                        up_Right = false;
                    }
                }
            }
            else
                up_Right = false;

            if (cursor_Width - 1 >= 0 && cursor_Height + 1 < Board_height)
            {

                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width - 1 && player.cursor_Height == cursor_Height + 1)
                    {
                        down_Left = false;
                    }
                }
            }
            else
                down_Left = false;

            if (cursor_Width + 1 < Board_width && cursor_Height + 1 < Board_height)
            {
                foreach (Figura player in Players_allies)
                {
                    if (player.cursor_Width == cursor_Width + 1 && player.cursor_Height == cursor_Height + 1)
                    {
                        down_Right = false;
                    }
                }
            }
            else
                down_Right = false;


            if (up_Left == true || up_Right == true || down_Left == true || down_Right == true)
            {
                board.Paint_availabe_moves(cursor_Width, cursor_Height, up_Left, up_Right, down_Left, down_Right, type, false);
            }
            else
            {
                availabe = false;
            }

            return availabe;

        }




    }
}
