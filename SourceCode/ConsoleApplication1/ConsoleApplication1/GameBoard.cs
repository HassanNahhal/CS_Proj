/* GameBoard.cs
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
    public class GameBoard
    {
        const int NUM_OF_CELL = 40;
        const int FIX_CELL_PRICE = 2000;
        const int FIX_RENT_PRICE = 500;

        List<Cell> cells = new List<Cell>();

        public GameBoard()
        {
            for (int index = 1; index <= NUM_OF_CELL; index++)
            {
                cells.Add(new Cell(index, "Cell" + index, FIX_CELL_PRICE, FIX_RENT_PRICE));
            }
        }

        public Cell MoveToAnotherCell(Cell curPosition, int distance)
        {
            return cells.ElementAt(((curPosition.GetIndex() + distance) % NUM_OF_CELL)-1);
        }

        public Cell GetCell(int index)
        {
            return cells.ElementAt(index-1);
        }

        public int GetCellNumber(Cell curPosition)
        {
            return curPosition.GetIndex();
        }

        public void GetPropertiesInMonopoly()
        {
            //Not Need, Will be erased
        }

        public void QueryCell()
        {
            //Not Need, Will be erased
        }

        public void QueryCellIndex()
        {
            //Not Need, Will be erased
        }
    }
}
