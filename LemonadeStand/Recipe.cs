using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        private int lemonsUsed;
        private int sugarUsed;
        private int iceUsed;
        private double price;
        private int cupUsed;

        public int LemonsUsed
        {
            get
            {
                return lemonsUsed;
            }
            set
            {
                lemonsUsed = value;
            }
        }
        public int SugarUsed
        {
            get
            {
                return sugarUsed;
            }
            set
            {
                sugarUsed = value;
            }
        }
        public int IceUsed
        {
            get
            {
                return iceUsed;
            }
            set
            {
                iceUsed = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public int CupUsed
        {
            get
            {
                return cupUsed;
            }
        }

        public Recipe(int lemonsUsed, int sugarUsed, int iceUsed, double price)
        {
            this.LemonsUsed = lemonsUsed;
            this.SugarUsed = sugarUsed;
            this.IceUsed = iceUsed;
            this.Price = price;
        }
    }
}
