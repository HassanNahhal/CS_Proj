/* GameMaster.cs
 * Final Project
 * Revision History 
 * Hassan Nahhal, 2015.07.28: Created 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class GameMaster
    {
        private Die [] die;
        private GameBoard gameBoard;
        private Player [] arrayOfPlayers;
        static private int turn;
        private int utilDiceRoll;
        private int iterationNum = 0;

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
            Cell position;
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
            int index = cell.Index;
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
            return turn = ( turn + 1 ) % arrayOfPlayers.Length;
        }

        //get the sum of both dies
        //not sure if its important ,I can access it from Die Class
        public int GetUtilDiceRoll ()
        {
            int diceRollSum = 0;
            Die die = new Die ();
            diceRollSum = die.DieRoll ();

            //Test ONLY~~~~~~~~~
            Console.Write("=====TEST Die Number: ");
            diceRollSum = int.Parse(Console.ReadLine());
            //~~~~~~~~~~~~~~~~~~
            return diceRollSum;
        }

        public void PlayGame ()
        {
            int numRemainedPlayer = arrayOfPlayers.Length;

            do
            {
                Print (true);
                if ((arrayOfPlayers[turn].IsKickedOut == false) && (!arrayOfPlayers[turn].Position.CellName.ToLower().Contains("jail")))
                {
                    Console.WriteLine();
                    Console.WriteLine("Player " + (turn + 1) + " will play now ");
                    Console.WriteLine("Player " + (turn + 1) + " will roll the die ");
                    utilDiceRoll = GetUtilDiceRoll();

                    //Use Polymorephism : It will launch landed on with respect to cell kind.
                    MovePlayer(arrayOfPlayers[turn], utilDiceRoll).LandedOn(arrayOfPlayers[turn]);
                    if (arrayOfPlayers[turn].IsKickedOut == true)
                    {
                        arrayOfPlayers[turn].TurnNumber = iterationNum;
                    }
                    Console.WriteLine();

                }
                else if (arrayOfPlayers[turn].Position.CellName.ToLower().Contains("jail"))
                {
                    Console.WriteLine("Player " + (turn + 1) + " Skipped this turn, and start at next cell!!");
                    MovePlayer(arrayOfPlayers[turn], 1);   //To Make Simple for Jail, Just move player 1 position
                }
                GetTurn();
                iterationNum++;
                Console.WriteLine("\n\n\nEnter anykey to continue...");
                Console.ReadKey();
            } while (numRemainedPlayer > 1);

            EndGame();
        }

        public void EndGame ()
        {
            Console.Clear();
            Console.WriteLine("Final Result is");
            Print(false);
            Console.WriteLine("Thank you...");
            Console.WriteLine("Enter anykey to continue..." );
            Console.ReadKey ();
        }

        //Done By Joe
        //Set the current position of the Player into the Cell object via GameBoard Object
        public Cell MovePlayer ( Player curPlayer , int distance )
        {
            const int TURN_BONUS = 1000;
            bool isTurn;
            //Player cannot get the number of RollDie, hence cannot pass the distance
            //Game Master has to pass the number of RollDie(int distance)
            //to the MovePlayer method as parameter

            curPlayer.Position = gameBoard.MoveToAnotherCell ( curPlayer.GetPosition () , distance , out isTurn );
            if ( isTurn == true )
            {
                Console.WriteLine("Congratulation on finishing turn! Bonus $" + TURN_BONUS + " will be given");
                curPlayer.Money += TURN_BONUS;
            }
            return curPlayer.Position;
        }

        public void Print (bool clearScreen)
        {
            if (clearScreen == true)
            {
                Console.Clear();
            }
            //player name, money,properties,current location, isKickedOut,
            //String.Format ( "|{0,10}|{1,10}|{2,10}|{3,10}|" , "F" , "G" , "H" , "Y" );           
            /*
            for ( int counter = 0 ; counter < typeOfShirtArray.Length ; counter++ )
            {
                Console.WriteLine ( "{0,-20}{1,10:N1}" , typeOfShirtArray [ counter ] , priceOfShirtArray [ counter ] );
            }
            */
            Console.WriteLine("Interation# : {0}", this.iterationNum);
            Console.WriteLine ( "__________________________________________________________________________________________________" );

            Console.WriteLine ( String.Format ( "{0,0}{1,14}{2,20}{3,20}{4,20}{5,20}" , "Name" , "Money" , "CurrentPosition" , "Number of cells" , "Iskickedout" , "Turn Number" ) );
            Console.WriteLine ( "__________________________________________________________________________________________________" );

            for (int i = 0; i < arrayOfPlayers.Length; i++)
            {
                Debug.WriteLine("Name:"+arrayOfPlayers[i].Name);
                Debug.WriteLine("Money:" + arrayOfPlayers[i].Money);
                Debug.WriteLine("Position.Index:" + arrayOfPlayers[i].Position.Index);
                Debug.WriteLine("getPropertyNumber:" + arrayOfPlayers[i].getPropertyNumber());
                Debug.WriteLine("IsKickedOut:" + arrayOfPlayers[i].IsKickedOut);

                Console.WriteLine(String.Format("{0,0}{1,10}{2,10}{3,25}{4,20}{5,20}", arrayOfPlayers[i].Name, arrayOfPlayers[i].Money, arrayOfPlayers[i].Position.Index, arrayOfPlayers[i].getPropertyNumber(), arrayOfPlayers[i].IsKickedOut, arrayOfPlayers[i].TurnNumber));
            }
            Console.WriteLine ( "__________________________________________________________________________________________________" );
            Console.WriteLine ();
        }
        //in the order of filo
        //PRINT FUNCTION 
        // 
        //=====================Methods End===========================


    }
}
