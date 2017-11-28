using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        public int thirstiness; //1-10, 1 = not thirsty, 10 = very thirsty
        public int flavorPreference; //1-10, 1 prefers sour, 10 prefers sweet
        public int friendlyness;    //1-10, 1 is grumpy, 10 is happy
        public int awareOfLemonadeStand;    //1-10, 1 = stand is unpopular, 10 = stand is very popular; by default starts low and gradually goes up
        public double percentChanceOfBuying;
        public bool isPleased = false;
        public bool hasPurchasedToday;
        public bool isDispleased;

        public Customer(int thirstiness, int flavorPreference, int friendlyness, int awareOfLemonadeStand, bool isPleased)
        {
            this.thirstiness = thirstiness;
            this.flavorPreference = flavorPreference;
            this.friendlyness = friendlyness;
            this.awareOfLemonadeStand = awareOfLemonadeStand;
            this.isPleased = isPleased;
            this.hasPurchasedToday = false;
            this.isDispleased = false;
            this.percentChanceOfBuying = 5;
        }
    }
}
