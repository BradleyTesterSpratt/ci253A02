using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Program
    {     
        static void Main(string[] args)
        {
            Motel vMotel = new Motel(10, 2);            
            Console.ReadKey();



            Game g = new Game();
            TimerCallback timerCallBack = g.TickTock;
            Timer tmr = new Timer(timerCallBack, null, 1000, g.RefreshRate);

        }
    }
}
