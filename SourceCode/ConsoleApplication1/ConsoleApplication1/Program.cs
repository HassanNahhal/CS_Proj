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
           // this will be static , anyone who wants to test , test below it and add comments 
            int numberOfPlayers;

            Console.WriteLine ( "Welcome to MONOPOLY" );
            Console.WriteLine ( "please enter the number of players to start the game" );
            numberOfPlayers = int.Parse ( Console.ReadLine () );

            GameMaster gameMaster = new GameMaster ();
            gameMaster.MaxNumberOfPlayers = numberOfPlayers;

            Console.WriteLine ( "enter anykey to continue..." );
            Console.ReadKey ();


        }


    }
}
