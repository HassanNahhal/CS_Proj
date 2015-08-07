using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main ( string [] args )
        {
            /*
            GameMaster gameMaster = new GameMaster();
            gameMaster.Print ();
            Console.WriteLine ( "enter anykey to continue..." );
            Console.ReadKey ();
             */

            MainHassan ();

        }
        static public void MainHassan ()
        {
            //HASSAN TEST HERE
            int numberOfPlayers = 0;

            Console.WriteLine ( "                 Welcome to MONOPOLY" );
            Console.WriteLine ( "______________________________________________________" );

            Console.WriteLine ( "               **** Game Started ****" );
            Console.WriteLine ();

            Console.Write ( "please enter the number of players to start the game : " );
            numberOfPlayers = int.Parse ( Console.ReadLine () );

            //creating the array of players,die array and the gameBoard that contains 40 cell
            Player [] arrayOfPlayers = new Player [ numberOfPlayers ];
            Die [] die = new Die [ 2 ];
            GameBoard gameBoard = new GameBoard ();

            for ( int i = 0 ; i < numberOfPlayers ; i++ )
            {
                arrayOfPlayers [ i ] = new Player ( 5000 , "Player" + ( i + 1 ) );
            }

            //creating gameMaster
            GameMaster gameMaster = new GameMaster ( die , gameBoard , arrayOfPlayers );

            Console.WriteLine ();



            gameMaster.PlayGame ();
            //ask the user if he want to buy a cell

            Console.WriteLine ( "enter anykey to continue..." );
            Console.ReadKey ();
        }
        static public void MainJoe ()
        {
            //JOE TEST HERE

        }

        static public void MainChang ()
        {
            //CHANG TEST HERE


        }
    }
}
