/* Die.cs
 * Final Project
 * Revision History 
 * Sungjoe Kim, 2015.07.28: Created 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{

    public class Die
    {
        private const int maxNumber = 7;
        private const int minNumber = 1;

        private int dieFirstFaceValue;
        private int dieSecondFaceValue;

        private Random random = new Random();

        public Die()
        {
           // Remove DieRoll();
        }        
        
        //Roll the die twice and assign the total number
        //into the local dicdeFaceValue variable
        public int DieRoll()
        {
            Console.WriteLine("Dice are rolled !!!");

            dieFirstFaceValue = random.Next(minNumber,maxNumber);
            Console.Write( "1st Die = " + dieFirstFaceValue );

            dieSecondFaceValue = random.Next ( minNumber , maxNumber );
            Console.WriteLine ( "  2ndDie = " + dieSecondFaceValue );

            return dieFirstFaceValue + dieSecondFaceValue;

        }
    }
 
}
