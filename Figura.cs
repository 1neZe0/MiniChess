using System;
using System.Collections.Generic;
using System.Text;

namespace Les_5._View_2
{
    abstract class Figura
    {
        enum PlayerTypes
        {
            King = 1,
            Queen = 2
        }

        #region Fields

        public byte figure_number;
        public byte type;
        public byte cursor_Width;
        public byte cursor_Height;

        public bool blue_red;
        public bool life;

        #region For king


        protected bool Up;
        protected bool Down;
        protected bool Left;
        protected bool Right;


        #endregion

        #region For Queen

        protected bool up_Left;
        protected bool up_Right;
        protected bool down_Left;
        protected bool down_Right;


        #endregion


        #endregion



        #region Construction


        public Figura(byte Figure_Number,byte Cursor_Width, byte Cursor_Height, bool Blue_red)
        {
            figure_number = Figure_Number;
            cursor_Width = Cursor_Width;
            cursor_Height = Cursor_Height;
            blue_red = Blue_red;
            life = true;
        }


        #endregion



        #region Methods


        public abstract void Move(byte Board_width, byte Board_height, List<Figura> Players_allies, Board board, List<Figura> Enemy_players);

        public abstract bool Availabe_Move(byte Board_width, byte Board_height, List<Figura> Players_allies, Board board, byte mode);

        protected void Check_Enemy_On_Player_Position(List<Figura> Enemy_players)
        {
            foreach(Figura player in Enemy_players)
            {
                if(player.cursor_Height == cursor_Height && player.cursor_Width == cursor_Width)
                {
                    player.life = false;
                }
            }
        }

        #endregion
    }
}
