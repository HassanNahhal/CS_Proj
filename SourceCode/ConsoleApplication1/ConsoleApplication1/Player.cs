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
        private bool isKickedOut;
        private int turnNumber;

        public Player ()
        {
            money = 0;
            name = "";
            position = new Cell ();
            isKickedOut = false;
            turnNumber = 0;
        }

        public Player ( int _money , string _name )
        {
            money = _money;
            name = _name;
            position = new Cell ();
            isKickedOut = false;
            turnNumber = 0;
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

        public bool IsKickedOut
        {
            get;
            set;
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

        public bool PayRentTo ()
        {
            bool flag = false;
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
                        flag = true;
                    }

                    else
                    {
                        flag = false;
                    }
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
