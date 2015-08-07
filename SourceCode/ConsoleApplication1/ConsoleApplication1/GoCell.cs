/* GoCell.cs
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
    public class GoCell : Cell
    {
        public GoCell()
        {
        }

        public GoCell(int index)
            :base (index, "Go Cell")
        {
            //position will be index 40
            Debug.WriteLine("Go Cell Created with index"+index);
        }

        public override void LandedOn(Player curPlayer)
        {
            Console.WriteLine(curPlayer.Name + " arrived at " + this.CellName);
            Debug.WriteLine("Player Landed on GoCell Cell");
            //Money will be added at MoveCell
        }
    }
}
