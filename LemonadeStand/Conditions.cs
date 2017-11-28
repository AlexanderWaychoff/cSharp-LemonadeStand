using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Conditions
    {
        public string cloudiness;
        public bool isRaining;
        public double temperature; 
        public Conditions(string cloudiness, bool isRaining, double temperature)
        {
            this.cloudiness = cloudiness;
            this.isRaining = isRaining;
            this.temperature = temperature;
        }
    }
}
