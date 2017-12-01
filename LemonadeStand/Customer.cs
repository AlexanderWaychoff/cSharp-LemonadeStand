using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        private int thirstiness; //1-10, 1 = not thirsty, 10 = very thirsty
        private int flavorPreference; //1-10, 1 prefers sour, 10 prefers sweet
        private int friendlyness;    //1-10, 1 is grumpy, 10 is happy
        private int awareOfLemonadeStand;    //1-10, 1 = stand is unpopular, 10 = stand is very popular; by default starts low and gradually goes up
        private double percentChanceOfBuying;
        private bool isPleased = false;
        private bool hasPurchasedToday;
        private bool isDispleased;

        public int FlavorPreference
        {
            get
            {
                return flavorPreference;
            }
            set
            {
                flavorPreference = value;
            }
        }
        public int Friendlyness
        {
            get
            {
                return friendlyness;
            }
            set
            {
                friendlyness = value;
            }
        }
        public int AwareOfLemonadeStand
        {
            get
            {
                return awareOfLemonadeStand;
            }
            set
            {
                awareOfLemonadeStand = value;
            }
        }
        public double PercentChanceOfBuying
        {
            get
            {
                return percentChanceOfBuying;
            }
            set
            {
                percentChanceOfBuying = value;
            }
        }
        public bool IsPleased
        {
            get
            {
                return isPleased;
            }
            set
            {
                isPleased = value;
            }
        }
        public bool HasPurchasedToday
        {
            get
            {
                return hasPurchasedToday;
            }
            set
            {
                hasPurchasedToday = value;
            }
        }
        public bool IsDispleased
        {
            get
            {
                return isDispleased;
            }
            set
            {
                isDispleased = value;
            }
        }

        public Customer(int thirstiness, int flavorPreference, int friendlyness, int awareOfLemonadeStand, bool isPleased)
        {
            this.thirstiness = thirstiness;
            this.FlavorPreference = flavorPreference;
            this.Friendlyness = friendlyness;
            this.AwareOfLemonadeStand = awareOfLemonadeStand;
            this.IsPleased = isPleased;
            this.HasPurchasedToday = false;
            this.IsDispleased = false;
            this.PercentChanceOfBuying = 5;
        }
    }
}
