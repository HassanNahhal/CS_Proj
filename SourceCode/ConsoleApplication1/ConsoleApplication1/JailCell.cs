/* JailCell.cs
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
    class JailCell : Cell
    {
      
        public JailCell()
        {
        }

        public JailCell(int index)
            : base(index, "Jail Cell")
        {
            //position will be index 10
            Debug.WriteLine("Jail Cell Created with index" + index);
        }

        public override void LandedOn(Player curPlayer)
        {
            Console.WriteLine(curPlayer.Name + " arrived at " + this.CellName);
            Console.WriteLine("Sorry!! Next turn will be skipped");
            Debug.WriteLine("Player Landed on Jail Cell");
            //If user is from GotoJail, then fine will be given and next turn will be skipped
            //But If user is landed by turn, he will just skip next turn.
        }
    }
}
