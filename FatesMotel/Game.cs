using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Game
    {
        private int RefreshRate;
        private Motel vMotel;
        public Game (Motel motel, GameSpeed speed)
        {
            vMotel = motel;
            RefreshRate = (int)speed;

        }
        public void TickTock(Object data)
        {
            //Console.WriteLine("The Next Tick");
            foreach (Location room in vMotel.GetRooms())
            {
                if (room.GetType() == typeof(Room))
                {
                    ((Room)room).GetNeighbors();
                    ((Room)room).OnTick();
                }
            }
        }
        public int GetRefreshRate()
        {
            return RefreshRate;
        }

    }
}
