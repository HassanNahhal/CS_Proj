/*
 * Done by SUNG JOE KIM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        private int money;
        private string name;
        private Cell position;
        private GameBoard gameBoard;

        public Player ()
        {
            money = 0;
            name = "";
            position = new Cell ();
            gameBoard = new GameBoard ();
        }

        public Player ( int _money , string _name )
        {
            money = _money;
            name = _name;
            position = new Cell ();
            gameBoard = new GameBoard ();
        }

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        //Todo return true or false based on subtraction of price
        public bool BuyProperty ()
        {
            try
            {
                if ( money - position.GetPrice () >= 0 )
                {
                    money = money - position.GetPrice ();

                    position.SetOwner ( this );
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch ( Exception e )
            {
                Console.WriteLine ( e );
            }
            return false;
        }

        public void PayRentTo ()
        {
            try
            {
                //Todo If owner is me then nothing
                if ( this != position.GetOwner () )
                {
                    //current player has more money that the player has to pay for rent
                    if ( money - position.GetRentPrice () >= 0 )
                    {
                        //deduct the money of player by rent fee for the owner
                        money = money - position.GetRentPrice ();

                        //transfer the money for Rent to the owner
                        PayRentToOwner ();
                    }
                }
            }
            catch ( Exception e )
            {
                Console.WriteLine ( e );
            }
        }

        public void PayRentToOwner ()
        {
            //transfer the money for Rent to the owner
            int rentPrice = position.GetRentPrice ();
            int moneyOfOwner = position.GetOwner ().Money;
            moneyOfOwner += rentPrice;
            position.GetOwner ().Money = moneyOfOwner;
        }

        //What is different from between available and owner?
        public bool CheckProperty ()
        {
            return position.IsAvailable ();
        }

        //Get the owner of current position, return the Player Class type
        public Cell GetPosition ()
        {
            return position;
        }

        //Set the current position of the Player into the Cell object via GameBoard Object
        public Cell SetPosition ( int distance )
        {
            //Player cannot get the number of RollDie, hence cannot pass the distance
            //Game Master has to pass the number of RollDie(int distance)
            //to the SetPosition method as parameter

            position = gameBoard.MoveToAnotherCell ( position , distance , false );
            return position;

        }

        //Sell the one of property which urrent player has
        //To pay for rent to the owner of current position
        public bool SellProperty()
        {
            bool returnValue = false;
            int[] indexOfOwnerOfCell = gameBoard.QueryCellIndex(this);
            string selectedIndex = "";
            string displayIndexOfCell = "";
            string temp = "";

<<<<<<< HEAD
            displayIndexOfCell += "Select the index number of property to sell: \n";
            //input value of the index of the Cell that Player decide to sell
            for ( int i = 1 ; i <= indexOfOwnerOfCell.Length ; i++ )
=======
            //input value of the index of the Cell that Player decide to sell
>>>>>>> origin/master
            if (indexOfOwnerOfCell.Length > 0)
            {
                displayIndexOfCell += "Select the index number of property to sell: \n";
                displayIndexOfCell += "index[ ";

                //input value of the index of the Cell that Player decide to sell
                for (int j = 1; j <= indexOfOwnerOfCell.Length; j++)
                {
                    temp += indexOfOwnerOfCell[j].ToString();

                    if (j < indexOfOwnerOfCell.Length)
                    {
                        temp += ", ";
                    }
                }
                displayIndexOfCell += temp + " ]";

                Console.WriteLine(displayIndexOfCell);

                selectedIndex = Console.ReadLine();

                //Set the current cell available = true After selling the property
                //need to pass the parameter the index of cell which will

                //Get the Cell which the player decided to sell the index of Cell
                Cell changeCellOfOwner = gameBoard.GetCell(int.Parse(selectedIndex));
                changeCellOfOwner.SetOwner(null);       //change the Owner of the index of the Cell to "null"
                changeCellOfOwner.SetAvailable(true);   //change the "Available" of the index of the Cell to "True"

                returnValue = true;
            }
            else
            {
                displayIndexOfCell = "There is no property of the current player.\n";

                Console.WriteLine(displayIndexOfCell);
                Console.ReadKey();

                returnValue = false;
            }

            return returnValue;
        }
    }
}
