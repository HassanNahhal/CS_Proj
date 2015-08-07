/* Cell.cs
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
    public abstract class Cell
    {
        int index; 
        String cellName;

        protected Cell()
        {
        }

        protected Cell(int index, String cellName)
        {
            this.index = index;
            this.cellName = cellName;
        }

        public abstract void LandedOn(Player curPlayer);

        public int Index 
        {
            get 
            {
                return this.index;
            }
        }
        public String CellName
        {
            get
            {
                return this.cellName;
            }
        }

        public virtual int GetPrice()
        {
            throw new System.InvalidOperationException("Invalid!!! Get Price()");
        }

        public virtual int GetRentPrice()
        {
            throw new System.InvalidOperationException("Invalid!!! Get GetRentPrice()");
        }

        public virtual Boolean IsAvailable()
        {
            throw new System.InvalidOperationException("Invalid!!! Get IsAvailable()");
        }

        public virtual void SetAvailable(Boolean available)
        {
            throw new System.InvalidOperationException("Invalid!!! Get SetAvailable()");
        }

        public virtual Player GetOwner()
        {
            throw new System.InvalidOperationException("Invalid!!! Get GetOwner()");
        }

        public virtual void SetOwner(Player owner)
        {
            throw new System.InvalidOperationException("Invalid!!! SetOwner()");
        }

    }
}
