using System;
using System.Collections.Generic;
using System.Text;

namespace Les_5._View_2
{
    class Gamemode
    {
        byte board_width;
        byte board_height;
        List<Figura> red_players;
        List<Figura> blue_players;
        Board board;


        public Gamemode(byte Board_Width, byte Board_Height)
        {
            red_players = new List<Figura>();
            blue_players = new List<Figura>();

            board_width = Board_Width < 20 || Board_Width > 60 ? (byte)20 : Board_Width;
            board_height = Board_Width < 10 || Board_Width > 40 ? (byte)10 : Board_Height;
            board = new Board(board_width, board_height);
        }
        public void init()
        {
            board.Board_Paint();
            Players_Add_Paint();
        }

        public void Game_Start()
        {
            bool Game_Players_Check = board.Game_Players_Check(red_players, blue_players);
            while (true)
            {
                red_players[Choose_Number_Of_Player(red_players)].Move(board_width, board_height, red_players, board, blue_players);
                Game_Players_Check = board.Game_Players_Check(red_players, blue_players);
                if (Game_Players_Check == true)
                {
                    break;
                }

                blue_players[Choose_Number_Of_Player(blue_players)].Move(board_width, board_height, blue_players, board, red_players);
                Game_Players_Check = board.Game_Players_Check(red_players, blue_players);
                if (Game_Players_Check == true)
                {
                    break;
                }

            }



        }
        public void Players_Add_Paint()
        {
            for (byte i = 0; i < board_width; i++)
            {
                if (i == (board_width / 2) - 1 || i == ((board_width / 2) + 1))
                {
                    red_players.Add(new Queen(i, i, 0, true));
                }
                else
                    red_players.Add(new King(i, i, 0, true));

                board.Player_paint(i, 0, true, red_players[i].type);
            }

            for (byte i = 0; i < board_width; i++)
            {
                if (i == (board_width / 2) - 1 || i == ((board_width / 2) + 1))
                {
                    blue_players.Add(new Queen(i, i, board_height, false));
                }
                else
                    blue_players.Add(new King(i, i, board_height, false));

                board.Player_paint(i, board_height, false, blue_players[i].type);
            }

        }
        public byte Choose_Number_Of_Player(List<Figura> players)
        {
            byte i = 0;
            ConsoleKeyInfo key;
            foreach(Figura player in players)
            {
                if(player.life == true)
                {
                    break;
                }
                i++;
            }
            for ( ; ;)
            {
                if(players[i].life == true)
                {
                    board.Move_Painter(players[i].type, players[i].cursor_Width, players[i].cursor_Height, false);
                }
                while (true)
                {
                    Console.SetCursorPosition(27, board_height + 7);
                    key = Console.ReadKey(true);
                    if (i + 1 < board_width)
                    {
                        if (key.Key == ConsoleKey.D)
                        {
                            if (players[i + 1].life == true)
                            {
                                board.Player_paint(players[i].cursor_Width, players[i].cursor_Height, players[i].blue_red, players[i].type);
                                i++;
                                break;
                            }
                        }
                    }

                    if (i - 1 >= 0)
                    {
                        if (key.Key == ConsoleKey.A)
                        {
                            if (players[i].life == true)
                            {
                                board.Player_paint(players[i].cursor_Width, players[i].cursor_Height, players[i].blue_red, players[i].type);
                                i--;
                                break;
                            }
                        }
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (players[i].life == true)
                        {
                            board.Player_paint(players[i].cursor_Width, players[i].cursor_Height, players[i].blue_red, players[i].type);
                            return i;
                        }
                    }

                }
            }
        }
    }
}
