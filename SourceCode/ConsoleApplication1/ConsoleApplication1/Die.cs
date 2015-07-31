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
        private int dieFaceValue;
        private Random random = new Random();

        public Die()
        {
           // Remove DieRoll();
        }        
        
        //Roll the die twice and assign the total number
        //into the local dicdeFaceValue variable
        public int DieRoll()
        {
            dieFaceValue = 0;
            dieFaceValue = random.Next(maxNumber);
            dieFaceValue += random.Next(maxNumber);
            return dieFaceValue;

        }
    }
 
}
