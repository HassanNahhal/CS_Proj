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

    class Die
    {
        public static int maxNumber = 6;
        private int dieFaceValue;
        Random r = new Random();

        public Die()
        {
            DieRoll();
        }        
        
        public void DieRoll()
        {
            dieFaceValue = r.Next(maxNumber);
        }
        
        public int GetRoll()
        {
            return dieFaceValue;
        }
    }
}
