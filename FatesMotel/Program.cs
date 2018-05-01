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
            //for use with custom
            //string vRoomsInput;
            //string vFloorsInput;
            Motel vMotel;
            Game vGame;
            TimerCallback timerCallBack;
            Timer vTimer;

            Console.WriteLine(" Choose Difficulty ");
            Console.WriteLine(" ----------------- ");
            Console.WriteLine("INPUT    DIFFICULTY");
            Console.WriteLine("-----    ----------");
            Console.WriteLine("  1         Easy   ");
            Console.WriteLine("  2        Normal  ");
            Console.WriteLine("  3         Hard   ");
            //do not use custom, no input checking yet
            //Console.WriteLine("  4        Custom  ");
            string vDifficulty = Console.ReadLine();

            while (!(int.Parse(vDifficulty)<4&& int.Parse(vDifficulty) > 0))
            {
                Console.WriteLine(" Invalid Input, Choose Difficulty ");
                vDifficulty = Console.ReadLine();
            }
            switch (int.Parse(vDifficulty))
            {
                case 1:
                    vMotel = new Motel(16, 1);
                    vGame = new Game(vMotel, GameSpeed.FAST);
                    timerCallBack = vGame.TickTock;
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                    break;

                case 2:
                    vMotel = new Motel(16, 1);
                    vGame = new Game(vMotel, GameSpeed.SUPERFAST);
                    timerCallBack = vGame.TickTock;
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                    break;

                case 3:
                    vMotel = new Motel(32, 2);
                    vGame = new Game(vMotel, GameSpeed.FAST);
                    timerCallBack = vGame.TickTock;
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());

                    break;
                /*
                case 4:
                    //add checks to make sure acceptable numbers
                        Console.Write("Choose Number of Floors: ");
                        vFloorsInput = Console.ReadLine();
                        Console.Write("Choose Number of Rooms: ");
                        vRoomsInput = Console.ReadLine();
                        Console.WriteLine("   Choose Speed   ");
                        Console.WriteLine("   ------------   ");
                        Console.WriteLine("INPUT      SPEED  ");
                        Console.WriteLine("-----    ---------");
                        Console.WriteLine("  1        Slow   ");
                        Console.WriteLine("  2       Average ");
                        Console.WriteLine("  3        Fast   ");
                        Console.WriteLine("  4     Super Fast ");
                        Console.WriteLine("  5     Impossible ");
                    //add checks to make sure acceptable number
                        string vSpeed = Console.ReadLine();
                        vMotel = new Motel(int.Parse(vRoomsInput), int.Parse(vFloorsInput));
                        switch (int.Parse(vSpeed))
                        {
                            case 1 : 
                                vGame = new Game(vMotel, GameSpeed.SLOW;
                                break;
                        }
                        break;
                    */
                default:
                    break;
            }
            Console.Clear();
            Console.ReadKey();
        }
    }
}
