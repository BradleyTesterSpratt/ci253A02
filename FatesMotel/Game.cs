using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    internal class Game
    {
        private int RefreshRate;
        private Motel vMotel;
        private Engine vEngine;
        public bool vGameOver;
        public Game (Motel motel, GameSpeed speed) //gets gameSpeed
        {
            vMotel = motel;
            RefreshRate = (int)speed;
            vEngine = new Engine(vMotel.GetRooms().ElementAt(0), 2318); //gets the use of engine and the ID for the engine
            vGameOver = false;
        }
        public void TickTock(Object data) // allows this function to then be used in the program class to allow the game to tick for rooms to burn
        {

                foreach (Location room in vMotel.GetRooms())
                {
                    if (room.GetType() == typeof(Room))
                    {
                        ((Room)room).OnTick(); //allows the rooms to tick so they can get hotter from the fire
                    }
                }
                vEngine.OnTick();
                if (vMotel.GameOver() == true)
                {
                vGameOver = true;
                //get final results
                End(); 
            }
        }

        public void End()
        {
            Console.WriteLine("    Game Over    ");
            Console.WriteLine("    ---- ----    ");
            Console.WriteLine("Your results are:");
            GameReport();
            Console.ReadLine();
        }

        public void RoomHelp()
        {
            Console.WriteLine("Valid Room Commands are:");
            Console.WriteLine("room list - list all rooms in the hotel and their current state");
            Console.WriteLine("room report - list how many rooms are in each state");
            Console.WriteLine("room help - shows room commands");
        }

        public void EngineHelp()
        {
            Console.WriteLine("Valid Engine commands are:");
            Console.WriteLine("engine report - get the engines current status");
            Console.WriteLine("engine goto room xxx - go to xxx room");
            Console.WriteLine("engine recall - return to the station");
            Console.WriteLine("engine refill - refill the engines coolant at station");
            Console.WriteLine("engine help - shows engine commands");
        }

        public void MiscHelp()
        {
            Console.WriteLine("Other valid commands are :");
            Console.WriteLine("clear - clears the screen");
            Console.WriteLine("quit - ends the current game");
            Console.WriteLine("help - shows all commands");
        }

        public void Help()
        {
            EngineHelp();
            RoomHelp();
            MiscHelp();
        }
        public int GetRefreshRate()
        {
            return RefreshRate; //gets refreshrate
        }

        public void EngineReport()
        {
            vEngine.Report(); //gets the engine report
        }

        public void RoomReport()
        {
            vMotel.RoomReports(); //gets the room report 
        }

        public void GameReport()
        {
            vMotel.MotelReport(); //allows to get the report on the motel
        }

        public void MoveEngine(Location destination)
        {
            vEngine.Move(destination); //moves the engine to the correct location
        }

        public void EngineRefill()
        {
            vEngine.Refill(); //will refill the engine
        }

        public HashSet<Location> GetRooms()
            

        { return vMotel.GetRooms(); }

        //method to give access to engine for testing
        internal Engine TestEngine()
        {
            return vEngine;
        }
    }
}
