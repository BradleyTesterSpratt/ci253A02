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
        private Engine vEngine;
        public bool vGameOver;
        public Game (Motel motel, GameSpeed speed)
        {
            vMotel = motel;
            RefreshRate = (int)speed;
            vEngine = new Engine(vMotel.GetRooms().ElementAt(0), 2318);
            vGameOver = false;
        }
        public void TickTock(Object data)
        {
            if(vGameOver==false)
            { 
                foreach (Location room in vMotel.GetRooms())
                {
                    if (room.GetType() == typeof(Room))
                    {
                        ((Room)room).OnTick();
                    }
                }
                vEngine.OnTick();
                if (vMotel.GameOver() == true)
                {
                    vGameOver = true;
                    End();
                }
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
        public int GetRefreshRate()
        {
            return RefreshRate;
        }

        public void EngineReport()
        {
            vEngine.Report();
        }

        public void RoomReport()
        {
            vMotel.RoomReports();
        }

        public void GameReport()
        {
            vMotel.MotelReport();
        }

        public void MoveEngine(Location destination)
        {
            vEngine.Move(destination);
        }

        public void EngineRefill()
        {
            vEngine.Refill();
        }

        public HashSet<Location> GetRooms()
            
        { return vMotel.GetRooms(); }
    }
}
