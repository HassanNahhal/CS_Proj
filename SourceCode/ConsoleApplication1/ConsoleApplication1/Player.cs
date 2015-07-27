/*
 * 
 * 
 * Done by SUNG JOE KIM
 * 
 * Question : Who writing the programming 
 * to create object of player and die, 
 * and perform the operations of them?
 *  
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Player
    {
        private int money = 0;
        private string name = "";
        private int diceNumber = 0;
        private int latestPosition = 0;
        private Cell position = new Cell();
        private Die d = new Die();

        public Player()
        { 
            
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
                Money = Money - position.GetPrice(LatestPosition);

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
                Money = Money - position.GetPrice(LatestPosition);

                position.SetPrice(LatestPosition);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }   
        }
        
        //What is different from between available and owner?
        public bool CheckProperty()
        {
            return position.IsAvailable(LatestPosition);            
        }

        //Which class have the value of position? cell or player?
        public Player GetPosition()
        {
            return position.GetOwner(LatestPosition);
        }

        public void SetPosition()
        {
            position.SetAvailable(this);
        }

        public void ThrowDie()
        {
            int dieFace = 0;

            dieFace = d.getRoll();
            dieFace += d.getRoll();
               
            DiceNumber = dieFace;
        }
    }
}
