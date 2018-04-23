using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FatesMotel
{
    class Program
    {     
        static void Main(string[] args)
        {
            string vRoomsInput;
            string vFloorsInput;
            Console.Write("Choose Number of Floors: ");
            vFloorsInput = Console.ReadLine();
            Console.Write("Choose Number of Rooms: ");
            vRoomsInput = Console.ReadLine();
            Motel vMotel = new Motel(int.Parse(vRoomsInput), int.Parse(vFloorsInput));            

            // Add choices for game here (EASY, NORMAL, HARD, VERY HARD, CUSTOM
            // Set GameSpeed and motel size with state machine

            Game g = new Game(vMotel,GameSpeed.SUPERFAST);
            TimerCallback timerCallBack = g.TickTock;
            Timer tmr = new Timer(timerCallBack, null, 1000, g.GetRefreshRate());
            Console.ReadKey();
        }
    }
}
