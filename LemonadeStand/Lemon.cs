using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon
    {
        private List<string> lemonDetail = new List<string>() {"squishy", "lumpy", "firm"};
        private string lemonStatus;
        private int daysToSpoil = 3;
        private int spoilTime;
        public Lemon()
        {
            this.spoilTime = daysToSpoil;
            this.lemonStatus = lemonDetail[daysToSpoil - 1];
        }
    }
}
