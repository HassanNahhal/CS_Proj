/* Program.cs
 * Final Project
 * Revision History 
 * Hassan Nahhal, 2015.07.28: Created 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main (string [] args)
        {
            int numberOfPlayers = 0;

 
            Console.WriteLine("                 Welcome to MONOPOLY");
            Console.WriteLine("______________________________________________________");

            Console.WriteLine("               **** Game Started ****");
            Console.WriteLine();

            Console.Write("Please enter the number of players to start the game : ");
            while (!((int.TryParse(Console.ReadLine(), out numberOfPlayers)) &&
                    ((numberOfPlayers >= 2) && (numberOfPlayers <= 8))))
            {
                Console.WriteLine("Player should between 2 and 8 !");
            }

            //creating the array of players,die array and the gameBoard that contains 40 cell
            Player[] arrayOfPlayers = new Player[numberOfPlayers];
            Die[] die = new Die[2];
            GameBoard gameBoard = new GameBoard();


            for (int i = 0; i < numberOfPlayers; i++)
            {
                arrayOfPlayers[i] = new Player(5000, "Player" + (i + 1));
                arrayOfPlayers[i].Position = gameBoard.GetCell(0);
            }

            //creating gameMaster
            GameMaster gameMaster = new GameMaster(die, gameBoard, arrayOfPlayers);

            Console.WriteLine();
            if ((args.Length > 0) && args[0].Equals("test"))
            {
                gameMaster.PlayGame("test");
            }
            else
            {
                gameMaster.PlayGame();
            }
            
        }
    }
}
