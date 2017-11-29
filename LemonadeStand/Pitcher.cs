using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitcher
    {
        public double lemonsUsed;
        public double sugarUsed;
        public double iceUsed;
        public double cupsLeft;
        public bool hasEnoughStock;

        private int cupsPerPitcher = 8;

        public Pitcher(double lemons, double sugarCups, double iceCubes, double cupsPerPitcher, bool hasEnoughStock)
        {
            this.lemonsUsed = lemons;
            this.sugarUsed = sugarCups;
            this.iceUsed = iceCubes;
            this.cupsLeft = cupsPerPitcher;
            this.hasEnoughStock = hasEnoughStock;
        }
        public double CupsPerPitcher
        {
            get
            {
                return cupsPerPitcher;
            }
        }
    }
}
