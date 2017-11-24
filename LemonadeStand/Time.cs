using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Time
    {
        public static int minimumDays = 7;
        public static int maximumDays = 21;
        private int gameDays;
        private List<string> sunsetImage;
        public Time(int gameDays)
        {
            this.gameDays = gameDays;
        }
        public void PassageOfDay()
        {
            sunsetImage = new List<string>();
            Console.Clear();
            const int nCountDown = 12;

            for (int i = nCountDown; i >= 0; i--)
            {
                if (i != 0)
                {
                    Console.Write("__*_");
                }
                else
                {
                    Console.WriteLine("(ZzZz)_s|P----|");
                }

                Thread.Sleep(60);
            }
        }
    }
}
