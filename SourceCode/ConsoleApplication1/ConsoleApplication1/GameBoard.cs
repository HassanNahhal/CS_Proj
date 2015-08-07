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
using System.Diagnostics;

namespace Monopoly
{
    public class GameBoard
    {
        const int NUM_OF_CELL = 40;
        const int FIX_CELL_PRICE = 2000;
        const int FIX_RENT_PRICE = 500;
        const int GOCELL_INDEX = 0;
        const int INCOMETAXCELL_INDEX = 4;
        const int JAILCELL_INDEX = 10;
        const int LOTCELL_INDEX = 20;
        const int GOTOJAIL_INDEX = 30;

        List<Cell> cells = new List<Cell> ();

        public GameBoard ()
        {
            for ( int index = 0 ; index < NUM_OF_CELL ; index++ )
            {
                switch (index)
                {
                    case GOCELL_INDEX:
                         cells.Add (new GoCell(index));
                        break;
                    case INCOMETAXCELL_INDEX:
                        cells.Add (new IncomeTaxCell(index));
                        break;
                    case JAILCELL_INDEX:
                        cells.Add (new JailCell(index));
                        break;
                    case LOTCELL_INDEX:
                        cells.Add (new LotCell(index));
                        break;
                    case GOTOJAIL_INDEX :
                        cells.Add(new GoToJailCell(index, GetCell(JAILCELL_INDEX)));
                        break;
                    default:
                        cells.Add(new PropertyCell(index, FIX_CELL_PRICE, FIX_RENT_PRICE));
                        break;
                }
            }
        }

        public Cell MoveToAnotherCell (Cell curPosition , int distance , out bool isTurn )
        {
            int newIndex;

            newIndex = ( curPosition.Index) + distance;
            if ( newIndex >= NUM_OF_CELL )
            {
                isTurn = true;
                newIndex = newIndex - NUM_OF_CELL;
            }
            else
            {
                isTurn = false;
            }
            return cells.ElementAt ( newIndex );
        }

        public Cell GetCell ( int index )
        {
            return cells.ElementAt ( index);
        }

        public int GetCellNumber ( Cell curPosition )
        {
            return curPosition.Index;
        }

        public void GetPropertiesInMonopoly ()
        {
            //Not Need, Will be erased
        }

        public Cell QueryCell (String cellName)
        {
            return cells.Find(item => item.CellName.Equals(cellName));
        }

        public int [] QueryCellIndex ( Player queryPlayer )
        {
            int [] indexArrary = new int [ NUM_OF_CELL ];
            int j = 0;

            for ( int i = 0 ; i < NUM_OF_CELL ; i++ )
            {
                if ( cells.ElementAt ( i ).GetOwner () == queryPlayer )
                {
                    indexArrary [ j++ ] = i;
                }
            }
            return indexArrary;
        }
    }
}
