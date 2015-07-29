/* Cell.cs
 * Final Project
 * Revision History 
 * Changho Choi, 2015.07.28: Created 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Cell
    {
        Boolean available;
        String cellName;
        int index;
        int cellPrice;
        Player owner;

        public Cell(int index, String cellName, int cellPrice)
        {
            this.index = index;
            available = true;
            owner = null;
            this.cellName = cellName;
            this.cellPrice = cellPrice;
        }

        public Cell()
        {
        }

        public int GetPrice()
        {
            return this.cellPrice;
        }
        
        public Boolean IsAvailable()
        {
            return available;
        }

        public void SetAvailable(Boolean available)
        {
            this.available = available;
        }
        
        public String GetName()
        {
           return  this.cellName;
        }


        public void SetName(String cellName)
        {
             this.cellName = cellName;
        }

        public Player GetOwner()
        {
            return this.owner;
        }

        public void SetOwner(Player owner)
        {
            this.owner = owner;
        }

        public int GetIndex()
        {
            return this.index;
        }
    }
}
