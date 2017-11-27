using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitcher
    {
        public int lemonsUsed;
        public int sugarUsed;
        public int iceUsed;
        public int cupsLeft;

        public int cupsPerPitcher = 8;

        public Pitcher(int lemons, int sugarCups, int iceCubes)
        {
            this.lemonsUsed = lemons;
            this.sugarUsed = sugarCups;
            this.iceUsed = iceCubes;
            this.cupsLeft = cupsPerPitcher;
        }
    }
}
