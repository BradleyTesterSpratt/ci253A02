using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FatesMotel
{
    class Program
    {

        static void StartGame(double rooms, int floors, GameSpeed speed)
        {
            Motel vMotel = new Motel(rooms, floors);
            Game vGame = new Game(vMotel, speed);
            TimerCallback timerCallBack = vGame.TickTock;
            Timer vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
            HandlingInput vInput = new HandlingInput(vGame);
            vInput.Play();
        }

        static void PrintHelp()
        {
            Console.Clear();

        }
        
        static void Main(string[] args)
        {
            //for use with custom
            string vRoomsInput;
            string vFloorsInput;

            Console.WriteLine(" Choose Difficulty ");
            Console.WriteLine(" ----------------- ");
            Console.WriteLine("INPUT    DIFFICULTY");
            Console.WriteLine("-----    ----------");
            Console.WriteLine("  1         Easy   ");
            Console.WriteLine("  2        Normal  ");
            Console.WriteLine("  3         Hard   ");
            Console.WriteLine("  4        Custom  ");
            Console.Write("Input : ");
            string vDifficulty = Console.ReadLine();

            while (!(int.Parse(vDifficulty)<5&& int.Parse(vDifficulty) > 0))
            {
                Console.WriteLine(" Invalid Input, Choose Difficulty ");
                Console.Write("Input : ");
                vDifficulty = Console.ReadLine();
            }
            switch (int.Parse(vDifficulty))
            {
                case 1:
                    StartGame(16, 1,GameSpeed.FAST);
                    break;

                case 2:
                    StartGame(16, 1, GameSpeed.SUPERFAST);
                    break;

                case 3:
                    StartGame(32, 2, GameSpeed.FAST);
                    break;

                case 4:
                    //input flors and check they are valid
                    Console.Write("Choose Number of Floors (up to 3): ");
                    vFloorsInput = Console.ReadLine();
                    while (!(int.Parse(vFloorsInput) < 4 && int.Parse(vFloorsInput) > 0))
                    {
                        Console.Write(" Invalid Input, Choose Number of Floors (up to 3):");
                        vFloorsInput = Console.ReadLine();
                    }
                    //input rooms and check they are valid

                    Console.Write("Choose Number of Rooms per Floor (minimum of 5, maximum of 16): ");
                    vRoomsInput = Console.ReadLine();
                    while (!(int.Parse(vRoomsInput) < 17 && int.Parse(vRoomsInput) > 4))
                    {
                        Console.Write(" Invalid Input, Choose Number of Rooms per Floor(minimum of 5, maximum of 16):");
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
                    Console.Write("Input : ");
                    string vSpeed = Console.ReadLine();

                    while (!(int.Parse(vSpeed)<6&& int.Parse(vSpeed) > 0))
                    {
                        Console.WriteLine(" Invalid Input, Choose Speed ");
                        Console.Write("Input : ");
                        vSpeed = Console.ReadLine();
                    }

                    switch (int.Parse(vSpeed))
                    {
                        case 1 : 
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.SLOW);
                            break;
                        case 2 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.AVERAGE);
                            break;
                        case 3 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.FAST);
                            break;
                        case 4 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.SUPERFAST);
                            break;
                        case 5 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.IMPOSSIBLE);
                            break;
                        default:
                            break;
                    }
                    break;
                       
                default:
                break;
            }
        }
    }
}
