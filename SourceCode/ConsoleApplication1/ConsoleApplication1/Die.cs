/*
 * 
 * Done by SUNG JOE KIM
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

            Console.WriteLine ( "The first Die is being rolled" );
            dieFirstFaceValue = random.Next(maxNumber);
            Console.WriteLine ( "The first Die = " + dieFirstFaceValue );
            Console.WriteLine ();

            Console.WriteLine ( "The second Die is being rolled" );
            dieSecondFaceValue= random.Next(maxNumber);
            Console.WriteLine ( "The second Die = " + dieSecondFaceValue );

            return dieFirstFaceValue + dieSecondFaceValue;

        }
    }
 
}
