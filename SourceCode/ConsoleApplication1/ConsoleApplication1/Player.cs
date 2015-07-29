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
        private int diceNumber;
        private int latestPosition;
        private Cell position;
        private Die die;
            
        public Player()
        { 
            money = 0;
            name = "";
            latestPosition = 0;
            diceNumber = 0;
            position = new Cell();
            die = new Die();
        }
        
        public Player(int _money, string _name)
        {
            money = _money;
            name = _name;
            latestPosition = 0;
            diceNumber = 0;
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

        public void BuyProperty()
        {
            try
            {
                Money = Money - position.GetPrice();

                position.SetOwner(this);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }            
        }

        public void PayForOwnerOfProperty()
        {
            try
            {
                Money = Money - position.GetPrice();
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
        public Player GetPosition()
        {
            return position.GetOwner();
        }

        public void SetPosition()
        {
            position.SetAvailable(true);
        }

        //Throw the dice and return the number and assign local dicenumber
        public void ThrowDie()
        {
            int dieFace = 0;

            dieFace = die.GetRoll();
               
            DiceNumber = dieFace;
        }
    }
}
