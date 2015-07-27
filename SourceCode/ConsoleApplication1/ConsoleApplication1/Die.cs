/*
 * 
 * 
 * Done by SUNG JOE KIM
 * 
 * 
 * 
 * 
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
        Random r = new Random();

        public Die()
        {  
        }        
        
        public int getRoll()
        {
            return r.Next(6);
        }
    }
}
