/*
 * 
 * 
 * Done by SUNG JOE KIM
 *  
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
        private Die die;
            
        public Player()
        { 
            money = 0;
            name = "";
            position = new Cell();
            die = new Die();
        }
        
        public Player(int _money, string _name)
        {
            money = _money;
            name = _name;
            position =  new Cell();
            die = new Die();
        }

        public int LatestPosition
        {
            get;
            set;
        }

        public int Money
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int DiceNumber
        {
            get;
            set;
        }

        //Todo return true or false based on subtraction of price
        public bool BuyProperty()
        {
            try
            {
                if (Money - position.GetPrice() >= 0)
                {
                    Money = Money - position.GetPrice();

                    position.SetOwner(this);
                    return true;
                }else
                {
                    return false;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public void PayRentTo()
        {
            try
            {
                //Todo If owner is me then nothing
                //Todo Check!!!! if(position.GetOwner() != this)
                {
                    //Todo Check Money is enough
                    Money = Money - position.GetPrice();
                }
                //Changho  Add Cell Owner's Money needed
                //position.SetPrice();                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }   
        }
        
        //What is different from between available and owner?
        public bool CheckProperty()
        {
            return position.IsAvailable();            
        }

        //Get the owner of current position, return the Player Class type
        public Cell GetPosition()
        {
            return position;
        }

        /*
        //Joe please remove the unwanted code from below 
        public void SetPosition(Cell newCell)
        {
<<<<<<<HEAD
            position = newCell;
=======
            position.SetAvailable(true);
>>>>>>> 289afe9093e6bc80a0cec445ccd2a46b1b9d10c5
        }
         */

        //Throw the dice and return the number and assign local dicenumber
        //Remove public void ThrowDie()
        //{
        //    int dieFace = 0;

        //    dieFace = die.GetRoll();
               
        //    DiceNumber = dieFace;
        //}
    }
}
