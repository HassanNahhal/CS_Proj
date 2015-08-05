/*
 * 
 * 
 * Done by : Hassan Nahhal
 *           7192602
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
        private Die [] die;
        private GameBoard gameBoard;
        private Player [] arrayOfPlayers;
        static private int turn;
        private int utilDiceRoll;

        //=====================Constructors===========================
        public GameMaster ()
        {
        }

        public GameMaster ( Die [] dice , GameBoard gameBoard , Player [] arrayOfPlayers )
        {
            this.die = dice;
            this.gameBoard = gameBoard;
            this.arrayOfPlayers = arrayOfPlayers;
        }
        //=====================Constructors End===========================


        //=====================Properties===========================

        public int Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = Turn;
            }
        }


        public Die [] Die
        {
            get
            {
                return die;
            }
            set
            {
                die = Die;
            }
        }

        public GameBoard GameBoard
        {
            get;
            set;
        }

        public Player [] ArrayOfPlayers
        {
            get
            {
                return arrayOfPlayers;
            }
            set
            {
                arrayOfPlayers = ArrayOfPlayers;
            }
        }

        public int UtilDiceRoll
        {
            get
            {
                return utilDiceRoll;
            }

            set
            {
                utilDiceRoll = UtilDiceRoll;
            }
        }



        //=====================Properties End===========================

        //=====================Methods===========================

        //get the possision of  player
        public Cell GetPosition ( Player player )
        {
            Cell position = new Cell ();
            position = player.GetPosition ();

            return position;
        }

        //get a player based on the current turn
        public Player GetCurrentPlayer ()
        {
            Player player = new Player ();
            int turn = GetTurn ();
            player = GetPlayer ( turn + 1 );
            return player;
        }

        //get the index of the player based on the turn
        public int GetCurrentPlayerIndex ()
        {
            Player player = GetCurrentPlayer ();
            Cell cell = player.GetPosition ();
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
            if ( turn == arrayOfPlayers.Length )
            {
                turn = 0;
            }

            return turn;
        }

        //get the sum of both dies
        //not sure if its important ,I can access it from Die Class
        public int GetUtilDiceRoll ()
        {
            int diceRollSum = 0;
            Die die = new Die ();
            diceRollSum = die.DieRoll ();

            return diceRollSum;
        }

        public void PlayGame ()
        {
            turn = GetTurn ();

            Console.WriteLine ( "Player " + ( turn + 1 ) + " will play now " );
            Console.WriteLine ( "Player " + ( turn + 1 ) + " is at cell # " + arrayOfPlayers [ turn ].GetPosition ().GetIndex () );
            Console.WriteLine ();
            Console.WriteLine ( "Player " + ( turn + 1 ) + " will roll the die " );
            Console.WriteLine ();

            utilDiceRoll = GetUtilDiceRoll ();
            Console.WriteLine ();

            Console.WriteLine ( "Player " + ( turn + 1 ) + " will move " + utilDiceRoll + " cells" );
            Console.WriteLine ();

            Console.WriteLine ( "Player " + ( turn + 1 ) + " is at cell # " + MovePlayer ( utilDiceRoll ) + " now" );
            Console.WriteLine ();


            if ( arrayOfPlayers [ turn ].CheckProperty () == true )
            {
                string answer;
                Console.WriteLine ( "This cell is available" );
                Console.WriteLine ( "Do you want to buy this cell? \n y/n" );
                answer = Console.ReadLine ();

                if ( answer == "y" || answer == "Y" )
                {
                    if ( arrayOfPlayers [ turn ].BuyProperty () == true )
                        Console.WriteLine ( "Congratulation , you own this cell now" );
                }
            }

            else
            {
                Console.WriteLine ( "Unfortunaetly you are in someone's properties \n You have you pay rent for him" );
                arrayOfPlayers [ turn ].PayRentTo ();
            }
        }


        //give the turn to another player
        public void SwitchTurn ()
        {
            turn = ( turn + 1 ) % arrayOfPlayers.Length;
            PlayGame ();
        }

        public int MovePlayer ( int utilDiceRoll )
        {
            return arrayOfPlayers [ turn ].SetPosition ( utilDiceRoll ).GetIndex ();
        }

        public void EndGame ()
        {
            Console.WriteLine ( "enter anykey to continue..." );
            Console.ReadKey ();
        }



        // 
        //=====================Methods End===========================



    }
}
