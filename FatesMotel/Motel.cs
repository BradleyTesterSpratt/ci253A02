using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatesMotel
{
    class Motel
    {
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
        }

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

        public HashSet<Location> GetRooms()
        {
            return vRoomList;
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
