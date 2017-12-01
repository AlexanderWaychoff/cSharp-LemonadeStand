using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitcher
    {
        private double lemonsUsed;
        private double sugarUsed;
        private double iceUsed;
        private double cupsLeft;
        private bool hasEnoughStock;
        private int cupsPerPitcher = 8;

        public int CupsPerPitcher
        {
            get
            {
                return cupsPerPitcher;
            }
        }
        public double CupsLeft
        {
            get
            {
                return cupsLeft;
            }
            set
            {
                cupsLeft = value;
            }
        }
        public bool HasEnoughStock
        {
            get
            {
                return hasEnoughStock;
            }
            set
            {
                hasEnoughStock = value;
            }
        }

        public Pitcher(double lemons, double sugarCups, double iceCubes, int cupsPerPitcher, bool hasEnoughStock)
        {
            this.lemonsUsed = lemons;
            this.sugarUsed = sugarCups;
            this.iceUsed = iceCubes;
            this.CupsLeft = cupsPerPitcher;
            this.HasEnoughStock = hasEnoughStock;
        }
    }
}
