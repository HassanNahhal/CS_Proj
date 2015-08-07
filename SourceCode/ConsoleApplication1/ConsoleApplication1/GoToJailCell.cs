/* GoToJail.cs
 * Final Project
 * Revision History 
 * Changho Choi, 2015.07.28: Created 
 * Changho Choi, 2005.08.05: Modifed add characteristics of square
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    class GoToJailCell : Cell
    {
        Cell refOfJailCell;

        public GoToJailCell()
        {
        }

        public GoToJailCell(int index, Cell ptrJailCell)
            :base(index, "Goto Jail Cell")
        {
            //position will be index 30
            Debug.WriteLine("GoToJail Cell Created with index" + index);
            this.refOfJailCell = ptrJailCell;
        }

        public override void LandedOn(Player curPlayer)
        {
            const int FINE_FOR_JAIL=2000;

            Debug.WriteLine("Player Landed on GoToJail Cell");
            Console.WriteLine(curPlayer.Name + " arrived at " + this.CellName);
            Console.WriteLine("Sorry, $"+FINE_FOR_JAIL+" will be take for Fine");

            if (curPlayer.Money >= FINE_FOR_JAIL)
            {
               curPlayer.Money -= FINE_FOR_JAIL;
            }
            else
            {
                Console.WriteLine("You dont have suffecient funds \nPlease sell a property ");
                if ((curPlayer.SellProperty() == true) && (curPlayer.Money >= FINE_FOR_JAIL))
                {
                    curPlayer.Money -= FINE_FOR_JAIL;
                }
                else
                {
                    curPlayer.IsKickedOut = true;
                    Console.WriteLine("You dont have any propertie to sell \nYou have been kicked out of the game");
                }
            }
            moveToJailCell(curPlayer);
        }

        private void moveToJailCell(Player curPlayer)
        {
            curPlayer.Position = refOfJailCell;
        }
    }
}
