using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon
    {
        public List<string> lemonDetail = new List<string>() {"squishy", "lumpy", "firm"};
        public string lemonStatus;
        public int daysToSpoil = 3;
        public int spoilTime;
        public Lemon()
        {
            this.spoilTime = daysToSpoil;
            this.lemonStatus = lemonDetail[daysToSpoil - 1];
        }
    }
}
