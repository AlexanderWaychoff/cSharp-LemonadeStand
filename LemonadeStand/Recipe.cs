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
        public Recipe(int lemonsUsed, int sugarUsed, int iceUsed)
        {
            this.lemonsUsed = lemonsUsed;
            this.sugarUsed = sugarUsed;
            this.iceUsed = iceUsed;
        }
    }
}
