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
        byte player_choose_red;
        byte player_choose_blue;


        public Gamemode(byte Board_Width, byte Board_Height)
        {
            red_players = new List<Figura>();
            blue_players = new List<Figura>();
            player_choose_red = 0;
            player_choose_blue = 0;

            board_width = Board_Width <= 20 || Board_Width > 100 ? (byte)20 : Board_Width;
            board_height = Board_Height <= 10 || Board_Height > 35 ? (byte)10 : Board_Height;
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
                red_players[Choose_Number_Of_Player(red_players, true)].Move(board_width, board_height, red_players, board, blue_players);

                Game_Players_Check = board.Game_Players_Check(red_players, blue_players);
                if (Game_Players_Check == true)
                {
                    break;
                }



                blue_players[Choose_Number_Of_Player(blue_players, false)].Move(board_width, board_height, blue_players, board, red_players);

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
        public byte Choose_Number_Of_Player(List<Figura> players, bool blue_red)
        {
            byte player_choose = 0;
            if (blue_red == false)
                player_choose = player_choose_blue;
            else
                player_choose = player_choose_red;
            
            bool Left_Right = false;
            while (true)
            {
                if(players[player_choose].life == true)
                {
                    break;
                }
                else
                {
                    if(Left_Right == false)
                    {
                        if(player_choose - 1 < 0)
                        {
                            Left_Right = true;
                        }
                        else
                            player_choose--;
                    }
                    else
                    {
                        if (player_choose + 1 == board_width)
                        {
                            Left_Right = false;
                        }
                        else
                            player_choose++;
                    }
                }
            }
            byte wrong = 0;
            ConsoleKeyInfo key;
            while (true)
            {
                board.Move_Painter(players[player_choose].type, players[player_choose].cursor_Width, players[player_choose].cursor_Height, false);

                Console.SetCursorPosition(27, board_height + 7);
                key = Console.ReadKey(true);

                if (player_choose < board_width - 1 && key.Key == ConsoleKey.D)
                {
                    wrong = player_choose;
                    board.Player_paint(players[player_choose].cursor_Width, players[player_choose].cursor_Height, players[player_choose].blue_red, players[player_choose].type);
                    while (true)
                    {
                        player_choose++;
                        if (player_choose == board_width - 1 && players[player_choose].life == false)
                        {
                            player_choose = wrong;
                            break;
                        }

                        if (players[player_choose].life == true)
                        {
                            break;
                        }
                    }
                }


                if (player_choose > 0 && key.Key == ConsoleKey.A)
                {
                    if (players[player_choose].life == true)
                    {
                        wrong = player_choose;
                        board.Player_paint(players[player_choose].cursor_Width, players[player_choose].cursor_Height, players[player_choose].blue_red, players[player_choose].type);
                        while (true)
                        {
                            player_choose--;

                            if (player_choose == 0 && players[0].life == false)
                            {
                                player_choose = wrong;
                                break;
                            }

                            if (players[player_choose].life == true)
                            {
                                break;
                            }
                        }
                    }
                }


                if (key.Key == ConsoleKey.Enter)
                {
                    if (players[player_choose].life == true)
                    {
                        if (players[player_choose].blue_red == false && players[player_choose].Availabe_Move(board_width, board_height, blue_players, board, 2) == true
                           || players[player_choose].blue_red == true && players[player_choose].Availabe_Move(board_width, board_height, red_players, board, 2))
                        {
                            if (blue_red == false)
                                player_choose_blue = player_choose;
                            else
                                player_choose_red = player_choose;
                            board.Player_paint(players[player_choose].cursor_Width, players[player_choose].cursor_Height, players[player_choose].blue_red, players[player_choose].type);
                            return player_choose;
                        }
                    }
                }
            }

        }
    }
}
