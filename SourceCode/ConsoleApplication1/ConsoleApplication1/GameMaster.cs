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

            Console.WriteLine ( "Player " + ( turn + 1 ) + " is at cell # " + MovePlayer ( arrayOfPlayers [ turn ] , utilDiceRoll ).GetIndex () + " now" );
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
                if ( arrayOfPlayers [ turn ].PayRentTo () == true )
                {
                    Console.WriteLine ( "Rent have been paid " );
                }

                else
                {
                    Console.WriteLine ( "You dont have suffecient funds \n please sell a property " );
                    if ( SellProperty () == false )
                    {
                        arrayOfPlayers [ turn ].IsKickedOut = true;
                        Console.WriteLine ( "You dont have any propertie to sell \n you have been kicked out of the game" );
                    }

                }

            }
            SwitchTurn ();
        }


        //give the turn to another player
        public void SwitchTurn ()
        {
            bool flag = arrayOfPlayers [ turn ].IsKickedOut;

            turn = ( turn + 1 ) % arrayOfPlayers.Length;
            if (flag != false )
                PlayGame ();
            else
                SwitchTurn ();

        }
        /*
                public int MovePlayer ( int utilDiceRoll )
                {
                    return arrayOfPlayers [ turn ].MovePlayer ( utilDiceRoll ).GetIndex ();
                }
                */
        public void EndGame ()
        {
            Console.WriteLine ( "enter anykey to continue..." );
            Console.ReadKey ();
        }


        //Done By Joe
        //Set the current position of the Player into the Cell object via GameBoard Object
        public Cell MovePlayer ( Player curPlayer , int distance )
        {
            bool isTurn;
            //Player cannot get the number of RollDie, hence cannot pass the distance
            //Game Master has to pass the number of RollDie(int distance)
            //to the MovePlayer method as parameter

            curPlayer.Position = gameBoard.MoveToAnotherCell ( curPlayer.GetPosition () , distance , out isTurn );
            if ( isTurn == true )
                curPlayer.Money += 1000;

            return curPlayer.Position;
        }

        //Done By Joe
        public bool SellProperty ()
        {
            bool returnValue = false;
            int [] indexOfOwnerOfCell = gameBoard.QueryCellIndex ( arrayOfPlayers [ turn ] );
            string selectedIndex = "";
            string displayIndexOfCell = "";
            string temp = "";

            //input value of the index of the Cell that Player decide to sell
            if ( indexOfOwnerOfCell.Length > 0 )
            {
                displayIndexOfCell += "Select the index number of property to sell: \n";
                displayIndexOfCell += "index[ ";

                //input value of the index of the Cell that Player decide to sell
                for ( int j = 1 ; j <= indexOfOwnerOfCell.Length ; j++ )
                {
                    temp += indexOfOwnerOfCell [ j ].ToString ();

                    if ( j < indexOfOwnerOfCell.Length )
                    {
                        temp += ", ";
                    }
                }
                displayIndexOfCell += temp + " ]";

                Console.WriteLine ( displayIndexOfCell );

                selectedIndex = Console.ReadLine ();

                //Set the current cell available = true After selling the property
                //need to pass the parameter the index of cell which will

                //Get the Cell which the player decided to sell the index of Cell
                Cell changeCellOfOwner = gameBoard.GetCell ( int.Parse ( selectedIndex ) );
                changeCellOfOwner.SetOwner ( null );       //change the Owner of the index of the Cell to "null"
                changeCellOfOwner.SetAvailable ( true );   //change the "Available" of the index of the Cell to "True"

                returnValue = true;
            }
            else
            {
                displayIndexOfCell = "There is no property of the current player.\n";

                Console.WriteLine ( displayIndexOfCell );
                Console.ReadKey ();

                returnValue = false;
            }

            return returnValue;
        }

        //PRINT FUNCTION 
        //kick out 
        // 
        //=====================Methods End===========================



    }
}
