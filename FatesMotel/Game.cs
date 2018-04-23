using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Game
    {
        public int RefreshRate = (int)GameSpeed.FAST;

        public void TickTock(Object data)
        {
            Console.WriteLine("The Next Tick");
        }
    }
}
