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
    public class GameMaster
    {
        private int numberOfPlayers;
        private Die [] dice;
        private GameBoard gameBoard;
        private Player [] arrayOfPlayers;
        static private int turn;
        private int utilDiceRoll;

    
        //=====================Constructors===========================
        public GameMaster ()
        {
        }

        public GameMaster (Die [] dice , GameBoard gameBoard , Player [] arrayOfPlayers  )
        {
            this.dice = dice;
            this.gameBoard = gameBoard;
            this.arrayOfPlayers = arrayOfPlayers;
        }
        //=====================Constructors End===========================


        //=====================Properties===========================

        public int Turn
        {
            get;
            set;
        }

        public int NumberOfPlayers
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

        public int UtilDiceRoll
        {
            get;
            set;
        }

        //=====================Properties End===========================

        //=====================Methods===========================

        //get the possision of  player
        public Cell GetPosition ( Player player )
        {
            Cell position = new Cell ();
            position=player.GetPosition ();

            return position;
        }

        //get a player based on the current turn
        public Player GetCurrentPlayer ()
        {
            Player player = new Player ();
            int turn= GetTurn();
            player = GetPlayer ( turn+1);
            return player;
        }

        //get the index of the player based on the turn
        public int GetCurrentPlayerIndex ()
        {
            Player player = GetCurrentPlayer ();
            Cell cell= player.GetPosition ();
            int index = cell.GetIndex ();
            return index;
        }

        //what is this ?? maybe be deleted 
        public GameBoard GetGameBoard ()
        {
            GameBoard X = new GameBoard ();
            return X;
        }

        //get a player based on his possion
        public Player GetPlayer ( int index )
        {
            Player X = new Player ();
            return X;
        }

        //get the location of a specific player
        public int GetPlayerIndex ( Player player )
        {
            int index = 0;
            return index;
        }

        //Remove
        public int GetTurn ()
        {
            if ( turn == numberOfPlayers )
            {
                turn = 0;
            }
            return turn;
        }
        
        //get the sum of both dies
        //not sure if its important ,I can access it from Die Class
        public Die GetUtilDiceRoll ()
        {
            Die X = new Die ();
            return X;
        }

        //reset the game
        public void ResetGame ()
        {
        }

        //start the game
        public void StartGame ()
        {
        }
        
        //give the turn to another player
        public void SwitchTurn ()
        {
        }

        //=====================Methods End===========================



    }
}
