using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Conditions
    {
        public string cloudiness;
        public bool isRaining;
        public int temperature; 
        public Conditions(string cloudiness, bool isRaining, int temperature)
        {
            this.cloudiness = cloudiness;
            this.isRaining = isRaining;
            this.temperature = temperature;
        }
    }
}
