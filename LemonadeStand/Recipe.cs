using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public double lemonsUsed;
        public double sugarUsed;
        public double iceUsed;
        public double price;
        public Recipe(int lemonsUsed, int sugarUsed, int iceUsed, double price)
        {
            this.lemonsUsed = lemonsUsed;
            this.sugarUsed = sugarUsed;
            this.iceUsed = iceUsed;
            this.price = price;
        }
    }
}
