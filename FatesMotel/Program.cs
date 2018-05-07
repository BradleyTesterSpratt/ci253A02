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
            string vRoomsInput;
            string vFloorsInput;
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
            Console.WriteLine("  4        Custom  ");
            string vDifficulty = Console.ReadLine();

            while (!(int.Parse(vDifficulty)<5&& int.Parse(vDifficulty) > 0))
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
                    HandlingInput vInput = new HandlingInput(vGame);
                    vInput.Play();
                    break;

                case 2:
                    vMotel = new Motel(16, 1);
                    vGame = new Game(vMotel, GameSpeed.SUPERFAST);
                    timerCallBack = vGame.TickTock;
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                    HandlingInput vInput = new HandlingInput(vGame);
                    vInput.Play();
                    break;

                case 3:
                    vMotel = new Motel(32, 2);
                    vGame = new Game(vMotel, GameSpeed.FAST);
                    timerCallBack = vGame.TickTock;
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                    HandlingInput vInput = new HandlingInput(vGame);
                    vInput.Play();
                    break;

                case 4:
                    //input flors and check they are valid
                    Console.Write("Choose Number of Floors (up to 3): ");
                    vFloorsInput = Console.ReadLine();
                    while (!(int.Parse(vFloorsInput) < 4 && int.Parse(vFloorsInput) > 0))
                    {
                        Console.WriteLine(" Invalid Input, Choose Number of Floors (up to 3):");
                        vFloorsInput = Console.ReadLine();
                    }
                    //input rooms and check they are valid
                    Console.Write("Choose Number of Rooms per Floor (minimum of 5, maximum of 16): ");
                    vRoomsInput = Console.ReadLine();
                    while (!(int.Parse(vRoomsInput) < 17 && int.Parse(vRoomsInput) > 4))
                    {
                        Console.WriteLine(" Invalid Input, Choose Number of Rooms per Floor(minimum of 5, maximum of 16):");
                        vFloorsInput = Console.ReadLine();
                    }
                    int vRoomNo = (int.Parse(vRoomsInput) * int.Parse(vFloorsInput));

                    Console.WriteLine("   Choose Speed   ");
                    Console.WriteLine("   ------------   ");
                    Console.WriteLine("INPUT      SPEED  ");
                    Console.WriteLine("-----    ---------");
                    Console.WriteLine("  1        Slow   ");
                    Console.WriteLine("  2       Average ");
                    Console.WriteLine("  3        Fast   ");
                    Console.WriteLine("  4     Super Fast ");
                    Console.WriteLine("  5     Impossible ");
                    string vSpeed = Console.ReadLine();

                    while (!(int.Parse(vSpeed)<6&& int.Parse(vSpeed) > 0))
                    {
                        Console.WriteLine(" Invalid Input, Choose Speed ");
                        vSpeed = Console.ReadLine();
                    }

                    vMotel = new Motel(vRoomNo, int.Parse(vFloorsInput));
                    switch (int.Parse(vSpeed))
                    {
                        case 1 : 
                            vGame = new Game(vMotel, GameSpeed.SLOW);
                            timerCallBack = vGame.TickTock;
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 2 :
                            vGame = new Game(vMotel, GameSpeed.AVERAGE);
                            timerCallBack = vGame.TickTock;
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 3 :
                            vGame = new Game(vMotel, GameSpeed.FAST);
                            timerCallBack = vGame.TickTock;
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 4 :
                            vGame = new Game(vMotel, GameSpeed.SUPERFAST);
                            timerCallBack = vGame.TickTock;
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 5 :
                            vGame = new Game(vMotel, GameSpeed.IMPOSSIBLE);
                            timerCallBack = vGame.TickTock;
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        default:
                            break;
                    }
                    HandlingInput vInput = new HandlingInput(vGame);
                    vInput.Play();
                    break;
                       
                default:
                    break;
            }

        }
    }
}
