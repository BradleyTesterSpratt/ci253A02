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
        //should this be public? or accessor methods?
        public HashSet<Location> vRoomList = new HashSet<Location>();
       

        public Motel(double rooms, int floors)
        {
            vRooms = rooms;
            vFloors = floors;
            mPopulateMotel();
            mAssignNeighbors();
        }

        private void mPopulateMotel()
        {
            vRoomList.Add(new Station(000, "Station"));
            int vRoomNum = 0;
            int vCurrentFloor = 1;
            for (int n = 0; n < vRooms; n++)
            {
                double vRoomsPerFloor = Math.Ceiling(vRooms / vFloors);
                if (vRoomNum >= vRoomsPerFloor)
                {
                    vCurrentFloor += 1;
                    vRoomNum = 0;
                }
                int vFloorNo = vCurrentFloor * 100 + 1;
                vRoomList.Add(new Room(vRoomNum + vFloorNo));
                vRoomNum += 1;
            }
        }

        private void mAssignNeighbors()
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
                            vCurrentLocation.mSetNeighbors((Room)room);
                        }
                    }
                    vCurrentLocation.mPrintNeighbors();
                }
            }
         }
    }
}
