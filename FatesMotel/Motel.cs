using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    internal class Motel
    {
        //argumenst for room and floors
        private double vRooms;
        private int vFloors;
        private HashSet<Location> vRoomList = new HashSet<Location>();
       

        public Motel(double rooms, int floors)
        {
            vRooms = rooms;
            vFloors = floors;
            PopulateMotel();
            AssignNeighbors();
        }
        /*
         * add locations to motel
         * assign rooms to floors
         * rooms / floor
         * if odd number of rooms, ground floor has the extra
         */
        private void PopulateMotel()
        {
            vRoomList.Add(new Station(000, "Station"));
            int vRoomNum = 0;
            int vCurrentFloor = 1;
            double vRoomsPerFloor = Math.Ceiling(vRooms / vFloors);
            for (int n = 0; n < vRooms; n++)
            { 
                if (vRoomNum >= vRoomsPerFloor)
                {
                    vCurrentFloor += 1;
                    vRoomNum = 0;
                }
                int vFloorNo = vCurrentFloor * 100 + 1;
                vRoomList.Add(new Room(vRoomNum + vFloorNo));
                vRoomNum += 1;
            }
            Random vRand = new Random();

            //start random no from 1, to skip station, which is always 0
            Room vBurningRoom = (Room)vRoomList.ElementAt(vRand.Next(1, (int)vRooms - 1));
            vBurningRoom.HeatUp();
            vBurningRoom.InitialBurn();
            RoomReports();
        }
        //
        private void AssignNeighbors()
        {
            for (int n = 0; n < vRoomList.Count; n++)
            {
                if (vRoomList.ElementAt(n).GetType() == typeof(Room))
                {
                    Room vCurrentLocation = (Room)vRoomList.ElementAt(n);
                    foreach (Location room in vRoomList)
                    {
                        if (room.GetType() == typeof(Room))
                        {
                            vCurrentLocation.SetNeighbors((Room)room);
                        }
                    }
                    //debug only command
                    //vCurrentLocation.PrintNeighbors();
                }
            }
         }
        //return list of rooms in hashset
        public HashSet<Location> GetRooms()
        {
            return vRoomList;
        }
        //gets currentRoom report
        public void RoomReports()
        {
            foreach(Location location in vRoomList)
            {
                if (location.GetType() == typeof(Room))
                {
                    Room vCurrentRoom = (Room)location;
                    vCurrentRoom.Report();
                }
            }
        }
        //displays how many rooms are in set STATE
        public void MotelReport()
        {
            int vSafeCount=0;
            int vBurnedOutCount = 0;
            int vDangerCount=0;
            int vSmoulderCount=0;
            int vFireCount=0;
            foreach (Location location in vRoomList)
            {
                if (location.GetType() == typeof(Room))
                {
                    Room vCurrentRoom = (Room)location;
                    if (vCurrentRoom.GetState()==Room.State.SAFE)
                    {
                        vSafeCount++;
                    }
                    else if (vCurrentRoom.GetState() == Room.State.DANGER)
                    {
                        vDangerCount++;
                    }
                    else if (vCurrentRoom.GetState() == Room.State.SMOULDER)
                    {
                        vSmoulderCount++;
                    }
                    else if (vCurrentRoom.GetState() == Room.State.FIRE)
                    {
                        vFireCount++;
                    }
                    else if (vCurrentRoom.GetState() == Room.State.BURNEDOUT)
                    {
                        vBurnedOutCount++;
                    }
                }
            }
            Console.WriteLine("   ROOM    COUNT");
            Console.WriteLine("---------- -----");
            if (vSafeCount!=0)
            {
                Console.WriteLine("   SAFE      "+vSafeCount);
            }
            if (vDangerCount != 0)
            {
                Console.WriteLine("  DANGER     " + vDangerCount);
            }
            if (vSmoulderCount != 0)
            {
                Console.WriteLine(" SMOULDER    " + vSmoulderCount);
            }
            if (vFireCount != 0)
            {
                Console.WriteLine("   FIRE      " + vFireCount);
            }
            if (vBurnedOutCount != 0)
            {
                Console.WriteLine("BURNED OUT   " + vBurnedOutCount);
            }
        }
        public bool GameOver()
        {
            bool vGameOver=false;
            for (int n = 0; n < vRoomList.Count; n++)
            {
                if (vRoomList.ElementAt(n).GetType() == typeof(Room))
                {
                    Room vCurrentLocation = (Room)vRoomList.ElementAt(n);
                    if (vCurrentLocation.GetState() == Room.State.DANGER || vCurrentLocation.GetState() == Room.State.SMOULDER || vCurrentLocation.GetState() == Room.State.FIRE)
                    {
                        n = vRoomList.Count;
                        vGameOver = false;
                    }
                    else
                    {
                        vGameOver = true;
                    }
                }
            }
            return vGameOver;
        }
    }
}
