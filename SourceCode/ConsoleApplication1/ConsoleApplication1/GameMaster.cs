/*
 * 
 * 
 * Done by Hassan Nahhal
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class GameMaster
    {
        private int maxNumberOfPlayers;
        private Die [] dice;
        private GameBoard gameBoard;
        private Player [] arrayOfPlayers;
        private int turn;
        //private int utilDiceRoll;

        /*
        public int UtilDiceRoll
        {
            get;
            set;
        }
         */

        public int Turn
        {
            get;
            set;
        }

        public int MaxNumberOfPlayers
        {
            get;
            set;
        }

        public Die Die
        {
            get;
            set;
        }

        public GameBoard GameBoard
        {
            get;
            set;
        }

        public Player [] ArrayOfPlayers
        {
            get;
            set;
        }

        public GameMaster ()
        {
        }

        /*
        public GameMaster ()
        {
        }
        */


        public int GetPosition ( Player player )
        {
            int position = 0;

            return position;
        }
        public Player GetCurrentPlayer ()
        {
            Player player = new Player ();


            return player;
        }

        public int GetCurrentPlayerIndex ()
        {
            int index = 0;
            return index;
        }

        public GameBoard GetGameBoard ()
        {
            GameBoard X = new GameBoard ();
            return X;
        }

        public Player GetPlayer ( int index )
        {
            Player X = new Player ();
            return X;
        }

        public int GetPlayerIndex ( Player X )
        {
            int index = 0;
            return index;
        }

        public int GetTurn ()
        {
            int turn = 0;
            return turn;
        }

        public Die GetUtilDiceRoll ()
        {
            Die X = new Die ();
            return X;
        }

        public void ResetGame ()
        {
        }

        public void StartGame ()
        {
        }

        /*
        public int RollDice ()
        {
            int Dice = 0;
            return Dice;
        }
        */

        /*
        public void SetMaxNumberOfPlayers ()
        {
        }
        */

        public void SwitchTurn ()
        {
        }


    }
}
