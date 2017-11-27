using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Players
    {
        Inventory playerInventory = new Inventory(0, 0, 0, 0);
        public Players()
        {

        }
        public Inventory ObtainInventoryStatus()
        {
            return playerInventory;
        }
    }
}
