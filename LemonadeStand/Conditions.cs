using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Conditions
    {
        private string cloudiness;
        private bool isRaining;
        private double temperature; 

        public string Cloudiness
        {
            get
            {
                return cloudiness;
            }
            set
            {
                cloudiness = value;
            }
        }
        public bool IsRaining
        {
            get
            {
                return isRaining;
            }
            set
            {
                isRaining = value;
            }
        }
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
            }
        }

        public Conditions(string cloudiness, bool isRaining, double temperature)
        {
            this.Cloudiness = cloudiness;
            this.IsRaining = isRaining;
            this.Temperature = temperature;
        }
    }
}
