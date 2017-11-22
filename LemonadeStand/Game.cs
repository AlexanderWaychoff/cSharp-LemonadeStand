using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Interface userInterface = new Interface();
        Player player = new Player();
        Weather dailyForecast = new Weather();
        public Game()
        {

        }
        public void PlayGame()
        {
            dailyForecast.DetermineCloudCover();
        }
        public void DisplayDayStats()
        {

        }
    }
}
