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
        const int NUM_OF_CELL = 20;
        const int FIX_CELL_PRICE = 2000;
        const int FIX_RENT_PRICE = 500;

        List<Cell> cells = new List<Cell> ();

        public GameBoard ()
        {
            for ( int index = 1 ; index <= NUM_OF_CELL ; index++ )
            {
                cells.Add ( new Cell ( index , "Cell" + index , FIX_CELL_PRICE , FIX_RENT_PRICE ) );
            }
        }

        public Cell MoveToAnotherCell ( Cell curPosition , int distance , out bool isTurn )
        {
            int newIndex;

            newIndex = ( curPosition.GetIndex () - 1 ) + distance;
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
            return cells.ElementAt ( index - 1 );
        }

        public int GetCellNumber ( Cell curPosition )
        {
            return curPosition.GetIndex ();
        }

        public void GetPropertiesInMonopoly ()
        {
            //Not Need, Will be erased
        }

        public void QueryCell ()
        {
            //Not Need, Will be erased
        }

        public int [] QueryCellIndex ( Player queryPlayer )
        {
            int [] tempArrary = new int [ NUM_OF_CELL ];
            int [] arraryOfCellsOfPlayer;
            int j = 0;

            for ( int i = 0 ; i < NUM_OF_CELL ; i++ )
            {

                if ( cells.ElementAt ( i ).GetOwner () == queryPlayer )
                {
                    tempArrary [ j++ ] = i + 1;
                }
            }

            int k = 0;
            int counter = 0;

            while ( tempArrary [ k ] != 0 )
            {
                k++;
                counter++;
            }

            arraryOfCellsOfPlayer = new int [ counter ];
            for ( int i = 0 ; i < counter ; i++ )
            {
                arraryOfCellsOfPlayer [ i ] = tempArrary [ i ];
            }
            return arraryOfCellsOfPlayer;
        }
    }
}
