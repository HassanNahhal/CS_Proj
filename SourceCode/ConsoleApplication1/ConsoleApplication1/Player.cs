/* Player.cs
 * Final Project
 * Revision History 
 * Sungjoe Kim, 2015.07.28: Created 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class Player
    {
        private int money;
        private string name;
        private Cell position;
        private bool isKickedOut;
        private int turnNumber;
        private List<Cell> myPropertyList = new List<Cell>();

        public Player ()
        {
            money = 0;
            name = "";
            turnNumber = 1;
        }

        public Player ( int _money , string _name )
        {
            money = _money;
            name = _name;
            turnNumber = 1;
        }

        public bool IsKickedOut
        {
            get
            {
                return isKickedOut;
            }
            set
            {
                isKickedOut = value;
            }
        }

        public int TurnNumber
        {
            get
            {
                return turnNumber;
            }

            set
            {
                turnNumber = value;
            }
        }



        public Cell Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
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

        public int getPropertyNumber()
        {
            return myPropertyList.Count;
        }

        public int getNetWorth()
        {
            int totalProperty=0;
            for (int i = 0; i < myPropertyList.Count; i++)
            {
                totalProperty = totalProperty + (myPropertyList.ElementAt(i)).GetPrice();
            }
            totalProperty += this.money;
            return totalProperty;
        }

        //Todo return true or false based on subtraction of price
        public bool BuyProperty ()
        {
            bool flag = false;
            try
            {
                if ( money - position.GetPrice () >= 0 )
                {
                    money = money - position.GetPrice ();

                    position.SetOwner ( this );
                    position.SetAvailable(false);
                    flag = true;
                    myPropertyList.Add(position);
                }
                else
                {
                    flag = false;
                }

            }
            catch ( Exception e )
            {
                Console.WriteLine ( e );
            }
            return flag;
        }
        
        public void SellAllProperty()
        {
            for (int i = 0; i < myPropertyList.Count; i++)
            {
                myPropertyList.ElementAt(i).SetOwner(null);
                myPropertyList.ElementAt(i).SetAvailable(true);
            }
        }

        //Done By Joe
        public bool SellProperty()
        {
            bool returnValue = false;
            int selectedIndex;

            //input value of the index of the Cell that Player decide to sell
            if (myPropertyList.Count > 0)
            {
                Console.WriteLine("Please choose the property that you want to sell");

                for (int i = 0; i < myPropertyList.Count; i++)
                {
                    Console.Write(myPropertyList.ElementAt(i).Index + " ");
                }

                //input value of the index of the Cell that Player decide to sell
                while (!((int.TryParse(Console.ReadLine(), out selectedIndex)) && (myPropertyList.Find(x => (x.Index == selectedIndex)) != null)))
                {
                    Console.WriteLine("Please input valid sell index !");
                }

                //Set the current cell available = true After selling the property
                //need to pass the parameter the index of cell which will

                //Get the Cell which the player decided to sell the index of Cell
                Cell changeCellOfOwner = myPropertyList.Find(x => (x.Index == selectedIndex));

                //change the Owner of the index of the Cell to "null"
                changeCellOfOwner.SetOwner(null);
                //change the "Available" of the index of the Cell to "True"
                changeCellOfOwner.SetAvailable(true);

                Debug.WriteLine("Before Sell Property Count" + myPropertyList.Count);
                myPropertyList.Remove(changeCellOfOwner);
                Debug.WriteLine("After Sell Property Count" + myPropertyList.Count);


                Console.WriteLine("You have sold a property at 75% of value!!");
                this.money += (int)Math.Floor(changeCellOfOwner.GetPrice() * 0.75);

                returnValue = true;
            }
            else
            {
                Console.WriteLine("There is no property of the current player");
                returnValue = false;
            }

            return returnValue;
        }

        public bool PayRentTo ()
        {
            bool flag = false;
            try
            {
                //Todo If owner is me then nothing

                //current player has more money that the player has to pay for rent
                if ( money - position.GetRentPrice () >= 0 )
                {
                    //deduct the money of player by rent fee for the owner
                    money = money - position.GetRentPrice ();

                    //transfer the money for Rent to the owner
                    PayRentToOwner ();
                    flag = true;
                }

                else
                {
                    flag = false;
                }

            }
            catch ( Exception e )
            {
                Console.WriteLine ( e );

            }

            return flag;

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



        //Sell the one of property which urrent player has
        //To pay for rent to the owner of current position

    }
}
