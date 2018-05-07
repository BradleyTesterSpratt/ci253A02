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
            string vRoomsInput; //allows the player to add any number of rooms
            string vFloorsInput; //allows the player to add any number if floors 
            Motel vMotel; //gets the motel class
            Game vGame; //gets games class
            TimerCallback timerCallBack;
            Timer vTimer; //allows the use of timer 
            HandlingInput vInput; //gets the use of the handlingInput

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
                Console.WriteLine(" Invalid Input, Choose Difficulty "); //allows the player to choose the difficulty of the game 
                Console.Write("Input : "); //input the number for difficulty
                vDifficulty = Console.ReadLine();
            }
            switch (int.Parse(vDifficulty))
            {
                case 1:
                    vMotel = new Motel(16, 1); //sets it to have 16 rooms and one floor
                    vGame = new Game(vMotel, GameSpeed.FAST); //game speed set to fast
                    timerCallBack = vGame.TickTock; //tick rate
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate()); //refresh
                    vInput = new HandlingInput(vGame); //gets handling input
                    vInput.Play();
                    break;

                case 2:
                    vMotel = new Motel(16, 1); //sets 16 rooms and one floor
                    vGame = new Game(vMotel, GameSpeed.SUPERFAST); //has the superfast speed for added difficulty
                    timerCallBack = vGame.TickTock; //tick rate
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate()); //refresh
                    vInput = new HandlingInput(vGame);
                    vInput.Play();
                    break;

                case 3:
                    vMotel = new Motel(32, 2); //gets 32 rooms to then be spreed over 2 floors 
                    vGame = new Game(vMotel, GameSpeed.FAST); //this is the fast speed for difficulty over two floors 
                    timerCallBack = vGame.TickTock; //tick rate
                    vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate()); //refresh
                    vInput = new HandlingInput(vGame);
                    vInput.Play();
                    break;

                case 4:
                    //input flors and check they are valid
                    Console.Write("Choose Number of Floors (up to 3): ");
                    Console.Write("Input : "); //input from the player
                    vFloorsInput = Console.ReadLine();
                    while (!(int.Parse(vFloorsInput) < 4 && int.Parse(vFloorsInput) > 0)) //can only set the room to be less than 4 floors 
                    {
                        Console.WriteLine(" Invalid Input, Choose Number of Floors (up to 3):"); //if someone goes over the 3 floors
                        Console.Write("Input : "); //input
                        vFloorsInput = Console.ReadLine();
                    }
                    //input rooms and check they are valid

                    Console.Write("Choose Number of Rooms per Floor (minimum of 5, maximum of 16): "); //sets the number of rooms in the motel of 5-16
                    Console.Write("Input : ");
                    vRoomsInput = Console.ReadLine();
                    while (!(int.Parse(vRoomsInput) < 17 && int.Parse(vRoomsInput) > 4)) //has to be less 17 but more than 4
                    {
                        Console.WriteLine(" Invalid Input, Choose Number of Rooms per Floor(minimum of 5, maximum of 16):"); // if the wrong input has been put in
                        Console.Write("Input : ");
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
                    string vSpeed = Console.ReadLine();

                    while (!(int.Parse(vSpeed)<6&& int.Parse(vSpeed) > 0))
                    {
                        Console.WriteLine(" Invalid Input, Choose Speed ");
                        Console.Write("Input : "); //input for the speed
                        vSpeed = Console.ReadLine();
                    }

                    vMotel = new Motel(vRoomNo, int.Parse(vFloorsInput)); //input for the floor and the rooms
                    switch (int.Parse(vSpeed))
                    {
                        case 1 : 
                            vGame = new Game(vMotel, GameSpeed.SLOW); //sets game speed to slow
                            timerCallBack = vGame.TickTock; //tick rate
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 2 :
                            vGame = new Game(vMotel, GameSpeed.AVERAGE); //sets game speed to average 
                            timerCallBack = vGame.TickTock; //tick rate
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 3 :
                            vGame = new Game(vMotel, GameSpeed.FAST); //sets game speed to fast
                            timerCallBack = vGame.TickTock; //tick rate
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 4 :
                            vGame = new Game(vMotel, GameSpeed.SUPERFAST); //sets game speed to superfast
                            timerCallBack = vGame.TickTock; //tick rate
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        case 5 :
                            vGame = new Game(vMotel, GameSpeed.IMPOSSIBLE); //sets game speed to implssible... not recomended
                            timerCallBack = vGame.TickTock; //tick rate
                            vTimer = new Timer(timerCallBack, null, 1000, vGame.GetRefreshRate());
                            break;
                        default:
                            break;
                    }
                    //vInput = new HandlingInput(vGame);
                    //vInput.Play();
                    break;
                       
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
