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
            MainHassan ();

        }
        static public void MainHassan ()
        {
            //HASSAN TEST HERE
            int numberOfPlayers = 0;

            Console.WriteLine ( "Welcome to MONOPOLY" );
            Console.WriteLine ( "_______________________________________________________" );

            Console.WriteLine ( "please enter the number of players to start the game" );
            numberOfPlayers = int.Parse ( Console.ReadLine () );
            Player [] arrayOfPlayers = new Player [ numberOfPlayers ];
            Die [] die = new Die [ 2 ];
            GameBoard gameBoard = new GameBoard ();

            for ( int i = 0 ; i < numberOfPlayers ; i++ )
            {
                arrayOfPlayers [ i ] = new Player ();
            }
            GameMaster gameMaster = new GameMaster ( die , gameBoard , arrayOfPlayers );

            Console.WriteLine ( "gameMaster.NumberOfPlayers :" + gameMaster.ArrayOfPlayers.Length );

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
