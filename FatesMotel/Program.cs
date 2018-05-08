using FatesMotel;
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
            Console.Clear();
            vGame.Help();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            vGame.RoomReport();
            vInput.Play();
        }
        
        static void Main(string[] args)
        {
            //for use with custom
            string vRoomsInput; //allows the player to add any number of rooms
            string vFloorsInput; //allows the player to add any number if floors 
            

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

            //try parse makes sure it is not a string, parse checks it is a valid option
            while (!int.TryParse(vDifficulty, out int check)||!(int.Parse(vDifficulty)<5&& int.Parse(vDifficulty) > 0))
            {
                Console.WriteLine(" Invalid Input, Choose Difficulty "); //allows the player to choose the difficulty of the game 
                Console.Write("Input : "); //input the number for difficulty
                vDifficulty = Console.ReadLine();
            }
            switch (int.Parse(vDifficulty))
            {
                case 1:
                    StartGame(16, 1, GameSpeed.FAST);
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
                    Console.Write("Input : "); //input from the player
                    vFloorsInput = Console.ReadLine();
                    while (!int.TryParse(vDifficulty, out int check) || !(int.Parse(vFloorsInput) < 4 && int.Parse(vFloorsInput) > 0)) //can only set the room to be less than 4 floors 
                    {
                        Console.WriteLine(" Invalid Input, Choose Number of Floors (up to 3):"); //if someone goes over the 3 floors
                        Console.Write("Input : "); //input
                        vFloorsInput = Console.ReadLine();
                    }
                    //input rooms and check they are valid

                    Console.Write("Choose Number of Rooms per Floor (minimum of 5, maximum of 16): "); //sets the number of rooms in the motel of 5-16
                    vRoomsInput = Console.ReadLine();
                    while (!int.TryParse(vDifficulty, out int check) || !(int.Parse(vRoomsInput) < 17 && int.Parse(vRoomsInput) > 4)) //has to be less 17 but more than 4
                    {
                        Console.Write(" Invalid Input, Choose Number of Rooms per Floor(minimum of 5, maximum of 16):"); // if the wrong input has been put in
                        vFloorsInput = Console.ReadLine();
                    }
                    int vRoomNo = (int.Parse(vRoomsInput) * int.Parse(vFloorsInput)); //in custom allows the player to choose speed

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
                    //input for the speed
                    string vSpeed = Console.ReadLine();

                    while (!int.TryParse(vDifficulty, out int check) || !(int.Parse(vSpeed)<6&& int.Parse(vSpeed) > 0))
                    {
                        Console.Write(" Invalid Input, Choose Speed ");
                        vSpeed = Console.ReadLine();
                    }

                    switch (int.Parse(vSpeed))
                    {
                        case 1 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.SLOW); //sets game speed to slow
                            break;
                        case 2 :
                            //sets game speed to average 
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.AVERAGE);
                            break;
                        case 3 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.FAST); //sets game speed to fast
                            break;
                        case 4 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.SUPERFAST); //sets game speed to superfasT
                            break;
                        case 5 :
                            StartGame(vRoomNo, int.Parse(vFloorsInput), GameSpeed.IMPOSSIBLE); //sets game speed to implssible... not recomended
                            break;
                        default:
                            break;
                    }
                    break;
                       
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
