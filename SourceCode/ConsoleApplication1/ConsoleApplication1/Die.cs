﻿/*
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
        private const int maxNumber = 6;
        private int dieFaceValue;
        Random random = new Random();

        public Die()
        {
            DieRoll();
        }        
        
        //Roll the die twice and assign the total number
        //into the local dicdeFaceValue variable
        public void DieRoll()
        {
            dieFaceValue = random.Next(maxNumber);
            dieFaceValue += random.Next(maxNumber);
        }
        
        public int GetRoll()
        {
            return dieFaceValue;
        }
    }
}
