/* IncomeTaxCell.cs
 * Final Project
 * Revision History 
 * Changho Choi, 2015.08.05: Created 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Monopoly
{
    class IncomeTaxCell : Cell
    {
        public IncomeTaxCell()
        {
        }

        public IncomeTaxCell(int index)
            :base (index, "Income Tax Cell")
        {
            //position will be index 4
            Debug.WriteLine("IncomeTax Cell Created with index" + index);
        }

        public override void LandedOn(Player curPlayer)
        {
            int tax;
            Debug.WriteLine("Player Landed on IncomeTax Cell");
            Console.WriteLine(curPlayer.Name + " arrived at " + this.CellName);

            //Minimum of 2000 and 10% of player's property value will be deducted.
            //Player should know his property value
           tax = (int)Math.Floor(Math.Min((double)2000, (double)(curPlayer.getNetWorth() * 0.1)));
           
            if (tax > 0)
            {
                Console.WriteLine("Sorry!!! $"+tax+" will be charged for tax");
                if (curPlayer.Money >= tax)
                {
                    curPlayer.Money -= tax;
                }
                else 
                {
                    Console.WriteLine("You dont have suffecient funds \nPlease sell a property ");
                    if ((curPlayer.SellProperty() == true) &&   (curPlayer.Money < 0))
                    {
                        curPlayer.Money -= tax;
                    }
                    else
                    {
                        curPlayer.IsKickedOut = true;
                        Console.WriteLine("You dont have any propertie to sell \nYou have been kicked out of the game");
                    }
                }
            }
        }
    }
}
