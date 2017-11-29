using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public int lemonsUsed;
        public int sugarUsed;
        public int iceUsed;
        public double price;
        public int cupUsed = 1;
        public Recipe(int lemonsUsed, int sugarUsed, int iceUsed, double price)
        {
            this.lemonsUsed = lemonsUsed;
            this.sugarUsed = sugarUsed;
            this.iceUsed = iceUsed;
            this.price = price;
        }
    }
}
