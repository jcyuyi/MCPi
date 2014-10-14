using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCPi
{
    class MCRandom
    {
        private static Random random;
        public static double getRandomNumber(double minimum, double maximum)
        {
            if (random == null)
            {
                random = new Random();
            }
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}