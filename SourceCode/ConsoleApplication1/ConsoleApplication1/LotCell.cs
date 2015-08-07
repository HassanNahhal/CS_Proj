/* LotCell.cs
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
    class LotCell : Cell
    {
        public LotCell()
        {
        }

        public LotCell(int index)
            : base(index, "Lot Cell")
        {
            //position will be index 20
            Debug.WriteLine("Lot Cell Created with index" + index);
        }

        public override void LandedOn(Player curPlayer)
        {
            Console.WriteLine(curPlayer.Name + " arrived at " + this.CellName);
            Debug.WriteLine(curPlayer.Name + "Player Landed on Lot Cell");
            //Do Nothing
            curPlayer.Money++;
        }
    }
    
}
