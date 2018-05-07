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
                Console.WriteLine("GAME OVER"); //will signify the end of the game
                }
            //}
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
            
<<<<<<< Updated upstream
        { return vMotel.GetRooms(); }

        //method to give access to engine for testing
        internal Engine TestEngine()
        {
            return vEngine;
        }
=======
        { return vMotel.GetRooms(); } //gets room
>>>>>>> Stashed changes
    }
}
